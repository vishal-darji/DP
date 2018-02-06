using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //access level protection - private
            //SingletonLogger logger = new SingletonLogger();

            Thread thread = new Thread(new ThreadStart(test));
            thread.Start();
            Thread thread1 = new Thread(new ThreadStart(test));
            thread1.Start();
            
            Console.Read();
        }
        static void test()
        {
            //SingletonLogger obj = SingletonLogger.Instance;
            //SingletonThreadSafeLogger obj = SingletonThreadSafeLogger.Instance;
            SingletonNoLocks obj = SingletonNoLocks.Instance;

        }

       
    }
    //singleton - non-thread safe
    //selaed to block its inheritance
    public sealed class SingletonLogger
    {
        private static SingletonLogger instance = null;
        //private constructor so that it's instance can not be generated
        private SingletonLogger()
        {
        }
        //Static method or static property
        public static SingletonLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    Console.WriteLine("Delay started for" + Thread.CurrentThread.ManagedThreadId);
                    System.Threading.Thread.Sleep(5000);
                    Console.WriteLine("Delay ended");
                    instance = new SingletonLogger();
                    Console.WriteLine("New instance is created");
                }
                else
                {
                    Console.WriteLine("same instance returned, no new instance");
                }
                
                return instance;
            }
        }
    }
    //singleton - thread safe
    public sealed class SingletonThreadSafeLogger
    {
        private static SingletonThreadSafeLogger instance = null;
        private static readonly object padlock = new object();

        SingletonThreadSafeLogger()
        {
        }

        public static SingletonThreadSafeLogger Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        Console.WriteLine("New instance is created");
                        instance = new SingletonThreadSafeLogger();
                    }
                    else
                    {
                        Console.WriteLine("Same instance is returned");
                    }
                    return instance;
                }
            }
        }
    }
    //singleton double check
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();

        Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
    //Singleton without locks - thread safe
    public sealed class SingletonNoLocks
    {
        //static initialization
        private static readonly SingletonNoLocks instance = new SingletonNoLocks();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static SingletonNoLocks()
        {
        }

        private SingletonNoLocks()
        {
        }

        public static SingletonNoLocks Instance
        {
            get
            {
                return instance;
            }
        }
    }

    public sealed class mycustomSingltonClass
    {
        private static mycustomSingltonClass instance = null;
        private static readonly object obj = new object();
        private mycustomSingltonClass()
        { }

        public static mycustomSingltonClass singltonObject {
            get {

                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            Console.WriteLine("Delay started for" + Thread.CurrentThread.ManagedThreadId);
                            System.Threading.Thread.Sleep(5000);
                            Console.WriteLine("Delay ended");
                            instance = new mycustomSingltonClass();
                            Console.WriteLine("New instance is created");
                        }
                        else
                        {
                            Console.WriteLine("same instance returned, no new instance");
                        }
                        
                    }
                }
                return instance;
                
            
            }
        
        }
        
    }

}
