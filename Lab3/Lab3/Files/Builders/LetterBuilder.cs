using Lab3.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Files.Builders
{
     interface ILetterBuilder : IBuilder
    {
        public void AddSender(string name);
        public void AddReceiver(string name);
        public Letter GetLetter();

    }

    class LetterBuilder : ILetterBuilder
    {
        private Letter letter = new Letter();
        public void AddId(string id_)
        {
            letter.id = id_;
        }

        public void AddDate(string date_)
        {
            letter.date = date_;
        }

        public void AddInfo(string info_)
        {
            letter.info = info_;
        }

        public void AddSender(string name)
        {
            letter.status = "sender";
            letter.correspondent = name;
        }

        public void AddReceiver(string name)
        {
            letter.status = "receiver";
            letter.correspondent = name;
        }

        public Doc GetDoc()
        {
            return letter;
        }

        public Letter GetLetter()
        {
            return letter;
        }
    }
}
