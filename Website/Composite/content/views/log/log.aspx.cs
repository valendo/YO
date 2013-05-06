﻿using System;
using System.Globalization;
using System.Web.UI;
using System.Xml.Linq;
using System.Diagnostics;
using System.Linq;
using Composite.Core.Logging;
using Composite.Core.ResourceSystem;


public partial class Composite_content_views_log_log : System.Web.UI.Page
{
    private const string DateTimeFormat = "yyyy-MM-dd";

    private const string View_DateTimeFormat = "yyyy-MM-dd HH:mm:ss.ff";
    

    private string SelectedDateStr
    {
        get
        {
            return System.Web.HttpContext.Current.Request.Form["Pager"];
        }
    }

    private bool _allLogsHaveBeenDeleted;

    protected void Page_PreRender(object sender, EventArgs e)
    {
        bool includeVerbose = chkVerbose.Checked;
        bool includeInformation = chkInformation.Checked;
        bool includeWarning = chkWarning.Checked;
        bool includeError = chkError.Checked;
        bool includeCritical = chkCritical.Checked;

        var dates = LogManager.GetLoggingDates().OrderByDescending(date => date).ToArray();

        this.Pager.Items.Clear();
        foreach (var date in dates)
        {
            this.Pager.Items.Add(date.ToString(DateTimeFormat));
        }

        DateTime selectedDate = DateTime.Now.Date;

        string selectDateStr = SelectedDateStr;
        if(!_allLogsHaveBeenDeleted && !string.IsNullOrEmpty(SelectedDateStr) && this.Pager.Items.FindByText(SelectedDateStr) != null)
        {
            selectedDate = DateTime.ParseExact(selectDateStr, DateTimeFormat, CultureInfo.InvariantCulture);

            this.Pager.SelectedValue = SelectedDateStr;
        }
        else
        {
            selectedDate = DateTime.Now;
        }

        selectedDate = selectedDate.Date;
        LogEntry[] logEntries = LogManager.GetLogEntries(selectedDate, selectedDate.AddDays(1.0), includeVerbose, 0);


        logEntries = logEntries.Where(entry => (includeVerbose && entry.Severity == "Verbose")
                                              || (includeInformation && entry.Severity == "Information")
                                              || (includeWarning && entry.Severity == "Warning")
                                              || (includeError && entry.Severity == "Error")
                                              || (includeCritical && entry.Severity == "Critical")).ToArray();

        if (logEntries.Length > 0)
        {
            BuildLogTable(logEntries);
            
            EmptyLabelPlaheHolder.Visible = false;
        }
        else
        {
            EmptyLabelPlaheHolder.Visible = true;
        }

        DeleteOlderButton.Enabled = dates.Count() > 1;
    }


    private void BuildLogTable(LogEntry[] entries)
    {
        XElement table = new XElement("table");

        XElement tableHeader = new XElement("tr");
        tableHeader.Add(
                new XElement("th", " "),
                new XElement("th", StringResourceSystemFacade.GetString("Composite.Management","ServerLog.LogEntry.DateLabel")),
                new XElement("th", StringResourceSystemFacade.GetString("Composite.Management","ServerLog.LogEntry.MessageLabel")),
                new XElement("th", StringResourceSystemFacade.GetString("Composite.Management","ServerLog.LogEntry.TitleLabel")),
                new XElement("th", StringResourceSystemFacade.GetString("Composite.Management","ServerLog.LogEntry.EventTypeLabel"))
            );

        table.Add(tableHeader);

        foreach (LogEntry logEntry in entries.Reverse())
        {
            TraceEventType eventType;

            try
            {
                eventType = (TraceEventType)Enum.Parse(typeof(TraceEventType), logEntry.Severity);
            }
            catch (Exception)
            {
                eventType = TraceEventType.Information;
            }

            
            var colors = new []
                               {
                                   new Tuple<TraceEventType, string>(TraceEventType.Information, "lime"),
                                   new Tuple<TraceEventType, string>(TraceEventType.Verbose, "white"),
                                   new Tuple<TraceEventType, string>(TraceEventType.Warning, "yellow"),
                                   new Tuple<TraceEventType, string>(TraceEventType.Error, "orange"),
                                   new Tuple<TraceEventType, string>(TraceEventType.Critical, "red")
                               };

            string colorName = colors.Where(c => c.Item1 == eventType).Select(c => c.Item2).FirstOrDefault() ?? "orange";

            XAttribute color = new XAttribute("bgcolor", colorName);


            XElement row = new XElement("tr");
            row.Add(
                new XElement("td", color, " "),
                new XElement("td", logEntry.TimeStamp.ToString(View_DateTimeFormat)),
                new XElement("td", new XElement("pre", EncodeXml10InvalidCharacters(logEntry.Message.Replace("\n", "")))),
                new XElement("td", EncodeXml10InvalidCharacters(logEntry.Title)),
                new XElement("td", logEntry.Severity)
            );

            table.Add(row);
        }

        LogHolder.Controls.Add(new LiteralControl(table.ToString()));
    }


    private string EncodeXml10InvalidCharacters(string text)
    {
        // We double encoding charaters 00h -> 1Fh except spaces so the encoded version will be shown.
        for (int i = 0; i < 32; i++) {
            if(i == 8 || i == 10 || i == 13) continue;

            char ch = (char) i;

            if(text.Contains(ch))
            {
                text = text.Replace(new string(ch, 1), "&#" + (i/16) + "0123456789ABCDEF"[i % 16] + ";");
            }
        }

        return text;
    }

    protected void LogContentChanged(Object sender, EventArgs e)
    {
    }



    protected void DeleteOldButton_Click(Object sender, EventArgs e)
    {
        DateTime[] dates = LogManager.GetLoggingDates();

        DateTime today = DateTime.Now.Date;

        foreach(var date in dates)
        {
            if(date.Date != today)
            {
                LogManager.DeleteLogFile(date);
            }
        }
        
        this.DeleteOlderButton.Enabled = false;

        _allLogsHaveBeenDeleted = true;
    }


}
