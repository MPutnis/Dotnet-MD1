using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudyClasses
{
    //6. Izveidot klasi "Submission" ar:
    public class Submission
    {
        //īpašību "Assignement", datu tips Assignement.
        private Assignement _assignement;

        public Assignement Assignement
        {
            get { return _assignement; }
            set { _assignement = value; }
        }

        //īpašību "Student", datu tips Student.
        private Student _student;

        public Student Student
        {
            get { return _student; }
            set { _student = value; }
        }

        //īpašību "SubmissionTime", kas ir datums un laiks.
        private DateTime _submissionTime;

        public DateTime SubmissionTime
        {
            get { return _submissionTime; }
            set { _submissionTime = value; }
        }

        //īpašību "Score", kas ir vesels skaitlis.
        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public override string? ToString()
        {
            return Assignement.ToString() + " By: " + Student.ToString() + "on: " + SubmissionTime.ToString() + "\nScore: " + Score.ToString();
        }
    }
}
