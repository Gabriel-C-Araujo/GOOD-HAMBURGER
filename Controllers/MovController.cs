using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GOOD_HAMBURGER.DataBase;
using Microsoft.IdentityModel.Tokens;


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
        public IActionResult ListOrder(int Type)
        {
            var request = new RequestDb();
            try
            {
                var order = new List<Entity.Sales>();
                order = request.ListOrder();
                if (order.IsNullOrEmpty())
                {
                    BadRequest($"Error on products list. Check all registers to identify.");
                    throw new Exception();
                }
                ;
                return order == null ? NotFound() : Ok(order);
            }
            catch (Exception ex)
            {
                return NotFound($"Error on products list. Check registers with type {Type}. Exception error: {ex}");
            }
        }

        [HttpPost]
        [Route("/insertorder")]
        public IActionResult InsertOrder(int Type)
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

        [HttpPut]
        [Route("/updateorder")]
        public IActionResult UpdateOrder(int Type)
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

        [HttpDelete]
        [Route("/productstype")]
        public IActionResult DeleteOrder(int Type)
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
    }
}
