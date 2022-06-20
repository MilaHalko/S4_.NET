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
            Student st5 = new Student { Id = 5, FirstName = "Elena", LastName = "Kuzma", Patronymic = "Vyloriivna", Group = "IT-01", BirthDate = new DateTime(2001, 2, 11)};
            Student st6 = new Student { Id = 6, FirstName = "Aleksandr", LastName = "Marchenko", Patronymic = "Aleksandrovych", Group = "IT-02", BirthDate = new DateTime(2002, 3, 15)};

            List<Student> students = new List<Student> { st1, st2, st3, st4, st5, st6 };

            // Supervisors

            List<Student> students1 = new List<Student> { st1, st2, st3};
            List<Student> students2 = new List<Student> { st4};
            List<Student> students3 = new List<Student> { st5, st6};

            Supervisor sup1 = new Supervisor { ID = 1, FirstName = "Victor", LastName = "Barinov", Patronymic = "Petrovich", Post = "professor", Students = students1};
            Supervisor sup2 = new Supervisor { ID = 2, FirstName = "Victoria", LastName = "Honcharova", Patronymic = "Yevhenevna", Post = "lecturer", Students = students2};
            Supervisor sup3 = new Supervisor { ID = 3, FirstName = "Robert", LastName = "Dawny", Patronymic = "Second", Post = "philanthropist", Students = students3};

            List<Supervisor> allSupervisors = new List<Supervisor> { sup1, sup2, sup3 };

            // Subjects

            List<Student> students4 = new List<Student> { st1, st3, st4, st6 };
            List<Student> students5 = new List<Student> { st2, st5, st6 };
            List<Student> students6 = new List<Student> { st1, st2, st3, st4 };

            Subject sub1 = new Subject { Name = "Math", Students = students4};
            Subject sub2 = new Subject { Name = "Web", Students = students5};
            Subject sub3 = new Subject { Name = "Literature", Students = students6};

            List<Subject> allSubjects = new List<Subject> { sub1, sub2, sub3 };


            // Set Subjects' Scores & SupervisorIDs for Students

            st1.Scores[sub1] = 95;
            st1.Scores[sub3] = 73;
            st1.SupervisorID = 1;

            st2.Scores[sub2] = 85;
            st2.Scores[sub3] = 86;
            st2.SupervisorID = 1;

            st3.Scores[sub1] = 95;
            st3.Scores[sub3] = 76;
            st3.SupervisorID = 1;

            st4.Scores[sub1] = 89;
            st4.Scores[sub3] = 63;
            st4.SupervisorID = 2;

            st5.Scores[sub2] = 87;
            st5.SupervisorID = 3;

            st6.Scores[sub1] = 99;
            st6.Scores[sub3] = 98;
            st6.SupervisorID = 3;

            // 1. Simple select:
            Console.WriteLine("1) Supervisor_1's Students: ");
            var sup1_students = from student in sup1.Students
                                select student;
            PrintLINQ(sup1_students);

            Console.WriteLine("2) Literature's Students: ");
            var sub3_students = sub3.Students.Select(student => student);
            PrintLINQ(sub3_students);


            // 2. Select list's attribute / projection:
            Console.WriteLine("3) Supervisor_1's groups: ");
            var sup1_groups = sup1.Students.Select(s => s.Group);
            PrintLINQ(sup1_groups);

            Console.WriteLine("4) Student_4's scores: ");
            var student4_subjects = from s in st4.Scores
                                    select s.Value;
            PrintLINQ(student4_subjects);


            // 3. New anonymous type object + .Year:
            Console.WriteLine("5) Literature -> students + BD_year: ");
            var Literature_students_scores = from s in sub3.Students
                                             select new { s.FirstName, s.LastName, s.BirthDate.Year };
            PrintLINQ(Literature_students_scores);


            // 4. Conditions:
            Console.WriteLine("6) Top Students (Average score + 90): ");
            var topStudents = from s in students
                              where s.AverageScore > 90
                              select ( s.FirstName, s.LastName, s.AverageScore );
            PrintLINQ(topStudents);


            // 5. Sorting
            Console.WriteLine("7) Student_2's sorted subjects: ");
            var st6_sortedSubjects = from s in st2.Scores
                                     orderby (s.Key.Name)
                                     select ( s.Key.Name, s.Value );
            PrintLINQ(st6_sortedSubjects);


            // 6. Order + Then
            Console.WriteLine("8) Students's list by year of BD & Lastname: ");
            var stsByYearLastname = students.OrderBy(s => s.BirthDate.Year).ThenBy(s => s.LastName);
            foreach (var st in stsByYearLastname)
            {
                Console.WriteLine("{0} - {1} {2}", st.BirthDate.Year, st.LastName, st.FirstName);
            }
            Console.WriteLine();


            // 7. Hard Sorting + Count()
            Console.WriteLine("9) Sorted Students & Subjects' quantity: ");
            var sortedSupsStuds = from st in students
                                  orderby st.LastName
                                  orderby st.Scores.Count()
                                  select ( st.LastName, st.Scores.Count());
            PrintLINQ(sortedSupsStuds);


            // 8. Skip & Take
            Console.WriteLine("10) Skip Average < 60 and take Average < 90: ");
            var students_skipTake = students.SkipWhile(s => s.AverageScore < 60)
                                               .TakeWhile(s => s.AverageScore < 90)
                                               .OrderBy(s => s.AverageScore)
                                               .Select(s => (s.LastName, s.AverageScore));
            PrintLINQ(students_skipTake);


            // 9. Min & Max
            Console.WriteLine("11) Students with their lowest score: ");
            var lowestScore = from s in students
                              orderby s.Scores.Values.Min()
                              select (s.LastName, s.Scores.Values.Min());
            PrintLINQ(lowestScore);

            Console.WriteLine("12) Students with their highest score: ");
            var highestScore = from s in students
                              select (s.LastName, s.Scores.Values.Max());
            PrintLINQ(highestScore);


            // 10. StartWith + ToUpper
            Console.WriteLine("13) IP Students: ");
            var IPstudents = from st in students
                             where st.Group.ToUpper().StartsWith("IP")
                             orderby st.Group
                             select st.LastName + " " + st.FirstName + ", group: " + st.Group;
            PrintLINQ(IPstudents);

            Console.WriteLine("14) IT Students: ");
            var ITstudents = students.Where(s => s.Group.ToUpper().StartsWith("IT")).OrderBy(s => s.Group);
            PrintLINQ(ITstudents);


            // 11. Date
            Console.WriteLine("15) Students by age: ");
            var stsByAge = from st in students
                           orderby st.BirthDate
                           select st.BirthDate.ToString("yyyy/MM/dd") + " " + st.LastName + " " + st.FirstName;
            PrintLINQ(stsByAge);

            Console.WriteLine("16) Students by age of #3 supervisor: ");
            var stsByAgeOf3Sup = students3.OrderBy(s => s.BirthDate).Select(s => s.LastName + " " + s.FirstName);
            PrintLINQ(stsByAgeOf3Sup);


            // 12. All
            Console.WriteLine("16) Check all students are older than 18:");
            var boolAge18 = students.All(s => DateTime.Now.Year - s.BirthDate.Year > 18);
            Console.WriteLine("All students are +18 age - {0}", boolAge18);
            Console.WriteLine();


            // 12. Concat & Distinct
            Console.WriteLine("17) Concated Students from 1&3 Subjects: ");
            var concatStsBySubs13 = (from s in sub1.Students
                                     select s.LastName + " " + s.FirstName)
                                     .Concat(from s in sub3.Students
                                             select s.LastName + " " + s.FirstName).Distinct();
            PrintLINQ(concatStsBySubs13);


            // 13. Intersect
            Console.WriteLine("18) Intersect of Subject 1 & 3 students: ");
            var sub13StsIntersect = sub1.Students.Intersect(sub3.Students);
            PrintLINQ(sub13StsIntersect);


            // 14. Except
            Console.WriteLine("19) Subject1 students except Subject2:");
            var sub12Except = sub1.Students.Except(sub2.Students);
            PrintLINQ(sub12Except);


            // 13. Union
            Console.WriteLine("18) Union of Supervisor 1 & 3's Students: ");
            var unionSup13Sts = (from s in sup1.Students
                                         select s)
                                        .Union(from s in sup3.Students
                                               select s)
                                        .OrderByDescending(s => s.LastName);
            PrintLINQ(unionSup13Sts);


            // 14.Join
            Console.WriteLine("20) Student_1 -> join Subjects: ");
            var st1JoinSubs = from sc in st1.Scores
                              join sub in allSubjects on sc.Key equals sub
                              select sc.Key.Name + ": " + sc.Value;
            PrintLINQ(st1JoinSubs);

            Console.WriteLine("17) Supervisor_1 -> join Students Average Score: ");
            var sup1JoinStScores = sup1.Students.Join(students, s1 => s1.Id, s2 => s2.Id,
                                                     (s1, s2) => new { Name = s1.LastName + " " + s1.FirstName, Score = s1.AverageScore });
            PrintLINQ(sup1JoinStScores);


            // 12. Group Join
            Console.WriteLine("18) AllSupervisors -> GroupJoin Students: ");
            var supsJoinSts = allSupervisors.GroupJoin(students,
                                                       sup => sup.ID,
                                                       st => st.SupervisorID,
                                                       (sups, sts) => new
                                                       {
                                                           Supervisor = sups.FirstName + " " + sups.Patronymic,
                                                           Students = sts.Select(s => s.LastName)
                                                       });
            foreach (var sups in supsJoinSts)
            {
                Console.WriteLine($"{sups.Supervisor}:");
                foreach (var student in sups.Students)
                {
                    Console.WriteLine($"\t{student}");
                }
            }
            Console.WriteLine();


            // 13. Group by
            Console.WriteLine("19) Students grouped by LastName: ");
            var stsGroupedLastName = from st in students
                                     group st by st.LastName;
            foreach (var sts in stsGroupedLastName)
            {
                Console.WriteLine(sts.Key + ":");
                foreach (var student in sts)
                {
                    Console.WriteLine($"\t{student.FirstName}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("20) Students' level by Average score: ");
            var stsLevel = students.GroupBy(st =>
            {
                if (st.AverageScore < 80) { return "3 Low score"; }
                else if (st.AverageScore < 90) { return "2 Middle score"; }
                else { return "1 High score"; }
            }).OrderBy(st => st.Key);
            foreach (var sts in stsLevel)
            {
                Console.WriteLine(sts.Key + ": ");
                foreach (var st in sts)
                {
                    Console.WriteLine("\t{0} {1}: {2}", st.LastName, st.FirstName, st.AverageScore);
                }
            }
            Console.WriteLine();



            Console.ReadLine();

        }

        private static void PrintLINQ<T>(IEnumerable<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
