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

            List<Student> allStudents = new List<Student> { st1, st2, st3, st4, st5, st6 };

            // Supervisors

            List<Student> students1 = new List<Student> { st1, st2, st3};
            List<Student> students2 = new List<Student> { st4};
            List<Student> students3 = new List<Student> { st5, st6};

            Supervisor sup1 = new Supervisor { FirstName = "Victor", LastName = "Barinov", Patronymic = "Petrovich", Post = "professor", Students = students1};
            Supervisor sup2 = new Supervisor { FirstName = "Victoria", LastName = "Honcharova", Patronymic = "Yevhenevna", Post = "lecturer", Students = students2};
            Supervisor sup3 = new Supervisor { FirstName = "Robert", LastName = "Dawny", Patronymic = "Second", Post = "philanthropist", Students = students3};

            List<Supervisor> allSupervisors = new List<Supervisor> { sup1, sup2, sup3 };

            // Subjects

            List<Student> students4 = new List<Student> { st1, st3, st4, st6 };
            List<Student> students5 = new List<Student> { st2, st5, st6 };
            List<Student> students6 = new List<Student> { st1, st2, st3, st4 };

            Subject sub1 = new Subject { Name = "Math", Students = students4};
            Subject sub2 = new Subject { Name = "Web", Students = students5};
            Subject sub3 = new Subject { Name = "Literature", Students = students6};

            List<Subject> allSubjects = new List<Subject> { sub1, sub2, sub3 };


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
            Console.WriteLine("6) Top Students (Avarage score + 90): ");
            var topStudents = from s in allStudents
                              where s.AverageScore > 90
                              select ( s.FirstName, s.LastName, s.AverageScore );
            PrintLINQ(topStudents);


            // 5. Sorting
            Console.WriteLine("7) Student_2's sorted subjects: ");
            var st6_sortedSubjects = from s in st2.Scores
                                     orderby (s.Key.Name)
                                     select ( s.Key.Name, s.Value );
            PrintLINQ(st6_sortedSubjects);


            // 6. Hard Sorting + Count()
            Console.WriteLine("8) Sorted Students & Subjects' quantity: ");
            var sortedSupsStuds = from st in allStudents
                                  orderby st.LastName
                                  orderby st.Scores.Count()
                                  select ( st.LastName, st.Scores.Count());
            PrintLINQ(sortedSupsStuds);


            // 7. Skip & Take
            Console.WriteLine("9) Skip Average < 60 and take Average < 90: ");
            var students_skipTake = allStudents.SkipWhile(s => s.AverageScore < 60)
                                               .TakeWhile(s => s.AverageScore < 90)
                                               .OrderBy(s => s.AverageScore)
                                               .Select(s => (s.LastName, s.AverageScore));
            PrintLINQ(students_skipTake);


            // 8. Min & Max
            Console.WriteLine("10) Students with their lowest score: ");
            var lowestScore = from s in allStudents
                              orderby s.Scores.Values.Min()
                              select (s.LastName, s.Scores.Values.Min());
            PrintLINQ(lowestScore);

            Console.WriteLine("11) Students with their highest score: ");
            var highestScore = from s in allStudents
                              select (s.LastName, s.Scores.Values.Max());
            PrintLINQ(highestScore);


            // Group by
            


            /*
            // "З'єднання"
            Console.WriteLine("Декартовий добуток"); 
            Console.WriteLine("Inner Join з використанням Where");
            Console.WriteLine("Inner Join з використанням Join");
            Console.WriteLine("Inner Join (зберігаємо об'єкт)");
            //Обираємо всі елементи з d1 та якщо є пов'язані з d2 (outer join) 
            //В temp поміщуємо всю групу, далі її елементи перебираємо окремо 
            Console.WriteLine("Group Join");
            Console.WriteLine("Cross Join и Group Join");
            Console.WriteLine("Outer Join");
            Console.WriteLine("Використання Join для складених ключів");
            //Дії над множинами
            Console.WriteLine("Distinct - для значень");
            Console.WriteLine("Distinct - для об'єктів");
            Console.WriteLine("Union - об'єднання з виключенням дублікатів");
            Console.WriteLine("Union - об'єднання для объектів");
            Console.WriteLine("Union - об'єднання для объектів з виключенням дублікатів 1");
            Console.WriteLine("Union - об'єднання для объектів з виключенням дублікатів 2");
            Console.WriteLine("Concat - об'єднання без виключення дублікатів");
            Console.WriteLine("SequenceEqual - перевірка співпадіння та порядку слідування");
            Console.WriteLine("Intersect - перетин множин");
            Console.WriteLine("Intersect - перетин множин для об'єктів");
            Console.WriteLine("Except - різниця множин");
            Console.WriteLine("Except - різниця множин для об'єктів");
            // "Функції агрегування"
            Console.WriteLine("Count - кількість елементів");
            Console.WriteLine("Count - кількість з умовою");
            Console.WriteLine("Aggregate - агрегування значень");
            Console.WriteLine("Групування");
            Console.WriteLine("Групування з функціями агрегування");
            Console.WriteLine("Групування - Any");
            Console.WriteLine("Групування - All");
            // "Перетворення даних"
            Console.WriteLine("Результат перетворюється в масив");
            Console.WriteLine("Результат перетворюється в Dictionary");
            Console.WriteLine("Результат перетворюється в Lookup");
            // "Отримання елемента"
            Console.WriteLine("Перший елемент з вибірки");
            Console.WriteLine("Перший елемент з вибірки або значення за замовчанням");
            Console.WriteLine("Елемент в заданій позиції");
            // "Генерація послідовностей
            Console.WriteLine("Range");
            Console.WriteLine("Repeat"
            */


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
