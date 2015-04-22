namespace UmbracoCustomBackOfficeDemo.Models.MediaTypes
{
    using System;
    using Umbraco.CodeGen.Annotations;
    
    [MediaType(Icon="icon-picture", Thumbnail="icon-picture")]
    public partial class Image : Umbraco.CodeGen.WaitForSixTwo.PublishedContentModel
    {
        public Image(Umbraco.Core.Models.IPublishedContent content) : 
                base(content)
        {
        }
        [GenericProperty(DisplayName="Upload image", Definition="Upload", Tab="Image")]
        public virtual String UmbracoFile
        {
            get
            {
                return GetValue<String>("umbracoFile");
            }
        }
        [GenericProperty(DisplayName="Width", Definition="Label", Tab="Image")]
        public virtual String UmbracoWidth
        {
            get
            {
                return GetValue<String>("umbracoWidth");
            }
        }
        [GenericProperty(DisplayName="Height", Definition="Label", Tab="Image")]
        public virtual String UmbracoHeight
        {
            get
            {
                return GetValue<String>("umbracoHeight");
            }
        }
        [GenericProperty(DisplayName="Size", Definition="Label", Tab="Image")]
        public virtual String UmbracoBytes
        {
            get
            {
                return GetValue<String>("umbracoBytes");
            }
        }
        [GenericProperty(DisplayName="Type", Definition="Label", Tab="Image")]
        public virtual String UmbracoExtension
        {
            get
            {
                return GetValue<String>("umbracoExtension");
            }
        }
    }
}
