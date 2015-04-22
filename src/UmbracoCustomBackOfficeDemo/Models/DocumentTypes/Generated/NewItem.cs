namespace UmbracoCustomBackOfficeDemo.Models.DocumentTypes
{
    using System;
    using Umbraco.CodeGen.Annotations;
    
    [DocumentType(Icon=".sprTreeFolder", Thumbnail="folder.png", DefaultTemplate="NewItem", AllowedTemplates=new String[] {
            "NewItem"})]
    public partial class NewItem : Page
    {
        public NewItem(Umbraco.Core.Models.IPublishedContent content) : 
                base(content)
        {
        }
    }
}
