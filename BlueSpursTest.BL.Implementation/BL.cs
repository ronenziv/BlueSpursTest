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

        public async Task<Product> GetLowestPriceProductByName(string productName)
        {
            List<Product> items = new List<Product>();
            foreach (IExternalProductService service in ExternalProductService)
            {
                Product pr = await service.GetLowestPriceProductByName(productName);
                items.Add(pr);
            }

            return items.OrderBy(i => i.BestPrice).First();
        }
    }
}

