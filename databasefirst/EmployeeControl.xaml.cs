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
    /// Логика взаимодействия для EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void ClearPanel()
        {
            InputPanel.Visibility = Visibility.Visible;
            var textBoxes = UIHelper.FindChildren<TextBox>(InputPanel);
            foreach (var textBox in textBoxes)
            {
                textBox.Clear();
            }

        }

        private void EditWorker()
        {
            using (var context = new shopbooksContext())
            {
                var selectedItem = datagrid1.SelectedItem as Worker;
                selectedItem.SurnameWorker = SurnameTextBox.Text;
                selectedItem.NameWorker = NameTextBox.Text;
                selectedItem.FathernameWorker = FathernameTextBox.Text;
                selectedItem.NumberWorker = NumberTextBox.Text;
                selectedItem.AdressWorker = AdressTextBox.Text;


                var dbRow = context.Workers.FirstOrDefault(x => x.IdWorker == selectedItem.IdWorker);
                if (dbRow != null)
                {
                    dbRow.SurnameWorker = selectedItem.SurnameWorker;
                    dbRow.NameWorker = selectedItem.NameWorker;
                    dbRow.FathernameWorker = selectedItem.FathernameWorker;
                    dbRow.NumberWorker = selectedItem.NumberWorker;
                    dbRow.AdressWorker = selectedItem.AdressWorker;
            
                    context.SaveChanges();
                }
            }
            LoadData();


        }






        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ClearPanel();
            datagrid1.IsHitTestVisible = false;
            datagrid1.SelectedItem = null;
            InputPanel.Visibility = Visibility.Visible;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
          


            ClearPanel();
            datagrid1.SelectionMode = DataGridSelectionMode.Single;
            InputPanel.Visibility = Visibility.Visible;

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            datagrid1.SelectionMode = DataGridSelectionMode.Single;
            var selectedItem = datagrid1.SelectedItem as Worker;
            using (var dbContext = new shopbooksContext())
            {
                dbContext.Workers.Remove(selectedItem);
                dbContext.SaveChanges();
                dbContext.Workers.Update(selectedItem);
                LoadData();
            }

        }

        private void AddWorker()
        {
            using (var dbContext = new shopbooksContext())
            {
                Worker worker= new Worker();
                worker.AddWorker(SurnameTextBox.Text, NameTextBox.Text, FathernameTextBox.Text, NumberTextBox.Text, AdressTextBox.Text, dbContext);
                LoadData();



            }


        }




        private void LoadData()
        {
            using (var context = new shopbooksContext())
            {

                List<Worker> workers = context.Workers.ToList();
                datagrid1.ItemsSource = workers;


            }

        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagrid1.SelectedItem as Worker;
            if (selectedItem != null)
            {
                SurnameTextBox.Text = selectedItem.SurnameWorker;
                NameTextBox.Text = selectedItem.NameWorker;
                FathernameTextBox.Text = selectedItem.FathernameWorker;
                NumberTextBox.Text = selectedItem.NumberWorker;
                AdressTextBox.Text = selectedItem.AdressWorker;
   
            }
        }

        private void Image_MouseDown_Accept(object sender, MouseButtonEventArgs e)
        {
            if (datagrid1.SelectedItem != null)
            {


                if (SurnameTextBox.Text != "" && NameTextBox.Text != "" && NumberTextBox.Text != "" && AdressTextBox.Text != "" )
                {
                    EditWorker();
                }
                else

                {

                    MessageBox.Show("Поля пустые", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    e.Handled = true;


                }
                InputPanel.Visibility = Visibility.Hidden;

            }
            else
            {
                if (SurnameTextBox.Text != "" && NameTextBox.Text != "" && NumberTextBox.Text != "" && AdressTextBox.Text != "" )
                {
                    AddWorker();
                    datagrid1.IsHitTestVisible = true;

                    InputPanel.Visibility = Visibility.Hidden;



                }
                else

                {

                    MessageBox.Show("Поля пустые", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                    e.Handled = true;


                }


            }

        }

        private void Image_MouseDown_Cancel(object sender, MouseButtonEventArgs e)

        {
            datagrid1.IsHitTestVisible = true;

            InputPanel.Visibility = Visibility.Hidden;
            datagrid1.SelectionMode = DataGridSelectionMode.Single;
        }
    }
}
