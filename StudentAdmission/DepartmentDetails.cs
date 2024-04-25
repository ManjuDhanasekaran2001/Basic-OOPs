using System;

namespace StudentAdmission
{
    /// <summary>
    /// Class DepartmentDetails used to create instance for student <see cref="DepartmentDetails"/> 
    /// </summary>
    public class DepartmentDetails
    {
        /// <summary>
        /// static Field s_departmentID used to autoincrement StudentID of the instance of <see cref="s_departmentID"/>
        /// </summary>
        private static int s_departmentID=100;
        // Auto Property
        // Type "prop" and press "tab" key.

        /// <summary>
        /// DepartmentID Property used to hold a DepartmentID of instance of<see cref="StudentDetails"/> 
        /// </summary> 
        public string DepartmentID { get; }
        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }

        public DepartmentDetails(string departmentName, int numberOfSeats){
            s_departmentID++;
            DepartmentID="DID"+s_departmentID;
            DepartmentName=departmentName;
            NumberOfSeats=numberOfSeats;

        }
    }
}
