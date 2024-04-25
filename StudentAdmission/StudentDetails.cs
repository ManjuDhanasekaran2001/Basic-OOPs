using System;

namespace StudentAdmission
{
    /// <summary>
    /// Datatype Gender used to select a instance of <see cref="StudentDetails" /> Gender information
    /// </summary>
    public enum Gender {Select, Male, Female, Transgender}
    /// <summary>
    /// Class StudentDetails used to create instance for student <see cref="StudentDetails"/> 
    /// Refer documentation on <see href="www.syncfusion.com" /> 
    /// </summary>
    public class StudentDetails
    {
        /// <summary>
        /// static Field s_studentID used to autoincrement StudentID of the instance of <see cref="StudentDetails"/>
        /// </summary>
        private static int s_studentID=3000;//Field to auto increment the ID
        // Auto Property
        // Type "prop" and press "tab" key.

        /// <summary>
        /// StudentID Property used to hold a Student's ID of instance of<see cref="StudentDetails"/> 
        /// </summary> 
        

        public string StudentID { get;} //Read Only Property
        /// <summary>
        /// StudentName Property used to hold Student Name of a instance <see cref="StudentDetails"/> 
        /// </summary>
        
        public string StudentName { get; set; }
        /// <summary>
        /// FatherName property used to hold Father Name of a instance <see cref="StudentDetails"/> 
        /// </summary>
        
        public string FatherName { get; set; }
        /// <summary>
        /// DOB property used to hold Dob of a instance <see cref="StudentDetails"/>
        /// </summary>
        
        public DateTime DOB { get; set; }
        /// <summary>
        /// Gender property used to hold Gender of a instance <see cref="StudentDetails"/>
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Physics property used to hold physics of a instance <see cref="StudentDetails"/>
        /// </summary>
        /// <value>The value range 0-100</value>
        public double Physics { get; set; }
        /// <summary>
        /// Chemistry property used to hold chemistry of a instance <see cref="StudentDetails"/>
        /// </summary>
        /// <value>The value range 0-100</value>
        public double Chemistry { get; set; }
        /// <summary>
        /// Maths property used to hold Maths of a instance <see cref="StudentDetails"/>
        /// </summary>
        /// <value>The value range 0-100</value>
        public double Maths { get; set; }

        /// <summary>
        /// Constructor StudentDetails used to initialize default values to it's properties
        /// </summary>
        public StudentDetails(){

        }

        /// <summary>
        /// Constructor StudentDetails used to initialize parameterized values to it's properties
        /// </summary>
        /// <param name="studentName">studentName parameter used to assign its value to associated property </param>
        /// <param name="fatherName">fathername parameter used to assign its value toassociated property </param>
        /// <param name="dob">dob parameter used to assign its value to associated property</param>
        /// <param name="gender">gender parameter used to assign its value to associated property</param>
        /// <param name="physics">physics  parameter used to assign its value to associated property </param>
        /// <param name="chemistry">chemistry  parameter used to assign its value to associated property</param>
        /// <param name="maths">maths  parameter used to assign its value to associated property</param>

        public StudentDetails(string studentName, string fatherName, DateTime dob, Gender gender, double physics, double chemistry, double maths){
            s_studentID++;
            StudentID="SF"+s_studentID;
            StudentName=studentName;
            FatherName=fatherName;
            DOB=dob;
            Gender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }
        /// <summary>
        /// Method CheckEligibility used to check wether the instance of <see cref="StudentDetails"/> 
        /// CheckEligibility for admission based on cutoff
        /// </summary>
        /// <param name="Physics"></param>
        /// <param name="Chemistry"></param>
        /// <param name="Maths"></param>
        /// <returns>Returns true if eligible, else false</returns>

        public bool CheckEligibility(double Physics, double Chemistry, double Maths){

            bool answer = false;
            double sum = Physics+Chemistry+Maths;
            double average = sum/3.0;
            if(average>=75.0){
                answer = true;
            }
            
            return answer;
            
        }

    }
}
