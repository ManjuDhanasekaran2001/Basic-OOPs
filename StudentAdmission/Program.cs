using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace StudentAdmission;
class Program{
    static List<StudentDetails>  StudentDetail= new List<StudentDetails>();
    static List<DepartmentDetails>  DepartmentDetail = new List<DepartmentDetails>();
    static List<AdmissionDetails>  AdmissionDetail = new List<AdmissionDetails>();


    static void Register(){
        Console.Write("Emter Your Name : ");
        string studentName=Console.ReadLine();
        Console.Write("Enter Your Father Name : ");
        string fatherName=Console.ReadLine();
        Console.Write("Enter Your Date of Birth (dd/MM/yyyy) : ");
        DateTime dob;
            bool tempDob = DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out dob);
            while(!tempDob){
                 System.Console.WriteLine("Invalid Input. Enter a valid date");
                 tempDob = DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyyy",null,System.Globalization.DateTimeStyles.None,out dob);
            }
        
        Console.Write("Enter your Gender(Male,Female,Transgender) : ");
        Gender gender;
        bool tempGender = Enum.TryParse(Console.ReadLine(),true,out gender);
            while(!tempGender)
            {
                System.Console.WriteLine("Invalid Input. Enter a valid Gender");
                tempGender = Enum.TryParse(Console.ReadLine(),true,out gender);
            }
        
