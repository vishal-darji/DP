using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
   
        //abstract factory - create family of classes
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
    //Factories
        public abstract class LoggerFactory
        {
            public abstract Log createLogObject();

        }
        public class CsvLoggerFactory : LoggerFactory
        {

            public override Log createLogObject()
            {
                return new CSVLog(new CsvDependecyGenerator());
            }
        }
        public class ExcelLoggerFactory : LoggerFactory
        {

            public override Log createLogObject()
            {
                
                return new ExcelLog(new ExcelDependecyGenerator());
            }
        }
        public class OracleLoggerFactory : LoggerFactory
        {

            public override Log createLogObject()
            {
                return new OracleLog(new OracelDependecyGenerator());
            }
        }
        public class SQLLoggerFactory : LoggerFactory
        {

            public override Log createLogObject()
            {
                return new SQLLog(new SQLDependecyGenerator());
            }
        }
    //Dependency generator factories
        public abstract class dependecyGeneratorFactory
        {
            public abstract void callMethod();
        }

        public class TextDependecyGenerator : dependecyGeneratorFactory
        {
            TxtDriver txtdriver = new TxtDriver();
            TxtFile txtFileObj = new TxtFile();
            
            public override void callMethod()
            {
                txtdriver.showMessage();
                txtFileObj.showMessage();
                
            }
        }
        public class CsvDependecyGenerator : dependecyGeneratorFactory
        {
            CsvDriver csvdriver = new CsvDriver();
            CsvFile txtFileObj = new CsvFile();

            public override void callMethod()
            {
                csvdriver.showMessage();
                txtFileObj.showMessage();

            }
        }
        public class ExcelDependecyGenerator : dependecyGeneratorFactory
        {
            ExcelDriver exceldriver = new ExcelDriver();
            ExcelFile excelFileObj = new ExcelFile();

            public override void callMethod()
            {
                exceldriver.showMessage();
                excelFileObj.showMessage();

            }
        }
        public class OracelDependecyGenerator : dependecyGeneratorFactory
        {
            OracleConnection oracleConnection = new OracleConnection();
            OracleAdapter oracleAdapter = new OracleAdapter();

            public override void callMethod()
            {
                oracleConnection.showMessage();
                oracleAdapter.showMessage();

            }
        }

        public class SQLDependecyGenerator : dependecyGeneratorFactory
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlAdapter sqlAdapter = new SqlAdapter();

            public override void callMethod()
            {
                sqlConnection.showMessage();
                sqlAdapter.showMessage();

            }
        }
    
        public class TextLog : Log
        {

            TextDependecyGenerator textDependecyGenerator;
           public TextLog(TextDependecyGenerator obj)
            {
                textDependecyGenerator = obj;
            }
            
            public void logMessage()
            {
                textDependecyGenerator.callMethod();
                Console.WriteLine("textlogMessage logged");
            }
        }
        public class CSVLog : Log
        {
            
            CsvDependecyGenerator csvDependecyGenerator;
            public CSVLog(CsvDependecyGenerator obj)
            {
                csvDependecyGenerator = obj;
            }
            public void logMessage()
            {
                csvDependecyGenerator.callMethod();
                Console.WriteLine("CSVLogMessage logged");
            }
        }
        public class ExcelLog : Log
        {
             ExcelDependecyGenerator excelDependecyGenerator;
           public  ExcelLog(ExcelDependecyGenerator obj)
            {
                excelDependecyGenerator = obj;
            }
            public void logMessage()
            {
                excelDependecyGenerator.callMethod();
                Console.WriteLine("ExcelLogMessage logged");
            }
        }
        public class OracleLog : Log
        {
             OracelDependecyGenerator oracleDependecyGenerator;
            public OracleLog(OracelDependecyGenerator obj)
            {
                oracleDependecyGenerator = obj;
            }
            public void logMessage()
            {
                oracleDependecyGenerator.callMethod();
                Console.WriteLine("OracleLogMessage logged");
            }
        }
        public class SQLLog : Log
        {
            SQLDependecyGenerator sqlDependecyGenerator;
           public SQLLog(SQLDependecyGenerator obj)
            {
                sqlDependecyGenerator = obj;
            }
            public void logMessage()
            {
                sqlDependecyGenerator.callMethod();
                Console.WriteLine("SQLLogMessage logged");
            }
        }

        public class SqlConnection
        {
            public void showMessage()
            {
                Console.WriteLine("sqlConnection created");
            }
        }
        public class SqlAdapter
        {
            public void showMessage()
            {
                Console.WriteLine("sqlAdapter created");
            }
        }

        public class OracleConnection
        {
            public void showMessage()
            {
                Console.WriteLine("oracleConnection created");
            }
        }
        public class OracleAdapter
        {
            public void showMessage()
            {
                Console.WriteLine("oracleAdapter created");
            }
        }
        public class ExcelDriver
        {
            public void showMessage()
            {
                Console.WriteLine("excelDriver created");
            }
        }
        public class ExcelFile
        {
            public void showMessage()
            {
                Console.WriteLine("excelFile created");
            } 
        }
        public class CsvDriver
        {
            public void showMessage()
            {
                Console.WriteLine("csvDriver created");
            } 
        }
        public class CsvFile
        {
            public void showMessage()
            {
                Console.WriteLine("csvFile created");
            } 
        }
        public class TxtDriver
        {
            public void showMessage()
            {
                Console.WriteLine("txtDriver created");
            } 
        }
        public class TxtFile
        {
            public void showMessage()
            {
                Console.WriteLine("txtFile created");
            } 
        }

    



}
