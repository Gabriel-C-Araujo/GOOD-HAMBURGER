using GOOD_HAMBURGER.DataBase;
using GOOD_HAMBURGER.Entity;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Diagnostics;

namespace GOOD_HAMBURGER.DataBase
{
    public class RequestDb
    {

        public List<Stock> ProductsAll()
        {
            try
            {


                using (var db = new AppDb())
                {
                    db.Database.OpenConnection();
                    var produtos = db.Database.SqlQuery<List<Stock>>($"Exec AllProducts");
                    db.Database.CloseConnection();
                    return (List<Stock>)produtos;
                };
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Stock> ProductsSandwich(int Type)
        {
            try
            {

                using (var db = new AppDb())
                {
                    db.Database.OpenConnection();
                    var produtos = db.Database.SqlQuery<List<Stock>>($"Exec ProductsSandwich");
                    db.Database.CloseConnection();
                    return (List<Stock>)produtos;
                }
                ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Stock> ProductsType(int Type)
        {
            try
            {


                using (var db = new AppDb())
                {
                    db.Database.OpenConnection();
                    var produtos = db.Database.SqlQuery<List<Stock>>($"Exec ProductsType");
                    db.Database.CloseConnection();
                    return (List<Stock>)produtos;
                }
                ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