        Console.Write("Enter Your Physics Mark : ");
        double physics;
        bool tempPhysics = double.TryParse(Console.ReadLine(), out physics);
            while(!tempPhysics ||physics>100 || physics<0 )
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempPhysics = double.TryParse(Console.ReadLine(), out physics);
            }
        Console.Write("Enter Your Chemistry Mark : ");
        double chemistry;
        bool tempChemistry =double.TryParse(Console.ReadLine(), out chemistry);
            while(!tempChemistry || chemistry>100 ||chemistry<0 )
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempChemistry = double.TryParse(Console.ReadLine(), out chemistry);
            }
        Console.Write("Enter Your Maths Mark : ");
        double maths;
         bool tempMaths = double.TryParse(Console.ReadLine(), out maths);
            while(!tempMaths||maths>100||maths<0)
            {
                System.Console.WriteLine("Invalid Input. Enter a Valid Mark.");
                tempMaths = double.TryParse(Console.ReadLine(), out maths);
            }
        StudentDetails Student = new StudentDetails(studentName,fatherName,dob,gender,physics,chemistry,maths);
        StudentDetail.Add(Student);
        Console.WriteLine("Student Registered Successfully and StudentID is "+Student.StudentID);

    }
    static void ShowDetails(StudentDetails Details){
        Console.WriteLine("StudentID : "+Details.StudentID);
        Console.WriteLine("Student Name : "+Details.StudentName);
        Console.WriteLine("Student Father Name : "+Details.FatherName);
        Console.WriteLine("DOB : "+Details.DOB);
        Console.WriteLine("Gender : "+Details.Gender);
        Console.WriteLine("Physics Mark : "+Details.Physics);
        Console.WriteLine("Chemistry Mark : "+Details.Chemistry);
        Console.WriteLine("Maths Mark : "+Details.Maths);
        Console.WriteLine("-------------------------------------------------------");

    }


    static void DepartmentAvailable(){
        
        Console.WriteLine($"DepartmentID     Department Name     Number Of Seat");
        Console.WriteLine("-------------------------------------------------------");
        foreach(DepartmentDetails Department in DepartmentDetail){
            
            Console.WriteLine($"{Department.DepartmentID}           {Department.DepartmentName}                 {Department.NumberOfSeats}");
        }
        
    }


    public static void Login(){
        Console.Write("Enter Your Student ID : ");
        string studentID = Console.ReadLine().ToUpper();
        bool found = false;
        foreach (StudentDetails Details in StudentDetail)
        {
            if (studentID == Details.StudentID)
            {
                found = true;
                SubMenu(Details);
            }
        }
        if (!found)
        {
            Console.WriteLine("Invalid StudentID");
            Login();
        }
    }

    static void MakingAdmission(StudentDetails Details, DepartmentDetails Department){
        

        if(Department.NumberOfSeats>0){
            for(int i =0; i < AdmissionDetail.Count;i++){
                AdmissionDetails Admission =AdmissionDetail[i];
                if(Details.StudentID!=Admission.StudentID){
                    Department.NumberOfSeats--;
                    AdmissionDetails Admiision1 = new AdmissionDetails(Details.StudentID,Department.DepartmentID,DateTime.Now,(AdmissionStatus)AdmissionStatus.Admitted);
                    AdmissionDetail.Add(Admiision1);
                    Console.WriteLine("Admission took Successfully. Your admission ID - "+Admiision1.AdmissionID);
                    AdmissionDetail.RemoveAt(i);
                    break;
                
                }
                else{
                    Console.WriteLine("Your already taken the admission. If you want to take admission cancel the previous admission");
                    
                }
            }
        }
        else{
            Console.WriteLine("Seats Are not avilable Please choose another Department");
        }

    }



    static void SubMenu(StudentDetails Details)
    {
        while(true){
        Console.WriteLine(" 1. Check Eligibility\n 2. Show Details\n 3. Take Admission\n 4. Cancel Admission\n 5. Show Admission Details\n 6. Exit");
        int ch;
        bool tempOption = int.TryParse(Console.ReadLine(),out ch);
                while(!tempOption || ch>6 ||ch<1)
                {
                    System.Console.WriteLine("Invalid Input. Enter a correct option");
                    tempOption = int.TryParse(Console.ReadLine(),out ch);
                }
        switch (ch)
        {
            case 1:
                {
                   bool result =Details.CheckEligibility(Details.Physics,Details.Chemistry,Details.Maths);
                   if(result){
                    Console.WriteLine("Student is Eligible");
                   } 
                   else{
                    Console.WriteLine("Student is not Eligible");
                   }                 
                   
                    break;
                }
            case 2:
                {
                    ShowDetails(Details);
                    break;
                }
            case 3:
                {
                    DepartmentAvailable();
                    
                    Console.Write("Pick one DepartmentID : ");
                    string departmentId = Console.ReadLine().ToUpper();
                    foreach(DepartmentDetails Department in DepartmentDetail){
                        if(departmentId == Department.DepartmentID){
                           bool res = Details.CheckEligibility(Details.Physics,Details.Chemistry,Details.Maths);
                           if(res){
                                MakingAdmission(Details,Department);
                                break;
                           }
                           else{
                            Console.WriteLine("Student is not Eligible");
                            break;
                           }

                        }
                       
                    }
                    break;
                }


            case 4:{
                bool flag = true;
                string ad ="";
                foreach(AdmissionDetails Admission in AdmissionDetail)
                {
                    if(Details.StudentID==Admission.StudentID){
                        flag = false;
                        ad=Admission.DepartmentID;
                        Console.WriteLine($"AdmissionID : {Admission.AdmissionID}   SudentID : {Admission.StudentID}    DepartmentID: {Admission.DepartmentID}   AdmissionDate : {Admission.AdmissionDate.ToString("dd/MM/yyyy")}   AdmissionStatus : {Admission.AdmissionStatus} ");
                        
                        }
                        }
                        if(flag)
                        {
                            Console.WriteLine("There is no admission to cancel");
                        }
                        AdmissionDetail.Clear();
                        AdmissionDetails Admission1 = new AdmissionDetails("0");
                        AdmissionDetail.Add(Admission1);
                        foreach(DepartmentDetails Department in DepartmentDetail){
                            if(ad==Department.DepartmentID){
                                Department.NumberOfSeats++;
                                Console.WriteLine("Admission Cancelled Successfully");
                            }
                        }
                             
                        
                break;
            }
        case 5:{
            bool flag = true;
            foreach(AdmissionDetails Admission in AdmissionDetail){
                    if(Details.StudentID==Admission.StudentID){
                        flag = false;
                     Console.WriteLine($"AdmissionID : {Admission.AdmissionID}   SudentID : {Admission.StudentID}    DepartmentID: {Admission.DepartmentID}   AdmissionDate : {Admission.AdmissionDate.ToString("dd/MM/yyyy")}   AdmissionStatus : {Admission.AdmissionStatus} ");
                    }
                    }
                    if(flag){
                        Console.WriteLine("Theri is no admission details to show");
                    }
            break;
        }
        case 6 :{
            return;
        }
        }
        }
    }


    public static void Main(string[] args)
        {
        DepartmentDetails Department1 = new DepartmentDetails("EEE",29);
        DepartmentDetails Department2 = new DepartmentDetails("CSE",29);
        DepartmentDetails Department3 = new DepartmentDetails("MECH",30);
        DepartmentDetails Department4 = new DepartmentDetails("EcE",30);

        DepartmentDetail.Add(Department1);
        DepartmentDetail.Add(Department2);
        DepartmentDetail.Add(Department3);
        DepartmentDetail.Add(Department4);

        AdmissionDetails Admission1 = new AdmissionDetails("0");
        AdmissionDetail.Add(Admission1);
        
         
         while(true){
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(" 1. Student Register \n 2. Student Login \n 3. Department wise seat availability \n 4. Exit");
            Console.WriteLine("-------------------------------------------------------");
            int choice;
            bool tempMainOption = int.TryParse(Console.ReadLine(),out choice);
                while(!tempMainOption || choice>4 ||choice<1)
                {
                    System.Console.WriteLine("Invalid Input. Enter a correct option");
                    tempMainOption = int.TryParse(Console.ReadLine(),out choice);
                }
            switch(choice){
                case 1:{
                    Register();
                    break;
                }
                case 2:{
                    Login();
                    break;
                }
                case 3:{
                    DepartmentAvailable();
                    break;
                }
                case 4:{
                    return;
                }
            }
         }
    
                
    }
}
