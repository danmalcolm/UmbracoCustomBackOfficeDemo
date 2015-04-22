namespace UmbracoCustomBackOfficeDemo.Models.MediaTypes
{
    using System;
    using Umbraco.CodeGen.Annotations;
    
    [MediaType(Icon="icon-folder", Thumbnail="icon-folder", AllowAtRoot=true, Structure=new System.Type[] {
            typeof(Folder),
            typeof(Image),
            typeof(File)})]
    public partial class Folder : Umbraco.CodeGen.WaitForSixTwo.PublishedContentModel
    {
        public Folder(Umbraco.Core.Models.IPublishedContent content) : 
                base(content)
        {
        }
        [GenericProperty(DisplayName="Contents:", Definition="Folder Browser", Tab="Contents")]
        public virtual String Contents
        {
            get
            {
                return GetValue<String>("contents");
            }
        }
    }
}
