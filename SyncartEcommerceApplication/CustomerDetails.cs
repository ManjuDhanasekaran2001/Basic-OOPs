using System;
using System.Runtime.CompilerServices;

namespace EcommerceApplication
{
    public class CustomerDetails
    {
        private static int s_customerID = 1000;
        public string CustomerID { get; set; }
        public string Name  { get; set; }
        public string City { get; set; }
        public long PhoneNo{ get; set; }
        public double Balance { get; set; }
        public string Mail { get; set; }

        public CustomerDetails(string name, string city, long phoneNo, double balance,string mail)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            Name=name;
            City=city;
            PhoneNo=phoneNo;
            Balance=balance;
            Mail=mail;

        }
        public void WalletRecharge(double rechargeAmount){

            Balance+=rechargeAmount;
            Console.WriteLine("Your Wallet Balance iS : "+Balance);
        }

        public void DeductBalance(double price)
        {
           Balance-=price;
           Console.WriteLine("Your Balance IS : "+Balance);
        }
    }
}
