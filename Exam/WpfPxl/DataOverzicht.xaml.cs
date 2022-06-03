using Pxl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPxl
{
    /// <summary>
    /// Interaction logic for DataOverzicht.xaml
    /// </summary>
    public partial class DataOverzicht : Window
    {         // komt allen hierin als de 2de xaml word geopend 
        public DataOverzicht()
        {
            InitializeComponent();
        }
        private DataView dvStud;
        private DataView dvVak;
        private readonly Student st = new Student();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Data STUDENTEN tonen in datagrid
            dvStud = Databank.DsStudent.Tables["student"].DefaultView;
            DgdStudenten.ItemsSource = dvStud;
            dvVak = Databank.DsStudent.Tables["Vak"].DefaultView;
            dgdVakken.ItemsSource = dvVak;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //// === Nieuwe DATA VIEW ===
            DataView dv3 = dvStud;
            dv3.Sort = "Naam desc";
            dv3.RowFilter = "VakCode = 'PRO'";
            // === Afdruk in DataGrid
            DgdStudenten.ItemsSource = dv3;
            //== AFDRUK TxtResultaat
            DataRow[] res = Databank.DsStudent.Tables["student"].Select("VakCode = 'PRO'"); ;
            TxtResultaat.Clear();
            foreach (DataRow kolom in res)
            {
                TxtResultaat.Text += $"{kolom[1]} - {kolom[2]}\r\n";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // === Nieuwe DATA VIEW ===
            DataView dv3 = dvStud;
            dv3.RowFilter = "Naam like 'P%'";
            dv3.Sort = "naam";
            // === Afdruk in DataGrid
            DgdStudenten.ItemsSource = dv3;
            //== AFDRUK TxtResultaat
            DataRow[] res = Databank.DsStudent.Tables["student"].Select("Naam like 'P%'"); ;
            TxtResultaat.Clear();
            foreach (DataRow kolom in res)
            {
                TxtResultaat.Text += $"{kolom[1],-15} - {kolom[2]}\r\n";
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // === Afdruk in DataGrid
            DgdStudenten.ItemsSource = dvStud;
            dvStud.RowFilter = null;
            dvStud.Sort = "Naam";
            TxtResultaat.Clear();


        }
    }
}
