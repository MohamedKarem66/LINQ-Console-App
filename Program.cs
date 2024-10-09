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
            List<Department> departments = Data.GetDepartments();
            List<Employee> employees = Data.GetEmployees();

            ///Select and Where Operators - Method syntax
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

            ////Select and Where Operators - Query syntax
            //var Result_List = from emp in employees
            //                  join dep in departments on emp.Department_Id equals dep.id
            //                  select new
            //                  {
            //                      First_Name = emp.First_Name,
            //                      Last_Name = emp.Last_Name,
            //                      Annual_Salary = emp.Annual_Salary,
            //                      Manager = emp.Is_Manager,
            //                      Department = dep.Longe_Name 
            //                  };
            //foreach (var employee in Result_List)
            //{
            //    Console.WriteLine($"First Name : {employee.First_Name}");
            //    Console.WriteLine($"Last Name : {employee.Last_Name}");
            //    Console.WriteLine($"Annual Salary : {employee.Annual_Salary}");
            //    Console.WriteLine($"Manager : {employee.Manager}");
            //    Console.WriteLine($"Department : {employee.Department}");
            //    Console.WriteLine();
            //}
            //var Average_Saller = Result_List.Average(a => a.Annual_Salary);
            //var Max_Saller = Result_List.Max(a => a.Annual_Salary);
            //var Min_Saller = Result_List.Min(a => a.Annual_Salary);
            //Console.WriteLine($"Average Annual Salary : {Average_Saller}");
            //Console.WriteLine($"Max Annual Salary : {Max_Saller}");
            //Console.WriteLine($"Min Annual Salary : {Min_Saller}");

            ////Deferred Execution Example
            //var results = from emp in employees.GetHighSalariedEmployees()
            //              select new
            //              {
            //                  Full_Name = emp.First_Name + " " + emp.Last_Name,
            //                  Annual_Salary = emp.Annual_Salary
            //              };
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.Full_Name,-20}{item.Annual_Salary,10}");
            //}
            //employees.Add(new Employee
            //{
            //    id = 10,
            //    First_Name = "sam",
            //    Last_Name = "deves",
            //    Annual_Salary = 100000.20m,
            //    Is_Manager = true,
            //    Department_Id = 2
            //});
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.Full_Name,-20}{item.Annual_Salary,10}");
            //}

            ////Immdiate Execution Example
            //var results = (from emp in employees.GetHighSalariedEmployees()
            //              select new
            //              {
            //                  Full_Name = emp.First_Name + " " + emp.Last_Name,
            //                  Annual_Salary = emp.Annual_Salary
            //              }).ToList();
            //employees.Add(new Employee
            //{
            //    id = 10,
            //    First_Name = "sam",
            //    Last_Name = "deves",
            //    Annual_Salary = 100000.20m,
            //    Is_Manager = true,
            //    Department_Id = 2
            //});
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item.Full_Name,-20}{item.Annual_Salary,10}");
            //}

            //// Join Operation Example - Method Syntax
            //var results = departments.Join(employees,  // department is one employee is many
            //    Department => Department.id,
            //    Employee => Employee.Department_Id,
            //    (Department, Employee) => new
            //    {
            //        Full_Name = Employee.First_Name + " " + Employee.Last_Name,
            //        Annual_Salary = Employee.Annual_Salary,
            //        Department_Name = Department.Longe_Name
            //    });
            //foreach(var item in results)
            //{
            //    Console.WriteLine($"{item.Full_Name,-20}{item.Annual_Salary,10}\t{item.Department_Name}");
            //}

            //// Join Operation Example - Query Syntax
            var results = from dept in departments // department is one employee is many
                          join emp in employees
                          on dept.id equals emp.Department_Id
                          select new
                          {
                              Full_Name = emp.First_Name + " " + emp.Last_Name,
                              Annual_Salary = emp.Annual_Salary,
                              Department_Name = dept.Longe_Name
                          };
            foreach (var item in results)
            {
                Console.WriteLine($"{item.Full_Name,-20}{item.Annual_Salary,10}\t{item.Department_Name}");
            }

            //// GroupJoin Operation Example - Method Syntax
            //var results = departments.GroupJoin(employees,  // department is one employee is many
            //    Department => Department.id,
            //    Employee => Employee.Department_Id,
            //    (Department, EmployeeGroup) => new
            //    {
            //        Employees = EmployeeGroup,
            //        Department_Name = Department.Longe_Name
            //    });
            //foreach (var item in results)
            //{
            //    Console.WriteLine($"Department Name :{item.Department_Name}");
            //    foreach (var employee in item.Employees)
            //        Console.WriteLine($"\t{employee.First_Name} {employee.Last_Name}");
            //}

            //// GroupJoin Operation Example - Query Syntax
            var results1 = from dept in departments // department is one employee is many
                           join emp in employees
                           on dept.id equals emp.Department_Id
                           into EmployeeGroup
                           select new
                           {
                               Employees = EmployeeGroup,
                               Department_Name = dept.Longe_Name
                           };
            foreach (var item in results1)
            {
                Console.WriteLine($"Department Name :{item.Department_Name}");
                foreach (var employee in item.Employees)
                    Console.WriteLine($"\t{employee.First_Name} {employee.Last_Name}");
            }
            Console.ReadKey();
        }
    }
    public static class EmunarbleCollectionExtentionMethods
    {
        public static IEnumerable<Employee> GetHighSalariedEmployees(this IEnumerable<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                Console.WriteLine($"Accessing Employee : {emp.First_Name + " " + emp.Last_Name}");
                if (emp.Annual_Salary >= 8000)
                    yield return emp;
            }
        }
    }
}