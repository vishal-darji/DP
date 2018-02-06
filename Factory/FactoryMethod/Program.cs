using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    //Factory Method - Subclass to decide which object to instantiate
    class Program
    {

        static void Main(string[] args)
        {
            LoggerFactory[] loggerArray = new LoggerFactory[4];
            loggerArray[0] = new CsvLoggerFactory();
            loggerArray[1] = new ExcelLoggerFactory();
            loggerArray[2] = new OracleLoggerFactory();
            loggerArray[3] = new SQLLoggerFactory();
            foreach (LoggerFactory fact in loggerArray)
            {
                var obj = fact.createLogObject();
                obj.logMessage();
            }
            Console.Read();   
        }
    }

    public interface Log
    {
        void logMessage();
        
    }

    public abstract class LoggerFactory
    {
        public abstract Log createLogObject();
        
    }
    public class CsvLoggerFactory:LoggerFactory
    {

        public override Log createLogObject()
        {
            return new CSVLog();
        }
    }
    public class ExcelLoggerFactory : LoggerFactory
    {

        public override Log createLogObject()
        {
            return new ExcelLog();
        }
    }
    public class OracleLoggerFactory : LoggerFactory
    {

        public override Log createLogObject()
        {
            return new OracleLog();
        }
    }
    public class SQLLoggerFactory : LoggerFactory
    {

        public override Log createLogObject()
        {
            return new SQLLog();
        }
    }


    public class TextLog : Log
    {


        public void logMessage()
        {
            Console.WriteLine("textlogMessage logged");
        }
    }
    public class CSVLog : Log
    {

        public void logMessage()
        {
            Console.WriteLine("CSVLogMessage logged");
        }
    }
    public class ExcelLog : Log
    {

        public void logMessage()
        {
            Console.WriteLine("ExcelLogMessage logged");
        }
    }
    public class OracleLog : Log
    {

        public void logMessage()
        {
            Console.WriteLine("OracleLogMessage logged");
        }
    }
    public class SQLLog : Log
    {

        public void logMessage()
        {
            Console.WriteLine("SQLLogMessage logged");
        }
    }
}


