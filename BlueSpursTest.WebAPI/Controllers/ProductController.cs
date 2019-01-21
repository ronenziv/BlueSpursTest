using Aleph1.WebAPI.ExceptionHandler;
using BlueSpursTest.BL.Contracts;
using BlueSpursTest.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace BlueSpursTest.WebAPI.Controllers
{
    /// <summary>Handle Product actions</summary>
    public class ProductController : ApiController
    {
        private readonly IBL BL;

 
        /// <summary>Initializes a new instance of the <see cref="ProductController"/> class.</summary>
        /// <param name="BL">The BL</param>
        public ProductController(IBL BL)
        {
            this.BL = BL;
        }
        
        /// <summary>get lowest price product by Name</summary>
        /// <param name="name">the name of the product</param>
        /// <returns>the lowest product by name</returns>
        [HttpGet, Route("api/search"), FriendlyMessage("there was error on try get this product")]
        public async Task<Product> GetLowestPriceProductByName(string name)
        {
            return await BL.GetLowestPriceProductByName(name) ?? throw new Exception("Product Not Found");
        }
    }
}