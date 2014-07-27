using System.Collections.Generic;

namespace Our.DocumentTypeUsage
{
    public class OurDocumentTypeUsageSummaryViewModel
    {
        public IEnumerable<OurDocumentTypeUsageViewModel> List { get; set; }
        public IEnumerable<OurDocumentTypeUsageViewModel> ListDocumentTypesNotInUse { get; set; }
        public int DocumentTypeCount { get; set; }
        public int ContentNodeCount { get; set; }
    }
}