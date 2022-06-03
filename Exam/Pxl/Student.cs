using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxl
{      // dit is Entitie en Stundendata in een  ?  
    public class Student : Initialiseren, IStudentVak
    {
        public Student()
        { }
        public Student(string[] studGeg)   //// na het lezen van iedere rij worden de verzamelde gegevens meegegeven als een array en hier nog maals toegewezen aan een string
        {
            Initialiseer();
            if (studGeg.Length > 2) // Meer dan 2 elementen in array aanwezig.  //
            {                          ///// wrm? wat als het 4 of maar 2 elementen zijn ??  
                Naam = studGeg[0];
                Voornaam = studGeg[1];
                VakCode = studGeg[2];
                VoegRijToe();    ///// naar functie "voeg rij toe"  Student.cs  lijn +- 50 
            }
        }
        public DataTable DtStudent { get; set; }
        public override void Initialiseer()
        {
            string tableName = "student";   ///// hier word de tabel naam aangemaakt  
                                            //// wrm dit bij iedere rij contoleren ??
            if (Databank.DsStudent.Tables.Contains(tableName))
            {
                DtStudent = Databank.DsStudent.Tables[tableName];  
            }
            else
            {
                //Create Tabel    //// gaat hier enkel de eerst keer over als er nog geen TABEL naam is 
                                                                
                DtStudent = new DataTable(tableName);
                DtStudent.Columns.Add("Voornaam", typeof(string));
                DtStudent.Columns.Add("Naam", typeof(string));
                DtStudent.Columns.Add("VakCode", typeof(string));
                // Tabel toevoegen aan dataset
                Databank.DsStudent.Tables.Add(DtStudent);
            }

        }
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        public string VakCode { get; set; }
        public string VakVolledig => Databank.DictVakken[VakCode];
        
        public void VoegRijToe()    //// hier worden de gegevens van de student als een DataRow toegevoegd
        {
            DataRow dr = DtStudent.NewRow();  ////  hier gaan we naar een nieuwe rij in de DtStudent =  DataTable 
            dr["Voornaam"] = Voornaam;
            dr["Naam"] = Naam;
            dr["VakCode"] = VakCode;
            DtStudent.Rows.Add(dr);   //// rij word toegevoed aan de DtStudent  = DataTable
        }
        public override string ToString()   ////  hier komt de app in na het itereren van het hele csv bestand 
                                            //// het itereert vervolgens voor alle waarden van het csv bestand hier door 
        {                                    //// hierna is de ophet de wpf

                                             //// bij het opslaan van de gegevens in een csv bestand 
                                             //// bij data bestand 
                                             /// bij het overgaan naar 2de xaml 
            return $"{Voornaam} {Naam.ToUpper()} - {VakCode.ToUpper()} ({VakVolledig.ToLower()})";
        }

       
    }
}
