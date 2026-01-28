abstract class Carnivore
{
    public int Power { get; protected set; }

    public abstract void Eat(Herbivore herbivore);
}
