using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderSolution
{

    class Program
    {
        static void Main(string[] args)
        
        { // Lets create the Director first
            Manufacturer newManufacturer = new Manufacturer();
            // Lets have the Builder class ready
            IPhoneBuilder phoneBuilder = null;

            // Now let us create an android phone
            phoneBuilder = new AndroidPhoneBuilder();
            newManufacturer.Construct(phoneBuilder);
            Console.WriteLine("A new Phone built:\n\n{0}", phoneBuilder.Phone.ToString());

            // Now let us create a Windows Phone
            phoneBuilder = new WindowsPhoneBuilder();
            newManufacturer.Construct(phoneBuilder);
            Console.WriteLine("A new Phone built:\n\n{0}", phoneBuilder.Phone.ToString());

            Console.Read();
        }
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
        
       
        
    }
    // This is the "ConcreteBuilder" class
    class AndroidPhoneBuilder : IPhoneBuilder
    {
        MobilePhone phone;

        public AndroidPhoneBuilder()
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
    class WindowsPhoneBuilder : IPhoneBuilder
    {
        MobilePhone phone;

        public WindowsPhoneBuilder()
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
    // This is the "Director" class
    class Manufacturer
    {
        public void Construct(IPhoneBuilder phoneBuilder)
        {
            phoneBuilder.BuildBattery();
            phoneBuilder.BuildOS();
            phoneBuilder.BuildScreen();
            phoneBuilder.BuildStylus();
        }
    }
    // This is the "Builder" class
    interface IPhoneBuilder
    {
        void BuildScreen();
        void BuildBattery();
        void BuildOS();
        void BuildStylus();
        MobilePhone Phone { get; }
    }
}
