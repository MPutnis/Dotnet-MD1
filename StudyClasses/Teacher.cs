using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




//2.Izveidot klasei „Person” apakšklasi „Teacher” ar:
namespace StudyClasses
{
    public class Teacher : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //    Īpašība "ContractDate", kas ir datums.
        private DateOnly _contractDate;

        [XmlIgnore]
        // XML serialization does not support DateOnly, so Copilot showed how to serialize and deserialize it
        public DateOnly ContractDate
        {
            get { return _contractDate; }
            set { _contractDate = value; }
        }
        // Custom property for serializing and deserializing the ContractDate
        [XmlElement("ContractDate")]
        public string ContractDateSerialized
        {
            get { return ContractDate.ToString("yyyy-MM-dd"); }
            set { ContractDate = DateOnly.Parse(value); }
        }

        // Teacher constructors, full attributes and empty with default values
        public Teacher( string name, string surname, Gender gender,DateOnly contractDate ):
            base( name, surname, gender )
        {
            ContractDate = contractDate;
        }

        public Teacher () : base()
        {
            ContractDate = new DateOnly(1900, 01, 01);
        }
        //    Pārdefinēt metodi ToString(), lai tā atgriež visu (arī mantoto) īpašību vērtības kā tekstu.
        public override string? ToString()
        {
            return base.ToString() + " Contract date: " + _contractDate.ToString();
        }       

    }
}
