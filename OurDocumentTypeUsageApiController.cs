using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi;

namespace Our.DocumentTypeUsage
{
    [PluginController("OurDocumentTypeUsage")]
    public class OurDocumentTypeUsageApiController : UmbracoAuthorizedJsonController
    {
        private static OurDocumentTypeUsageSummaryViewModel _singleton = null;

        public OurDocumentTypeUsageSummaryViewModel Get()
        {
            if (_singleton == null)
            {
                return Get(true);
            }

            return _singleton;
        }

        public OurDocumentTypeUsageSummaryViewModel Get(bool refresh)
        {
            var context = ApplicationContext.Current;
            var serviceContext = context.Services;
            var contentService = serviceContext.ContentService;
            var contentTypeService = serviceContext.ContentTypeService;

            var list = contentTypeService.GetAllContentTypes()
                .OrderBy(o => o.Level).ThenBy(t => t.Name)
                .Select(
                    contentType =>
                        new OurDocumentTypeUsageViewModel
                        {
                            Id = contentType.Id,
                            Name = contentType.Name,
                            ParentId = contentType.ParentId,
                            Count = contentService.GetContentOfContentType(contentType.Id).Count(),
                        })
                .ToList();

            int countDocumentTypes = list.Count();

            foreach (var item in list)
            {
                if (item.ParentId != -1)
                {
                    if (list.Any(d => d.Id == item.ParentId))
                    {
                        list.First(d => d.Id == item.ParentId).Children.Add(item);
                    }
                }
            }

            var model = new OurDocumentTypeUsageSummaryViewModel
            {
                List = list.Where(d => d.ParentId == -1),
                ListDocumentTypesNotInUse = list.Where(d => d.Count == 0 && !d.Children.Any()),
                ContentNodeCount = list.Sum(c => c.Count),
                DocumentTypeCount = countDocumentTypes
            };

            _singleton = model;

            return model;
        }
    }
}