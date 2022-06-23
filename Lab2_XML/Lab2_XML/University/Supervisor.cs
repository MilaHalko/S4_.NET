using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_XML
{
    internal class Supervisor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Post { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            string students = string.Join(" ", Students);
            return String.Format(@"
                Supervisor: {0} {1} {2} 
                Post: {3} 
                    Students: {4}", LastName, FirstName, Patronymic, Post, students);
        }

        internal object Join(List<Student> students, Func<object, object> p1, Func<Student, Student> p2, Func<object, object, object> p3)
        {
            throw new NotImplementedException();
        }
    }
}