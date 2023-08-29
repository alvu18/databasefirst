using databasefirst.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
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
    /// Логика взаимодействия для Chart1Control.xaml
    /// </summary>
    public partial class Chart1Control : UserControl
    {
        public Chart1Control()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
         
        }
        private void SetDate() {
            using (shopbooksContext context = new shopbooksContext())
            {
                List<ViewChart1> viewChart1s = context.ViewChart1s.ToList();


                ChartValues<DateTime> chartDates = new ChartValues<DateTime>(viewChart1s.Select(item => item.DateOrder));
                ChartValues<int> chartValues = new ChartValues<int>(viewChart1s.Select(item => item.TotalPrice));

                SeriesCollection series = new SeriesCollection
        {
            new LineSeries
            {
                Title = "Сумма покупок",
                Values = chartValues,

            }
        };
                var labelstring = string.Join(" ", chartDates
     .Where(date => date >= StartDate.SelectedDate && date <= EndDate.SelectedDate)
     .Select(date => date.ToShortDateString())
     .ToList());
                if (!string.IsNullOrEmpty(labelstring))
                {
                   
                    List<string> result = new List<string>(labelstring.Split(' '));
                    result.ToList();
                    chart.AxisX.Clear();
                    chart.AxisX.Add(new Axis
                    {
                        Title = "Дата",
                        Labels = new List<string> { labelstring },
                       
                    });


                    chart.AxisY.Clear();
                    chart.AxisY.Add(new Axis
                    {
                        Title = "Сумма",
                        MinValue = 0,
                        MaxValue = chartValues.Max(),
                    });

                    chart.Series = series;
                   
            

                }
                else if (EndDate.SelectedDate!=null && StartDate.SelectedDate!=null) MessageBox.Show("Неверные даты или отсутсвуют продажи", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

private void LoadData()
    {
        using (shopbooksContext context = new shopbooksContext())
        {
            List<ViewChart1> viewChart1s = context.ViewChart1s.ToList();

      
            ChartValues<DateTime> chartDates = new ChartValues<DateTime>(viewChart1s.Select(item => item.DateOrder));
           ChartValues<int> chartValues = new ChartValues<int>(viewChart1s.Select(item => item.TotalPrice));

            SeriesCollection series = new SeriesCollection
        {
            new LineSeries
            {
                Title = "Сумма покупок", 
                Values = chartValues,
        
            }
        };
             

                chart.AxisX.Clear();
            chart.AxisX.Add(new Axis
            {
                Title = "Дата", 
                Labels = chartDates.Select(date => date.ToShortDateString()).ToList(), 
            });

   
            chart.AxisY.Clear();
            chart.AxisY.Add(new Axis
            {
                Title = "Сумма", 
                MinValue= 0,
                MaxValue = chartValues.Max(),
            });

            chart.Series = series;
          

            }
    }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();

        }

        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            SetDate();
        }
    }
}
