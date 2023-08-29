using databasefirst.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
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
using Xceed.Wpf.Toolkit;

namespace databasefirst
{
    /// <summary>
    /// Логика взаимодействия для BasketControl.xaml
    /// </summary>
    public partial class BasketControl : UserControl
    {
        public BasketControl()
        {
            InitializeComponent();
        }
        public int? selectedId;



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           using (shopbooksContext context = new shopbooksContext()) {
                int myValue = 1;
  
              string  myValue111 = Application.Current.Properties["IdWorker"].ToString();

                if (!string.IsNullOrEmpty(myValue111))
                {
                    myValue = Convert.ToInt32(myValue111);
                    Order order = new Order();
                    order.AddOrder(DateTime.Now, selectedId, myValue, context);
                    context.SaveChanges();
                }
                
                
                else System.Windows.MessageBox.Show("Не введен пользватель", "Ошибка");

                InputPanel.Visibility = Visibility.Visible;
            }
        }
        public int selectedIdBook;
        public int IDORDER;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData() { 
        using (shopbooksContext context= new shopbooksContext())
            {
                var NameClient = context.Clients.ToList();
                var NameBook=context.Books.ToList();
                ComboBook.ItemsSource= NameBook;
                ComboClient.ItemsSource = NameClient;


            }
        
        }

        private void LabelSum()
        {
            int sum = 0;
            foreach (var item in DataGridBasket.Items)
            {
                var bookInBasket = (ViewBookinBasket)item;
                sum += bookInBasket.CountBook * bookInBasket.PriceBook;


            }
            SumLabel.Content = sum;


        }






        private void Image_MouseDown_Accept(object sender, MouseButtonEventArgs e)
        {
            using (shopbooksContext context= new shopbooksContext()) {
                Book book = new Book();
    
                book = book.AddBookinBasket(Convert.ToInt32(ComboBook.SelectedValue));
                var BookinBasket = new ViewBookinBasket()
                {
                    IdBook = Convert.ToInt32(ComboBook.SelectedValue),
                    IdGenre = book.IdGenre,
                    IdEditorialOffice = book.IdEditorialOffice,
                    IdAuthor = book.IdAuthor,
                    NameBook = book.NameBook,
                    PriceBook = book.PriceBook,
                    FullNameAuthor = SaveNameAuthor(book.IdAuthor),
                    CountBook= myUpDownControl.Value ?? 0

            };

                DataGridBasket.Items.Add(BookinBasket);
            }
            LabelSum();
        }

        private void Image_MouseDown_Cancel(object sender, MouseButtonEventArgs e)
        {
            if (DataGridBasket.SelectedItem != null)
            {
                DataGridBasket.Items.Remove(DataGridBasket.SelectedItem);

            }
            else System.Windows.MessageBox.Show("Выбкрите Элемент", "Ошибка");

            LabelSum();
        }
     

        private void ComboClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboClient.SelectedItem != null)
            {
                selectedId = (int?)ComboClient.SelectedValue;


            }
        }

        private int OrderTakeId()
        {
            using (shopbooksContext context=new shopbooksContext())
            {
                var itemsToDelete = context.Orders
      .OrderByDescending(item => item.IdOrder)
              .Take(1)
              .ToList();

                foreach (var item in itemsToDelete)
                {
                    IDORDER = item.IdOrder;
         
                }

                return IDORDER;
            }


        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
    
    using (shopbooksContext context= new shopbooksContext())
            {
                var itemsToDelete = context.Orders
        .OrderByDescending(item => item.IdOrder) 
                .Take(1)
                .ToList();
                    
                foreach (var item in itemsToDelete)
                {
                    IDORDER=item.IdOrder;
                
                }
   
         
                context.Orders.RemoveRange(itemsToDelete);
                context.SaveChanges();



            }
            InputPanel.Visibility = Visibility.Hidden;
            DataGridBasket.Items.Clear();
          

        
          
        }

        public string SaveNameAuthor(int id)
        {
            using (shopbooksContext dbContext = new shopbooksContext())
            {

                string query1 = "SELECT  * FROM dbo.Author WHERE IdAuthor = @Id";
                var result = dbContext.Authors.FromSqlRaw(query1, new SqlParameter("@id", id)).ToList();

                StringBuilder stringBuilder = new StringBuilder();
               
                foreach (var user in result)
                {
                    stringBuilder.AppendLine($"{user.SurnameAuthor} {user.NameAuthor} {user.FathernameAuthor}");
             
                }

                string combinedResults = stringBuilder.ToString();

        return combinedResults;

              

            }

        }

        private void ComboBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBook.SelectedItem != null)
            {
                selectedIdBook = (int)ComboBook.SelectedValue;


            }
        }

        private void SuccessMethod() {
            using (shopbooksContext context = new shopbooksContext()) {
            

                foreach (var item in DataGridBasket.Items)
                {
                    var bookInBasket = (ViewBookinBasket)item;
                    string message = $"IdBook: {bookInBasket.IdBook}\nCountBook: {bookInBasket.CountBook}\nIdOrder: {OrderTakeId()}\nIdShop: {1}";

                 
    

                }
            }
        }


        private void SuccessButton_Click(object sender, RoutedEventArgs e)
        {
            SuccessMethod();

        }

        private void DataGridBasket_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            
        }

        private void myUpDownControl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
