namespace UmbracoCustomBackOfficeDemo.Models.DocumentTypes
{
    using System;
    using Umbraco.CodeGen.Annotations;
    
    [DocumentType(Icon=".sprTreeFolder", Thumbnail="folder.png", DefaultTemplate="NewsArticle", AllowedTemplates=new String[] {
            "NewsArticle"})]
    public partial class NewsArticle : ContentPage
    {
        public NewsArticle(Umbraco.Core.Models.IPublishedContent content) : 
                base(content)
        {
        }
    }
}
