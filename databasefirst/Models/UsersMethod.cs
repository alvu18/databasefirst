using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databasefirst.Models
{
    public partial class User
    {
        public  int? UserCheck(string login , string password , shopbooksContext dbContext) {


            string query = "SELECT * FROM dbo.Users WHERE Name = @Login AND Password = @Password";
            var result = dbContext.Users.FromSqlRaw(query, new SqlParameter("@Login", login), new SqlParameter("@Password", password)).FirstOrDefault();

            if (result != null )
            return result.IdWorker;


            return 0;
        }

        public void AddUser(string login, string password, int IdWorker, shopbooksContext dbContext)
        {
            var newUser = new User()
            {
                Name = login,
                Password = password,
                IdWorker = IdWorker
            };

            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
        }


        public bool LoginCheck(string login,int id , shopbooksContext dbContext)
        {


            string query = "SELECT * FROM dbo.Users WHERE Name = @Login or idWorker=@id";
            var result = dbContext.Users.FromSqlRaw(query, new SqlParameter("@Login", login), new SqlParameter("@id", id)).ToList();

            if (result != null && result.Any())
                return false;


            return true;
        }


    }
}
