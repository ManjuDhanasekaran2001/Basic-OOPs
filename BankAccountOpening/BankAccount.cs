using System;

namespace BankAccountOpening
{
    public enum Gender { Select, Male, Female, Transgender }

    public class BankAccount
    {
        private static int s_customerID = 1000;

        public string CustomerID { get; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }

        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string MailID { get; set; }
        public DateTime DOB { get; set; }

        public BankAccount(string customername, double balance, Gender gender, long phone, string mailid, DateTime dob){

            s_customerID++;
            CustomerID="HDFC"+s_customerID;
            CustomerName=customername;
            Balance=balance;
            Gender=gender;
            Phone=phone;
            MailID=mailid;
            DOB=dob;

        }


        public void Deposit(double depositAmount)
        {
            Balance += depositAmount;

            Console.WriteLine("Total Balance is" + Balance);
            Console.WriteLine("----------------------------------------");

        }

        public void Withdraw(double withdrawAmount)
        {   if(withdrawAmount<=Balance){
            Balance -= withdrawAmount;
            Console.WriteLine("Total Balance is " + Balance);
            Console.WriteLine("----------------------------------------");
        }
        else{
            Console.WriteLine("Your Balance is less than the Withdraw Amount");
        }

        }
    }



}
