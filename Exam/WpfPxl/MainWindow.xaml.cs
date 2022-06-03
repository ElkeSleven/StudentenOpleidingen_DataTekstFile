using DocumentFormat.OpenXml.EMMA;
using Microsoft.Win32;
using Pxl;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPxl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Student s;                                                /// hier word de verkenner van de gebruiker geopende en moet hij de csv file aanduiden 
            Vak vk = new Vak();
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
                FileName = "Studenten_toepassing.csv",
                Multiselect = true,
                InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestanden"), // volledig pad

            };
            if (ofd.ShowDialog() == true)
            {
                Databank.DataFolder = System.IO.Path.GetDirectoryName(ofd.FileName);
                string[] kolommen;                                                                      //// hier word de data uitgelezen gesplits door ";"
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        //Scheidingsteken opgeven, geeft array terug gescheiden door opgegeven karakter.
                        kolommen = sr.ReadLine().Split(';');
                        //Geeft kolommen met gegevens door aan klasse Student
                        s = new Student(kolommen);
                        // Voegt aan klasse Databank de List van studenten toe.
                        Databank.ListStudenten.Add(s);
                    }
                    LstStudent.ItemsSource = Databank.ListStudenten;
                }
            }
            // Vakken vullen
            foreach (var item in Databank.DictVakken)
            {
                vk = new Vak(item.Key, item.Value);
            }

        }


        //// messagebox met info als de gebruiker op een listItem klikt 
        private void LstStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = LstStudent.SelectedIndex;
            MessageBox.Show($" {Databank.ListStudenten[index].Voornaam.Substring(0, 1)}.{Databank.ListStudenten[index].Naam} volgt les in de afdeling{Databank.ListStudenten[index].VakVolledig.ToUpper()}", "Info student");
        }

        //// opslaan van de file 
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.csv)|*.csv",
                FilterIndex = 2,
                Title = "Geef een bestandsnaam op",
                OverwritePrompt = true, //Bevestiging wordt gevraagd bij overschrijven van een bestand.
                AddExtension = true, // Extensie wordt toegevoegd.
                InitialDirectory = Databank.DataFolder
            };
            if (sfd.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (Student stud in Databank.ListStudenten)
                    {
                        sw.WriteLine($"{stud.Naam};{stud.Voornaam};{stud.VakVolledig}");
                    }
                }
            }
        }
        //// opslaan data gegevens 
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (Databank.DataFolder != string.Empty)
            {
                string dataBestand = $"{Databank.DataFolder}\\data.xml";  /// XML ? 
                Databank.DsStudent.WriteXml(dataBestand);
            }
        }


        //// overzicht gegevens 
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //// opent nieuw window 
            DataOverzicht dWin = new DataOverzicht();
            dWin.ShowDialog();
        }
    }
}