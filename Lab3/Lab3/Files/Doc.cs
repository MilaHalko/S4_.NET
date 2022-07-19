
namespace Lab3.Docs
{
    public abstract class Doc
    {
        public string id { get; }
        public string date { get; }
        public string info { get; }
        public Doc(string id, string date, string info)
        {
            this.id = id;
            this.date = date;
            this.info = info;
        }
        public override string ToString()
        {
            return $"Document #{id} by {date}\n" +
                   $"Information: {info}\n";
        }
    }

    class Memo : Doc
    {
        public Memo(string id, string date, string info) : base(id, date, info) { }
        public override string ToString()
        {
            return $"Doc.Memo #{id} by {date}\n" +
                   $"Information: {info}\n";
        }
    }

    class Letter : Doc
    {
        public bool sender { get; }
        public string correspondent { get; }
        public Letter(string id, string date, string info, bool sender, string correspondent) 
            : base(id, date, info)
        {
            this.sender = sender;
            this.correspondent = correspondent;
        }
        public override string ToString()
        {
            string status = sender ? "Sender" : "Receiver";
            return $"Doc.Letter #{id} by {date}\n" +
                   $"{status}: {correspondent}\n" +
                   $"Information: {info}\n";
        }
    }

    class Decree : Doc
    {
        public string deadline { get; }
        public string subdivision { get; }
        public Decree(string id, string date, string info, string deadline, 
            string subdivision) : base(id, date, info)
        {
            this.deadline = deadline;
            this.subdivision = subdivision;
        }
        public override string ToString()
        {
            return $"Doc.Decree #{id} by {date}\n" +
                   $"Information: {info}\n" +
                   $"Deadline: {deadline}\n" +
                   $"Subdivision: {subdivision}\n";
        }
    }

    class Order : Decree
    {
        public string executor { get; }
        public Order(string id, string date, string info, string deadline,
            string subdivision, string executor) 
            : base(id, date, info, deadline, subdivision)
        {
            this.executor = executor;
        }
        public override string ToString()
        {
            return $"Doc.Order #{id} by {date}\n" +
                   $"Information: {info}\n" +
                   $"Deadline: {deadline}\n" +
                   $"Subdivision: {subdivision}\n" +
                   $"Executor: {executor}\n";
        }
    }

    class ResourceRequest : Doc
    {
        public string resources { get; }
        public string assistant { get; }
        public ResourceRequest(string id, string date, string info, 
            string resouces, string assistant) : base(id, date, info)
        {
            this.resources = resouces;
            this.assistant = assistant;
        }
        public override string ToString()
        {
            return $"Doc.ResourseRequest #{id} by {date}\n" +
                   $"Information: {info}\n" +
                   $"Assistant: {assistant}\n" +
                   $"Resources: {resources}\n";
        }
    }
}
