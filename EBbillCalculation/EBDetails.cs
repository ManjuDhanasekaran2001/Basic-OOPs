using System;

namespace EBbillCalculation
{
    public class EBDetails
    {
        private static int s_meterID=1000;
         public string MeterID { get; set; }
         public string UserName { get; set; }
         public long PhoneNo { get; set; }
         public string MailID { get; set; }
         public double UnitsUsed { get; set; }

         public EBDetails(string userName, long phoneNo, string mailID,double unitUsed){
            s_meterID++;
            MeterID="EB"+s_meterID;
            UserName=userName;
            PhoneNo=phoneNo;
            MailID=mailID;
            UnitsUsed=unitUsed;
         }

         public void CalculateAmount(double units){
            double amount = units*5;
            Console.WriteLine("Bill ID : "+MailID);
            Console.WriteLine("User Name : "+UserName);
            Console.WriteLine("Unit : "+UnitsUsed);
            Console.WriteLine("Amount : "+amount);

         }
    }


}
