using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Africa ===");
        AnimalWorld africa = new AnimalWorld(new Africa());
        africa.MealsHerbivores();
        africa.NutritionCarnivores();

        Console.WriteLine("\n=== North America ===");
        AnimalWorld northAmerica = new AnimalWorld(new NorthAmerica());
        northAmerica.MealsHerbivores();
        northAmerica.NutritionCarnivores();
    }
}
