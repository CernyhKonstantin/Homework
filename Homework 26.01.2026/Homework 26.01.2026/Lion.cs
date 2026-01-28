class Lion : Carnivore
{
    public Lion()
    {
        Power = 110;
    }

    public override void Eat(Herbivore herbivore)
    {
        if (!herbivore.Life)
        {
            Console.WriteLine("Herbivore is already dead.");
            return;
        }

        if (Power > herbivore.Weight)
        {
            Power += 10;
            herbivore.Die();
            Console.WriteLine($"Lion eats herbivore. Power increased to {Power}");
        }
        else
        {
            Power -= 10;
            Console.WriteLine($"Lion failed to hunt. Power decreased to {Power}");
        }
    }
}
