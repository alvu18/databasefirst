using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databasefirst.Models
{


public partial  class View1
    {
     
        public List<View1> GetBooksSortedByName(shopbooksContext dbContext)
        {
            string query = "SELECT * FROM dbo.view1 ORDER BY NameBook";

            return dbContext.View1s.FromSqlRaw(query).ToList() ;
        }


        public List<View1> GetBooksSortedByNameChart3(shopbooksContext dbContext, string ListGenre)
        {
            
            string query = "SELECT * FROM dbo.view1 WHERE NameGenre = @ListGenre ORDER BY NameBook";
            SqlParameter parameter = new SqlParameter("@ListGenre", ListGenre);

            return dbContext.View1s.FromSqlRaw(query, parameter).ToList();
        }


    }
}
