using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Processor control = new Processor();
            Screen scrn = new Screen();
            Command scrnOn = new ScreenOnCommand(scrn);
            Command scrnOff = new ScreenOffCommand(scrn);
            //switch on
            control.setCommand(scrnOn);
            control.pressButton();
            //switch off
            control.setCommand(scrnOff);
            control.pressButton();
            Console.ReadLine();
        }
    }


    //Command
    public interface Command
    {
        void execute();
    }




    //Concrete Command
    public class ScreenOnCommand : Command
    {
        //reference to the light
        Screen light;
        public ScreenOnCommand(Screen light)
        {
            this.light = light;
        }
        public void execute()
        {
            light.switchOn();
        }
    }

    //Concrete Command
    public class ScreenOffCommand : Command
    {
        //reference to the light
        Screen screen;
        public ScreenOffCommand(Screen light)
        {
            this.screen = light;
        }
        public void execute()
        {
            screen.switchOff();
        }
    }


    //Receiver
    public class Screen
    {
        private bool on;
        public void switchOn()
        {
            Console.WriteLine("screen ON");
            on = true;
        }
        public void switchOff()
        {
            Console.WriteLine("screen OFF");
            on = false;
        }
    }


    //Invoker
    public class Processor
    {
        private Command command;
        public void setCommand(Command command)
        {
            this.command = command;
        }
        public void pressButton()
        {
            command.execute();
        }
    }

}
