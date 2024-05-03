using System;

namespace VaccinationDrive
{
    public enum VaccineName {Selected,Covishield, Covaccine}
    public class Vaccine
    {
        private static int s_vaccineID= 2000;
        public string VaccineID { get;}
        public VaccineName VaccineName { get; set; }
        public int NoOfDoseAvailable { get; set; }

        public Vaccine(VaccineName vaccinename, int noOfDoseAvailable)
        {
            s_vaccineID++;
            VaccineID="CID"+s_vaccineID;
            VaccineName=vaccinename;
            NoOfDoseAvailable=noOfDoseAvailable;
        }
    }
}
