using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATZClient.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public int Quantily { get; set; }
        public string ImageUrl { get; set; }      
        public string Color { get; set; }
    }
}