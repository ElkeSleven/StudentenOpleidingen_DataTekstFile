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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DgdStudenten.ItemsSource = StudentenData.GetDataView();
        }



    }
}
