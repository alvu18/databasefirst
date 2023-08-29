using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace databasefirst.Models
{
    public partial class Ordelist
    {

        

        public static void AddOrderList(int idbook, int count, int idorder, int idshop, shopbooksContext dbContext)
        {
            var newlist = new Ordelist()
            {
                IdOrder = idorder,
                IdBook = idbook,
                IdShop = idshop,
                CountBook = count,
            };

            dbContext.Ordelists.Add(newlist);
            dbContext.SaveChanges();
        }


    }
}
