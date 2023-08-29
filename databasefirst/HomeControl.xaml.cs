using databasefirst.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
using static System.Reflection.Metadata.BlobBuilder;

namespace databasefirst
{
    /// <summary>
    /// Логика взаимодействия для HomeControl.xaml
    /// </summary>
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            using (var context = new shopbooksContext())
            {

                View1 view1 = new View1();
                List<View1> dataList2 = view1.GetBooksSortedByName(context);
                datagrid1.ItemsSource = dataList2;


            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBook = new AddBookWindow();
            addBook.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        { 
            Book book=new Book();          
                var selectedItem = datagrid1.SelectedItem as View1;
                book = SearchBook(selectedItem.NameBook);        
                EditBookWindow editBookWindow = new EditBookWindow(book);
                editBookWindow.ShowDialog();
            
        }

        private Book SearchBook(string namebook)
        {
            using (shopbooksContext dbContext = new shopbooksContext())
            {
                string query = "SELECT * FROM dbo.Book WHERE NameBook = @namebook ";
                var result = dbContext.Books.FromSqlRaw(query, new SqlParameter("@namebook", namebook)).FirstOrDefault();
                if (result != null)
                {
                    return result;


                }
               else
                {
                    MessageBox.Show("Не найдено книги","Ошибка");
                    return result;
                }


            }


        }




        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            datagrid1.SelectionMode = DataGridSelectionMode.Single;
            var selectedItem = datagrid1.SelectedItem as View1;
            Book book = new Book();
            book=SearchBook(selectedItem.NameBook);
            



            if (selectedItem != null)
            {
                using (var dbContext = new shopbooksContext())
                {
                    dbContext.Books.Remove(book);
                    dbContext.SaveChanges();
           
                    LoadData();
                }

            }
            else MessageBox.Show("не выбранно поле", "Ошибка");
        }
    }
}
