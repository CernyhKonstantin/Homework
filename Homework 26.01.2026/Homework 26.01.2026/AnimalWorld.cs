class AnimalWorld
{
    private Herbivore herbivore;
    private Carnivore carnivore;

    public AnimalWorld(Continent continent)
    {
        herbivore = continent.CreateHerbivore();
        carnivore = continent.CreateCarnivore();
    }

    public void MealsHerbivores()
    {
        herbivore.EatGrass();
    }

    public void NutritionCarnivores()
    {
        carnivore.Eat(herbivore);
    }
}
