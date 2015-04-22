using System;
using System.Linq;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoCustomBackOfficeDemo.Models;
using UmbracoCustomBackOfficeDemo.Models.DocumentTypes;

namespace UmbracoCustomBackOfficeDemo.Templates
{
    public abstract class DocumentTemplate<TDocument> : UmbracoViewPage<RenderModel>
        where TDocument : Page
    {
        public TDocument Document
        {
            get
            {
                return Model.Content.As<TDocument>();
            }
        }
    }
}
