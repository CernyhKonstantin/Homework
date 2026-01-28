class Africa : Continent
{
    public override Herbivore CreateHerbivore()
    {
        return new Wildebeest();
    }

    public override Carnivore CreateCarnivore()
    {
        return new Lion();
    }
}
