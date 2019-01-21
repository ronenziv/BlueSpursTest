using System.ComponentModel;

namespace BlueSpursTest.Models
{
    /// <summary>product details</summary>
    public class Product
    {
        /// <summary>ID</summary>
        [DisplayName(@"ID")]
        public long ID { get; set; }

        /// <summary>Product Name</summary>
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        /// <summary>Best Price</summary>
        [DisplayName("Best Price")]
        public double BestPrice { get; set; }

        /// <summary>Currency</summary>
        [DisplayName("Currency")]
        public string Currency { get; set; }

        /// <summary>Location</summary>
        [DisplayName("Location")]
        public string Location { get; set; }

    }
}
