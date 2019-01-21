using BlueSpursTest.External.Services.Contracts;
using BlueSpursTest.Models;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlueSpursTest.External.WALMARTServices.Implementation
{
    internal class WALMARTProductService : IExternalProductService
    {
        private readonly HttpClient httpClient;
        public WALMARTProductService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://api.walmartlabs.com/v1/search")
            };
        }

        public async Task<Product> GetLowestPriceProductByName(string productName)
        {
        //http://api.walmartlabs.com/v1/search?query=apple&format=json&apiKey=rm25tyum3p9jm9x9x7zxshfa&sort=price&ord=asc&numItems=1
            HttpResponseMessage response = await httpClient.GetAsync($"?query={productName}&format=json&apiKey={SettingsManager.WallmartAPIKey}&sort=price&ord=asc&numItems=1");
            response.EnsureSuccessStatusCode();
            RootObject rootObject = await response.Content.ReadAsAsync<RootObject>();

            return rootObject.items.OrderBy(p => p.salePrice)
                .Select(p => new Product()
                {
                    BestPrice = p.salePrice,
                    Currency = "CAD",
                    Location = "Wallmart",
                    ProductName = p.name
                }).FirstOrDefault();
        }

    }
}

