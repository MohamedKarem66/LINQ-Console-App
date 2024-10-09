using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee
            {
                id = 1,
                First_Name = "Bob",
                Last_Name = "jones",
                Annual_Salary = 60000.3m,
                Is_Manager = true,
                Department_Id = 1
            };
            employees.Add(employee);
            employee = new Employee
            {
                id = 2,
                First_Name = "sara",
                Last_Name = "khaled",
                Annual_Salary = 80000.31m,
                Is_Manager = true,
                Department_Id = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                id = 3,
                First_Name = "menna",
                Last_Name = "sobhy",
                Annual_Salary = 55000.93m,
                Is_Manager = false,
                Department_Id = 3
            };
            employees.Add(employee);
            employee = new Employee
            {
                id = 4,
                First_Name = "hassan",
                Last_Name = "mohamed",
                Annual_Salary = 160000.6m,
                Is_Manager = true,
                Department_Id = 1
            };
            employees.Add(employee);
            employee = new Employee
            {
                id = 5,
                First_Name = "ahmed",
                Last_Name = "sameh",
                Annual_Salary = 90000.3m,
                Is_Manager = true,
                Department_Id = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                id = 6,
                First_Name = "mohamed",
                Last_Name = "karem",
                Annual_Salary = 70000.13m,
                Is_Manager = false,
                Department_Id = 3
            };
            employees.Add(employee);
            employee = new Employee
            {
                id = 6,
                First_Name = "Ali",
                Last_Name = "mohamed",
                Annual_Salary = 80000.13m,
                Is_Manager = false,
                Department_Id = 3
            };
            employees.Add(employee);
            return employees;
        }
        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            Department department = new Department
            {
                id = 1,
                Short_Name = "HR",
                Longe_Name = "Human Recourses",
            };
            departments.Add(department);
            department = new Department
            {
                id = 2,
                Short_Name = "FN",
                Longe_Name = "Finance",
            };
            departments.Add(department);
            department = new Department
            {
                id = 3,
                Short_Name = "TE",
                Longe_Name = "Technologe",
            };
            departments.Add(department);
            return departments;
        }
    }
}
