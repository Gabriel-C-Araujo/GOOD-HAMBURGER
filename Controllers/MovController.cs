using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GOOD_HAMBURGER.DataBase;


namespace GOOD_HAMBURGER.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MovController : ControllerBase
    {

        [HttpGet]
        [Route("/allproducts")]
        public void All() 
        {
            var request = new RequestDb();
            try
            {
                var products = request.ProductsAll();
            }
            catch (Exception ex) 
            {
                BadRequest($"Error on products list. Check all registers to identify. Exception error: {ex} ");
                throw ex;
            }
        }

        [HttpGet]
        [Route("/productssandwich")]
        public void ProductsSandwich(int Type)
        {
            var request = new RequestDb();
            try
            {
                var products = request.ProductsSandwich(Type);
            }
            catch (Exception ex)
            {
                BadRequest($"Error on products list. Check registers with type {Type}. Exception error: {ex} ");
                throw ex;
            }
        }

        [HttpGet]
        [Route("/ProductsType")]
        public void ProductsType(int Type)
        {
            var request = new RequestDb();
            try
            {
                var products = request.ProductsType(Type);
            }
            catch (Exception ex)
            {
                BadRequest($"Error on products list. Check registers with type {Type}. Exception error: {ex} ");
                throw ex;
            }
        }
    }
}
