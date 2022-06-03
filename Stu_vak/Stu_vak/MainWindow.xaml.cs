﻿using ClassLibStuVak;
using System;
using System.Collections.Generic;
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
using System.IO;
using Microsoft.Win32;

namespace Stu_vak
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
            Student s;
            OpenFileDialog padNaarCsv = new OpenFileDialog
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.txt) |*.txt",
                FileName = "Studenten_toepassing.csv",
                Multiselect = true,
                InitialDirectory = System.IO.Path.GetFullPath(@"..\..\Bestanden"), // volledig pad

            };
            if(padNaarCsv.ShowDialog() == true)
            {
                StudentenData.DataFolder = System.IO.Path.GetDirectoryName(padNaarCsv.FileName);
                StudentenData.LoadCSV(padNaarCsv.ToString());
                using (StreamReader sr = new StreamReader(padNaarCsv.FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        s = null;
                        string regel = sr.ReadLine();
                        string[] csv = regel.Split(';');

                        string voornaam = csv[0];
                        string achtenaam = csv[1];
                        string vakcode = csv[2];

                       s = StudentenData.LoadRowCSV(vakcode, voornaam, achtenaam);
                        StudentenData.VoegRijToe(voornaam, achtenaam, vakcode);
                        StudentenData.ListStudenten.Add(s);
                    }
                    LstStudent.ItemsSource = StudentenData.ListStudenten;

                }
                
            }
          

        }



        private void datavieuwAnderWindow_Click(object sender, RoutedEventArgs e)
        {
            //// opent nieuw window 
            DataVieuwStudentenVak dWin = new DataVieuwStudentenVak();
            dWin.ShowDialog();
        }

        private void opslaanAlsXml_Click(object sender, RoutedEventArgs e)
        {
            if (StudentenData.DataFolder != string.Empty)
            {
                string dataBestand = $"{StudentenData.DataFolder}\\data.xml";  /// XML ? 
                StudentenData.DsStudent.WriteXml(dataBestand);
            }
        }

        private void opslaanAlsCsv_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog padNaarSavedCsv = new SaveFileDialog()
            {
                Filter = "Alle bestanden (*.*)|*.*|Tekstbestanden (*.csv)|*.csv",
                FilterIndex = 2,
                Title = "Geef een bestandsnaam op",
                OverwritePrompt = true, //Bevestiging wordt gevraagd bij overschrijven van een bestand.
                AddExtension = true, // Extensie wordt toegevoegd.
                //InitialDirectory = Databank.DataFolder
            };
            if (padNaarSavedCsv.ShowDialog() == true)
            {
                
                using (StreamWriter sw = new StreamWriter(padNaarSavedCsv.FileName))
                {
                    foreach (Student stud in StudentenData.ListStudenten)
                    {
                        sw.WriteLine($"{stud.Voornaam};{stud.Achternaam};{stud.Vakcode}");
                    }
                }
            }
        }

      
    }
}
