using Lab3.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Files.Builders
{
    interface IDecreeBuilder : IBuilder
    {
        public void AddDeadline(string deadline);
        public void AddSubdivision(string subdivision);
        public Decree GetDecree();
    }

    class DecreeBuilder : IDecreeBuilder
    {
        private Decree decree = new();

        public void AddDate(string date)
        {
            decree.date = date;
        }

        public void AddDeadline(string deadline)
        {
            decree.deadline = deadline;
        }

        public void AddId(string id)
        {
            decree.id = id;
        }

        public void AddInfo(string info)
        {
            decree.info = info;
        }

        public void AddSubdivision(string subdivision)
        {
            decree.subdivision = subdivision;
        }

        public Decree GetDecree()
        {
            return decree;
        }

        public Docs.Doc GetDoc()
        {
            return decree;
        }
    }
}
