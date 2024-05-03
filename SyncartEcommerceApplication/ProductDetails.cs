using System;

namespace EcommerceApplication
{
    public class ProductDetails
    {
        private static int s_productID = 100;
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        
        public int Stock { get; set; }

        public int ShippingDuriation { get; set; }

        public ProductDetails(string productName, int stock, double price, int duriation)
        {
            s_productID++;
            ProductID="PID"+s_productID;
            ProductName=productName;
            Price=price;
            Stock=stock;
            ShippingDuriation=duriation;

        }
    }
}
