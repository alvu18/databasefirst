using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databasefirst.Models
{
    public partial class Order
    {
        public void AddOrder(DateTime CurrentTime, int? IDclient, int IDWorker , shopbooksContext dbContext)
        {
            var newOrder = new Order()
            {
             DateOrder= CurrentTime,
             IdClient=IDclient,
             IdWorker= IDWorker
            };

            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();
        }


    }
}
