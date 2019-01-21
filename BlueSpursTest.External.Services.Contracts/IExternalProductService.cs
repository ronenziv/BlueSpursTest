using BlueSpursTest.Models;
using System.Threading.Tasks;

namespace BlueSpursTest.External.Services.Contracts
{
    /// <summary>
    /// Handles data access
    /// </summary>
    public interface IExternalProductService
    {
        /// <summary>get product by name</summary>
        /// <param name="productName">the name of the product</param>
        /// <returns>the product</returns>
        Task<Product> GetLowestPriceProductByName(string productName);
    }
}
