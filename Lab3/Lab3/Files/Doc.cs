using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Docs
{
    abstract class Doc
    {
        public string id { get; set; }
        public string date { get; set; }
        public string info { get; set; }
        public override string ToString()
        {
            return $"Document #{id} by {date}\n" +
                   $"Information: {info}\n";
        }
    }

    class Letter : Doc
    {
        public string status { get; set; }
        public string correspondent { get; set; }

        public override string ToString()
        {
            return $"Doc.Letter #{id} by {date}\n" +
                   $"{status}: {correspondent}\n" +
                   $"Information: {info}\n";
        }
    }

    class Memo : Doc
    {
        public override string ToString()
        {
            return $"Doc.Memo #{id} by {date}\n" +
                   $"Information: {info}\n";
        }
    }
    class Decree : Doc
    {
        public string deadline { get; set; }
        public string subdivision { get; set; }
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
        public string executor { get; set; }
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
        public string resources { get; set; }
        public string assistant { get; set; }

        public override string ToString()
        {
            return $"Doc.ResourseRequest #{id} by {date}\n" +
                   $"Information: {info}\n" +
                   $"Assistant: {assistant}\n" +
                   $"Resources: {resources}\n";
        }
    }
}
