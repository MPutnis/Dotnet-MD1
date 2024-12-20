﻿/*
 1. Izveidot abstraktu klasi „Person” ar:

    Privātiem atribūtiem un publiskām īpašībām „Name” un „Surname”.

    Uzstādot īpašības „Name” vērtību, jāpārbauda vai jaunā 
    vērtība ir tukša un, ja ir, tad jāatstāj iepriekšējā vērtība.
    
    Tikai lasāmu īpašību „FullName”, kas atgriež vārda un uzvārda 
    konkatenāciju ar vienu atstarpi pa vidu.
    
    Īpašību Gender, kuras vērtība ir Jūsu definēts pārskaitāmais tips.
    (Pārskaitāmā tipam ir vismaz 2 vērtības: Man, Woman).
    
    Pārdefinēt metodi ToString(), lai tā atgriež visu īpašību 
    vērtības kā tekstu.
 */

using System.Diagnostics.CodeAnalysis;

namespace StudyClasses
{
    public abstract class Person
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                // if Name isn't null, change _name
                if (value != null)
                {
                    _name = value;
                }
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value != null)
                {
                    _surname = value;
                }
            }
        }
        // Constructors with and without parameters
        /*
             Source for constructor inheritance:
            https://www.geeksforgeeks.org/c-sharp-inheritance-in-constructors/
         */
        public Person( string name, string surname, Gender gender)
        {
            Name = name;
            Surname = surname;
            PersonGender = gender;
        }

        public Person()
        {
            Name = "Jane";
            Surname = "Doe";
            PersonGender = Gender.Female;
        }
        public string FullName
        {
            get { return $"{_name} {_surname}"; }
        }
        
        public Gender PersonGender
        {
            get;
            set;
        }

        public override string? ToString()
        {
            return "Full name: " + FullName.ToString() + " Gender: " + PersonGender.ToString();
        }
    }
}
