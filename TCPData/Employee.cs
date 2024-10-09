using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    public class Employee
    {
        public int id {  get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public decimal Annual_Salary { get; set; }
        public bool Is_Manager { get; set; }
        public int Department_Id { get; set; }
    }
}
