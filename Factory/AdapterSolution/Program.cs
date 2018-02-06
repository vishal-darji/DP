using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterSolution
{
    class Program
    {
        static void Main()
        {
            // Create adapter and place a request
            Console.WriteLine("convert Namaste");
            Dictionary target = new HindiToEnglishConverter();
            
            target.Request();

            // Wait for user

            Console.ReadKey();
        }

    }
    /// <summary>

  /// The 'Target' class

  /// </summary>

    class Dictionary
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }
 
  /// <summary>

  /// The 'Adapter' class

  /// </summary>

    class HindiToEnglishConverter : Dictionary
    {
        private English _adaptee = new English();

        public override void Request()
        {
            // Possibly do some other work

            //  and then call SpecificRequest

            _adaptee.SpecificRequest();
        }
    }
 
  /// <summary>

  /// The 'Adaptee' class

  /// </summary>

  class English

  {
    public void SpecificRequest()
    {
      Console.WriteLine("Hello");
    }
  }
}
