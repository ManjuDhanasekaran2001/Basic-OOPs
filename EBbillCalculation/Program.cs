using System;
using System.Collections.Generic;
using System.Transactions;
namespace EBbillCalculation;
class Program{
    static List<EBDetails> EBbill = new List<EBDetails>();
    public static void Main(string[] args)
    {
        while(true){
            Console.WriteLine("Select The Option \n 1.Register \n 2.Login \n 3.Exit");
           
            string choice = Console.ReadLine();
             Console.WriteLine("------------------------------------------------------");
            switch(choice){
                case "1":{
                    Register();
                    break;
                }
                case "2":{
                    Login();
                    break;
                }
                case "3":{
                    return;
                }
            }
         }
    
    }
    static void Register(){
        Console.Write("Enter your Name : ");
        string userName = Console.ReadLine();
        Console.Write("Enter phone number : ");
        long phoneNo = long.Parse(Console.ReadLine());
        Console.Write("Enter your MailID : ");
        string mailid = Console.ReadLine();
        Console.Write("Enter the usedUnit : ");
        double units=double.Parse(Console.ReadLine());

        EBDetails Bill = new EBDetails(userName,phoneNo,mailid,units);
        EBbill.Add(Bill);
        Console.WriteLine("MeterID ID : "+Bill.MeterID);

    }
    static void Login(){
         Console.Write("Enter your id : ");
        string meterid = Console.ReadLine();
        bool found = false;
        foreach (EBDetails Details in EBbill)
        {
            if (meterid== Details.MeterID)
            {
                found = true;
                SubMenu(Details);
            }
        }
        if (!found)
        {
            Console.WriteLine("Invalid MeterID");
        }
    }
    static void SubMenu(EBDetails Details){

        while(true){
        Console.WriteLine("Select option \n 1.Calculate Bill \n 2.Display Details  \n 3. Exit");
        
        int ch = int.Parse(Console.ReadLine());
        Console.WriteLine("----------------------------------------------------");
        switch (ch)
        {
            case 1:
                {
                    Console.Write("Enter the used units : ");
                    double units = double.Parse(Console.ReadLine());
                    Details.CalculateAmount(units);
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Meter ID : "+Details.MeterID);
                    Console.WriteLine("UserName : "+Details.UserName);
                    Console.WriteLine("Phone Number : "+Details.PhoneNo);
                    Console.WriteLine("Mail ID : "+Details.MailID);
                    Console.WriteLine("----------------------------------------------------------");

                    break;
                }
            case 3:
                {
                    return;
                }

           

        }
        }

    }
}
