using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibStuVak
{
    public static class StudentenData
    {
        // read csv file LoadCSV
        // set vakcode to vakVoluit 
        // Student = new Student(.. .. .. .)
        public static string DataFolder = "";
        public static DataTable DataTableStudentenVak { get; set; }
        public static DataSet DsStudent = new DataSet("StudentenDB");
      
        public static void LoadCSV(string padNaarCsv)
        {
            DataTableStudentenVak = new DataTable("DataTableStudentenVak");
            if (padNaarCsv != null)
            {
                DataTableStudentenVak = new DataTable("DtStuVak");


                DataTableStudentenVak.Columns.Add("Voornaam", typeof(string));
                DataTableStudentenVak.Columns.Add("Achternaam", typeof(string));
                DataTableStudentenVak.Columns.Add("VakCode", typeof(string));

                DsStudent.Tables.Add(DataTableStudentenVak);

            }
        }
        public static Student LoadRowCSV(string vakcode, string voornaam, string achtenaam)
        {
            Student student = null;

            student = new Student(
                voornaam, achtenaam, vakcode
                );

            return student;
        }
        public static void VoegRijToe(string voornaam, string achternaam, string vakcode)
        {
            DataRow dr = DataTableStudentenVak.NewRow();
            dr[0] = voornaam;
            dr[1] = achternaam;
            dr[2] = vakcode;
            DataTableStudentenVak.Rows.Add(dr);
        }


        public static DataView GetDataView()
        {
            return DataTableStudentenVak.DefaultView;
        }


        public static List<Student> ListStudenten = new List<Student>();

    }
}
