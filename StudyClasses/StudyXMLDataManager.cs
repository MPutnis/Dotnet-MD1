using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
namespace StudyClasses
{
    //9. Izveidot klasi vai klases, kas implementē interfeisu IDataManager.
    //Izmantojot šo klasi(vai klases) jāvar radīt testa datus visām 2.-6. punktos minētajām klasēm.
    //Jāvar šos testa datus atgriezt kā cilvēkam lasāmu tekstu, saglabāt failā un nolasīt no faila.
    public class StudyXMLDataManager: IDataManager
    {
        // Holds lists of all classes
        DataHolder dataHolder = new DataHolder();
        
        // Print all data to console
        public string Print()
        {
            string result = "";
            result += $"Teachers:\n{dataHolder.ListToString<Teacher>(dataHolder.Teachers)}\n";
            result += $"Students:\n{dataHolder.ListToString<Student>(dataHolder.Students)}\n";
            result += $"Courses:\n{dataHolder.ListToString<Course>(dataHolder.Courses)}\n";
            result += $"Assignements:\n{dataHolder.ListToString<Assignement>(dataHolder.Assignements)}\n";
            result += $"Submissions:\n{dataHolder.ListToString<Submission>(dataHolder.Submissions)}\n";
            return result;
        }
        // Save data to file
        public bool Save(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataHolder));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, dataHolder);
            }
            Console.WriteLine("Data has been saved");
            return true;
        }
        // Load data from file
        public bool Load(string path)
        {
            if (File.Exists(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DataHolder));
                using (TextReader reader = new StreamReader(path))
                {
                    var f = (DataHolder)serializer.Deserialize(reader);
                    if (f != null && f is DataHolder) { dataHolder = f; }
                }
                Console.WriteLine("Data has been loaded");
                return true;
            }
            Console.WriteLine("File not found");
            return false;
        }

        // Create test data for all classes
        public bool CreateTestData()
        {
            
            // Test data for Teacher
            var teach1 = new Teacher();
            teach1.Name = "Albert";
            teach1.Surname = "Loop";
            teach1.PersonGender = Gender.Male;
            teach1.ContractDate = new DateOnly(2021, 10, 10);
            dataHolder.AddTeacher(teach1);

            var teach2 = new Teacher();
            teach2.Name = "Linda";
            teach2.Surname = "Palinda";
            teach2.PersonGender = Gender.Female;
            teach2.ContractDate = new DateOnly(2015, 08, 08);
            dataHolder.AddTeacher(teach2);

            var teach3 = new Teacher();
            teach3.Name = "John";
            teach3.Surname = "Doe";
            teach3.PersonGender = Gender.Male;
            teach3.ContractDate = new DateOnly(2019, 05, 06);
            dataHolder.AddTeacher(teach3);

            var teach4 = new Teacher();
            teach4.Name = "Jane";
            teach4.Surname = "Done";
            teach4.PersonGender = Gender.Other;
            teach4.ContractDate = new DateOnly(2023, 03, 04);
            dataHolder.AddTeacher(teach4);

            var teach5 = new Teacher();
            teach5.Name = "Hanter";
            teach5.Surname = "Banter";
            teach5.PersonGender = Gender.Male;
            teach5.ContractDate = new DateOnly(2020, 02, 01);
            dataHolder.AddTeacher(teach5);

            // Test data for Student
            dataHolder.AddStudent(new Student("Jenny", "Doe", Gender.Female, "jd241001"));
            dataHolder.AddStudent(new Student("John", "Doe", Gender.Male, "jd220510"));
            dataHolder.AddStudent(new Student("Anna", "Wayhat", Gender.Female, "aw230909"));
            dataHolder.AddStudent(new Student("Peter", "Walker", Gender.Male, "pw200101"));
            dataHolder.AddStudent(new Student("Sasha", "Wool", Gender.Other, "sw210303"));

            // Test data for Course
            var course1 = new Course();
            course1.Name = "Math";
            course1.Teacher = teach1;
            dataHolder.AddCourse(course1);

            var course2 = new Course();
            course2.Name = "Physics";
            course2.Teacher = teach2;
            dataHolder.AddCourse(course2);

            var course3 = new Course();
            course3.Name = "Chemistry";
            course3.Teacher = teach3;
            dataHolder.AddCourse(course3);

            var course4 = new Course();
            course4.Name = "Biology";
            course4.Teacher = teach4;
            dataHolder.AddCourse(course4);

            var course5 = new Course();
            course5.Name = "History";
            course5.Teacher = teach5;
            dataHolder.AddCourse(course5);
            // Test data for Assignement
            var assign1 = new Assignement();
            assign1.Description = "First Math homework";
            assign1.Deadline = new DateTime(2024, 10, 15, 23, 59, 59);
            assign1.Course = course1;
            dataHolder.AddAssignement(assign1);

            var assign2 = new Assignement();
            assign2.Description = "First Physics homework";
            assign2.Deadline = new DateTime(2024, 10, 16, 23, 59, 59);
            assign2.Course = course2;
            dataHolder.AddAssignement(assign2);

            var assign3 = new Assignement();
            assign3.Description = "First Chemistry homework";
            assign3.Deadline = new DateTime(2024, 10, 17, 23, 59, 59);
            assign3.Course = course3;
            dataHolder.AddAssignement(assign3);

            var assign4 = new Assignement();
            assign4.Description = "First Biology homework";
            assign4.Deadline = new DateTime(2024, 10, 18, 23, 59, 59);
            assign4.Course = course4;
            dataHolder.AddAssignement(assign4);

            var assign5 = new Assignement();
            assign5.Description = "First History homework";
            assign5.Deadline = new DateTime(2024, 10, 19, 23, 59, 59);
            assign5.Course = course5;
            dataHolder.AddAssignement(assign5);

            // Test data for Submission
            var sub1 = new Submission();
            sub1.Assignement = assign1;
            sub1.Student = dataHolder.Students[0];
            sub1.Score = 8;
            dataHolder.AddSubmission(sub1);

            var sub2 = new Submission();
            sub2.Assignement = assign2;
            sub2.Student = dataHolder.Students[1];
            sub2.Score = 9;
            dataHolder.AddSubmission(sub2);

            var sub3 = new Submission();
            sub3.Assignement = assign3;
            sub3.Student = dataHolder.Students[2];
            sub3.Score = 6;
            dataHolder.AddSubmission(sub3);

            var sub4 = new Submission();
            sub4.Assignement = assign4;
            sub4.Student = dataHolder.Students[3];
            sub4.Score = 7;
            dataHolder.AddSubmission(sub4);

            var sub5 = new Submission();
            sub5.Assignement = assign5;
            sub5.Student = dataHolder.Students[4];
            sub5.Score = 10;
            dataHolder.AddSubmission(sub5);

            return true;
        }

        // Clear all data
        public bool Reset()
        {
            // Clear all lists
            dataHolder.Teachers.Clear();
            dataHolder.Students.Clear();
            dataHolder.Courses.Clear();
            dataHolder.Assignements.Clear();
            dataHolder.Submissions.Clear();
            Console.WriteLine("Data has been reset");
            return true;
        }
    }
}
