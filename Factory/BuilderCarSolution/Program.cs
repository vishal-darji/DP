using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderCarProblem
{
    /// <summary>
    /// Problem
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface ICar
    {
        void BuildEngine();
        void BuildTyres();
        void SetColour();
        
    
    }
    
    public enum EngineType
    { 
        Medium,
        Heavy,
        Regular

    };
    public enum TyreType
    {
        Regular,
        RaceTyre,
        MountainTyre

    };
    public enum Colour
    {
        Red,
        Green,
        Blue

    };

    public class Car
    {
        public EngineType EngineTypeProp { get; set; }
        public TyreType EngineTypeProp1 { get; set; }
        public Colour colourprop { get; set; }
    
    }

    public class RegularCar : ICar
    {

        Car objCar = new Car();
        public void BuildEngine()
        {
            throw new NotImplementedException();
        }

        public void BuildTyres()
        {
            throw new NotImplementedException();
        }

        public void SetColour()
        {
            throw new NotImplementedException();
        }
    }
}
