namespace UmbracoCustomBackOfficeDemo.Models.DocumentTypes
{
    using System;
    using Umbraco.CodeGen.Annotations;
    
    [DocumentType(Icon=".sprTreeFolder", Thumbnail="folder.png", AllowAtRoot=true, DefaultTemplate="HomePage", AllowedTemplates=new String[] {
            "HomePage"}, Structure=new System.Type[] {
            typeof(NewsListing)})]
    public partial class HomePage : ContentPage
    {
        public HomePage(Umbraco.Core.Models.IPublishedContent content) : 
                base(content)
        {
        }
    }
}
