using BlueSpursTest.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BlueSpursTest.BL.Contracts
{
    /// <summary>
    /// Handles buisness logic
    /// </summary>
    public interface IBL
    {
        /// <summary>get product by ID</summary>
        /// <param name="ID">the ID of the product</param>
        /// <returns>the product</returns>
        Task<Product> GetLowestPriceProduct(int ID);


        /// <summary>get product by name</summary>
        /// <param name="productName">the name of the product</param>
        /// <returns>the product</returns>
        Task<Product> GetLowestPriceProductByName(string productName);

    }
}
