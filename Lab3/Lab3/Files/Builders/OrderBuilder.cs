using Lab3.Docs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Files.Builders
{
    interface IOrderBuilder : IBuilder
    {
        public void AddDeadline(string deadline);
        public void AddSubdivision(string subdivision);
        public void AddExecutor(string name);
        public Order GetOrder();

    }

    class OrderBuilder : IOrderBuilder
    {
        private Order order = new();

        public void AddDate(string date)
        {
            order.date = date;
        }

        public void AddDeadline(string deadline)
        {
            order.deadline = deadline;
        }

        public void AddExecutor(string name)
        {
            order.executor = name;
        }

        public void AddId(string id)
        {
            order.id = id;
        }

        public void AddInfo(string info)
        {
            order.info = info;
        }

        public void AddSubdivision(string subdivision)
        {
            order.subdivision = subdivision;
        }

        public Doc GetDoc()
        {
            return order;
        }

        public Order GetOrder()
        {
            return order;
        }
    }
}
