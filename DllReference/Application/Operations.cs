using System;
using System.Collections.Generic;
using CollegeDetails;
namespace Application
{
    //Static Class
    public static class Operations
    {

        //Local/Global Oject creation

        static StudentDetails currentLoggedInStudent;
        //static List ccreation
        static List<StudentDetails> studentList = new List<StudentDetails>();
        static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

        //Main Menu 
        public static void MainMenu()
        {
            Console.WriteLine("********Welcome to Syncfusion College*********");
            

            string mainChoice ="yes";
           do
           {
            //Need to show main menu option
            Console.WriteLine("MainMenu\n1. Registration\n2. Login\n3. Departmentwise Seat Availability\n4. Exit");
            // Need to get input from user and validate.
            Console.Write("Select an Option : ");
            int mainOption = int.Parse(Console.ReadLine());
            //Need to create mainmenu structure
            switch(mainOption){
                case 1:
                {
                    Console.WriteLine("**********Student Registration**************");
                    StudentRegistration();
                    break;
                }
                case 2:
                {
                    Console.WriteLine("**************Student Login**********");
                    StudentLogin();
                    break;
                }
                case 3 : 
                {
                    Console.WriteLine("******Departmentwise Seat Availability***************");
                    DepartmentwiseSeatAvailability();
                    break;
                }
                case 4:
                {
                    Console.WriteLine("Application Exited Successfully");
                    mainChoice="no";
                    break;
                }

            }
            //Need to iterate untill the option is exit.

           }while(mainChoice=="yes");
        }//Main Menu ends

        //Student Redistration
        public static void StudentRegistration()
        {
            //Need to get required details
            Console.Write("Enter your Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your FatherName : ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your DOB as Sepecified DD/MM/YYYY : ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your Gender (Male/Female) : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);
            Console.Write("Enter your Physics mark : ");
            int physicsMark = int.Parse(Console.ReadLine());
            Console.Write("Enter your Chemistry mark : ");
            int chemistryMark = int.Parse(Console.ReadLine());
            Console.Write("Enter your maths mark : ");
            int mathsMark = int.Parse(Console.ReadLine());
            //Need to create an object
            StudentDetails student = new StudentDetails(name,fatherName,dob,gender,physicsMark,chemistryMark,mathsMark);
            //Need to add in the list
            studentList.Add(student);
            //Need to display confirmation mmessage and ID
            Console.WriteLine($"registration successful. Student ID : {student.StudentID}");

        }//student registration ends

        //student login
        public static void StudentLogin()
        {
            //need to get id input
            Console.Write("Enter your StudentID : ");
            string loginID = Console.ReadLine().ToUpper();
            //validate by its presence in the list.
            bool flag = true;
            foreach(StudentDetails student in studentList)
            {
                if(loginID.Equals(student.StudentID))
                {
                    flag=false;
                    //assigning current user to global variable
                    currentLoggedInStudent = student;
                    Console.WriteLine("Logged In successfully.");
                    //Need to call SubMenu
                    SubMenu();
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("Invalid ID or ID is noT present");
            }
            //If not - Invalid  valid

        }// Student login ends

        //SubMenu
        public static void SubMenu()
        {
            string subChoice ="yes";
            do
            {
                Console.WriteLine("*********SunMenu*******");
                //Need to show submenu options
                Console.WriteLine("Select an Option\n1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancell Admission\n5. Admission Details\n6. Exit");
                //Getting User option
                Console.Write("Enter your Option : ");
                int subOption = int.Parse(Console.ReadLine());
                //Need to create submenu structure
                switch(subOption){
                    case 1:{
                        Console.WriteLine("*********Check Eligibility*********");
                        CheckEligibility();
                        break;
                    }
                    case 2:{
                        Console.WriteLine("*********Show Details*********");
                        ShowDetail();
                        break;
                    }
                    case 3:{
                        Console.WriteLine("*********Take Admission*********");
                        TakeAdmission();
                        break;
                    }
                    case 4:{
                        Console.WriteLine("*********Cancel Admission*********");
                        CancelAdmission();
                        break;
                    }
                    case 5:{
                        Console.WriteLine("*********Admission Details*********");
                        AdmissionDetail();
                        break;
                    }
                    case 6:{
                        Console.WriteLine("Taking back to MainMenu");
                        subChoice="no";
                        break;
                    }
                }
                //Iterate till the option is exit

            }while(subChoice=="yes");

        }//SubMenu ends

        //Check eligibility
        public static void CheckEligibility()
        {
            //Get the cut of value as input
            Console.Write("Enter the cutoff value : ");
            double cutOff = double.Parse(Console.ReadLine());
            //Check eligible or not
            if(currentLoggedInStudent.CheckEligibility(cutOff))
            {
                Console.WriteLine("Student is Eligible");
            }
            else{
                Console.WriteLine("Student is not Eligible");
            }
        }// Chech Eligibility ends

        //Show Details 
        public static void ShowDetail()
        {
        //need to show current student Details
            Console.WriteLine("|Student ID|Student Name|Father Name|DOB|Gender|Physics Mark|Chemistry Mark|Maths Mark|");
            Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.PhysicsMark}|{currentLoggedInStudent.ChemistryMark}|{currentLoggedInStudent.MathsMark}|");

        }//Show Detail ends

        // Take Admission
        public static void TakeAdmission()
        {
            //Need to show available department deatails
            DepartmentwiseSeatAvailability();
            //Ask department ID from user
            Console.Write("Select a department ID : ");
            string departmentID = Console.ReadLine().ToUpper();
            //Check the Id is present or not
            bool flag = true;
            foreach(DepartmentDetails department in departmentList)
            {
                if(departmentID.Equals(department.DepartmentID))
                {
                    flag=false;
                    //Check the student is Eligible or not
                    if(currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        //check the seat availability
                        if(department.NumberOfSeats>0)
                        {
                            //Check student already taken any admission
                            int count =0;
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)&& admission.AdmissionSatus.Equals(AdmissionStatus.Amitted))
                                {
                                    count++;
                                }
                            }
                            if(count==0)
                            {
                                //create admission object
                                AdmissionDetails admissionTake = new AdmissionDetails(currentLoggedInStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Amitted);
                                //reduce seat count
                                department.NumberOfSeats--;
                                //add to the admission list 
                                admissionList.Add(admissionTake);
                                //Display Admission successful message
                                Console.WriteLine($"You have taken admission successfully. Admission ID : {admissionTake.AdmissionID}");
                            }
                            else{
                                Console.WriteLine("You have already taken an admission");
                            }
                            
                        }
                        else{
                            Console.WriteLine("seats are not availabel");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("You are not Eligible due to low cutoff");
                    }
                    
                    break;
                }
            }
            if(flag){
                Console.WriteLine("Invalid ID or ID not present");
            }
            
            
        }// Take Admission ends

