using BlueSpursTest.BL.Contracts;
using BlueSpursTest.External.Services.Contracts;
using BlueSpursTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BlueSpursTest.BL.Implementation
{
    internal class BL : IBL
    {
        private readonly IExternalProductService [] ExternalProductService;

        public BL(IExternalProductService [] ExternalProductService)
        {
            this.ExternalProductService = ExternalProductService;
        }

        public async Task<Product> GetLowestPriceProduct(int ID)
        {
            return await ExternalProductService[0].GetLowestPriceProduct(ID);
        }

        public async Task<Product> GetLowestPriceProductByName(string productName)
        {
            //return await ExternalProductService.GetLowestPriceProductByName(productName);
            Product productBestBuy = await ExternalProductService[0].GetLowestPriceProductByName(productName);
            Product productWalmart = await ExternalProductService[1].GetLowestPriceProductByName(productName);
            IEnumerable<Product> items = new List<Product>() { productBestBuy, productWalmart };
            Product lowest = items.OrderByDescending(i => i.BestPrice).Last();
            return lowest;
        }
    }
}

