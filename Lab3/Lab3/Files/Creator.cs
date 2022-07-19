using Lab3.DocsArgs;
using Lab3.Docs;

namespace Lab3.Creators
{
    abstract class DocCreator<T> where T : Docs.Doc
    {
        protected string id;
        protected string date;
        protected string info;
        public DocCreator(DocArgs args)
        {
            id = args.id;
            date = args.date;
            info = args.info;
        }
        abstract public T Create();
    }
    class MemoCreator : DocCreator<Memo>
    {
        public MemoCreator(DocArgs args) : base(args)
        {
        }
        public override Memo Create()
        {
            return new Memo(id, date, info);
        }
    }

    class LetterCreator : DocCreator<Letter>
    {
        protected bool sender;
        protected string correspondent;
        public LetterCreator(LetterArgs args) : base(args)
        {
            sender = args.sender;
            correspondent = args.correspondent;
        }
        public override Letter Create() 
        {
            return new Letter(id, date, info, sender, correspondent);
        }
    }

    class DecreeCreator : DocCreator<Decree>
    {
        protected string deadline;
        protected string subdivision;
        public DecreeCreator(DecreeArgs args) : base(args)
        {
            deadline = args.deadline;
            subdivision = args.subdivision;
        }

        public override Decree Create()
        {
            return new Decree(id, date, info, deadline, subdivision);
        }
    }

    class OrderCreator : DocCreator<Order>
    {
        protected string deadline;
        protected string subdivision;
        protected string executor;
        public OrderCreator(OrderArgs args) : base(args)
        {
            deadline = args.deadline;
            subdivision = args.subdivision;
            executor = args.executor;
        }

        public override Order Create()
        {
            return new Order(id, date, info, deadline, subdivision, executor);
        }
    }

    class ResourceRequestCreator : DocCreator<ResourceRequest>
    {
        protected string resources;
        protected string assistant;
        public ResourceRequestCreator(ResourceRequestArgs args) : base(args)
        {
            resources = args.resources;
            assistant = args.assistant;
        }
        public override ResourceRequest Create()
        {
            return new ResourceRequest(id, date, info, resources, assistant);
        }
    }

}
