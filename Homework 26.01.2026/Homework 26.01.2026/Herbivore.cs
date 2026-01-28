abstract class Herbivore
{
    public int Weight { get; protected set; }
    public bool Life { get; private set; } = true;

    public abstract void EatGrass();

    public void Die()
    {
        Life = false;
    }
}
