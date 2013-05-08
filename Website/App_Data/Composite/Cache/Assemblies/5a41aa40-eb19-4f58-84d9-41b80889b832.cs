namespace My.Content {
    
    
    [Composite.Data.AutoUpdatebleAttribute()]
    [Composite.Data.DataScopeAttribute("public")]
    [Composite.Data.RelevantToUserTypeAttribute("Developer")]
    [Composite.Data.CodeGeneratedAttribute()]
    [Composite.Data.Hierarchy.DataAncestorProviderAttribute(typeof(Composite.Data.Hierarchy.DataAncestorProviders.NoAncestorDataAncestorProvider))]
    [Composite.Data.ImmutableTypeIdAttribute("5a41aa40-eb19-4f58-84d9-41b80889b832")]
    [Composite.Core.WebClient.Renderings.Data.KeyTemplatedXhtmlRendererAttribute(Composite.Core.WebClient.Renderings.Data.XhtmlRenderingType.Embedable, "<span>{label}</span>")]
    [Composite.Data.KeyPropertyNameAttribute("Id")]
    [Composite.Data.TitleAttribute("Places")]
    [Composite.Data.LabelPropertyNameAttribute("Title")]
    public interface Place : Composite.Data.IData, Composite.Data.ProcessControlled.IProcessControlled, Composite.Data.ProcessControlled.ILocalizedControlled {
        
        [Composite.Data.ImmutableFieldIdAttribute("b22017c9-d198-4be5-8c88-dcaef7144da9")]
        [Composite.Data.FunctionBasedNewInstanceDefaultFieldValueAttribute("<f:function name=\"Composite.Utils.Guid.NewGuid\" xmlns:f=\"http://www.composite.net" +
            "/ns/function/1.0\" />")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(-1)]
        System.Guid Id {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("8f3e961b-7c5b-4fd7-aaf8-f4a9b6d86d38")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 256)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(0)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 256)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string Title {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("34be9888-e3d7-4892-b75d-b3d12af1a1d4")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.Guid)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.Validation.Validators.GuidNotEmptyAttribute()]
        [Composite.Data.FieldPositionAttribute(1)]
        [Composite.Data.DefaultFieldGuidValueAttribute("00000000-0000-0000-0000-000000000000")]
        [Composite.Data.ForeignKeyAttribute("My.Content.PlaceArea", AllowCascadeDeletes=true, NullReferenceValue="{00000000-0000-0000-0000-000000000000}")]
        [Composite.Data.GroupByPriorityAttribute(1)]
        System.Guid Area {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("4822126d-aaeb-4fad-b380-7a0455af2bc2")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.LargeString, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(2)]
        string Teaser {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("2f135f7d-d032-46c5-80a6-87c438576564")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.LargeString, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(3)]
        string Content {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("ebd5a6a2-091d-4e6d-a3be-c63d1c7e46bf")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 2048, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(4)]
        [Composite.Data.Validation.Validators.NullStringLengthValidatorAttribute(0, 2048)]
        [Composite.Data.ForeignKeyAttribute("Composite.Data.Types.IImageFile,Composite", AllowCascadeDeletes=true, NullableString=true)]
        string Image {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("b7f0a743-6b83-4aef-a392-2e97b499f6d9")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.LargeString, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(5)]
        string Gallery {
            get;
            set;
        }
    }
}
