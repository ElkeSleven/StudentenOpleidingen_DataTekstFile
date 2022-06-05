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
        
        //**
        public DataVieuwStudentenVak()
        {
            InitializeComponent();
        }

        //**
        private DataView x;
     
        //**DataGrid inladen met gegevens 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DgdStudenten.ItemsSource = StudentenData.GetDataView();
            VulComboBox();
        }

        //** CombomboBox met waarde vullen 
        private void VulComboBox()
        {

            DataRow[] res = StudentenData.DataTableStudentenVak.Select();

            foreach (DataRow kolom in res)
            {
                if (!comboBoxVak.Items.Contains(kolom[2].ToString()))
                {
                    comboBoxVak.Items.Add(kolom[2].ToString());
                }

            }

        }

        //**Sort ***
        private void ResetDataVieuw_Click(object sender, RoutedEventArgs e)
        {
            x = StudentenData.GetDataView();
            DgdStudenten.ItemsSource = x;
            x.RowFilter = null;
            x.Sort = "Voornaam";
            TxtResultaat.Clear();
        }

        //**Sort ***
        private void SorterenOpNaam_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLetter.Text) && txtLetter.Text.Length == 1 && !Int32.TryParse(txtLetter.Text, out int i))
            {
                x = StudentenData.GetDataView();
                string columnaam = "Voornaam";
                string letter = txtLetter.Text;
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
            else
            {
                MessageBox.Show("ingave niet goed");
            }


        }

        //**Sort ***  
        private void SorterenOpVakcode_Click(object sender, RoutedEventArgs e)
        {
            if(comboBoxVak.SelectedIndex != -1)
            {
                x = StudentenData.GetDataView();
                string columnaam = "Voornaam";
                string vakcode = comboBoxVak.SelectedValue.ToString();
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
            else
            {
                MessageBox.Show("eerst een vakcode in de combobox silecteren");
            }
        }

   
        //**close 
        private void mnuAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
