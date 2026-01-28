class Wildebeest : Herbivore
{
    public Wildebeest()
    {
        Weight = 100;
    }

    public override void EatGrass()
    {
        Weight += 10;
        Console.WriteLine($"Wildebeest eats grass. Weight = {Weight}");
    }
}
