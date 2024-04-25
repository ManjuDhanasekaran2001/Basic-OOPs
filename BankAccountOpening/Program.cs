using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace BankAccountOpening;
class Program
{
    static List<BankAccount> BankDetail = new List<BankAccount>();
    static void Register()
    {

        Console.Write("Enter your name : ");
        string CustomerName = Console.ReadLine();
        Console.Write("Enter your Balance :");
        double Balance = double.Parse(Console.ReadLine());
        Console.Write("Enter your gender Male,Female,Transgender : ");
        Gender Gender = Enum.Parse<Gender>(Console.ReadLine(), true);
        Console.Write("Enter your phone number : ");
        long Phone = long.Parse(Console.ReadLine());
        Console.Write("Enter your mail id : ");
        string MailID = Console.ReadLine();
        Console.Write("Enter your date of birth : ");
        DateTime DOB = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

        BankAccount BankInformation = new BankAccount(CustomerName, Balance, Gender, Phone, MailID, DOB);
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Your customer id is : " + BankInformation.CustomerID);
        Console.WriteLine("Your Name : "+CustomerName);
        Console.WriteLine("Balance : "+Balance);
        Console.WriteLine("Gender : "+Gender);
        Console.WriteLine("Phone No : "+Phone);
        Console.WriteLine("MailID : "+ MailID);
        Console.WriteLine("Your Date of Birth : "+DOB.ToString("dd/MM/yyyy"));
        Console.WriteLine("---------------------------------------------------");

        BankDetail.Add(BankInformation);

    }

    static void Login()
    {
        Console.Write("Enter your id : ");
        string coustomerid = Console.ReadLine();
        bool found = false;
        foreach (BankAccount Details in BankDetail)
        {
            if (coustomerid == Details.CustomerID)
            {
                found = true;
                SubMenu(Details);
            }
        }
        if (!found)
        {
            Console.WriteLine("Invalid CustomerID");
        }
    }

    static void SubMenu(BankAccount Details)
    {
        while(true){
        Console.WriteLine("Select option \n 1.Deposite \n 2.Withdraw   \n 3.Balane \n 4.Exit");
        int ch = int.Parse(Console.ReadLine());
        switch (ch)
        {
            case 1:
                {
                    Console.Write("Enter your money to deoposit : ");
                    double depositemony = double.Parse(Console.ReadLine());
                    Details.Deposit(depositemony);
                    break;
                }
            case 2:
                {
                    Console.Write("Enter your Money to with draw : ");
                    double withdrawmoney = double.Parse(Console.ReadLine());
                    Details.Withdraw(withdrawmoney);
                    break;
                }
            case 3:
                {
                    Console.WriteLine("The balance Amount is : "+Details.Balance);
                    Console.WriteLine("----------------------------------------");
                    break;
                }

            case 4 :{
                return;
            }

        }
        }
    }
        public static void Main(string[] args)
        {
         
         while(true){
            Console.WriteLine("Select The Option \n 1.Register \n 2.Login \n 3.Exit");
            string choice = Console.ReadLine();
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
        }