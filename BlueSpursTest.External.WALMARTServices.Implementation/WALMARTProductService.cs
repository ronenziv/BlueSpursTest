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
            //BaseAddress = new Uri("https://api.bestbuy.com/v1/products/8880044.json?show=sku,name,salePrice&apiKey=YourAPIKey")
        }

        public async Task<Product> GetLowestPriceProduct(int ID)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"(name={ID}*)?format=json&show=itemId,name,salePrice&sort=price&ord=asc&count=1&apiKey=rm25tyum3p9jm9x9x7zxshfa");
            response.EnsureSuccessStatusCode();
            //List<WALMARTProduct> products = await response.Content.ReadAsAsync<List<WALMARTProduct>>();
            RootObject rootObject = await response.Content.ReadAsAsync<RootObject>();

            return rootObject.items.OrderBy(p => p.salePrice)
                .Select(p => new Product()
                {
                    ID = p.itemId,
                    BestPrice = p.salePrice,
                    Currency = "CAD",
                    Location = "Wallmart",
                    ProductName = p.name
                }).FirstOrDefault();
        }

        public async Task<Product> GetLowestPriceProductByName(string productName)
        {
        //http://api.walmartlabs.com/v1/search?query=apple&format=json&apiKey=rm25tyum3p9jm9x9x7zxshfa&sort=price&ord=asc&numItems=1
            HttpResponseMessage response = await httpClient.GetAsync($"?query={productName}&format=json&apiKey=rm25tyum3p9jm9x9x7zxshfa&sort=price&ord=asc&numItems=1");
            response.EnsureSuccessStatusCode();
            //List<WALMARTProduct> products = await response.Content.ReadAsAsync<List<WALMARTProduct>>();
            RootObject rootObject = await response.Content.ReadAsAsync<RootObject>();

            return rootObject.items.OrderBy(p => p.salePrice)
                .Select(p => new Product()
                {
                    ID = p.itemId,
                    BestPrice = p.salePrice,
                    Currency = "CAD",
                    Location = "Wallmart",
                    ProductName = p.name
                }).FirstOrDefault();
        }

    }
}

