class Bison : Herbivore
{
    public Bison()
    {
        Weight = 120;
    }

    public override void EatGrass()
    {
        Weight += 10;
        Console.WriteLine($"Bison eats grass. Weight = {Weight}");
    }
}
