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
using System.Windows.Shapes;

namespace databasefirst
{
    /// <summary>
    /// Логика взаимодействия для EditBookWindow.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        MainWindow mainWindow = new MainWindow();
        public Book book1 = new Book();
        public EditBookWindow(Book book)
        {
            book1 = book;
            InitializeComponent();
        }

        public int selectidauthor;
        public int selectidgenre;
        public int selectidoffice;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
         

            if (!string.IsNullOrEmpty(namebox.Text) && !string.IsNullOrEmpty(ComboGenre.SelectedValuePath) && !string.IsNullOrEmpty(ComboEditorialOffice.SelectedValuePath) && !string.IsNullOrEmpty(ComboAuthor.SelectedValuePath) && !string.IsNullOrEmpty(pricebox.Text))
            {
                EditWorker();



            }


            else System.Windows.MessageBox.Show("Не все поля заполнены", "Ошибка");





            MessageBox.Show("Успешно добавлена", "Уведомление");
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.LoadData();
            this.Close();

        }

        private void pass1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void ComboAuthor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboAuthor.SelectedItem != null)
            {
                selectidauthor = (int)ComboAuthor.SelectedValue;


            }
        }

        private void ComboEditorialOffice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboEditorialOffice.SelectedItem != null)
            {
                selectidoffice = (int)ComboEditorialOffice.SelectedValue;


            }
        }

        private void ComboGenre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboGenre.SelectedItem != null)
            {
                selectidgenre = (int)ComboGenre.SelectedValue;


            }
        }

        private void CloseMenuButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow.LoadData();
            this.Close();
        }

        private void CollapseMenuButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (shopbooksContext context = new shopbooksContext())
            {
                var Genre = context.Genres.OrderBy(genre => genre.IdGenre).ToList();
                var Author = context.Authors.OrderBy(Author => Author.IdAuthor).ToList();
                var Office = context.EditorialOffices.OrderBy(EditorialOffice => EditorialOffice.IdEditorialOffice).ToList();
                ComboGenre.ItemsSource = Genre;
                ComboAuthor.ItemsSource = Author;
                ComboEditorialOffice.ItemsSource = Office;


            }
           
            namebox.Text = book1.NameBook;
            pricebox.Text = book1.PriceBook.ToString();
           

        }

        private void EditWorker()
        {
            using (var context = new shopbooksContext())
            {



                var dbRow = context.Books.FirstOrDefault(x => x.IdBook == book1.IdBook);
                if (dbRow != null)
                {
                    dbRow.NameBook = namebox.Text;
                    dbRow.PriceBook = Convert.ToInt32(pricebox.Text);
                    dbRow.IdGenre = selectidgenre;
                    dbRow.IdEditorialOffice = selectidoffice;
                    dbRow.IdAuthor= selectidauthor;
                    context.SaveChanges();
                }
            }
            LoadData();


        }






        private void Window_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

    }
}

