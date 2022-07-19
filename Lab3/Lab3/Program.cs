using Lab3.Creators;
using Lab3.DocsArgs;
using Lab3.Docs;

namespace Lab3
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Docs.Doc> docs = new();

            var mArgs = new MemoArgs("rst-3Re", "12/12/2022", "Memo to stuff.");
            var mCreator = new MemoCreator(mArgs);
            Doc m = mCreator.Create();
            docs.Add(m);

            var lArgs = new LetterArgs("hd3_5", "18/04/2022", "Letter to officer, IMPOrTAnt!", false, "Mr.James");
            var lCreator = new LetterCreator(lArgs);
            Doc l = lCreator.Create();
            docs.Add(l);

            var dArgs = new DecreeArgs("4gT-13e", "09/09/2021", "Stop rewriting memo!", "12/12/2022", "SD-13");
            var dCreator = new DecreeCreator(dArgs);
            Doc d = dCreator.Create();
            docs.Add(d);

            var oArgs = new OrderArgs("d1R4", "01/01/2018", "Order13/4-1", "15/06/2020", "SD-01A", "Lia Charms");
            var oCreator = new OrderCreator(oArgs);
            Doc o = oCreator.Create();
            docs.Add(o);

            var rrArgs = new ResourceRequestArgs("5oR_7", "18/10/2019", "Institute resources", "pens, tables, books, tablets", "Louis Baroette");
            var rrCreator = new ResourceRequestCreator(rrArgs);
            Doc rr = rrCreator.Create();
            docs.Add(rr);

            foreach (Docs.Doc doc in docs)
            {
                Console.WriteLine(doc);
            }
        }

        
    }
}