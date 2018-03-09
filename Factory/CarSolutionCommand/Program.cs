using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSolutionCommand
{
    class Program
    {
        static void Main(string[] args)
        {
            Car objCar = new Car();
            Command objOffCommand = new EngineOffCommand(objCar);
            Command objOnCommand = new EngineOnCommand(objCar);

            carProcessor objCarProcessor = new carProcessor(objOffCommand);
            objCarProcessor.pressEngineButton();

            objCarProcessor = new carProcessor(objOnCommand);
            objCarProcessor.pressEngineButton();

            Console.ReadLine();
            

        }
    }
    public class Car
    { 
        private bool carButton;
        public void EngineOff()
        {
            carButton = false;
            Console.WriteLine("Car Engine Off");
        }
        public void EngineOn()
        {
            carButton = true;
            Console.WriteLine("Car Engine On");
        }

    }
    public abstract class Command
    {

        public abstract void Execute();
    }

    public class EngineOffCommand : Command
    {
        private Car objCar;

        public EngineOffCommand(Car car)
        {
            this.objCar = car;
        }

        public override void Execute()
        {
            this.objCar.EngineOff();
        }

    }
    public class EngineOnCommand : Command
    {
        private Car objCar;

        public EngineOnCommand(Car car)
        {
            this.objCar = car;
        }

        public override void Execute()
        {
            this.objCar.EngineOn();
        }
    }
    public class carProcessor
    {
        Command objCommand;
        public carProcessor(Command cmd)
        {
            this.objCommand = cmd;
        }

        public void pressEngineButton()
        {
            objCommand.Execute();
        }


    }
}
