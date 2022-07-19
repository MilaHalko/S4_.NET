using Lab3.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Files.Builders
{
    interface IBuilder
    {
        public void AddId(string id);
        public void AddDate(string date);
        public void AddInfo(string info);
        public Doc GetDoc();
    }
}

