using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace databasefirst.Models
{
 
    public partial class Autorization : Window
    {
        public Autorization()
        {
    
            InitializeComponent();
        }

        public static string CreateSHA256(string input)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new shopbooksContext()) {
                if (!string.IsNullOrEmpty(loginbox.Text) && !string.IsNullOrEmpty(pass1.Password) && pass2.Password == pass1.Password)
                {
                    User user = new User();
                    string passwordhash = CreateSHA256(pass1.Password);
                    int? IDWORKER = user.UserCheck(loginbox.Text, passwordhash, context);
                    if (IDWORKER != 0)
                    {
                        SaveNameWorker(IDWORKER);
                        MainWindow MainWindow = new MainWindow();
                        MainWindow.Show();
                        this.Close();
                    }
                    else {

                        MessageBox.Show("Логин или пароль неверные", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);

                    }


                }
                else {
                    MessageBox.Show("Поля пустые либо пароди не совпадают", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
           
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            
                Registration registration = new Registration();
                registration.Show();
                this.Close();
            
            
        }
        private void CollapseMenuButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseMenuButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            
        }

        public void SaveNameWorker(int? id) {
            using (shopbooksContext dbContext = new shopbooksContext())
            {

                string query1 = "SELECT  * FROM dbo.Worker WHERE IdWorker = @Id";
                var result = dbContext.Workers.FromSqlRaw(query1,  new SqlParameter("@id", id)).ToList();
         
                StringBuilder stringBuilder = new StringBuilder();
                string StringIdWorker="";
                foreach (var user in result)
                {
                    stringBuilder.AppendLine($"{user.SurnameWorker} {user.NameWorker} {user.FathernameWorker}");
                    StringIdWorker = user.IdWorker.ToString();
                }

                string combinedResults = stringBuilder.ToString();

                Application.Current.Properties["IdWorker"] = StringIdWorker;
                Application.Current.Properties["WorkerName"] = combinedResults;

            
             
            }

        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

    }
}
