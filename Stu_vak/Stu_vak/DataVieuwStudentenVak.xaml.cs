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

        }

        private void SorterenOpProgrammeren_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
