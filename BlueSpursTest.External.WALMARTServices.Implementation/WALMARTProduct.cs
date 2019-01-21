using System.Collections.Generic;

namespace BlueSpursTest.External.WALMARTServices.Implementation
{
    public class GiftOptions
    {
    }

    public class ImageEntity
    {
        public string thumbnailImage { get; set; }
        public string mediumImage { get; set; }
        public string largeImage { get; set; }
        public string entityType { get; set; }
    }

    public class Item
    {
        public int itemId { get; set; }
        public int parentItemId { get; set; }
        public string name { get; set; }
        public double salePrice { get; set; }
        public string upc { get; set; }
        public string categoryPath { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string thumbnailImage { get; set; }
        public string mediumImage { get; set; }
        public string largeImage { get; set; }
        public string productTrackingUrl { get; set; }
        public double standardShipRate { get; set; }
        public bool marketplace { get; set; }
        public string sellerInfo { get; set; }
        public string productUrl { get; set; }
        public string customerRating { get; set; }
        public int numReviews { get; set; }
        public string customerRatingImage { get; set; }
        public string categoryNode { get; set; }
        public string rhid { get; set; }
        public bool bundle { get; set; }
        public string stock { get; set; }
        public string addToCartUrl { get; set; }
        public string affiliateAddToCartUrl { get; set; }
        public bool freeShippingOver35Dollars { get; set; }
        public GiftOptions giftOptions { get; set; }
        public List<ImageEntity> imageEntities { get; set; }
        public string offerType { get; set; }
        public bool availableOnline { get; set; }
    }

    public class RootObject
    {
        public string query { get; set; }
        public string sort { get; set; }
        public string responseGroup { get; set; }
        public int totalResults { get; set; }
        public int start { get; set; }
        public int numItems { get; set; }
        public List<Item> items { get; set; }
        public List<object> facets { get; set; }
    }

    /*public class WALMARTProduct
    {
        /// <summary>ITEM ID</summary>
        public long itemId { get; set; }

        /// <summary>NAME</summary>
        public string name { get; set; }

        /// <summary>sale price</summary>
        public string salePrice { get; set; }
    }*/
}
