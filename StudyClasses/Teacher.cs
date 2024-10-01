using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




//2.Izveidot klasei „Person” apakšklasi „Teacher” ar:
namespace StudyClasses
{
    public class Teacher : Person
    {
        //    Īpašība "ContractDate", kas ir datums.
        private DateTime _contractDate;

        public DateTime ContractDate
        {
            get { return _contractDate; }
            set { _contractDate = value; }
        }

        //    Pārdefinēt metodi ToString(), lai tā atgriež visu (arī mantoto) īpašību vērtības kā tekstu.
        public override string? ToString()
        {
            return base.ToString() + " Contract date: " + _contractDate.ToString();
        }       

    }
}
