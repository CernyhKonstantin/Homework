using System;
using System.Collections.Generic;

class BackpackItem
{
    public string Name { get; set; }
    public double Volume { get; set; }

    public BackpackItem(string name, double volume)
    {
        Name = name;
        Volume = volume;
    }

    public override string ToString()
    {
        return $"{Name} (Volume: {Volume})";
    }
}

class Backpack
{
    // Characteristics
    public string Color { get; private set; }
    public string Brand { get; private set; }
    public string Fabric { get; private set; }
    public double Weight { get; private set; }
    public double MaxVolume { get; private set; }

    private List<BackpackItem> contents = new List<BackpackItem>();

    // Events
    public event Action<BackpackItem> ItemAdded;
    public event Action<BackpackItem> ItemRemoved;
    public event Action<BackpackItem> ItemChanged;

    public Backpack(string color, string brand, string fabric, double weight, double maxVolume)
    {
        Color = color;
        Brand = brand;
        Fabric = fabric;
        Weight = weight;
        MaxVolume = maxVolume;
    }

    private double CurrentVolume()
    {
        double sum = 0;
        foreach (var item in contents)
            sum += item.Volume;
        return sum;
    }

    public void AddItem(BackpackItem item)
    {
        if (CurrentVolume() + item.Volume > MaxVolume)
            throw new Exception("Backpack volume exceeded!");

        contents.Add(item);
        ItemAdded?.Invoke(item);
    }

    public void RemoveItem(string name)
    {
        BackpackItem item = contents.Find(i => i.Name == name);
        if (item != null)
        {
            contents.Remove(item);
            ItemRemoved?.Invoke(item);
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    public void ChangeItem(string name, double newVolume)
    {
        BackpackItem item = contents.Find(i => i.Name == name);
        if (item == null)
        {
            Console.WriteLine("Item not found.");
            return;
        }

        double volumeWithoutItem = CurrentVolume() - item.Volume;
        if (volumeWithoutItem + newVolume > MaxVolume)
            throw new Exception("Backpack volume exceeded after modification!");

        item.Volume = newVolume;
        ItemChanged?.Invoke(item);
    }

    public void PrintContents()
    {
        Console.WriteLine("\nBackpack contents:");
        foreach (var item in contents)
            Console.WriteLine(item);

        Console.WriteLine($"Current volume: {CurrentVolume()} / {MaxVolume}\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Backpack backpack = new Backpack(
            color: "Black",
            brand: "Adidas",
            fabric: "Polyester",
            weight: 1.1,
            maxVolume: 20
        );

        // Anonymous event handlers
        backpack.ItemAdded += delegate (BackpackItem item)
        {
            Console.WriteLine($"[EVENT] Item added: {item}");
        };

        backpack.ItemRemoved += delegate (BackpackItem item)
        {
            Console.WriteLine($"[EVENT] Item removed: {item}");
        };

        backpack.ItemChanged += delegate (BackpackItem item)
        {
            Console.WriteLine($"[EVENT] Item changed: {item}");
        };

        while (true)
        {
            Console.WriteLine("===== BACKPACK MENU =====");
            Console.WriteLine("1 - Add item");
            Console.WriteLine("2 - Remove item");
            Console.WriteLine("3 - Change item volume");
            Console.WriteLine("4 - Show backpack contents");
            Console.WriteLine("0 - Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            try
            {
                if (choice == "1")
                {
                    Console.Write("Item name: ");
                    string name = Console.ReadLine();

                    Console.Write("Item volume: ");
                    double volume = double.Parse(Console.ReadLine());

                    backpack.AddItem(new BackpackItem(name, volume));
                }
                else if (choice == "2")
                {
                    Console.Write("Item name to remove: ");
                    string name = Console.ReadLine();
                    backpack.RemoveItem(name);
                }
                else if (choice == "3")
                {
                    Console.Write("Item name to change: ");
                    string name = Console.ReadLine();

                    Console.Write("New volume: ");
                    double volume = double.Parse(Console.ReadLine());

                    backpack.ChangeItem(name, volume);
                }
                else if (choice == "4")
                {
                    backpack.PrintContents();
                }
                else if (choice == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid menu option!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}
