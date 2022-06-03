using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxl
{
    public class Student : Initialiseren, IStudentVak
    {
        public Student()
        { }
        public Student(string[] studGeg)
        {
            Initialiseer();
            if (studGeg.Length > 2) // Meer dan 2 elementen in array aanwezig.
            {
                Naam = studGeg[0];
                Voornaam = studGeg[1];
                VakCode = studGeg[2];
                VoegRijToe();
            }
        }
        public DataTable DtStudent { get; set; }
        public override void Initialiseer()
        {
            string tableName = "student";
            if (Databank.DsStudent.Tables.Contains(tableName))
            {
                DtStudent = Databank.DsStudent.Tables[tableName];
            }
            else
            {
                //Create Tabel
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
        public void VoegRijToe()
        {
            DataRow dr = DtStudent.NewRow();
            dr["Voornaam"] = Voornaam;
            dr["Naam"] = Naam;
            dr["VakCode"] = VakCode;
            DtStudent.Rows.Add(dr);
        }
        public override string ToString()
        {
            return $"{Voornaam} {Naam.ToUpper()} - {VakCode.ToUpper()} ({VakVolledig.ToLower()})";
        }

       
    }
}
