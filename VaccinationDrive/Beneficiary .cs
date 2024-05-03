using System;

namespace VaccinationDrive
{
    public enum Gender{Select,Female,Male,Others}
    public class Beneficiary 
    {
        private static int s_registrationNumber= 1000;
        public string RegistrationNumber { get;}

        public string Name { get; set; }
        public int Age { get; set; }

        public Gender Gender { get; set; }

        public string MobileNumber { get; set; }
        public string City { get; set; }


        public Beneficiary(string name, int age, Gender gender, string mobilenumber,string city)
        {
            s_registrationNumber++;
            RegistrationNumber = "BID"+s_registrationNumber;
            Name = name;
            Age = age;
            Gender = gender;
            MobileNumber= mobilenumber;
            City= city;
        }
    }
}
