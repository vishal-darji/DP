using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    //Simple Factory
    class Program
    {
        //Two types of customers in bank, Walkin customer and Online registred customer
        static void Main(string[] args)
        {

            switch (Console.ReadLine())
            { 
                case "walkin":
                    walkInCustomer cust = new walkInCustomer();
                    cust.requestAService();
                    cust.deliverService();
                    break;
                case "online":
                    onlineCustomer onlineCust = new onlineCustomer();
                    onlineCust.requestAService();
                    onlineCust.deliverService();
                    break;
            }
            Console.ReadLine();

        }


        public class onlineCustomer
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
        public class walkInCustomer
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
}
