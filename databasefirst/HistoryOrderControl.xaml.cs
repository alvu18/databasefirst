using databasefirst.Models;
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

namespace databasefirst
{
    /// <summary>
    /// Логика взаимодействия для HistoryOrderControl.xaml
    /// </summary>
    public partial class HistoryOrderControl : UserControl
    {
        public HistoryOrderControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData() {
        
            using (shopbooksContext context = new shopbooksContext())
            {
                List<ViewHistoryChart> viewChart1s= new List<ViewHistoryChart>();
                viewChart1s=context.ViewHistoryCharts.ToList();
                datagrid1.ItemsSource= viewChart1s;


            }

        
        }

    }
}
