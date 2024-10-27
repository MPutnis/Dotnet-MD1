using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudyClasses
{
    //5. Izveidot klasi "Assignment" ar:   
    public class Assignment
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //īpašību "Deadline", datu tips Date.
        private DateTime _deadline;

        public DateTime Deadline
        {
            get { return _deadline; }
            set { _deadline = value; }
        }

        //īpašība "Course", datu tips Course.
        private Course _course;

        public Course Course
        {
            get { return _course; }
            set { _course = value; }
        }

        //īpašība "Description", kas ir teksts.
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        //pārdefinēt metodi ToString(), lai tā atgriež visu(arī mantoto) īpašību vērtības kā tekstu.
        public override string? ToString()
        {
            return $"Assignment: {Name}\n" + Description.ToString() + "\nDeadline: " + Deadline.ToString() + "\n" + Course.ToString();
        }
    }
}
