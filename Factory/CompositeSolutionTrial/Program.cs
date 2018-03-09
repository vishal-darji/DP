using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeSolutionTrial
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployee objDeveloper1 = new developer("Dev-Suresh");
            IEmployee objDeveloper2 = new developer("Dev-Ramesh");
            IEmployee objManager = new Manager("Manager - Hitesh");
            objManager.add(objDeveloper1);
            objManager.add(objDeveloper2);
            IEmployee objGeneralManager = new Manager("GeneralManager-Mitesh");
            objGeneralManager.add(objManager);
            objGeneralManager.print();
            Console.ReadLine();
        }
    }
    public interface IEmployee
    {
        void add(IEmployee employee);
        void remove(IEmployee employee);
        
        void print();
    }
    public class developer : IEmployee
    {
        public string name { get; set; }
        List<IEmployee> objEmployees = new List<IEmployee>();
        public developer(string name)
        {
            this.name = name;
        }

        public void add(IEmployee employee)
        {
           
            
        }

        public void remove(IEmployee employee)
        {
          
        }

       

        public void print()
        {
            Console.WriteLine(this.name);

            
                
        }
    }
    public class Manager : IEmployee
    {
        public string name { get; set; }
        List<IEmployee> objEmployees = new List<IEmployee>();
        public Manager(string name)
        {
            this.name = name;
        }

        public void add(IEmployee employee)
        {
            objEmployees.Add(employee);

        }

        public void remove(IEmployee employee)
        {
            objEmployees.Remove(employee);
        }



        public void print()
        {
            Console.WriteLine(this.name);
            foreach (IEmployee emp in objEmployees)
            {
                emp.print();
            }
        }
    }
}
