using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VaccinationDrive
{
    public static class Operations
    {
        static Beneficiary currentUser;
        static List<Beneficiary> beneficiaryList = new List<Beneficiary>();
        static List<Vaccine> vaccineList = new List<Vaccine>();
        static List<Vaccination> vaccinationList = new List<Vaccination>();

        public static void ManiMenu()
            {
                Console.WriteLine("WelCome To Online Shopping App");
                string temp = "yes";
                do
                {

                    Console.WriteLine($"1. Beneficiary Registration \n2. Login\n3. Get Vaccine Info\n4. Exit");
                    Console.Write("Selct The Option");
                    int MainChoice = int.Parse(Console.ReadLine());
                    switch (MainChoice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Welcome to Beneficiary Registration");
                                BeneficiaryRegistartion();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Welcome to  Login");
                                Login();
                                break;
                            }
                            case 3:
                            {
                                Console.WriteLine("Welcome to GetVaccineInfo");
                                GetVaccineInfo();
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Application Exited Successfullu");
                                temp = "no";
                                break;
                            }
                    }
                } while (temp == "yes");

            }
        public static void BeneficiaryRegistartion(){
            Console.Write("Entert your NAme : ");
            string name = Console.ReadLine();
            Console.Write("Enter your Age : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter your Gender Female,Male,Others : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your MobliNumber : ");
            string mobile = Console.ReadLine();
            Console.Write("Enter your city : ");
            string city = Console.ReadLine();
            Beneficiary  person =  new Beneficiary(name,age,gender,mobile,city);
            beneficiaryList.Add(person);
            Console.WriteLine("Your registerNumber is : "+person.RegistrationNumber);


        }

        public static void Login(){
             Console.Write("Entre the Registration Number : ");
                string userRegisterNumber = Console.ReadLine().ToUpper();
                bool flag = true;
                foreach (Beneficiary person in beneficiaryList)
                {
                    if (userRegisterNumber.Equals(person.RegistrationNumber))
                    {
                        currentUser = person;
                        flag = false;
                        SubMenu();
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Invalid user ID");
                }
        }
        public static void SubMenu(){
             string temp = "yes";
                do
                {
                    Console.WriteLine("********SubMenu**********");
                    Console.WriteLine("1. Show MyDetails\n2. Take Vaccine\n3. my Vaccination history\n4. Next Due Date\n5. Exit");
                    Console.Write("Select The Option : ");
                    int mainChoice = int.Parse(Console.ReadLine());
                    switch (mainChoice)
                    {
                        case 1:
                            {
                                Console.WriteLine("***********ShowMyDetailss*************");
                                ShowMyDetails();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("************TakeVaccinations************");
                                TakeVaccination();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("********MyVaccinationHistory***********");
                                MyVaccinationHistory();
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("*************NextDueDate*************");
                                NextDueDate();
                                break;
                            }
                       
                        case 5:
                            {
                                Console.WriteLine("return to the Main Menu");
                                temp = "no";
                                break;
                            }

                    }
                } while (temp == "yes");
        }
public static void ShowMyDetails(){
    foreach(Beneficiary person in beneficiaryList){
        if(currentUser.RegistrationNumber.Equals(person.RegistrationNumber)){
            Console.WriteLine("RegisterNumber : "+person.RegistrationNumber);
            Console.WriteLine("Name  : "+person.Name);
             Console.WriteLine("Age  : "+person.Age);
              Console.WriteLine("Gender  : "+person.Gender);
               Console.WriteLine("Mobile Number  : "+person.MobileNumber);
                Console.WriteLine("City  : "+person.City);

        }
    }
}
public  static void TakeVaccination(){
    GetVaccineInfo();
    Vaccination vaccinartion2= null;
    int does = 0;
    Console.Write("Select The Vaccine ID  : ");
    string userPickedID = Console.ReadLine();
    bool flag = true;
    foreach(Vaccine vaccine in vaccineList){

        if(userPickedID.Equals(vaccine.VaccineID))
        {
            flag = false;
            foreach(Vaccination vaccination in vaccinationList)
            {
                if(currentUser.RegistrationNumber.Equals(vaccination.RegistrationNumber)){
                  vaccinartion2 = vaccination;
                  does = vaccination.DoesNumber;
                }
            }
            
               if(does<3&&does>0){
                      if(userPickedID.Equals(vaccinartion2.VaccineID))
                      {    
                           vaccine.NoOfDoseAvailable-=1;
                           Vaccination vaccination1 = new Vaccination(currentUser.RegistrationNumber,userPickedID,does+1,DateTime.Now);
                           vaccinationList.Add(vaccination1);
                           Console.WriteLine("Vaccinated Sucessfuly");
                      }
                      else {
                        Console.WriteLine("Picked Wrong Vaccine");
                      }
               }
               else if(does==3){
                   Console.WriteLine("All the three Vaccination are completed, you cannot be vaccinated now");
               }
               else{
                  if(currentUser.Age>14){
                        Vaccination vaccination1 = new Vaccination(currentUser.RegistrationNumber,userPickedID,does+1,DateTime.Now);
                        vaccinationList.Add(vaccination1);
                        vaccine.NoOfDoseAvailable-=1;
                        Console.WriteLine("Vaccinated Sucessfuly");
                  }
                  else{
                    Console.WriteLine("Not Eligible for Vaccination");
                  }
               }
            
        }

    }
    if(flag){
        Console.WriteLine("Invalid vaccineID");
    }
}
public static void MyVaccinationHistory(){
    bool flag = true;
    Console.WriteLine("VaccinationID	RegisterNumber	VaccineID	DoseNumber	VaccinatedDate");
    foreach(Vaccination vaccination in vaccinationList){
        if(currentUser.RegistrationNumber.Equals(vaccination.RegistrationNumber)){
            flag =false;
            Console.WriteLine($"{vaccination.VaccinationID}|{vaccination.RegistrationNumber}|{vaccination.VaccineID}|{vaccination.DoesNumber}|{vaccination.VaccinatedDate.ToString("dd/MM/yyyy")}|");
        }
    }
    if(flag){
        Console.WriteLine("No vaccine History is Found");
    }
}
public static void NextDueDate(){
    Vaccination vaccinartion2= null;
    int does = 0;
    foreach(Vaccination vaccination in vaccinationList)
            {
                if(currentUser.RegistrationNumber.Equals(vaccination.RegistrationNumber)){
                  vaccinartion2 = vaccination;
                  does = vaccination.DoesNumber;
                }
            }

            if(does<3&&does>0){

                

                Console.WriteLine("Your Due Date is "+vaccinartion2.VaccinatedDate.AddDays(30).ToString("dd/MM/yyyy"));

            }
            else if(does==3){
                Console.WriteLine("You have completed all vaccination. Thanks for your participation in the vaccination drive.");
            }
            else{
                Console.WriteLine("you can take the vaccine now");
            }

}


        public static void GetVaccineInfo(){
            Console.WriteLine("VaccineID|VaccineName|NoOdDoesAvailable");
            foreach(Vaccine vaccine in vaccineList){
                Console.WriteLine($"{vaccine.VaccineID}|{vaccine.VaccineName}|{vaccine.NoOfDoseAvailable}|");
            }
        }
        public static void AddDefault(){

            Beneficiary beneficiary1 = new Beneficiary("Ravichandran",21,Gender.Male,"8484484","Chennai");
            Beneficiary beneficiary2 = new Beneficiary("Baskarn",22,Gender.Male,"8484487","Chennai");
            beneficiaryList.Add(beneficiary1);
             beneficiaryList.Add(beneficiary2);

             Vaccine vaccine1 = new Vaccine(VaccineName.Covishield,50);
             Vaccine vaccine2 = new Vaccine(VaccineName.Covaccine,50);

             vaccineList.Add(vaccine1);
             vaccineList.Add(vaccine2);

             Vaccination vaccination1 =new Vaccination("BID1001","CID2001",1,new DateTime(2021,11,11));
             Vaccination vaccination2 =new Vaccination("BID1001","CID2001",2,new DateTime(2022,03,11));
             Vaccination vaccination3 =new Vaccination("BID1002","CID2002",1,new DateTime(2022,04,04));
             vaccinationList.Add(vaccination1);
              vaccinationList.Add(vaccination2);
               vaccinationList.Add(vaccination3);

        }
    }
}
