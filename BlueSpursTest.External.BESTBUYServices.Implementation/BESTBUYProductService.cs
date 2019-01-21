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
            //BaseAddress = new Uri("https://api.bestbuy.com/v1/products/8880044.json?show=sku,name,salePrice&apiKey=YourAPIKey")
        }

        public async Task<Product> GetLowestPriceProduct(int ID)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"(name=*{ID}*)?format=json&show=sku,name,salePrice&apiKey=YourAPIKey");
            response.EnsureSuccessStatusCode();
            List<BESTBUYProduct> products = await response.Content.ReadAsAsync<List<BESTBUYProduct>>();

            return products.OrderBy(p => p.salePrice)
                .Select(p => new Product() {
                    ID = p.sku,
                    BestPrice = p.salePrice,
                    Currency = "CAD",
                    Location = "Bestbuy",
                    ProductName = p.name
            }).FirstOrDefault();
        }

        public async Task<Product> GetLowestPriceProductByName(string productName)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"products(name={productName}*)?format=json&show=sku,name,salePrice&sort=salePrice.asc&apiKey=pfe9fpy68yg28hvvma49sc89");
            //https://api.bestbuy.com/v1/products(name=pad*)?show=sku,name,salePrice&sort=salePrice.asc&apiKey=pfe9fpy68yg28hvvma49sc89
            response.EnsureSuccessStatusCode();
            string s = await response.Content.ReadAsStringAsync(); 

            //List<BESTBUYProduct> products = await response.Content.ReadAsAsync<List<BESTBUYProduct>>();
            RootObject rootObject = await response.Content.ReadAsAsync<RootObject>();

            return rootObject.products.OrderBy(p => p.salePrice)
                .Select(p => new Product()
                {
                    ID = p.sku,
                    BestPrice = p.salePrice,
                    Currency = "CAD",
                    Location = "BestBuy",
                    ProductName = p.name
                }).FirstOrDefault();
        }

    }
}