        //Cancel Admission

        public static void CancelAdmission()
        {
            //Check the student is taken any admission and diaplay it.
            bool flag = true;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)&&  admission.AdmissionSatus.Equals(AdmissionStatus.Amitted))
                {
                    //Cancel the found admiision
                    admission.AdmissionSatus=AdmissionStatus.Cancelled;
                    // return the seat to department
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            break;
                        }
                    }
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("You have not admission to cancel");
            }

        }//Cancel Admission ends

        //AdmissionDeatail
        public static void AdmissionDetail()
        {
            // Need to show current logged in student admission details
            Console.WriteLine("|Amission Id|Student ID|Department ID|Admission Date|Admission Status|");
             foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)){
                    Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.AdmissionSatus}|");
                }
            }

        }//AdmissionDetail Ends

        //Departmentwise seat availabilitiy
        public static void DepartmentwiseSeatAvailability()
        {
            //Need to show all department deatail
            string tepm ="_________________________________________";
            Console.WriteLine(tepm);
            Console.WriteLine("|DepartmentID|DepartmentName|NumberOfSeats|");
            Console.WriteLine(tepm);
             foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"|{department.DepartmentID,-12}|{department.DepartmentName,-14}|{department.NumberOfSeats,-13}|");
                Console.WriteLine(tepm);
            }
            Console.WriteLine();

        }//Departmentwise seat availabilitiy ends


        //Adding Default Data
        public static void AddDefaultData()
        {
            StudentDetails student1 = new StudentDetails("Ravichandran","Ettapparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            StudentDetails student2 = new StudentDetails("Baskaran","Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            studentList.AddRange(new List<StudentDetails>(){student1,student2});
            //studentList.Add(student1);
            //studentList.Add(student2);

            DepartmentDetails department1 = new DepartmentDetails("EEE",29);
            DepartmentDetails department2 = new DepartmentDetails("CSE",29);
            DepartmentDetails department3 = new DepartmentDetails("MECH",30);
            DepartmentDetails department4 = new DepartmentDetails("ECE",30);
            departmentList.AddRange(new List<DepartmentDetails>(){department1,department2,department3,department4});


            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID,department1.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Amitted);
            AdmissionDetails admission2 = new AdmissionDetails("SF3002","DID102",new DateTime(2022,05,12),AdmissionStatus.Amitted);
            admissionList.AddRange(new List<AdmissionDetails>(){admission1,admission2});

            //priting data
            
        }
        
    }
}
