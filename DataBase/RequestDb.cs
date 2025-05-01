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

        public decimal InsertOrder(Sales sale)
        {
            try
            {
                using (var db = new AppDb())
                {
                    db.Database.OpenConnection();
                    db.Sales.FromSql($"Exec InsertSales");
                    foreach(var itens in sale.SalesDetails)
                    {
                        var products = db.SalesDetails.FromSql($"Exec InsertSalesDetails {itens.FK_Stock_IdItem} , {itens.Quantity}");
                    }
                    db.Database.CloseConnection();
                    return 1;
                }
    ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public bool UpdateOrder(int idOrder, Sales orderUpdate)
        {
            try
            {
                using (var db = new AppDb())
                {
                    db.Database.OpenConnection();
                    foreach(var itens in orderUpdate.SalesDetails)
                    {
                        var products = db.Sales.FromSql($"Exec UpdateOrder {idOrder}, {itens.FK_Stock_IdItem},{itens.Quantity}");
                    }   
                    db.Stock.FromSql($"Exec UpdateOrder {idOrder}, {orderUpdate}");
                    db.Database.CloseConnection();
                    return true;
                }
    ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteOrder(int idOrder)
        {
            try
            {
                using (var db = new AppDb())
                {
                    db.Database.OpenConnection();
                    db.Stock.FromSql($"Exec DeleteOrder {idOrder}").ToList();
                    db.Database.CloseConnection();
                    return true;
                }
    ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
