namespace My.Content {
    
    
    [Composite.Data.AutoUpdatebleAttribute()]
    [Composite.Data.DataScopeAttribute("public")]
    [Composite.Data.RelevantToUserTypeAttribute("Developer")]
    [Composite.Data.CodeGeneratedAttribute()]
    [Composite.Data.Hierarchy.DataAncestorProviderAttribute(typeof(Composite.Data.Hierarchy.DataAncestorProviders.NoAncestorDataAncestorProvider))]
    [Composite.Data.ImmutableTypeIdAttribute("73b87085-4229-4d07-9599-b21d275111cc")]
    [Composite.Core.WebClient.Renderings.Data.KeyTemplatedXhtmlRendererAttribute(Composite.Core.WebClient.Renderings.Data.XhtmlRenderingType.Embedable, "<span>{label}</span>")]
    [Composite.Data.KeyPropertyNameAttribute("Id")]
    [Composite.Data.TitleAttribute("Most Places")]
    [Composite.Data.LabelPropertyNameAttribute("Place")]
    public interface MostPlace : Composite.Data.IData, Composite.Data.ProcessControlled.ILocalizedControlled, Composite.Data.ProcessControlled.IProcessControlled {
        
        [Composite.Data.ImmutableFieldIdAttribute("a265ed18-ed83-420a-9044-0cfe7013b00d")]
        [Composite.Data.FunctionBasedNewInstanceDefaultFieldValueAttribute("<f:function name=\"Composite.Utils.Guid.NewGuid\" xmlns:f=\"http://www.composite.net" +
            "/ns/function/1.0\" />")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(-1)]
        System.Guid Id {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("186c19ad-1908-4a22-99eb-efb88fc83088")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.Validation.Validators.GuidNotEmptyAttribute()]
        [Composite.Data.FieldPositionAttribute(0)]
        [Composite.Data.DefaultFieldGuidValueAttribute("00000000-0000-0000-0000-000000000000")]
        [Composite.Data.ForeignKeyAttribute("My.Content.Place", AllowCascadeDeletes=true, NullReferenceValue="{00000000-0000-0000-0000-000000000000}")]
        System.Guid Place {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("737b4e20-2763-4557-8f3b-528cbbf7f590")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Integer, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(1)]
        [Composite.Data.Validation.Validators.NullIntegerRangeValidatorAttribute(-2147483648, 2147483647)]
        [Composite.Data.TreeOrderingAttribute(1)]
        System.Nullable<int> Order {
            get;
            set;
        }
    }
}
