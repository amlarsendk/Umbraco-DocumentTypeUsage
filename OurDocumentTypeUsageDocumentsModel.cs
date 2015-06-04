using System.Collections.Generic;

namespace Our.DocumentTypeUsage
{
    public class OurDocumentTypeUsageDocumentsModel
    {

        public int id { get; set; }
        public string Name { get; set; }
        public string Breadcrumb { get; set; }


        public OurDocumentTypeUsageDocumentsModel(Umbraco.Core.Models.IContent content)
        {
            id = content.Id;
            Name = content.Name;
        }


    }
}
