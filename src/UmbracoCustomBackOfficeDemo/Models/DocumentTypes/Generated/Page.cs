namespace UmbracoCustomBackOfficeDemo.Models.DocumentTypes
{
    using System;
    using Umbraco.CodeGen.Annotations;
    
    [DocumentType(Description="Base page containing common properties", Icon=".sprTreeFolder", Thumbnail="folder.png")]
    public partial class Page : Umbraco.CodeGen.WaitForSixTwo.PublishedContentModel
    {
        public Page(Umbraco.Core.Models.IPublishedContent content) : 
                base(content)
        {
        }
        [GenericProperty(Definition="Textstring", Tab="Content")]
        public virtual String Title
        {
            get
            {
                return GetValue<String>("title");
            }
        }
        [GenericProperty(Definition="Textstring", Tab="Content")]
        public virtual String MetaDescription
        {
            get
            {
                return GetValue<String>("metaDescription");
            }
        }
    }
}
