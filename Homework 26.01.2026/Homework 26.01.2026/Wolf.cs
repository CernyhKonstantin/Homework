class Wolf : Carnivore
{
    public Wolf()
    {
        Power = 90;
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
            Console.WriteLine($"Wolf eats herbivore. Power increased to {Power}");
        }
        else
        {
            Power -= 10;
            Console.WriteLine($"Wolf failed to hunt. Power decreased to {Power}");
        }
    }
}
