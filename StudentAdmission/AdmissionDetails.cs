using System;

namespace StudentAdmission
{
    public enum AdmissionStatus {Select, Admitted, Cancelled}
    public class AdmissionDetails
    {
        private static int s_admissionID = 1000;
        public string AdmissionID { get; }
        public string  StudentID{ get; set; }
        public string DepartmentID{ get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus AdmissionStatus{ get; set; }

       
        public AdmissionDetails(string studentID){
            StudentID=studentID;
        }

        public AdmissionDetails(string studentID, string departmentId,DateTime admissionDate,  AdmissionStatus admissionStatus){
            s_admissionID++;
            AdmissionID="AID"+s_admissionID;
            StudentID=studentID;
            DepartmentID=departmentId;
            AdmissionDate=admissionDate;
            AdmissionStatus=admissionStatus;

        }
    }

    
}
