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
                    var order = db.Sales.FromSql($"Exec ListOrder ").ToList(); 
                    var allDetails = db.SalesDetails.FromSql($"Exec ListOrderDetails").ToList();
                    foreach (var orders in order)
                    {
                        orders.SalesDetails = allDetails.Where(d => d.FK_Sales == orders.PK_Sales).ToList();
                    }
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
                //List<int> checkItensType = new List<int>();
                //foreach (var itens in sale.SalesDetails)
                //{
                //    checkItensType.Add(itens.Type);
                //}
                //if(checkItensType.)

                using (var db = new AppDb())
                {
                    db.Database.OpenConnection();
                    //db.Sales.FromSql($"Exec InsertSales");
                    db.Database.ExecuteSql($"Exec InsertSales");
                    foreach (var itens in sale.SalesDetails)
                    {
                        db.Database.ExecuteSql($"Exec InsertSalesDetails {itens.FK_Stock_IdItem} , {itens.Quantity}");
                    }
                    var types = db.Set<SaleTypeDTO>().FromSql($"EXEC SaleTypes").AsEnumerable().Select(c => c.Type).Distinct().ToList();

                    var total = db.Sales.FromSql($"Exec TotalPrice").AsEnumerable().FirstOrDefault();

                    if (total.Price == 0 || total.Price == null)
                    {
                        return 0;
                    }

                    decimal fullPrice = total.Price;
                    decimal finalPrice = fullPrice;
                    decimal discount = 0;

                    bool sandwich = types.Contains(1);
                    bool fries = types.Contains(2);
                    bool drink = types.Contains(3);

                    // Aplica desconto baseado na combinação
                    if (sandwich && fries && drink)
                    {
                        finalPrice *= 0.80m;
                        discount = 20;
                    }
                    else if (sandwich && drink)
                    {
                        finalPrice *= 0.85m; 
                        discount = 15;
                    }
                    else if (sandwich && fries)
                    {
                        finalPrice *= 0.90m;
                        discount = 10;
                    }

                    var lastSale = db.Set<SalePKDTO>().FromSql($"Exec LastSale").AsEnumerable().FirstOrDefault();

                    int idOrder = lastSale.PK_Sales;

                    db.Database.ExecuteSql($"Exec UpdateSale {idOrder}, {finalPrice},{discount}");

                    db.Database.CloseConnection();
                    sale.Price = finalPrice;
                    return sale.Price;
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
                        db.Database.ExecuteSql($"Exec UpdateOrder {idOrder}, {itens.FK_Stock_IdItem},{itens.Quantity}");
                    }   
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
                    db.Database.ExecuteSql($"Exec DeleteOrder {idOrder}");
                    db.Database.CloseConnection();
                }
                return true;
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
