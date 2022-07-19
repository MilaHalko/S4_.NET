using Lab3.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Files
{
    class Manager
    {
        public Memo CreateDoc(Builders.MemoBuilder builder, string id, string date, string info)
        {
            builder.AddId(id);
            builder.AddDate(date);
            builder.AddInfo(info);
            return builder.GetMemo();
        }

        public Letter CreateDoc(Builders.LetterBuilder builder, string id, string date, 
            string info, bool sender, string name)
        {
            builder.AddId(id);
            builder.AddDate(date);
            builder.AddInfo(info);
            if (sender)
            {
                builder.AddSender(name);
            }
            else 
            {
                builder.AddReceiver(name);
            }
            return builder.GetLetter();
        }

        public Decree CreateDoc(Builders.DecreeBuilder builder, string id, string date, string info,
            string deadline, string subdivision)
        {
            builder.AddId(id);
            builder.AddDate(date);
            builder.AddInfo(info);
            builder.AddDeadline(deadline);
            builder.AddSubdivision(subdivision);
            return builder.GetDecree();
        }

        public Order CreateDoc(Builders.OrderBuilder builder, string id, string date, string info,
            string deadline, string subdivision, string executor)
        {
            builder.AddId(id);
            builder.AddDate(date);
            builder.AddInfo(info);
            builder.AddDeadline(deadline);
            builder.AddSubdivision(subdivision);
            builder.AddExecutor(executor);
            return builder.GetOrder();
        }

        public ResourceRequest CreateDoc(Builders.ResourceRequestBuilder builder, string id, string date, string info,
            string assistant, string resourses)
        {
            builder.AddId(id);
            builder.AddDate(date);
            builder.AddInfo(info);
            builder.AddAssistant(assistant);
            builder.AddResources(resourses);
            return builder.GetResourceRequest();
        }
    }
}
