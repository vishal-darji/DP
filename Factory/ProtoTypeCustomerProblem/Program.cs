using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoTypeCustomerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer objCustomer= new Customer();
            objCustomer.getDataFromDatabase();
            Customer objCustomer2 = objCustomer;
            objCustomer.Name = "Sachin1";
            objCustomer2.Address = "Pune1";
            Console.WriteLine(objCustomer.ToString());
            Console.WriteLine(objCustomer2.ToString());

            Console.Read();
        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public void getDataFromDatabase()
        {
            Console.WriteLine("Data fetched From Database");
            this.Name = "Sachin";
            this.MiddleName = "Laxman";
            this.LastName = "Patil";
            this.Address = "Pune";
            
        }
        public override string ToString()
        {
            return "Name:" + Name + ",MiddleName:" + MiddleName + ",LastName: " + LastName + ",Address:" + Address;
        }
    
    }
}
