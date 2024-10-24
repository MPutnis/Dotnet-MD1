using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyClasses
{
    public class DataLists
    {
        private List<Student> _students;

        public List<Student> Students
        { 
            get { return _students; }
            set { _students = value; }
        }

        private List<Teacher> _teachers;

        public List<Teacher> Teachers
        {
            get { return _teachers; }
            set { _teachers = value; }
        }

        private List<Course> _courses;

        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }

        private List<Assignement> _assignements;

        public List<Assignement> Assignements
        {
            get { return _assignements; }
            set { _assignements = value; }
        }

        private List<Submission> _submissions;

        public List<Submission> Submissions
        {
            get { return _submissions; }
            set { _submissions = value; }
        }



    }
}
