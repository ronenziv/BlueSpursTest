using BlueSpursTest.External.Services.Contracts;
using BlueSpursTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlueSpursTest.External.BESTBUYServices.Implementation
{
    internal class BESTBUYProductService : IExternalProductService
    {
        private readonly HttpClient httpClient;
        public BESTBUYProductService()
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.bestbuy.com/v1/products")
            };
        }

        public async Task<Product> GetLowestPriceProductByName(string productName)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"products(name={productName}*)?format=json&show=sku,name,salePrice&sort=salePrice.asc&apiKey={SettingsManager.BestBuyAPIKey}");
            //https://api.bestbuy.com/v1/products(name=pad*)?show=sku,name,salePrice&sort=salePrice.asc&apiKey=pfe9fpy68yg28hvvma49sc89
            response.EnsureSuccessStatusCode();

            //List<BESTBUYProduct> products = await response.Content.ReadAsAsync<List<BESTBUYProduct>>();
            RootObject rootObject = await response.Content.ReadAsAsync<RootObject>();

            return rootObject.products.OrderBy(p => p.salePrice)
                .Select(p => new Product()
                {
                    BestPrice = p.salePrice,
                    Currency = "CAD",
                    Location = "BestBuy",
                    ProductName = p.name
                }).FirstOrDefault();
        }

    }
}

