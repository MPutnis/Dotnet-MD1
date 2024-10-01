using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace StudyClasses
{
    // 3. Izveidot klasei „Person” apakšklasi „Student” ar:
    public class Student : Person
    {
        // Īpašība „StudentIdNumder”.
        private string _studentIdNumber;

        public string StudentIdNumber
        {
            get { return _studentIdNumber; }
            set { _studentIdNumber = value; }
        }

        /*  
            Klasei izveidot 2 konstruktorus, no kuriem viens kā parametru
            saņem visu īpašību vērtības, kas arī tiek uzstādītas jaunajam objektam.
        */
        public Student(string name, string surname, Gender gender, string studentIdNumber)
        {
            Name = name;
            Surname = surname;
            PersonGender = gender;
            StudentIdNumber = studentIdNumber;
        }

        public Student()
        {
            Name = "John";
            Surname = "Doe";
            PersonGender = Gender.Male;
            StudentIdNumber = "jd12345";
        }

        // Pārdefinēt metodi ToString(), lai tā atgriež visu (arī mantoto) īpašību vērtības kā tekstu.
        public override string? ToString()
        {
            return base.ToString() + " Student ID number: " + _studentIdNumber.ToString();
        }
    }
}
