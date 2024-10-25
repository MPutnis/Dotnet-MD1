// See https://aka.ms/new-console-template for more information
using StudyClasses; // asked copilot how to add class library to project


// DataManager test
string path = "..\\data.txt";
IDataManager dm = new StudyXMLDataManager();
dm.CreateTestData();
Console.WriteLine(dm.Print());
dm.Save();
dm.Reset();
Console.WriteLine(dm.Print());
dm.Load();
Console.WriteLine(dm.Print());
Console.ReadLine();






