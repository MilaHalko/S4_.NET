using Lab3.Docs;
using Lab3.Files;
using Lab3.Files.Builders;
using System;
using System.Collections.Generic;

namespace Lab3
{

    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            List<Doc> docs = new();

            var lBuilder = new LetterBuilder();
            Letter l = manager.CreateDoc(lBuilder, "3eR-14", "13/08/2024", "Hello, Dear..", true, "Milosh Berkovich");
            docs.Add(l);

            var dBuilder = new DecreeBuilder();
            Decree d = manager.CreateDoc(dBuilder, "gfh4", "31/08/2020", "Importance of deal..", "31/08/2022", "SD1");
            docs.Add(d);

            var mBuilder = new MemoBuilder();
            Memo m = manager.CreateDoc(mBuilder, "123", "01/02/2022", "Memo To Stuff");
            docs.Add(m);

            var oBuilder = new OrderBuilder();
            Order o = manager.CreateDoc(oBuilder, "12345", "02/04/2019", "Stop coercion! #54", "06/07/2021", "SD32-01", "Michael Stubsy");
            docs.Add(o);

            var rrBuilder = new ResourceRequestBuilder();
            ResourceRequest rr = manager.CreateDoc(rrBuilder, "76gR-9t", "30/12/2020", "Get Institution resouces", "Jeck Russly", "books, notes, pens, chairs");
            docs.Add(rr);

            foreach (Doc doc in docs)
            {
                Console.WriteLine(doc);
            }
        }

        
    }
}