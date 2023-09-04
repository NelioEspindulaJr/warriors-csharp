using System;

public class Warrior
{
    public string Name { get; private set; }
    public Faction Faction { get; private set; }
    public double Health { get; private set; }
    public bool IsAlive { get; private set; }
    public Weapon Weapon { get; private set; }
    public Armor Armor { get; private set; }

    private const double GoodGuyStartingHealth = 100.0;
    private const double BadGuyStartingHealth = 100.0;

    private readonly Random random = new Random();

    public Warrior(string warriorName, Weapon warriorWeapon, Armor warriorArmor, Faction warriorFaction)
    {
        Name = warriorName;
        Faction = warriorFaction;
        Health = warriorFaction == Faction.goodGuy ? GoodGuyStartingHealth : BadGuyStartingHealth;
        Weapon = warriorWeapon;
        Armor = warriorArmor;
        IsAlive = true;
    }

    public void Attack(Warrior enemy)
    {
        if (!enemy.IsAlive)
        {
            return;
        }
        if (!IsAlive)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{enemy.Name} is the winner!.");
            Console.ResetColor();
            return;
        }

        double bonusModifier = GenerateBonusModifier();

        double damageDealt = CalculateDamageDealt(bonusModifier, enemy);

        if (bonusModifier == 20)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"WOW! {Name} attacks {enemy.Name} using {Weapon.Name} with a critical hit and causes {damageDealt} of damage!");
            Console.ResetColor();
        }
        else if (bonusModifier > 0)
        {
            Console.WriteLine($"{Name} attacks {enemy.Name} using {Weapon.Name} and causes {damageDealt} of damage!");
        }
        else
        {
            Console.WriteLine($"{Name}'s attack is ineffective against {enemy.Name}'s {enemy.Armor.Name}.");
        }

        enemy.TakeDamage(damageDealt);
    }

    public void TakeDamage(double damage)
    {
        if (IsAlive)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Health = 0;
                IsAlive = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name} has been defeated.");
                Console.ResetColor();
            }
        }
    }

    private double GenerateBonusModifier()
    {
        int d20 = random.Next(20);
        double bonusModifier;

        if (d20 <= 8)
        {
            bonusModifier = 0.21;
        }
        else if (d20 <= 15)
        {
            bonusModifier = 0.28;
        }
        else if (d20 <= 19)
        {
            bonusModifier = 0.33;
        }
        else if (d20 == 20)
        {
            bonusModifier = 0.99;
        }
        else
        {
            bonusModifier = 0;
        }

        return bonusModifier;
    }

    private double CalculateDamageDealt(double bonusModifier, Warrior enemy)
    {
        if (bonusModifier == 0)
        {
            return 0;
        }

        double damageDealt = (Weapon.Damage + (Weapon.Damage * bonusModifier)) - Weapon.Damage * enemy.Armor.DefenseModifier;
        return damageDealt;
    }
}