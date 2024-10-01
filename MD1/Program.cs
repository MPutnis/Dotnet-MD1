// See https://aka.ms/new-console-template for more information
using StudyClasses; // asked copilot how to add class library to project


Console.WriteLine("Teacher test!");
var teach1 = new Teacher();
teach1.Name = "Albert";
teach1.Surname = "Loop";
teach1.PersonGender = Gender.Male;
teach1.ContractDate = new DateTime(2021, 10, 10);
Console.WriteLine(teach1.ToString());

Console.WriteLine("\nStudent test!");
var stud1 = new Student("Jane", "Doe", Gender.Female, "jd241001");
var stud2 = new Student();
Console.WriteLine(stud1.ToString());
Console.WriteLine(stud2.ToString());

Console.WriteLine("\nCourse test!");
var course1 = new Course();
course1.Name = "Math";
course1.Teacher = teach1;
Console.WriteLine(course1.ToString());

Console.WriteLine("\nAssignement test!");
var assign1 = new Assignement();
assign1.Description = "First Math homework";
assign1.Deadline = new DateTime(2021, 10, 15);
assign1.Course = course1;
Console.WriteLine(assign1.ToString());

Console.WriteLine("\nSubmission test!");
var sub1 = new Submission();
sub1.Assignement = assign1;
sub1.Student = stud1;
sub1.SubmissionTime = new DateTime(2021, 10, 14);
sub1.Score = 10;
Console.WriteLine(sub1.ToString());
