using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.UI.JavaScript;

namespace Our.DocumentTypeUsage
{
    public class UmbStartup : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            ServerVariablesParser.Parsing += ServerVariablesParser_Parsing;
        }

        void ServerVariablesParser_Parsing(object sender, Dictionary<string, object> e)
        {
            if (HttpContext.Current == null) throw new InvalidOperationException("HttpContext is null");
            var urlHelper = new UrlHelper(new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData()));
    
            e.Add("ourDocumentTypeUsage", new Dictionary<string, object>
            {
                {"ourDocumentTypeUsageApiPathGet", urlHelper.GetUmbracoApiServiceBaseUrl<OurDocumentTypeUsageApiController>(contr => contr.Get()) + "Get"}
            });
        }
    }
}
