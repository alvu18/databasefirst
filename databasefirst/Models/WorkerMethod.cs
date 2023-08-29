using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databasefirst.Models
{
    public partial class Worker
    {
        public void AddWorker(string Surname, string Name, string Fathername, string Number, string Adress,  shopbooksContext dbContext)
        {

            var newWorker = new Worker()
            {
                SurnameWorker = Surname,
                NameWorker = Name,
                FathernameWorker = Fathername,
                NumberWorker = Number,
                AdressWorker = Adress,
           
            };

            dbContext.Workers.Add(newWorker);
            dbContext.SaveChanges();

        }

    }
}
