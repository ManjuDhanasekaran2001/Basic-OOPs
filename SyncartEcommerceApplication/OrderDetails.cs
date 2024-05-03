using System;

namespace EcommerceApplication
{
    public enum OrderStatus {Default,Ordered,Cancelled}
    public class OrderDetails
    {
        
        private static int s_orderId = 1000;

        public string OrderID { get; set; }
        public string  CustomerID { get; set; }
        public string ProductID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime  PurchasedDate { get; set; }
        public int QuantityPurchased { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public OrderDetails(string customerID, string productID,double totalprice, DateTime purchasedDate, int quantity,OrderStatus orderStatus)
        {
            s_orderId++;
            OrderID="OID"+s_orderId;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalprice;
            PurchasedDate=purchasedDate;
            QuantityPurchased=quantity;
            OrderStatus=orderStatus;
        }


    }
}
