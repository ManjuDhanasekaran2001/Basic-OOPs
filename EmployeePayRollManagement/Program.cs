using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices.Marshalling;
namespace EmployeePayRollManagement;
class Program
{
    public static void Main(string[] args)

    {
        List<EmployeeDetails> EmployeeInfo = new List<EmployeeDetails>();

        string choice = "yes";
        do
        {
            Console.WriteLine(" 1.Registration\n 2.Login \n 3.Exit");
            Console.Write("Select the option :");
            string flag = Console.ReadLine();
            switch (flag)
            {
                case "1":
                    {

                        Console.Write("Enter your name : ");
                        string employeename = Console.ReadLine();
                        Console.Write("Enter your Role : ");
                        string role = Console.ReadLine();
                        Console.Write("Enter your worklocation chennai , Delhi , pune: ");
                        WorkLocation workLocation = Enum.Parse<WorkLocation>(Console.ReadLine(), true);
                        Console.Write("Enter your Teamname : ");
                        string teamName = Console.ReadLine();
                        Console.Write("Enter your date of joining dd/MM/yyyy : ");
                        DateTime joiningdate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        Console.Write("Enter the nuber og working day in month : ");
                        long workingDays = long.Parse(Console.ReadLine());
                        Console.Write("Enter the number of leave taken : ");
                        long leavetaken = long.Parse(Console.ReadLine());
                        Console.Write("Enter your Gender Male, Female : ");
                        Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

                        EmployeeDetails Employee1 = new EmployeeDetails(employeename, role, workLocation, teamName, joiningdate, workingDays, leavetaken, gender);
                        Console.WriteLine("-------------------------------------------------------");
                        Console.WriteLine("your Employee id : " + Employee1.EmployeeID);
                        Console.WriteLine("-------------------------------------------------------");
                        EmployeeInfo.Add(Employee1);
                        break;
                    }

                case "2":
                    {
                        Console.Write("Enter you EmployeeID : ");
                        string employeeId = Console.ReadLine();
                        foreach (EmployeeDetails Employee in EmployeeInfo)
                        {

                            if (Employee.EmployeeID == employeeId)

                            {
                                bool ch = true;
                                while (ch)
                                {

                                    Console.WriteLine(" 1.Calculate salary \n 2.Show Employee Details \n 3.Exit");
                                    Console.Write("Select the option : ");
                                    string option = Console.ReadLine();
                                    switch (option)
                                    {
                                        case "1":
                                            {

                                                Employee.CalculateSalary(Employee.WorkingDays, Employee.LeaveTaken);

                                                break;
                                            }

                                        case "2":
                                            {
                                                Console.WriteLine("-------------------------------------------------------");
                                                Console.WriteLine($" Employee name : {Employee.EmployeeName} \n EmployeeID : {Employee.EmployeeID}\n Employee Role : {Employee.Role} \n Employee TeamName : {Employee.TeamName}\n Employee Date of joing : {Employee.JoiningDate} \n Employee Working Day : {Employee.WorkingDays} \n Employee Leave taken : {Employee.LeaveTaken} \n Employee Gender : {Employee.Gender}");
                                                Console.WriteLine("-------------------------------------------------------");
                                                break;
                                            }

                                        case "3":
                                            {
                                                ch = false;
                                                break;
                                            }
                                    }

                                }

                            }
                            else
                            {
                                Console.WriteLine("Invalid ID");
                            }

                        }

                        break;
                    }
                case "3":
                    {
                        choice = "no";
                        break;
                    }
            }



        } while (choice == "yes");

    }

}
