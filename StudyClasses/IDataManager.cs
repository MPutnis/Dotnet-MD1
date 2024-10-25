using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace StudyClasses
{
    /*
        8. Izveidot Interfeisu “IDataManager”    
            Interfeisā nav jāraksta implementācija, norādes, 
            ko metodes dara jāizmanto implementējot interfeisu.
     */
    public interface IDataManager
    {
        //Metodi “print”, kas atgriež kā tekstu informāciju
        //par visiem kolekcijās(7. Punkts) esošajiem elementiem.
        string Print();

        //Metodi “save”, kas visu Kolekciju datus saglabātu failā.
        bool Save();
        
        //Metodi “load”, kas visu Kolekciju datus nolasītu no faila.
        bool Load();

        //Metodi “createTestData”, kas radītu testa datus.
        bool CreateTestData();
        
        //Metodi "reset", kas izdzēš visus datus.
        bool Reset();
    }
}
