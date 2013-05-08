namespace My.Content {
    
    
    [Composite.Data.AutoUpdatebleAttribute()]
    [Composite.Data.DataScopeAttribute("public")]
    [Composite.Data.RelevantToUserTypeAttribute("Developer")]
    [Composite.Data.CodeGeneratedAttribute()]
    [Composite.Data.Hierarchy.DataAncestorProviderAttribute(typeof(Composite.Data.Hierarchy.DataAncestorProviders.NoAncestorDataAncestorProvider))]
    [Composite.Data.ImmutableTypeIdAttribute("1674c787-582d-4813-ab75-342efe5c532f")]
    [Composite.Core.WebClient.Renderings.Data.KeyTemplatedXhtmlRendererAttribute(Composite.Core.WebClient.Renderings.Data.XhtmlRenderingType.Embedable, "<span>{label}</span>")]
    [Composite.Data.KeyPropertyNameAttribute("Id")]
    [Composite.Data.TitleAttribute("News")]
    [Composite.Data.LabelPropertyNameAttribute("Title")]
    public interface News : Composite.Data.IData, Composite.Data.ProcessControlled.IProcessControlled, Composite.Data.ProcessControlled.ILocalizedControlled {
        
        [Composite.Data.ImmutableFieldIdAttribute("d1e223f2-b992-43ae-ae39-3adfd53ed6e6")]
        [Composite.Data.FunctionBasedNewInstanceDefaultFieldValueAttribute("<f:function name=\"Composite.Utils.Guid.NewGuid\" xmlns:f=\"http://www.composite.net" +
            "/ns/function/1.0\" />")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(-1)]
        System.Guid Id {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("e6da6350-bb08-4230-adc8-06f976a2641a")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 1024)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(0)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 1024)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string Title {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("641c14fe-0ad1-41ca-bdfa-fe9433d09bd8")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 1024, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(1)]
        [Composite.Data.Validation.Validators.NullStringLengthValidatorAttribute(0, 1024)]
        string Summary {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("dffc0e2a-5e5a-48b3-87b6-669ae962ba13")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.LargeString, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(2)]
        string Content {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("fd774716-bef8-42bc-bf8f-8c03efb9c103")]
        [Composite.Data.FunctionBasedNewInstanceDefaultFieldValueAttribute("<f:function xmlns:f=\"http://www.composite.net/ns/function/1.0\" name=\"Composite.Co" +
            "nstant.DateTime\"><f:param name=\"Constant\" value=\"2013-04-26T10:44:00+07:00\" /></" +
            "f:function>")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.DateTime)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.DateTimeRangeValidatorAttribute("1753-01-01T00:00:00", "9999-12-31T23:59:59")]
        [Composite.Data.FieldPositionAttribute(3)]
        [Composite.Data.DefaultFieldNowDateTimeValueAttribute()]
        [Composite.Data.TreeOrderingAttribute(1, true)]
        [Composite.Data.GroupByPriorityAttribute(1)]
        System.DateTime PublishDate {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("18869a14-a3b2-48ac-82d8-6132f50e6061")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 2048, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(4)]
        [Composite.Data.Validation.Validators.NullStringLengthValidatorAttribute(0, 2048)]
        [Composite.Data.ForeignKeyAttribute("Composite.Data.Types.IImageFile,Composite", AllowCascadeDeletes=true, NullableString=true)]
        string Image {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("0d9de027-1f59-49af-a894-a7545fb6a38d")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Boolean)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(5)]
        [Composite.Data.DefaultFieldBoolValueAttribute(false)]
        bool IsPopular {
            get;
            set;
        }
    }
}
