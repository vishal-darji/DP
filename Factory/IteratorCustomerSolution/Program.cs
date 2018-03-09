using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorCustomerSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            BankOfMaharastra objM = new BankOfMaharastra();
            BankOfIndia objI = new BankOfIndia();
            BankOfKanrnataka objK = new BankOfKanrnataka();

            Merger objMerger = new Merger(objM,objI,objK);
            objMerger.ShowCustomer();
            Console.ReadLine();

        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        

    }
    public abstract class Iterator
    {
        public abstract IEnumerator createIterator();
    }
    public class BankOfMaharastra:Iterator
    {
        public List<Customer> customerList { get; set; }

        public BankOfMaharastra()
        {

            customerList = new List<Customer>();
            customerList.Add(new Customer{ Name="A",Middle="B",Last="c"});
        }
        public List<Customer> getAllCustomers()
        {
            return customerList;
        }

        public override IEnumerator createIterator()
        {
            return customerList.GetEnumerator();
        }
    }
    public class BankOfIndia : Iterator
    {
        public ArrayList customerList { get; set; }

        public BankOfIndia()
        {

            customerList = new ArrayList();
            customerList.Add(new Customer{ Name="BankOfIndia A",Middle="BankOfIndia B",Last="BankOfIndia c"});
        }
        public ArrayList getAllCustomers()
        {
            return customerList;
        }

        public override IEnumerator createIterator()
        {
            return customerList.GetEnumerator();
        }
    }
    public class BankOfKanrnataka : Iterator
    {
        public Dictionary<string,Customer> customerList { get; set; }

        public BankOfKanrnataka()
        {

            customerList = new Dictionary<string,Customer>();
            customerList.Add("Key1",new Customer{ Name="BankOfK A",Middle="BankOfK B",Last="BankOfK c"});
        }
        public Dictionary<string, Customer> getAllCustomers()
        {
            return customerList;
        }

        public override IEnumerator createIterator()
        {
            return customerList.Values.GetEnumerator();
        }
    }

    public class Merger
    {
        Iterator BOM;
        Iterator BOI;
        Iterator BOK;

        public Merger(Iterator BOMParam, Iterator BOIParam, Iterator BOKParam)
        {
            BOM = BOMParam;
            BOI = BOIParam;
            BOK = BOKParam;
        }
        public void ShowCustomer()
        {
            IEnumerator objEBOM = BOM.createIterator();
            IEnumerator objEBOI = BOI.createIterator();
            IEnumerator objEBOK = BOK.createIterator();
            
            PrintCustomer(objEBOM);
            PrintCustomer(objEBOI);
            PrintCustomer(objEBOK);
        }
        private void PrintCustomer(IEnumerator objEnumerator)
        {
            while (objEnumerator.MoveNext())
            {
                Customer objCustomer = (Customer)objEnumerator.Current;
                Console.WriteLine(objCustomer.Name);
            }
        
        }

    }
}
