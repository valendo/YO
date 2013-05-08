namespace Layout.Navigation {
    
    
    [Composite.Data.AutoUpdatebleAttribute()]
    [Composite.Data.DataScopeAttribute("public")]
    [Composite.Data.RelevantToUserTypeAttribute("Developer")]
    [Composite.Data.CodeGeneratedAttribute()]
    [Composite.Data.Hierarchy.DataAncestorProviderAttribute(typeof(Composite.Data.Hierarchy.DataAncestorProviders.NoAncestorDataAncestorProvider))]
    [Composite.Data.ImmutableTypeIdAttribute("572c9c36-f1a8-4f21-b6d5-cd60c36c0b88")]
    [Composite.Core.WebClient.Renderings.Data.KeyTemplatedXhtmlRendererAttribute(Composite.Core.WebClient.Renderings.Data.XhtmlRenderingType.Embedable, "<span>{label}</span>")]
    [Composite.Data.TitleAttribute("Top links")]
    [Composite.Data.LabelPropertyNameAttribute("Page")]
    [Composite.Data.CachingAttribute(Composite.Data.CachingType.Full)]
    public interface TopLink : Composite.Data.IData, Composite.Data.ProcessControlled.ILocalizedControlled, Composite.Data.ProcessControlled.IProcessControlled, Composite.Data.IPageData, Composite.Data.IPageFolderData {
        
        [Composite.Data.ImmutableFieldIdAttribute("56e290ab-e552-4164-a35e-aaa933282e64")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.Validation.Validators.GuidNotEmptyAttribute()]
        [Composite.Data.FieldPositionAttribute(0)]
        [Composite.Data.DefaultFieldGuidValueAttribute("00000000-0000-0000-0000-000000000000")]
        [Composite.Data.ForeignKeyAttribute("Composite.Data.Types.IPage,Composite", AllowCascadeDeletes=true, NullReferenceValue="{00000000-0000-0000-0000-000000000000}")]
        System.Guid Page {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("bb709059-ae2f-416d-b42f-3ae39e07d795")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Integer)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(1)]
        [Composite.Data.Validation.Validators.IntegerRangeValidatorAttribute(-2147483648, 2147483647)]
        [Composite.Data.DefaultFieldIntValueAttribute(0)]
        int Position {
            get;
            set;
        }
    }
}
