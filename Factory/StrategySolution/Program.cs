using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategySolution
{
    class Program
    {
        static void Main(string[] args)
        {
            developementContext ctx = new developementContext();
            
            //Setting the strtegy object Java
            ctx.setDevelopementStrategy(new JavaSrategy());
            
            //project execution isomg java
            ctx.developeProject();


            //Setting the strtegy object .Net
            ctx.setDevelopementStrategy(new dotNetSrategy());

            //project execution isomg .Net
            ctx.developeProject();

            Console.ReadLine();
        }
    }
    public interface IDevelopementStrategy
    {
        void DevelopeApplication();
    }
    public class JavaSrategy : IDevelopementStrategy
    {


        public void DevelopeApplication()
        {
            Console.WriteLine("Application developed with Java");
        }
    }


    public class dotNetSrategy : IDevelopementStrategy
    {
        public void DevelopeApplication()
        {
            Console.WriteLine("Application developed with .Net");
        }
    }

    public class developementContext
    {
        private IDevelopementStrategy objStrategy;
        public void setDevelopementStrategy(IDevelopementStrategy strtgy)
        {
            this.objStrategy = strtgy;
        }

        public void developeProject()
        {
            objStrategy.DevelopeApplication();
        }
        
    }


}
