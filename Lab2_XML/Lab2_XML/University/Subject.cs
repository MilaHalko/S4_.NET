using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_LINQ
{
    internal class Subject
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            string students = string.Join(" ", Students);
            return String.Format(@"
                Subject: {0} 
                    Students: {1}", Name, students);
        }
    }
}