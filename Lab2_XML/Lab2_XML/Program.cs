/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_XML
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


            // XML File
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create("students.xml", settings))
            {
                writer.WriteStartElement("students");
                foreach (User st in students)
                {
                    writer.WriteStartElement("student");
                    writer.WriteElementString("id", st.Id.ToString());
                    writer.WriteElementString("fName", st.FirstName);
                    writer.WriteElementString("lName", st.LastName);
                    writer.WriteElementString("patronymic", st.Patronymic);
                    writer.WriteElementString("group", st.Group);
                    writer.WriteElementString("DOB", st.BirthDate.ToString());
                    writer.WriteElementString("supId", st.SupervisorID.ToString());
                    writer.WriteElementString("score", st.AverageScore().ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("subjects");
                    foreach (var sub in st.Scores)
                    {
                        writer.WriteStartElement("subject");
                        writer.WriteElementString("name", sub.key.Name);
                        writer.WriteElementString("score", sub.value.ToString());
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();
            }

        }
    }
}
*/


// example
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Lab2Example
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            
            // Створюємо файл
            IList<User> users = new List<User> 
            {
                new User ("Bill Gates", "Microsoft", 48),
                new User ("Larry Page", "Google", 42)
            };

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create("users.xml", settings))
            {
                writer.WriteStartElement("users");
                foreach (User user in users)
                {
                    writer.WriteStartElement("user");
                    writer.WriteElementString("name", user.Name);
                    writer.WriteElementString("company", user.Company);
                    writer.WriteElementString("age", user.Age.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            

            // Виводимо файл
            XmlDocument doc = new XmlDocument();
            doc.Load("users.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node["name"].InnerText;
                string company = node["company"].InnerText;
                int age = Int32.Parse(node["age"].InnerText);
                Console.WriteLine(string.Format("Користувач={0} працює в {1}, вік {2}", name, company, age));
            }
            Console.WriteLine();
            
            
            // XDocument, XElement
            //
            XDocument xmlDoc = XDocument.Load("users.xml");
            foreach (XElement userElement in xmlDoc.Element("users").Elements("user"))
            {
                XElement nameAttribute = userElement.Element("name");
                XElement companyElement = userElement.Element("company");
                XElement ageElement = userElement.Element("age");
                if (nameAttribute != null && companyElement != null && ageElement != null)
                {
                    Console.WriteLine("Користувач: {0}", nameAttribute.Value);
                    Console.WriteLine("Компанія: {0}", companyElement.Value);
                    Console.WriteLine("Вік: {0}", ageElement.Value);
                }
                Console.WriteLine();
            }
            
            //
            Console.WriteLine("Перелік коммпаній, в котрих працюють користувачі, відсортовані за зростанням");
            var querySorted = xmlDoc.Descendants("user").Select(p => p.Element("company").Value).OrderBy(p => p.Trim());
            foreach (var s in querySorted)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
            
            //
            Console.WriteLine("Фільтр за віком");
            IEnumerable<XElement> queryAge = from b in xmlDoc.Root.Elements("user")
                                             where (int)b.Element("age") == 42
                                             select b;
            Console.WriteLine(queryAge.FirstOrDefault().Element("name").Value);
            Console.WriteLine();
 
            //
            Console.WriteLine("Працюють в Google");
            var items = from xe in xmlDoc.Element("users").Elements("user")
                        where xe.Element("company").Value == "Google"
                        select new User
                        {
                            Name = xe.Element("name").Value,
                            Company = xe.Element("company").Value,
                            Age = Int32.Parse(xe.Element("age").Value)
                        };
            foreach (var item in items)
            {
                Console.WriteLine("{0} - {1} - {2}", item.Name, item.Company, item.Age);
            }
            Console.WriteLine();
            
            Console.ReadKey();
        }
    }
    class User
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
        public User()
        { 
        }
        public User(string name, string company, int age)
        {
            Name = name;
            Company = company;
            Age = age;
        }
    }
}