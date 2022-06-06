using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibStuVak
{
    public static class VakData
    {

        public static DataTable DataTableVak { get; set; }
       // public static DataSet DataSetVak = new DataSet();



        private static List<string> uniekeValcodes = new List<string>();

        public static Dictionary<string, string> DictVakken = new Dictionary<string, string>
                    {
                      {"PRO", "Programmeren" },
                    {"SNE", "Systemen en netwerken" },
                    {"DVG", "Digitale Vormgeving" },
                    {"IOT", "Internet of things" }
                    };



        public static DataView GetDataView()
        {
            maakDataTable();
            return DataTableVak.DefaultView;
        }




        public static void maakDataTable()
        {
            DataTableVak = new DataTable();

            DataColumn vakcode = DataTableVak.Columns.Add("vakcode", typeof(string));
            DataColumn vakVoluit = DataTableVak.Columns.Add("vakVoluit", typeof (string));
            LeesDataUit();

        }
        public static void VoegRijToe(string code , string vol)    //// hier worden de gegevens van de student als een DataRow toegevoegd
        {
            DataRow dr = DataTableVak.NewRow(); 
            dr["vakcode"] = code;
            dr["vakVoluit"] = vol;

            DataTableVak.Rows.Add(dr);   //// rij word toegevoed aan de DtStudent  = DataTable

        }



        public static void LeesDataUit()
        {
          
            DataRow[] res = StudentenData.DataTableStudentenVak.Select();

            foreach (DataRow kolom in res)
            {
                if (!uniekeValcodes.Contains(kolom[2].ToString()))
                {
                    uniekeValcodes.Add(kolom[2].ToString());
                }

            }

            foreach (string code in uniekeValcodes)
            {
                //"SNE" "PRO" "IOT" "DVG"
               
                string a = DictVakken[code];
                VoegRijToe(code, a);
            }

           

        }

    }
}
