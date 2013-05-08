namespace My.Navigation {
    
    
    [Composite.Data.AutoUpdatebleAttribute()]
    [Composite.Data.DataScopeAttribute("public")]
    [Composite.Data.RelevantToUserTypeAttribute("Developer")]
    [Composite.Data.CodeGeneratedAttribute()]
    [Composite.Data.Hierarchy.DataAncestorProviderAttribute(typeof(Composite.Data.Hierarchy.DataAncestorProviders.NoAncestorDataAncestorProvider))]
    [Composite.Data.ImmutableTypeIdAttribute("4e9f82c9-b9e6-44cb-b97d-cf6d6680dc7e")]
    [Composite.Core.WebClient.Renderings.Data.KeyTemplatedXhtmlRendererAttribute(Composite.Core.WebClient.Renderings.Data.XhtmlRenderingType.Embedable, "<span>{label}</span>")]
    [Composite.Data.KeyPropertyNameAttribute("Id")]
    [Composite.Data.TitleAttribute("Main menu")]
    [Composite.Data.LabelPropertyNameAttribute("Page")]
    public interface MainMenu : Composite.Data.IData, Composite.Data.ProcessControlled.IProcessControlled, Composite.Data.ProcessControlled.ILocalizedControlled {
        
        [Composite.Data.ImmutableFieldIdAttribute("ba61dfcb-8f0d-4407-b059-01e69905222d")]
        [Composite.Data.FunctionBasedNewInstanceDefaultFieldValueAttribute("<f:function name=\"Composite.Utils.Guid.NewGuid\" xmlns:f=\"http://www.composite.net" +
            "/ns/function/1.0\" />")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(-1)]
        System.Guid Id {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("67f5eae8-ddcd-40df-a6be-6848785784b4")]
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
        
        [Composite.Data.ImmutableFieldIdAttribute("4417b303-56e6-48bd-87e9-1eda26490ad3")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 64, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(1)]
        [Composite.Data.Validation.Validators.NullStringLengthValidatorAttribute(0, 64)]
        string SubName {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("f1405f5d-7c2a-4463-9304-97af3668b714")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Integer, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(2)]
        [Composite.Data.Validation.Validators.NullIntegerRangeValidatorAttribute(-2147483648, 2147483647)]
        [Composite.Data.TreeOrderingAttribute(1)]
        System.Nullable<int> Order {
            get;
            set;
        }
    }
}
