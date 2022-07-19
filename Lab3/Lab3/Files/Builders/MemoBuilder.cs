using Lab3.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Files.Builders
{
    interface IMemoBuilder : IBuilder
    {
        public Memo GetMemo();
    }
    class MemoBuilder : IMemoBuilder
    {
        private Memo memo = new();
        public void AddDate(string date)
        {
            memo.date = date;
        }

        public void AddId(string id)
        {
            memo.id = id;
        }

        public void AddInfo(string info)
        {
            memo.info = info;
        }

        public Doc GetDoc()
        {
            return memo;
        }

        public Memo GetMemo()
        {
            return memo;
        }
    }
}
