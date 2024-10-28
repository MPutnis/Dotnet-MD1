using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public DataHolder dataHolder = new DataHolder();
        
        // Print all data to console
        public string Print()
        {
            string result = "";
            result += $"Teachers:\n{dataHolder.ListToString<Teacher>(dataHolder.Teachers)}\n";
            result += $"Students:\n{dataHolder.ListToString<Student>(dataHolder.Students)}\n";
            result += $"Courses:\n{dataHolder.ListToString<Course>(dataHolder.Courses)}\n";
            result += $"Assignements:\n{dataHolder.ListToString<Assignment>(dataHolder.Assignments)}\n";
            result += $"Submissions:\n{dataHolder.ListToString<Submission>(dataHolder.Submissions)}\n";
            return result;
        }
        // Save data to file
        public bool Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataHolder));
            using (TextWriter writer = new StreamWriter("C:\\Temp\\data.txt"))
            {
                serializer.Serialize(writer, dataHolder);
            }
            Debug.WriteLine("Data has been saved");
            return true;
        }
        // Load data from file
        public bool Load()
        {
            if (File.Exists("C:\\Temp\\data.txt"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DataHolder));
                using (TextReader reader = new StreamReader("C:\\Temp\\data.txt"))
                {
                    var f = (DataHolder)serializer.Deserialize(reader);
                    if (f != null && f is DataHolder) { dataHolder = f; }
                }
                Debug.WriteLine("Data has been loaded");
                return true;
            }
            Debug.WriteLine("File not found");
            return false;
        }

        // Create test data for all classes
        public bool CreateTestData()
        {

            // Test data for Teacher
            dataHolder.AddTeacher(new Teacher("Albert", "Loop", Gender.Male, new DateOnly(2021, 10, 10)));
            dataHolder.AddTeacher(new Teacher("Linda", "Palinda", Gender.Female, new DateOnly(2015, 08, 08)));
            dataHolder.AddTeacher(new Teacher("John", "Doe", Gender.Male, new DateOnly(2019, 05, 06)));
            dataHolder.AddTeacher(new Teacher("Jane", "Done", Gender.Other, new DateOnly(2023, 03, 04)));
            dataHolder.AddTeacher(new Teacher("Hanter", "Banter", Gender.Male, new DateOnly(2020, 02, 01)));

            // Test data for Student
            dataHolder.AddStudent(new Student("Jenny", "Doe", Gender.Female, "jd241001"));
            dataHolder.AddStudent(new Student("John", "Doe", Gender.Male, "jd220510"));
            dataHolder.AddStudent(new Student("Anna", "Wayhat", Gender.Female, "aw230909"));
            dataHolder.AddStudent(new Student("Peter", "Walker", Gender.Male, "pw200101"));
            dataHolder.AddStudent(new Student("Sasha", "Wool", Gender.Other, "sw210303"));
            Debug.WriteLine($"Test data for {dataHolder.Students.Count} Students has been created");
            // Test data for Course
            var course1 = new Course();
            course1.Name = "Math";
            course1.Teacher = dataHolder.Teachers[0];
            dataHolder.AddCourse(course1);

            var course2 = new Course();
            course2.Name = "Physics";
            course2.Teacher = dataHolder.Teachers[1];
            dataHolder.AddCourse(course2);

            var course3 = new Course();
            course3.Name = "Chemistry";
            course3.Teacher = dataHolder.Teachers[2];
            dataHolder.AddCourse(course3);

            var course4 = new Course();
            course4.Name = "Biology";
            course4.Teacher = dataHolder.Teachers[3];
            dataHolder.AddCourse(course4);

            var course5 = new Course();
            course5.Name = "History";
            course5.Teacher = dataHolder.Teachers[4];
            dataHolder.AddCourse(course5);

            // Test data for Assignement
            var assign1 = new Assignment();
            assign1.Name = "First Math homework";
            assign1.Description = "First Math homework";
            assign1.Deadline = new DateTime(2024, 10, 15, 23, 59, 59);
            assign1.Course = course1;
            dataHolder.AddAssignment(assign1);

            var assign2 = new Assignment();
            assign2.Name = "First Physics homework";
            assign2.Description = "First Physics homework";
            assign2.Deadline = new DateTime(2024, 10, 16, 23, 59, 59);
            assign2.Course = course2;
            dataHolder.AddAssignment(assign2);

            var assign3 = new Assignment();
            assign3.Name = "First Chemistry homework";
            assign3.Description = "First Chemistry homework";
            assign3.Deadline = new DateTime(2024, 10, 17, 23, 59, 59);
            assign3.Course = course3;
            dataHolder.AddAssignment(assign3);

            var assign4 = new Assignment();
            assign4.Name = "First Biology homework";
            assign4.Description = "First Biology homework";
            assign4.Deadline = new DateTime(2024, 10, 18, 23, 59, 59);
            assign4.Course = course4;
            dataHolder.AddAssignment(assign4);

            var assign5 = new Assignment();
            assign5.Name = "First History homework";
            assign5.Description = "First History homework";
            assign5.Deadline = new DateTime(2024, 10, 19, 23, 59, 59);
            assign5.Course = course5;
            dataHolder.AddAssignment(assign5);

            // Test data for Submission
            var sub1 = new Submission();
            sub1.Assignment = assign1;
            sub1.Student = dataHolder.Students[0];
            sub1.Score = 8;
            dataHolder.AddSubmission(sub1);

            var sub2 = new Submission();
            sub2.Assignment = assign2;
            sub2.Student = dataHolder.Students[1];
            sub2.Score = 9;
            dataHolder.AddSubmission(sub2);

            var sub3 = new Submission();
            sub3.Assignment = assign3;
            sub3.Student = dataHolder.Students[2];
            sub3.Score = 6;
            dataHolder.AddSubmission(sub3);

            var sub4 = new Submission();
            sub4.Assignment = assign4;
            sub4.Student = dataHolder.Students[3];
            sub4.Score = 7;
            dataHolder.AddSubmission(sub4);

            var sub5 = new Submission();
            sub5.Assignment = assign5;
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
            dataHolder.Assignments.Clear();
            dataHolder.Submissions.Clear();
            Debug.WriteLine("Data has been reset");
            return true;
        }
    }
}
