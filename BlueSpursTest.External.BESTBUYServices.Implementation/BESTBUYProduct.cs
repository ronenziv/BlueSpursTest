using System.Collections.Generic;

namespace BlueSpursTest.External.BESTBUYServices.Implementation
{
    public class BESTBUYProduct
    {
        /// <summary>SKU ID</summary>
        public int sku { get; set; }

        /// <summary>NAME</summary>
        public string name { get; set; }

        /// <summary>sale price</summary>
        public double salePrice { get; set; }
    }

    public class RootObject
    {
        public int from { get; set; }
        public int to { get; set; }
        public int currentPage { get; set; }
        public int total { get; set; }
        public int totalPages { get; set; }
        public string queryTime { get; set; }
        public string totalTime { get; set; }
        public bool partial { get; set; }
        public string canonicalUrl { get; set; }
        public List<BESTBUYProduct> products { get; set; }
    }
}
