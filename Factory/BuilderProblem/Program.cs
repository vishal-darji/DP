using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            AndroidPhone ph = new AndroidPhone();
            ph.BuildScreen();
            ph.BuildBattery();
            ph.BuildOS();
            ph.BuildStylus();
            Console.WriteLine("A new Phone built:\n\n{0}", ph.Phone.ToString());

            WindowsPhone wPh = new WindowsPhone();
            wPh.BuildScreen();
            wPh.BuildBattery();
            wPh.BuildOS();
            wPh.BuildStylus();
            Console.WriteLine("A new Phone built:\n\n{0}", wPh.Phone.ToString());


            Console.Read();

        }
    }
    // This is the "Builder" class
    interface IPhone
    {
        void BuildScreen();
        void BuildBattery();
        void BuildOS();
        void BuildStylus();
        MobilePhone Phone { get; }
    }
    #region enumns
    public enum ScreenType
    {
        ScreenType_TOUCH_CAPACITIVE,
        ScreenType_TOUCH_RESISTIVE,
        ScreenType_NON_TOUCH
    };

    public enum Battery
    {
        MAH_1000,
        MAH_1500,
        MAH_2000
    };

    public enum OperatingSystem
    {
        ANDROID,
        WINDOWS_MOBILE,
        WINDOWS_PHONE,
        SYMBIAN
    };

    public enum Stylus
    {
        YES,
        NO
    };

    #endregion
    // This is the "Product" class
    class MobilePhone
    {
        // fields to hold the part type
        string phoneName;
        ScreenType phoneScreen;
        Battery phoneBattery;
        OperatingSystem phoneOS;
        Stylus phoneStylus;

        public MobilePhone(string name)
        {
            phoneName = name;
        }

        // Public properties to access phone parts

        public string PhoneName
        {
            get { return phoneName; }
        }

        public ScreenType PhoneScreen
        {
            get { return phoneScreen; }
            set { phoneScreen = value; }
        }

        public Battery PhoneBattery
        {
            get { return phoneBattery; }
            set { phoneBattery = value; }
        }

        public OperatingSystem PhoneOS
        {
            get { return phoneOS; }
            set { phoneOS = value; }
        }

        public Stylus PhoneStylus
        {
            get { return phoneStylus; }
            set { phoneStylus = value; }
        }

        // Methiod to display phone details in our own representation
        public override string ToString()
        {
            return string.Format("Name: {0}\nScreen: {1}\nBattery {2}\nOS: {3}\nStylus: {4}",
                PhoneName, PhoneScreen, PhoneBattery, PhoneOS, PhoneStylus);
        }
        // This is the "ConcreteBuilder" class
        
    }
    class AndroidPhone : IPhone
    {
        MobilePhone phone;

        public AndroidPhone()
        {
            phone = new MobilePhone("Android Phone");
        }

        #region IPhoneBuilder Members

        public void BuildScreen()
        {
            phone.PhoneScreen = ScreenType.ScreenType_TOUCH_RESISTIVE;
        }

        public void BuildBattery()
        {
            phone.PhoneBattery = Battery.MAH_1500;
        }

        public void BuildOS()
        {
            phone.PhoneOS = OperatingSystem.ANDROID;
        }

        public void BuildStylus()
        {
            phone.PhoneStylus = Stylus.YES;
        }

        // GetResult Method which will return the actual phone
        public MobilePhone Phone
        {
            get { return phone; }
        }

        #endregion
    }
    // This is the "ConcreteBuilder" class
    class WindowsPhone : IPhone
    {
        MobilePhone phone;

        public WindowsPhone()
        {
            phone = new MobilePhone("Windows Phone");
        }

        #region IPhoneBuilder Members

        public void BuildScreen()
        {
            phone.PhoneScreen = ScreenType.ScreenType_TOUCH_CAPACITIVE;
        }

        public void BuildBattery()
        {
            phone.PhoneBattery = Battery.MAH_2000;
        }

        public void BuildOS()
        {
            phone.PhoneOS = OperatingSystem.WINDOWS_PHONE;
        }

        public void BuildStylus()
        {
            phone.PhoneStylus = Stylus.NO;
        }

        // GetResult Method which will return the actual phone
        public MobilePhone Phone
        {
            get { return phone; }
        }

        #endregion
    }
}