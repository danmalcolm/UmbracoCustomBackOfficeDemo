namespace UmbracoCustomBackOfficeDemo.Models.DocumentTypes
{
    using System;
    using Umbraco.CodeGen.Annotations;
    
    [DocumentType(Description="Basic editable content page", Icon=".sprTreeFolder", Thumbnail="folder.png", Structure=new System.Type[] {
            typeof(ContentPage)})]
    public partial class ContentPage : Page
    {
        public ContentPage(Umbraco.Core.Models.IPublishedContent content) : 
                base(content)
        {
        }
        [GenericProperty(Description="Main content", Definition="Richtext editor", Tab="Content")]
        public virtual System.Web.IHtmlString MainContent
        {
            get
            {
                return GetValue<System.Web.IHtmlString>("mainContent");
            }
        }
    }
}
