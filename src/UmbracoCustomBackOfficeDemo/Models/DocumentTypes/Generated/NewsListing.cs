namespace UmbracoCustomBackOfficeDemo.Models.DocumentTypes
{
    using System;
    using Umbraco.CodeGen.Annotations;
    
    [DocumentType(Icon=".sprTreeFolder", Thumbnail="folder.png", DefaultTemplate="NewsListing", AllowedTemplates=new String[] {
            "NewsListing"}, Structure=new System.Type[] {
            typeof(NewsArticle)})]
    public partial class NewsListing : ContentPage
    {
        public NewsListing(Umbraco.Core.Models.IPublishedContent content) : 
                base(content)
        {
        }
    }
}
