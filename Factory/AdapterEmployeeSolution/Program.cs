using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AdapterEmployeeSolution
{
    //add system.web.extension for json serialziation
    class Program
    {
        static void Main(string[] args)
        {
            IEmployee objManager = new employeeManagerAdapter();
            string value = objManager.getAllEmployees();
            Console.WriteLine(value);
            Console.ReadLine();

        }
        public interface IEmployee
        {
            string getAllEmployees();
        }
        public class Employee
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }

        }
        public class employeeManager
        {
            public  List<Employee> getAllEmployees()
            {
                List<Employee> emp = new List<Employee>();
                emp.Add(new Employee { FirstName = "sachin", MiddleName = "Ramesh", LastName = "Tendulkar" });
                emp.Add(new Employee { FirstName = "Mahendra", MiddleName = "Singh", LastName = "Dhoni" });

                return emp;
            }

        }

        public class employeeManagerAdapter : employeeManager,IEmployee
        {
            public string getAllEmployees()
            {
                List<Employee> objList = base.getAllEmployees();

                return new JavaScriptSerializer().Serialize(objList);

            }
        
        }

    }
}
