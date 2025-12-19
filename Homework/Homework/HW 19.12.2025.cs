using System;

namespace OfficeManagement
{
    // Interfaces
    interface IPrintable
    {
        void Print();
    }

    interface IScannable
    {
        void Scan();
    }

    interface ICopyable
    {
        void Copy();
    }

    interface IOfficeDevice
    {
        void TurnOn();
        void TurnOff();
    }

    // Abstract class for all office devices
    abstract class OfficeDevice : IOfficeDevice
    {
        public string Name { get; set; }

        public OfficeDevice(string name)
        {
            Name = name;
            Console.WriteLine($"{Name} created");
        }

        public virtual void TurnOn()
        {
            Console.WriteLine($"{Name} is ON");
        }

        public virtual void TurnOff()
        {
            Console.WriteLine($"{Name} is OFF");
        }
    }

    // Printer class
    class Printer : OfficeDevice, IPrintable
    {
        public Printer(string name) : base(name) { }

        public void Print()
        {
            Console.WriteLine($"{Name} is printing a document...");
        }
    }

    // Scanner class
    class Scanner : OfficeDevice, IScannable
    {
        public Scanner(string name) : base(name) { }

        public void Scan()
        {
            Console.WriteLine($"{Name} is scanning a document...");
        }
    }

    // Copier class
    class Copier : OfficeDevice, ICopyable
    {
        public Copier(string name) : base(name) { }

        public void Copy()
        {
            Console.WriteLine($"{Name} is copying a document...");
        }
    }

    // Multi-functional device (MFU)
    class Mfu : OfficeDevice, IPrintable, IScannable, ICopyable
    {
        public Mfu(string name) : base(name) { }

        public void Print()
        {
            Console.WriteLine($"{Name} is printing a document...");
        }

        public void Scan()
        {
            Console.WriteLine($"{Name} is scanning a document...");
        }

        public void Copy()
        {
            Console.WriteLine($"{Name} is copying a document...");
        }
    }

    // Office class to manage multiple devices
    class Office
    {
        private OfficeDevice[] devices;

        public Office(OfficeDevice[] devices)
        {
            this.devices = devices;
        }

        public void TurnOnAll()
        {
            Console.WriteLine("\n--- Turning on all devices ---");
            foreach (var device in devices)
            {
                device.TurnOn();
            }
        }

        public void TurnOffAll()
        {
            Console.WriteLine("\n--- Turning off all devices ---");
            foreach (var device in devices)
            {
                device.TurnOff();
            }
        }

        public void StartPrint()
        {
            Console.WriteLine("\n--- Starting Print on all capable devices ---");
            foreach (var device in devices)
            {
                if (device is IPrintable printable)
                    printable.Print();
            }
        }

        public void StartScan()
        {
            Console.WriteLine("\n--- Starting Scan on all capable devices ---");
            foreach (var device in devices)
            {
                if (device is IScannable scannable)
                    scannable.Scan();
            }
        }

        public void StartCopy()
        {
            Console.WriteLine("\n--- Starting Copy on all capable devices ---");
            foreach (var device in devices)
            {
                if (device is ICopyable copyable)
                    copyable.Copy();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating devices
            OfficeDevice[] devices =
            {
                new Printer("HP Printer"),
                new Scanner("Canon Scanner"),
                new Copier("Xerox Copier"),
                new Mfu("Epson MFU")
            };

            // Creating office
            Office office = new Office(devices);

            // Testing all operations
            office.TurnOnAll();
            office.StartPrint();
            office.StartScan();
            office.StartCopy();
            office.TurnOffAll();
        }
    }
}
