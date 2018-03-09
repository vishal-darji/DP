using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterEmployeeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            employeeManager objManager = new employeeManager();
            objManager.getAllEmployees();
            Console.WriteLine("I need in json format");

        }

        public class Employee
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            
        }
        public class employeeManager
        {
            public List<Employee> getAllEmployees()
            {
                List<Employee> emp = new List<Employee>();
                emp.Add(new Employee { FirstName = "sachin", MiddleName = "Ramesh", LastName = "Tendulkar" });
                emp.Add(new Employee { FirstName = "Mahendra", MiddleName = "Singh", LastName = "Dhoni" });

                return emp;
            }
        
        }

    }
}
