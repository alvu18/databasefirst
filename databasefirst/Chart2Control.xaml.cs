using databasefirst.Models;
using LiveCharts.Wpf;
using LiveCharts;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
    /// Логика взаимодействия для Chart2Control.xaml
    /// </summary>
    public partial class Chart2Control : UserControl
    {
        public Chart2Control()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }


        private void LoadData()
        {
            using (shopbooksContext context = new shopbooksContext())
            {
                List<ViewChart2> viewChart2s = context.ViewChart2s.ToList();



                SeriesCollection series = new SeriesCollection();
                foreach (ViewChart2 viewChart2 in viewChart2s)
                {

                    series.Add(new PieSeries
                    {

                        Title =viewChart2.NameBook ,

                        Values = new ChartValues<int> { viewChart2.PriceBook },
                        DataLabels = true,
            
                    }) ;;
                }

                chart.Series = series;       
            }
        }
    }
}



   


            