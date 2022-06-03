using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibStuVak
{
    public class Student
    {
        public Student(string voornaam, string achternaam, string vakcode)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Vakcode = vakcode;
        }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }  
        public string Vakcode { get; set; }
        //public string VakVolledig;// => //Databank.DictVakken[VakCode];
        // public DataTable DtStudent { get; set; }
        public override string ToString() 
        {   
            return $"{Voornaam.ToUpper()} - {Achternaam.ToUpper()} ({Vakcode.ToLower()})";
        }

    }

}
