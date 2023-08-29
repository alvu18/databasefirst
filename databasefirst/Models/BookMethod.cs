using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databasefirst.Models
{
    public partial class Book
    {

        public Book AddBookinBasket(int IdBook)
        {
            using (shopbooksContext dbContext = new shopbooksContext())
            {
                string query = "SELECT * FROM dbo.Book WHERE IdBook = @idBook ";
                var result = dbContext.Books.FromSqlRaw(query, new SqlParameter("@idBook", IdBook)).FirstOrDefault();
                return result;


            }
        }





        public void AddBook(int idGenre, int idEditorialOffice,int idAuthor ,string nameBook ,int priceBook) {
            using (shopbooksContext context= new shopbooksContext()) { 
            Book book = new Book()
            {
                IdGenre= idGenre,
                IdEditorialOffice= idEditorialOffice,
                IdAuthor= idAuthor,
                NameBook= nameBook,
                PriceBook= priceBook
                


            };

                context.Books.Add(book);
                context.SaveChanges();

            }


        }

    }
}
