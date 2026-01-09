using System;
using System.Collections;
using System.Collections.Generic;

// Base class for all sea creatures
public abstract class SeaCreature
{
    public string Name { get; set; }
    public int Age { get; set; }

    public SeaCreature(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public abstract void DisplayInfo();
}

// Concrete sea creature classes
public class Shark : SeaCreature
{
    public Shark(string name, int age) : base(name, age) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Shark: Name = {Name}, Age = {Age}");
    }
}

public class Dolphin : SeaCreature
{
    public Dolphin(string name, int age) : base(name, age) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Dolphin: Name = {Name}, Age = {Age}");
    }
}

public class Octopus : SeaCreature
{
    public Octopus(string name, int age) : base(name, age) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Octopus: Name = {Name}, Age = {Age}");
    }
}

// Oceanarium with iterator support
public class Oceanarium : IEnumerable<SeaCreature>
{
    private List<SeaCreature> inhabitants = new List<SeaCreature>();

    public void AddCreature(SeaCreature creature)
    {
        inhabitants.Add(creature);
    }

    public IEnumerator<SeaCreature> GetEnumerator()
    {
        return inhabitants.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        Oceanarium oceanarium = new Oceanarium();

        oceanarium.AddCreature(new Shark("Great White", 12));
        oceanarium.AddCreature(new Dolphin("Flipper", 8));
        oceanarium.AddCreature(new Octopus("Octy", 4));

        Console.WriteLine("Oceanarium inhabitants:");
        foreach (SeaCreature creature in oceanarium)
        {
            creature.DisplayInfo();
        }
    }
}
