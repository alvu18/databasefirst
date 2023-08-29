using databasefirst.Models;
using LiveCharts.Wpf;
using LiveCharts;
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
using Microsoft.EntityFrameworkCore;

namespace databasefirst
{
    /// <summary>
    /// Логика взаимодействия для Chart3Control.xaml
    /// </summary>
    public partial class Chart3Control : UserControl
    {
        public Chart3Control()
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

                List<String> GenreName=context.Genres.Select(Genres => Genres.NameGenre).ToList();
                ListViewChart3.ItemsSource = GenreName;
                View1 view1 = new View1();
                List<View1> view1s = view1.GetBooksSortedByNameChart3(context, (string)ListViewChart3.SelectedValue);




                SeriesCollection series = new SeriesCollection();
                foreach (View1 viewChart1 in view1s)
                {

                    series.Add(new ColumnSeries
                    {

                        Title = viewChart1.NameBook,

                        Values = new ChartValues<int> { viewChart1.PriceBook },
                        DataLabels = true,

                    }); ;
                }
                chart.AxisX.Clear();
                chart.AxisX.Add(new Axis
                {
                    Title = "Название книг",
                    
                });


                chart.AxisY.Clear();
                chart.AxisY.Add(new Axis
                {
                    Title = "Цена",
                    MinValue = 100,
                    MaxValue = 2000,
                });




                chart.Series = series;
            }
        }

        private void ListViewChart3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }
    }
}
