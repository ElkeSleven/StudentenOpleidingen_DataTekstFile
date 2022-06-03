using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pxl
{
   
    // Entetie Vak
        public class Vak : Initialiseren, IStudentVak
        {
            public Vak()
            {
                Initialiseer();
            }
            public Vak(string code, string omschr)
            {
                Initialiseer();
                VakCode = code;
                Omschrijving = omschr;
                VoegRijToe();
            }
            public override void Initialiseer()
            {
                string tableName = "Vak";
                if (Databank.DsStudent.Tables.Contains(tableName))
                {
                    DtVak = Databank.DsStudent.Tables[tableName];
                }
                else
                {
                    // Create tabel
                    DtVak = new DataTable(tableName);
                    DtVak.Columns.Add("Code", typeof(string));
                    DtVak.Columns.Add("Omschrijving", typeof(string));
                    // Tabel toevoegen aan Dataset
                    Databank.DsStudent.Tables.Add(DtVak);
                }
            }
        public string VakCode { get; set; }
        public string Omschrijving { get; set; }
        public DataTable DtVak { get; set; }
        public void VoegRijToe()
        {
            if (!Databank.DictVakken.ContainsKey(VakCode))
            {
                Databank.DictVakken.Add(VakCode, Omschrijving);
            }
            DataRow dr = DtVak.NewRow();
            dr["Code"] = VakCode;
            dr["Omschrijving"] = Omschrijving;
            DtVak.Rows.Add(dr);
        }
    }
}

