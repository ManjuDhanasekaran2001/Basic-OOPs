using System;

namespace EmployeePayRollManagement
{
    public enum Gender { Select, Male, Female }
    public enum WorkLocation { select, Chennai, Delhi, Pune }

    public class EmployeeDetails
    {
        private static int s_employeeID = 1000;
        public string EmployeeID { get; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public string TeamName { get; set; }
        public DateTime JoiningDate { get; set; }
        public long WorkingDays { get; set; }
        public long LeaveTaken { get; set; }
        public Gender Gender { get; set; }


        public EmployeeDetails(string employeename, string role, WorkLocation workLocation, string teamName, DateTime joiningdate, long workingDays, long leavetaken, Gender gender)
        {
            s_employeeID++;
            EmployeeID="SF"+s_employeeID;
            EmployeeName=employeename;
            Role=role;
            WorkLocation=workLocation;
            TeamName=teamName;
            JoiningDate=joiningdate;
            WorkingDays=workingDays;
            LeaveTaken=leavetaken;
            Gender=gender;

        }

        public void CalculateSalary(long workingDays, long leavetaken){
            long days = workingDays-leavetaken;
            long salary = days*500;
            Console.WriteLine("The monthly salary is : "+salary);
            Console.WriteLine("------------------------------------------");
        }
    }


}
