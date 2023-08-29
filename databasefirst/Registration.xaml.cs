using databasefirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace databasefirst
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        public int selectedId;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new shopbooksContext()) {
                if (!string.IsNullOrEmpty(loginbox.Text) && !string.IsNullOrEmpty(pass1.Password) && pass2.Password == pass1.Password) {
                    User user = new User();
                    string passwordtext = CreateSHA256(pass1.Password);

                    if (user.LoginCheck(loginbox.Text, selectedId, context)) {
                        
                        user.AddUser(loginbox.Text, passwordtext, selectedId, context);
                        Autorization autorization = new Autorization();
                        autorization.Show();
                        this.Close();
                    }
                    else {
                        MessageBox.Show("Пользователь с таким логином существует", "Ошибка логина", MessageBoxButton.OK, MessageBoxImage.Error);
                    }                    
                   
                }
                else {
                    MessageBox.Show("Поля пустые либо пароди не совпадают", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);

                }



            }

        }
        private void CollapseMenuButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseMenuButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();

        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            Autorization autorization = new Autorization();
            autorization.Show();
            this.Close();


        }

        public static string CreateSHA256(string input)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (shopbooksContext context=new shopbooksContext())
            {
                List<Worker> workers= new List<Worker>();
                workers=context.Workers.ToList();
                ComboWorker.ItemsSource = workers;
               


            }

        }

        private void ComboWorker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboWorker.SelectedItem != null)
            {
                selectedId = (int)ComboWorker.SelectedValue;


            }
        }
    }
}
