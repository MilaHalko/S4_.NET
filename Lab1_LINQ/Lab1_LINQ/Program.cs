using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Students

            Student st1 = new Student { Id = 1, FirstName = "Maksim", LastName = "Lavrov", Patronymic = "Leonidovych", Group = "IP-01", BirthDate = new DateTime(2000, 12,31)};
            Student st2 = new Student { Id = 2, FirstName = "Ekaterina", LastName = "Barinova", Patronymic = "Victorovna", Group = "IP-02", BirthDate = new DateTime(2001, 8, 14)};
            Student st3 = new Student { Id = 3, FirstName = "Anastasia", LastName = "Kuzma", Patronymic = "Stepanovna", Group = "IP-03", BirthDate = new DateTime(1999, 4, 23)};
            Student st4 = new Student { Id = 4, FirstName = "Larisa", LastName = "Diachenko", Patronymic = "Volodymirovna", Group = "IP-04", BirthDate = new DateTime(2000, 10, 11)};
            Student st5 = new Student { Id = 5, FirstName = "Elena", LastName = "Malianytsa", Patronymic = "Vyloriivna", Group = "IT-01", BirthDate = new DateTime(2001, 2, 11)};
            Student st6 = new Student { Id = 6, FirstName = "Aleksandr", LastName = "Marchenko", Patronymic = "Aleksandrovych", Group = "IT--02", BirthDate = new DateTime(2002, 3, 15)};


            // Supervisors

            List<Student> students1 = new List<Student> { st1, st2, st3};
            List<Student> students2 = new List<Student> { st4};
            List<Student> students3 = new List<Student> { st5, st6};

            Supervisor sup1 = new Supervisor { FirstName = "Victor", LastName = "Barinov", Patronymic = "Petrovich", Post = "professor", Students = students1};
            Supervisor sup2 = new Supervisor { FirstName = "Victoria", LastName = "Honcharova", Patronymic = "Yevhenevna", Post = "lecturer", Students = students2};
            Supervisor sup3 = new Supervisor { FirstName = "Robert", LastName = "Dawny", Patronymic = "Second", Post = "philanthropist", Students = students3};


            // Subjects

            List<Student> students4 = new List<Student> { st1, st3, st4, st6 };
            List<Student> students5 = new List<Student> { st2, st5, st6 };
            List<Student> students6 = new List<Student> { st1, st2, st3, st4 };

            Subject sub1 = new Subject { Name = "Math", Students = students4};
            Subject sub2 = new Subject { Name = "Web", Students = students5};
            Subject sub3 = new Subject { Name = "Literature", Students = students6};


            // Set Subjects' Scores for Students

            st1.Scores[sub1] = 95;
            st1.Scores[sub3] = 73;
            st2.Scores[sub2] = 85;
            st2.Scores[sub3] = 86;
            st3.Scores[sub1] = 90;
            st3.Scores[sub3] = 76;
            st4.Scores[sub1] = 89;
            st4.Scores[sub3] = 63;
            st5.Scores[sub2] = 87;
            st6.Scores[sub1] = 99;
            st6.Scores[sub3] = 98;



        }
    }
}
