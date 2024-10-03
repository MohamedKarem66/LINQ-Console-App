using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPData;
using TCPExtensions;

namespace LINQ_Console_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Employee> employees = Data.GetEmployees();
            //var Filtered_Employee = employees.Filter(emp => emp.Annual_Salary < 10000);
            //foreach (var employee in Filtered_Employee)
            //{
            //    Console.WriteLine($"First Name : {employee.First_Name}");
            //    Console.WriteLine($"Last Name : {employee.Last_Name}");
            //    Console.WriteLine($"Annual Salary : {employee.Annual_Salary}");
            //    Console.WriteLine($"Manager : {employee.Is_Manager}");
            //    Console.WriteLine();
            //}
            //List<Department> departments = Data.GetDepartments();
            //var Filtered_Department = departments.Where(dep => dep.id >= 1);
            //foreach (var department in Filtered_Department)
            //{
            //    Console.WriteLine($"First Name : {department.id}");
            //    Console.WriteLine($"Short Name : {department.Short_Name}");
            //    Console.WriteLine($"Longe Name : {department.Longe_Name}");
            //    Console.WriteLine();
            //}
            List<Department> departments = Data.GetDepartments();
            List<Employee> employees = Data.GetEmployees();
            var Result_List = from emp in employees
                              join dep in departments on emp.Department_Id equals dep.id
                              select new
                              {
                                  First_Name = emp.First_Name,
                                  Last_Name = emp.Last_Name,
                                  Annual_Salary = emp.Annual_Salary,
                                  Manager = emp.Is_Manager,
                                  Department = dep.Longe_Name 
                              };
            foreach (var employee in Result_List)
            {
                Console.WriteLine($"First Name : {employee.First_Name}");
                Console.WriteLine($"Last Name : {employee.Last_Name}");
                Console.WriteLine($"Annual Salary : {employee.Annual_Salary}");
                Console.WriteLine($"Manager : {employee.Manager}");
                Console.WriteLine($"Department : {employee.Department}");
                Console.WriteLine();
            }
            var Average_Saller = Result_List.Average(a => a.Annual_Salary);
            var Max_Saller = Result_List.Max(a => a.Annual_Salary);
            var Min_Saller = Result_List.Min(a => a.Annual_Salary);
            Console.WriteLine($"Average Annual Salary : {Average_Saller}");
            Console.WriteLine($"Max Annual Salary : {Max_Saller}");
            Console.WriteLine($"Min Annual Salary : {Min_Saller}");
            Console.ReadKey();
        }
    }
}
