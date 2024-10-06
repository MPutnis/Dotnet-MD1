using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyClasses
{
    //4. Izveidot klasi "Course" ar:
    public class Course
    {
        //Īpašību "Name", kas ir teksts.
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        //Īpasību "Teacher" ar tipu Teacher.
        private Teacher _teacher;

        public Teacher Teacher
        {
            get { return _teacher; }
            set { _teacher = value; }
        }

        //Pārdefinēt metodi ToString(), lai tā atgriež visu(arī mantoto) īpašību vērtības kā tekstu.
        public override string? ToString()
        {
            return "Course: " + Name.ToString() + " Teacher: " + Teacher.FullName;
        }

        

    }
}
