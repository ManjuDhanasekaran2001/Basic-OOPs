using System;

namespace VaccinationDrive
{
        public class Vaccination
    {
        private static int s_vaccinationID = 3000;
        public string VaccinationID { get; }

        public string RegistrationNumber { get; set; }
         public string VaccineID { get; set; }
         public int DoesNumber { get; set; }
         public DateTime VaccinatedDate{ get; set; }

         public Vaccination(string registrationNumber,string vaccineID,int doesNumber,DateTime vaccinatedDate)
         {
            s_vaccinationID++;
            VaccinationID= "VID"+s_vaccinationID;
            RegistrationNumber = registrationNumber;
            VaccineID = vaccineID;
            DoesNumber = doesNumber;
            VaccinatedDate=vaccinatedDate;

         }

    }
}
