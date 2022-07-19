
namespace Lab3.Docs
{
    public abstract class Doc
    {
        private string id;
        private string date;
        private string info;
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
        private bool sender;
        private string correspondent;
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
        private string deadline;
        private string subdivision;
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
        private string executor
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
        private string resources;
        private string assistant;
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
