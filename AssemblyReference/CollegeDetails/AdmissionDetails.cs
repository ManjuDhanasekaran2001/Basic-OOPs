using System;

namespace  CollegeDetails
{
    //Enum Declaration
    public enum AdmissionStatus{Select, Amitted, Cancelled}
    public class AdmissionDetails
    {
    /*
    a.	AdmissionID – (Auto Increment ID - AID1001)
    b.	StudentID
    c.	DepartmentID
    d.	AdmissionDate
    e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)

    */

    //Field 
    //static field
    private static int s_admissionID = 1000;

    //property
    public string AdmissionID { get;}//Read only Property

    public string StudentID { get; set; }
    public string DepartmentID { get; set; }
    public DateTime AdmissionDate { get; set; }
    public AdmissionStatus AdmissionSatus { get; set; }

    //Constructor
    public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus admissionStatus){
        //Auto Incrematation
        s_admissionID++;

        AdmissionID="AID"+s_admissionID;
        StudentID=studentID;
        DepartmentID=departmentID;
        AdmissionDate=admissionDate;
        AdmissionSatus=admissionStatus;
    }
    }
}
