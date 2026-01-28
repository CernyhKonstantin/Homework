class NorthAmerica : Continent
{
    public override Herbivore CreateHerbivore()
    {
        return new Bison();
    }

    public override Carnivore CreateCarnivore()
    {
        return new Wolf();
    }
}
