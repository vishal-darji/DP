using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonObserverSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            AmazonNotificationEngine objNotificationEngine = new AmazonNotificationEngine("Glass", "Rs.10");
            EmailSubscribers objSubscribers = new EmailSubscribers();
            objNotificationEngine.attach(objSubscribers);
            objNotificationEngine.Price = "Rs. 11";
            objNotificationEngine.Price = "Rs. 12";

            Console.ReadLine();
            
        }
    }
   
    public abstract class INotificationEngine
    {
        public abstract void attach(Subscribers objectSubscriber);
        public abstract void detach(Subscribers objectSubscriber);
        public abstract void notify(string name, string price);
        

    }
    public class AmazonNotificationEngine : INotificationEngine
    {
        List<Subscribers> objSubscriber = new List<Subscribers>();
        
        
        public string ProductName { get; set; }
        private string price;

        public string Price
        {
            get { return price; }
            set { price = value; notify(ProductName, price); }
        }
        
        public AmazonNotificationEngine(string name, string price)
        {
            ProductName = name;
            Price = price;
        }
        public override void attach(Subscribers objectSubscriber)
        {
            objSubscriber.Add(objectSubscriber);
        }

        public override void detach(Subscribers objectSubscriber)
        {
            objSubscriber.Remove(objectSubscriber);
        }

        public override void notify(string name, string price)
        {
            foreach (Subscribers objSub in objSubscriber)
            {
                objSub.notifyUsers(name, price);
            }
        }
    }

    public abstract class Subscribers
    {
        public abstract void notifyUsers(string name, string price);
    
    }
    public class EmailSubscribers : Subscribers
    {


        public override void notifyUsers(string name, string price)
        {
            Console.WriteLine("Price Has been changed for product:" + name + " as " + price);
        }
    }

}
