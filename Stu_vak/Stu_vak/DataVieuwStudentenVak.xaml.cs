using ClassLibStuVak;
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

namespace Stu_vak
{
    /// <summary>
    /// Interaction logic for DataVieuwStudentenVak.xaml
    /// </summary>
    public partial class DataVieuwStudentenVak : Window
    {
        
        public DataVieuwStudentenVak()
        {
            InitializeComponent();
        }
        private DataView x;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DgdStudenten.ItemsSource = StudentenData.GetDataView();
        }
        private void ResetDataVieuw_Click(object sender, RoutedEventArgs e)
        {
            x = StudentenData.GetDataView();
            DgdStudenten.ItemsSource = x;
            x.RowFilter = null;
            x.Sort = "Voornaam";
            TxtResultaat.Clear();
        }
        private void SorterenOpNaam_Click(object sender, RoutedEventArgs e)
        {
            x = StudentenData.GetDataView();
            string columnaam = "Voornaam";
            string letter = "P";
            x.Sort = $"{columnaam} desc";
            x.RowFilter = $"{columnaam} like '{letter}%'";
            // === Afdruk in DataGrid
            DgdStudenten.ItemsSource = x;
            //== AFDRUK TxtResultaat                                // Select("Naam like 'P%'");
            DataRow[] res = StudentenData.DataTableStudentenVak.Select($"{columnaam} like '{letter}%'");
            
            TxtResultaat.Clear();
                foreach (DataRow kolom in res)
            {
                TxtResultaat.Text += $"{kolom[1]} - {kolom[2]}\r\n";
            }


        }
        private void SorterenOpVakcode_Click(object sender, RoutedEventArgs e)
        {
            x = StudentenData.GetDataView();
            string columnaam = "Voornaam";
            string vakcode = "PRO";
            x.Sort = $"{columnaam} desc";
            x.RowFilter = $"Vakcode = '{vakcode}'";
            // === Afdruk in DataGrid
            DgdStudenten.ItemsSource = x;
            //== AFDRUK TxtResultaat
            DataRow[] res = StudentenData.DataTableStudentenVak.Select($"Vakcode = '{vakcode}'");
            TxtResultaat.Clear();
            foreach (DataRow kolom in res)
            {
                TxtResultaat.Text += $"{kolom[1]} - {kolom[2]}\r\n";
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MessageBoxResult resaltaat = MessageBox.Show("ben je zeker dat je de app wil afsluiten ?  ", "Afluiten ? ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //MessageBox.Show(resaltaat.ToString());
            if (MessageBoxResult.Yes == resaltaat)
            {
                Close();
            }
        }

        private void mnuAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
