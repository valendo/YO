namespace Composite.Forms {
    
    
    [Composite.Data.AutoUpdatebleAttribute()]
    [Composite.Data.DataScopeAttribute("public")]
    [Composite.Data.RelevantToUserTypeAttribute("Developer")]
    [Composite.Data.CodeGeneratedAttribute()]
    [Composite.Data.Hierarchy.DataAncestorProviderAttribute(typeof(Composite.Data.Hierarchy.DataAncestorProviders.NoAncestorDataAncestorProvider))]
    [Composite.Data.ImmutableTypeIdAttribute("181e8089-7521-4ec5-a8f5-7ea19868bbb5")]
    [Composite.Core.WebClient.Renderings.Data.KeyTemplatedXhtmlRendererAttribute(Composite.Core.WebClient.Renderings.Data.XhtmlRenderingType.Embedable, "<span>{label}</span>")]
    [Composite.Data.TitleAttribute("ContactForm")]
    [Composite.Data.LabelPropertyNameAttribute("Name")]
    public interface ContactFormData : Composite.Data.IData, Composite.Data.IPageData, Composite.Data.IPageFolderData {
        
        [Composite.Data.ImmutableFieldIdAttribute("69c1475a-e8d1-489a-9d13-f9d9eed40b2b")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 128)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(0)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 128)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string Name {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("b6ad3e66-0742-49f5-9383-a7df18d7787c")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 128)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(1)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 128)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string Email {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("eaad8377-20cc-4f67-8ead-736f784a5f04")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 128, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(2)]
        [Composite.Data.Validation.Validators.NullStringLengthValidatorAttribute(0, 128)]
        string Company {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("cd6a7eda-4cc2-4703-9981-c6fa86f8baf8")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 256, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(3)]
        [Composite.Data.Validation.Validators.NullStringLengthValidatorAttribute(0, 256)]
        string Website {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("5640646f-d3bb-4dbe-9693-fdd3f33d7d91")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 256, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(4)]
        [Composite.Data.Validation.Validators.NullStringLengthValidatorAttribute(0, 256)]
        string Address {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("82c77dae-a2e5-4e39-ab90-58d33d0b2552")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 128)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(5)]
        [Composite.Data.Validation.Validators.StringSizeValidatorAttribute(0, 128)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string PhoneNumber {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("32f5d294-6bd5-4ee1-9728-f7ab77cfaac6")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 256, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(6)]
        [Composite.Data.Validation.Validators.NullStringLengthValidatorAttribute(0, 256)]
        string Subject {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("2fac3947-be83-4a36-9bfd-333b47ce6b09")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.LargeString)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Composite.Data.FieldPositionAttribute(7)]
        [Composite.Data.DefaultFieldStringValueAttribute("")]
        string Message {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("29375e6a-070d-4d34-9f56-9ef030853929")]
        [Composite.Data.FunctionBasedNewInstanceDefaultFieldValueAttribute("<f:function xmlns:f=\"http://www.composite.net/ns/function/1.0\" name=\"Composite.Ut" +
            "ils.Date.Now\" />")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.DateTime)]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidatorAttribute()]
        [Microsoft.Practices.EnterpriseLibrary.Validation.Validators.DateTimeRangeValidatorAttribute("1753-01-01T00:00:00", "9999-12-31T23:59:59")]
        [Composite.Data.FieldPositionAttribute(8)]
        [Composite.Data.DefaultFieldNowDateTimeValueAttribute()]
        [Composite.Data.GroupByPriorityAttribute(1)]
        System.DateTime Date {
            get;
            set;
        }
        
        [Composite.Data.ImmutableFieldIdAttribute("7f937c84-ffe7-44e7-8c03-62513621b687")]
        [Composite.Data.StoreFieldTypeAttribute(Composite.Data.PhysicalStoreFieldType.String, 128, IsNullable=true)]
        [Composite.Data.FieldPositionAttribute(9)]
        [Composite.Data.Validation.Validators.NullStringLengthValidatorAttribute(0, 128)]
        string IP {
            get;
            set;
        }
    }
}
