using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_LINQ
{
    internal class Supervisor
    {
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
                    Students: {4}", FirstName, LastName, Patronymic, Post, students);
        }
    }
}
