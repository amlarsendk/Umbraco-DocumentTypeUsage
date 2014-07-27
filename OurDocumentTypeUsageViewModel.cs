using System.Collections.Generic;

namespace Our.DocumentTypeUsage
{
    public class OurDocumentTypeUsageViewModel
    {
        internal int Id { get; set; }
        internal int ParentId { get; set; }

        public string Name { get; set; }
        public int Count { get; set; }

        public List<OurDocumentTypeUsageViewModel> Children = new List<OurDocumentTypeUsageViewModel>();
    }
}