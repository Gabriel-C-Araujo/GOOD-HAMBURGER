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
                    List<Stock> produtos = db.Stock.FromSql($"Exec AllProducts").ToList();
                    db.Database.CloseConnection();
                    return produtos;
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
                    List<Stock> produtos = db.Stock.FromSql($"Exec ProductsSandwich {Type}").ToList();
                    db.Database.CloseConnection();
                    return produtos;
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
                    List<Stock> produtos = db.Stock.FromSql($"Exec ProductsType {Type}").ToList();
                    db.Database.CloseConnection();
                    return produtos;
                }
    ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Sales> ListOrder()
        {
            try
            {
                using (var db = new AppDb())
                {
                    db.Database.OpenConnection();
                    List<Sales> order = db.Sales.FromSql($"Exec ListOrder ").ToList();
                    db.Database.CloseConnection();
                    return order;
                }
    ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void InsertOrder(int FK_Stock_IdItem, int Quantity)
        {
            try
            {
                using (var db = new AppDb())
                {
                    db.Database.OpenConnection();
                    db.Stock.FromSql($"Exec InsertSales{FK_Stock_IdItem},{Quantity},{123} ").ToList();
                    db.Database.CloseConnection();
                }
    ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateOrder(int idOrder)
        {
            try
            {
                using (var db = new AppDb())
                {
                    db.Database.OpenConnection();
                    db.Stock.FromSql($"Exec UpdateOrder {idOrder}").ToList();
                    db.Database.CloseConnection();                    
                }
    ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteOrder(int idOrder)
        {
            try
            {
                using (var db = new AppDb())
                {
                    db.Database.OpenConnection();
                    db.Stock.FromSql($"Exec DeleteOrder {idOrder}").ToList();
                    db.Database.CloseConnection();
                }
    ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
