using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace databasefirst.Models
{
    public partial class Client
    {
        public void AddClient(string Surname, string Name, string Fathername, string Number, string Adress, string Email, shopbooksContext dbContext) {

            var newClient = new Client()
            {
                SurnameClient = Surname,
                NameClient = Name,
                FathernameClient = Fathername,
                NumberClient = Number,
                AdressClient = Adress,                  
            EmailClient = Email
            };

            dbContext.Clients.Add(newClient);
            dbContext.SaveChanges();

        }
      
    }
}
