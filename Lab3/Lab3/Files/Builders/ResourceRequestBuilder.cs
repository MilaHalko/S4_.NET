using Lab3.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Files.Builders
{
    interface IResourceRequestBuilder : IBuilder
    {
        public void AddResources(string resources);
        public void AddAssistant(string assistant);
        public ResourceRequest GetResourceRequest();
    }

    class ResourceRequestBuilder : IResourceRequestBuilder
    {
        private ResourceRequest rr = new();

        public void AddAssistant(string assistant)
        {
            rr.assistant = assistant;
        }

        public void AddDate(string date)
        {
            rr.date = date;
        }

        public void AddId(string id)
        {
            rr.id = id;
        }

        public void AddInfo(string info)
        {
            rr.info = info;
        }

        public void AddResources(string resources)
        {
            rr.resources = resources;
        }

        public Doc GetDoc()
        {
            return rr;
        }

        public ResourceRequest GetResourceRequest()
        {
            return rr;
        }
    }
}
