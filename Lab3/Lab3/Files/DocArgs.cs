namespace Lab3.DocsArgs
{
    abstract class DocArgs
    {
        public string id { get; set; }
        public string date { get; set; }
        public string info { get; set; }
        public DocArgs(string id, string date, string info)
        {
            this.id = id;
            this.date = date;
            this.info = info;
        }
    }

    class MemoArgs : DocArgs
    {
        public MemoArgs(string id, string date, string info) 
            : base(id, date, info) { }
    }

    class LetterArgs : DocArgs
    {
        public bool sender { get; set; }
        public string correspondent { get; set; }
        public LetterArgs(string id, string date, string info, 
            bool sender, string correspondent)
            : base(id, date, info)
        {
            this.sender = sender;
            this.correspondent = correspondent;
        }
    }

    class DecreeArgs : DocArgs
    {
        public string deadline { get; set; }
        public string subdivision { get; set; }
        public DecreeArgs(string id, string date, string info, 
            string deadline, string subdivision) : base(id, date, info)
        {
            this.deadline = deadline;
            this.subdivision = subdivision;
        }
    }

    class OrderArgs : DecreeArgs
    {
        public string executor { get; set; }
        public OrderArgs(string id, string date, string info, 
            string deadline, string subdivision, string executor)
            : base(id, date, info, deadline, subdivision)
        {
            this.executor = executor;
        }
    }

    class ResourceRequestArgs : DocArgs
    {
        public string resources { get; set; }
        public string assistant { get; set; }
        public ResourceRequestArgs(string id, string date, string info,
            string resouces, string assistant) : base(id, date, info)
        {
            this.resources = resouces;
            this.assistant = assistant;
        }
    }
}
