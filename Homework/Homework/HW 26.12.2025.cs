using System;
using System.Collections.Generic;

#region Interfaces

interface IItem
{
    string Name { get; }
    void Use(Hero hero);
}

#endregion

#region Abstract Base Class

abstract class Entity
{
    public string Name { get; protected set; }

    private int health;
    protected int maxHealth;

    public int Health => health;

    protected Entity(string name, int health)
    {
        Name = name;
        maxHealth = health;
        this.health = health;
    }

    public void TakeDamage(int amount)
    {
        if (amount < 0) return;
        health -= amount;
        if (health < 0) health = 0;
    }

    public void Heal(int amount)
    {
        if (amount < 0) return;
        health += amount;
        if (health > maxHealth) health = maxHealth;
    }

    public bool IsAlive => health > 0;

    public abstract void Attack(Entity target);
}

#endregion

#region Hero

class Hero : Entity
{
    public int Level { get; private set; } = 1;

    private int experience;
    public int Experience => experience;

    private int baseAttack;

    public List<IItem> Inventory { get; } = new List<IItem>();

    public Hero(string name, int health, int attack)
        : base(name, health)
    {
        baseAttack = attack;
    }

    public override void Attack(Entity target)
    {
        Console.WriteLine($"{Name} attacks for {baseAttack} damage.");
        target.TakeDamage(baseAttack);
    }

    public void GainExperience(int xp)
    {
        experience += xp;
        Console.WriteLine($"{Name} gains {xp} XP.");

        while (experience >= 100)
        {
            experience -= 100;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        baseAttack += 5;
        maxHealth += 20;
        Heal(20);
        Console.WriteLine($"LEVEL UP! {Name} is now level {Level}!");
    }
}

#endregion

#region Monsters

class Monster : Entity
{
    protected int attackPower;

    public Monster(string name, int health, int attack)
        : base(name, health)
    {
        attackPower = attack;
    }

    public override void Attack(Entity target)
    {
        Console.WriteLine($"{Name} claws the hero for {attackPower} damage.");
        target.TakeDamage(attackPower);
    }
}

class Boss : Monster
{
    private Random rand = new Random();

    public Boss(string name)
        : base(name, 200, 20) { }

    public override void Attack(Entity target)
    {
        bool critical = rand.Next(1, 101) <= 25;
        int damage = critical ? attackPower * 2 : attackPower;

        if (critical)
            Console.WriteLine($"{Name} lands a CRITICAL HIT for {damage} damage!");
        else
            Console.WriteLine($"{Name} attacks for {damage} damage.");

        target.TakeDamage(damage);
    }
}

#endregion

#region Items

class HealthPotion : IItem
{
    public string Name => "Health Potion";

    public void Use(Hero hero)
    {
        hero.Heal(40);
        Console.WriteLine("Health Potion used (+40 HP).");
    }
}

#endregion

#region Game

class Program
{
    static void Main()
    {
        Console.Write("Enter hero name: ");
        string heroName = Console.ReadLine();

        Console.WriteLine("Choose class:");
        Console.WriteLine("1 - Warrior (high health)");
        Console.WriteLine("2 - Mage (high damage)");

        int choice = int.Parse(Console.ReadLine());

        Hero hero = choice == 1
            ? new Hero(heroName, 150, 15)
            : new Hero(heroName, 100, 25);

        hero.Inventory.Add(new HealthPotion());

        List<Monster> dungeon = new List<Monster>
        {
            new Monster("Goblin", 60, 10),
            new Monster("Skeleton", 70, 12),
            new Monster("Orc", 90, 15)
        };

        Random rand = new Random();

        while (hero.IsAlive && dungeon.Count > 0)
        {
            Monster monster = dungeon[rand.Next(dungeon.Count)];
            Console.WriteLine($"\nA wild {monster.Name} appears!");

            while (hero.IsAlive && monster.IsAlive)
            {
                Console.WriteLine("\n1 - Attack");
                Console.WriteLine("2 - Use Potion");
                Console.WriteLine("3 - Run");

                int action = int.Parse(Console.ReadLine());

                if (action == 1)
                {
                    hero.Attack(monster);
                    if (monster.IsAlive)
                        monster.Attack(hero);
                }
                else if (action == 2 && hero.Inventory.Count > 0)
                {
                    hero.Inventory[0].Use(hero);
                    hero.Inventory.RemoveAt(0);
                }
                else if (action == 3)
                {
                    Console.WriteLine("You ran away!");
                    break;
                }

                Console.WriteLine($"Hero HP: {hero.Health}");
                Console.WriteLine($"{monster.Name} HP: {monster.Health}");
            }

            if (!monster.IsAlive)
            {
                Console.WriteLine($"{monster.Name} defeated!");
                hero.GainExperience(50);
                dungeon.Remove(monster);
            }
        }

        if (hero.IsAlive)
        {
            Console.WriteLine("\nFINAL BOSS APPEARS!");
            Boss boss = new Boss("Dragon");

            while (hero.IsAlive && boss.IsAlive)
            {
                hero.Attack(boss);
                if (boss.IsAlive)
                    boss.Attack(hero);

                Console.WriteLine($"Hero HP: {hero.Health}");
                Console.WriteLine($"Boss HP: {boss.Health}");
            }

            Console.WriteLine(hero.IsAlive
                ? "YOU DEFEATED THE BOSS! VICTORY!"
                : "YOU WERE SLAIN BY THE BOSS...");
        }
        else
        {
            Console.WriteLine("GAME OVER.");
        }
    }
}

#endregion
