using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Developer("Suresh", 10000);
            Employee emp2 = new Developer("Ramesh", 15000);
            Employee manager1 = new Manager("Mohan", 25000);
            manager1.add(emp1);
            manager1.add(emp2);
            Employee emp3 = new Developer("Soham", 20000);
            Manager generalManager = new Manager("Mahesh", 50000);
            generalManager.add(emp3);
            generalManager.add(manager1);
            generalManager.print();
            Console.Read();
        }
    }
    ///

    public interface Employee
    {

        void add(Employee employee);
        void remove(Employee employee);
        Employee getChild(int i);
        String getName();
        double getSalary();
        void print();
    }



    public class Manager : Employee
    {

        private String name;
        private double salary;

        public Manager(String name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }

        List<Employee> employees = new List<Employee>();
        public void add(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee getChild(int i)
        {
            return employees[i];
        }

        public String getName()
        {
            return name;
        }

        public double getSalary()
        {
            return salary;
        }

        public void print()
        {

            Console.WriteLine("-------------");
            Console.WriteLine("Name =" + getName());
            Console.WriteLine("Salary =" + getSalary());
            Console.WriteLine("-------------");

            foreach (Employee emp in employees)
            {
                emp.print();
            }


        }


        public void remove(Employee employee)
        {
            employees.Remove(employee);
        }

    }
    public class Developer : Employee
    {

        private String name;
        private double salary;

        public Developer(String name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }
        public void add(Employee employee)
        {
            //this is leaf node so this method is not applicable to this class.
        }

        public Employee getChild(int i)
        {
            //this is leaf node so this method is not applicable to this class.
            return null;
        }

        public String getName()
        {
            return name;
        }

        public double getSalary()
        {
            return salary;
        }

        public void print()
        {
            Console.WriteLine("-------------");
            Console.WriteLine("Name =" + getName());
            Console.WriteLine("Salary =" + getSalary());
            Console.WriteLine("-------------");
        }

        public void remove(Employee employee)
        {
            //this is leaf node so this method is not applicable to this class.
        }

    }

}
