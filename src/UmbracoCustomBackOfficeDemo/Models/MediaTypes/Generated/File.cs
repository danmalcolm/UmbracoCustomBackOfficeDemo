namespace UmbracoCustomBackOfficeDemo.Models.MediaTypes
{
    using System;
    using Umbraco.CodeGen.Annotations;
    
    [MediaType(Icon="icon-document", Thumbnail="icon-document")]
    public partial class File : Umbraco.CodeGen.WaitForSixTwo.PublishedContentModel
    {
        public File(Umbraco.Core.Models.IPublishedContent content) : 
                base(content)
        {
        }
        [GenericProperty(DisplayName="Upload file", Definition="Upload", Tab="File")]
        public virtual String UmbracoFile
        {
            get
            {
                return GetValue<String>("umbracoFile");
            }
        }
        [GenericProperty(DisplayName="Type", Definition="Label", Tab="File")]
        public virtual String UmbracoExtension
        {
            get
            {
                return GetValue<String>("umbracoExtension");
            }
        }
        [GenericProperty(DisplayName="Size", Definition="Label", Tab="File")]
        public virtual String UmbracoBytes
        {
            get
            {
                return GetValue<String>("umbracoBytes");
            }
        }
    }
}
