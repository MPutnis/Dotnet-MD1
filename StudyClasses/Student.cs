using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StudyClasses
{
    // 3. Izveidot klasei „Person” apakšklasi „Student” ar:
    public class Student : Person
    {
        [Key]
        public int StudentId { get; set; }
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
        public Student(string name, string surname, Gender gender, string studentIdNumber): 
            base( name, surname, gender)
        {
            StudentIdNumber = studentIdNumber;
        }

        public Student(): base() 
        {
            StudentIdNumber = "jd12345";
        }
        public string NameID
        {
            get { return $"{FullName}, {StudentIdNumber}"; }
        }
        // Pārdefinēt metodi ToString(), lai tā atgriež visu (arī mantoto) īpašību vērtības kā tekstu.
        public override string? ToString()
        {
            return $"{FullName}, {StudentIdNumber}, {PersonGender}";
        }
    }
}
