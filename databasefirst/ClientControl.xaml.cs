using databasefirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace databasefirst
{
    /// <summary>
    /// Логика взаимодействия для ClientControl.xaml
    /// </summary>
    public partial class ClientControl : UserControl
    {
        public ClientControl()
        {
            InitializeComponent();
        }

        private void AddClient()
        {
            using (var dbContext = new shopbooksContext())
            {
                Client client = new Client();
                client.AddClient(SurnameTextBox.Text, NameTextBox.Text, FathernameTextBox.Text, NumberTextBox.Text, AdressTextBox.Text, EmailTextBox.Text, dbContext);
                LoadData();



            }


        }

        private void EditClient()
        {
            using (var context = new shopbooksContext())
            {
                var selectedItem = datagrid1.SelectedItem as Client;
                selectedItem.SurnameClient = SurnameTextBox.Text;
                selectedItem.NameClient = NameTextBox.Text;
                selectedItem.FathernameClient = FathernameTextBox.Text;
                selectedItem.NumberClient = NumberTextBox.Text;
                selectedItem.AdressClient = AdressTextBox.Text;
                selectedItem.EmailClient = EmailTextBox.Text;


                var dbRow = context.Clients.FirstOrDefault(x => x.IdClient == selectedItem.IdClient);
                if (dbRow != null)
                {
                    dbRow.SurnameClient = selectedItem.SurnameClient;
                    dbRow.NameClient = selectedItem.NameClient;
                    dbRow.FathernameClient = selectedItem.FathernameClient;
                    dbRow.NumberClient = selectedItem.NumberClient;
                    dbRow.AdressClient = selectedItem.AdressClient;
                    dbRow.EmailClient = selectedItem.EmailClient;
                    context.SaveChanges();
                }
            }
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
            var selectedItem = datagrid1.SelectedItem as Client;
            using (var dbContext = new shopbooksContext())
            {
                dbContext.Clients.Remove(selectedItem);
                dbContext.SaveChanges();
                dbContext.Clients.Update(selectedItem);
                LoadData();
            }

        }

        private void Image_MouseDown_Accept(object sender, MouseButtonEventArgs e)
        {
            if (datagrid1.SelectedItem != null)
            {


                if (SurnameTextBox.Text != "" && NameTextBox.Text != "" && NumberTextBox.Text != "" && AdressTextBox.Text != "" && EmailTextBox.Text != "")
                {
                    EditClient();
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
                if (SurnameTextBox.Text != "" && NameTextBox.Text != "" && NumberTextBox.Text != "" && AdressTextBox.Text != "" && EmailTextBox.Text != "")
                {
                    AddClient();
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

        private void LoadData()
        {
            using (var context = new shopbooksContext())
            {

                List<Client> clients = context.Clients.ToList();
                datagrid1.ItemsSource = clients;


            }

        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = datagrid1.SelectedItem as Client;
            if (selectedItem != null) { 
             SurnameTextBox.Text= selectedItem.SurnameClient;
            NameTextBox.Text = selectedItem.NameClient;
             FathernameTextBox.Text = selectedItem.FathernameClient;
            NumberTextBox.Text = selectedItem.NumberClient;
            AdressTextBox.Text = selectedItem.AdressClient;
            EmailTextBox.Text = selectedItem.EmailClient;
            }

        }
    }
}
