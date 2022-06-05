using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibStuVak
{
    public static class VakData
    {

        public static DataTable DataTableVak { get; set; }
        public static DataSet DataSetVak = new DataSet();
        public static void LoadCSV(string padNaarCsv)
        {
            if(padNaarCsv != null)
            {
                DataTableVak = new DataTable("DataTableStudentenVak");

                DataTableVak.Columns.Add("Voornaam", typeof(string));
                DataTableVak.Columns.Add("Achternaam", typeof(string));
                DataTableVak.Columns.Add("Vakcode", typeof(string));
                DataTableVak.Columns.Add("VakVoluit", typeof(string));

                




                foreach(DataRow row in DataTableVak.Rows)
                {
                    


                    GetVakVoluit(); // return VakVoluit 
                }


                
                
                DataSetVak.Tables.Add(DataTableVak);




            }

        }


        public static void GetVakVoluit()
        {

        }

    }
}
