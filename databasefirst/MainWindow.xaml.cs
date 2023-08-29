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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using databasefirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace databasefirst
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void LoadData()
        {
            HomeControl homeControl = new HomeControl();
            contentControl.Content = homeControl;
            string myValue = (string)Application.Current.Properties["WorkerName"];
            if (!string.IsNullOrEmpty(myValue))
            WorkerLabel.Content = myValue;
            else WorkerLabel.Content = "Test";
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)

        {

            LoadData();

        }

        private void CollapseMenuButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
            WindowState = WindowState.Minimized;
        }

        private void CloseMenuButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();

        }

        //private void ExtendMenuButton_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (WindowState == WindowState.Normal)
        //    {
              
        //        WindowState = WindowState.Maximized;
        //    }
        //    else
        //    {
          
        //        WindowState = WindowState.Normal;
        //    }
        //}

  

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Autorization autorization  = new Autorization();
            autorization.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            string menuItemHeader = menuItem.Header.ToString();

            switch (menuItemHeader)
            {
                case "Home":

                    HomeControl homeControl= new HomeControl();
                    contentControl.Content = homeControl;
                    break;

                case "Client":


                    ClientControl clientControl = new ClientControl();
                    contentControl.Content = clientControl;
                    break;

                case "Employee":


                   EmployeeControl employeeControl= new EmployeeControl();
                    contentControl.Content = employeeControl;
                    break;


                case "График 1":


                    Chart1Control chart1Control= new Chart1Control();
                    contentControl.Content = chart1Control;
                    break;

                case "График 2":

                    Chart2Control chart2Control = new Chart2Control();
                    contentControl.Content = chart2Control;
                    break;

                case "График 3":

                    Chart3Control chart3Control = new Chart3Control();
                    contentControl.Content = chart3Control;
                    break;


                case "История покупок":

                    HistoryOrderControl orderControl = new HistoryOrderControl();
                    contentControl.Content = orderControl;
                    break;

                case "Оформить":

                    BasketControl basketControl = new BasketControl();
                    contentControl.Content = basketControl;
                    break;

                default:
                    MessageBox.Show("Ошибка ввода", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                    break;
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void SuplierButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
