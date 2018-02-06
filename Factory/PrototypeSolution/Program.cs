using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            


            weekDays wDays = new weekDays(true);
            weekDays copywDays = wDays;
            //weekDays copywDays = (weekDays)wDays.Clone(false);
            



            foreach (dynamic test in wDays.workingDays)
            {
                Console.WriteLine(test.isWorkingDay);
            }
            Console.WriteLine("-----------------------------------");
            foreach (dynamic test in copywDays.workingDays)
            {
                Console.WriteLine(test.isWorkingDay);
            }
            Console.ReadLine();
        }
    }
    public class Monday
    {
        public Monday(bool flag)
        {
            isWorkingDay = flag;
        }
        public bool isWorkingDay { get; set; }

        
    }
    public class Tueseday
    {
        public Tueseday(bool flag)
        {
            isWorkingDay = flag;
        }
        public bool isWorkingDay { get; set; }
    }
    public class Wedensday
    {
        public Wedensday(bool flag)
        {
            isWorkingDay = flag;
        }
        public bool isWorkingDay { get; set; }
    }
    public class Thursday
    {
        public Thursday(bool flag)
        {
            isWorkingDay = flag;
        }
        public bool isWorkingDay { get; set; }
    }
    public class Friday
    {
        public Friday(bool flag)
        {
            isWorkingDay = flag;
        }
        public bool isWorkingDay { get; set; }
    }
    public class Saturday
    {
        public Saturday(bool flag)
        {
            isWorkingDay = flag;
        }
        public bool isWorkingDay { get; set; }
    }
    public class Sunday
    {
        public Sunday(bool flag)
        {
            isWorkingDay = flag;
        }
        public bool isWorkingDay { get; set; }
    }

    public abstract class days
    {
        public abstract days Clone(bool flag);
    }

    public class weekDays:days
    {
        ArrayList arrayList = new ArrayList();
        public weekDays(bool flag)
        {
            arrayList.Add(new Monday(flag));
            arrayList.Add(new Tueseday(flag));
            arrayList.Add(new Wedensday(flag));
            arrayList.Add(new Thursday(flag));
            arrayList.Add(new Friday(flag));
            workingDays = arrayList;

        }
        public ArrayList workingDays { get; set; }
        public void setArraylistValue(bool val)
        {
            foreach (dynamic test in workingDays)
            {
                test.isWorkingDay = false;
            }

        }


        public override days Clone(bool flag)
        {
            return new weekDays(flag);
        }
    }
    public class WeekEnds
    {
        public ArrayList days { get; set; }

    }
            
}
