using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GOOD_HAMBURGER.DataBase;
using Microsoft.IdentityModel.Tokens;
using GOOD_HAMBURGER.Entity;


namespace GOOD_HAMBURGER.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MovController : ControllerBase
    {

        [HttpGet]
        [Route("/allproducts")]
        public IActionResult All() 
        {
            var request = new RequestDb();
            try
            {
                var products = request.ProductsAll();
                if (products.IsNullOrEmpty())
                {
                    BadRequest($"Error on products list. Check all registers to identify.");
                    throw new Exception();
                }
                ;
                return products == null ? NotFound() : Ok(products);
            }
            catch (Exception ex) 
            {
                return NotFound($"Error on products list. Check all registers to identify. Exception error: {ex} ");
            }
        }

        [HttpGet]
        [Route("/productssandwich")]
        public IActionResult ProductsSandwich(int Type)
        {
            var request = new RequestDb();
            try
            {
                var products = new List<Entity.Stock>();
                products = request.ProductsSandwich(Type);
                if (products.IsNullOrEmpty())
                {
                    BadRequest($"Error on products list. Check all registers to identify.");
                    throw new Exception();
                };
                return products == null ? NotFound() : Ok(products);
            }
            catch (Exception ex)
            {
                return NotFound($"Error on products list. Check registers with type {Type}. Exception error: {ex}");
            }
        }

        [HttpGet]
        [Route("/productstype")]
        public IActionResult ProductsType(int Type)
        {
            var request = new RequestDb();
            try
            {
                var products = new List<Entity.Stock>();
                products = request.ProductsType(Type);
                if (products.IsNullOrEmpty())
                {
                    BadRequest($"Error on products list. Check all registers to identify.");
                    throw new Exception();
                }
                ;
                return products == null ? NotFound() : Ok(products);
            }
            catch (Exception ex)
            {
                return NotFound($"Error on products list. Check registers with type {Type}. Exception error: {ex}");
            }
        }

        [HttpGet]
        [Route("/listorder")]
        public IActionResult ListOrder()
        {
            var request = new RequestDb();
            try
            {
                var order = new List<Entity.Sales>();
                order = request.ListOrder();
                if (order.IsNullOrEmpty())
                {
                    BadRequest($"Error on orders list. Check all registers to identify.");
                    throw new Exception();
                }
                ;
                return order == null ? NotFound() : Ok(order);
            }
            catch (Exception ex)
            {
                return NotFound($"Error on orders list. Check registers. Exception error: {ex}");
            }
        }

        [HttpPost]
        [Route("/insertorder")]
        public IActionResult InsertOrder(Sales Order)
        {
            var request = new RequestDb();

            using var db = new AppDb();
            var itemIds = Order.SalesDetails.Select(c => c.FK_Stock_IdItem).ToList();

            var types = db.Stock.Where(d => itemIds.Contains(d.PK_Stock)).Select(d => new { d.PK_Stock, d.Type }).ToList();

            var typeCount = Order.SalesDetails.Join(types,detail => detail.FK_Stock_IdItem,stock => stock.PK_Stock,(detail, stock) => stock.Type).GroupBy(t => t).ToDictionary(g => g.Key, g => g.Count());

            // 3. Validar se há mais de um item do mesmo tipo
            var typeDuplicate = typeCount.Where(e => e.Value > 1).Select(e => e.Key).ToList();

            if (typeDuplicate.Any())
            {
                return BadRequest($"Just one type of each item. Repeat itens with same type: {string.Join(", ", typeDuplicate)}");
            }

            try
            {
                var sales = request.InsertOrder(Order);
                if (sales == 0)
                {
                    BadRequest($"Error on products list. Check all registers to identify.");
                    throw new Exception();
                };
                return Ok(String.Concat(sales, " to pay"));
            }
            catch (Exception ex)
            {
                return NotFound($"Error on products list. Check registers with type {Order}. Exception error: {ex}");
            }
        }

        [HttpPut]
        [Route("/updateorder")]
        public IActionResult UpdateOrder(int idOrder, Sales changeOrder)
        {
            var request = new RequestDb();
            try
            {
                var result = request.UpdateOrder(idOrder, changeOrder);
                if (!result)
                {
                    BadRequest($"Error on products list. Check all registers to identify.");
                    throw new Exception();
                }
                ;
                return result == false ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound($"Error on products list. Check registers with type {idOrder}. Exception error: {ex}");
            }
        }

        [HttpDelete]
        [Route("/deleteorder")]
        public IActionResult DeleteOrder(int idOrder)
        {
            var request = new RequestDb();
            try
            {
                var result = request.DeleteOrder(idOrder);
                if (!result)
                {
                    BadRequest($"Error on products list. Check all registers to identify.");
                    throw new Exception();
                };                
                return result == false ? NotFound("Not deleted") : Ok("Delete successfully");
            }
            catch (Exception ex)
            {
                return NotFound($"Error on products list. Check registers with type {idOrder}. Exception error: {ex}");
            }
        }
    }
}
