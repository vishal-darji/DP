using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorySolution
{
    //Simple Factory
    class Program
    {

        static void Main(string[] args)
        {

            customerFactory custFactory = new customerFactory();
            ICustomer objEatables = custFactory.createCustomer(Console.ReadLine());
            objEatables.requestAService();
            objEatables.deliverService();
            Console.ReadLine();

        }
    }

    public interface ICustomer
    {
        void requestAService();
        void deliverService();
        

    }
   
    public class customerFactory
    {
        public ICustomer createCustomer(string choice)
        {
            ICustomer customer;
            switch (choice)
            {
               case "walkin":
                    walkInCustomer cust = new walkInCustomer();
                    return cust;
                    break;
                case "online":
                    onlineCustomer onlineCust = new onlineCustomer();
                    return onlineCust;
                    break;
                default:
                    customer = new onlineCustomer();
                    return customer;
            }
        }
    }

    public class onlineCustomer:ICustomer
    {
        public void requestAService()
        {
            Console.WriteLine("request received for onlineCustomer.");
        }
        public void deliverService()
        {
            Console.WriteLine("service delivered for onlineCustomer.");
        }

    }
    public class walkInCustomer:ICustomer
    {
        public void requestAService()
        {
            Console.WriteLine("request received for walkInCustomer.");
        }
        public void deliverService()
        {
            Console.WriteLine("service delivered for walkInCustomer.");
        }

    }
}
    

