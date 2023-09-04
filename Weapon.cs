using System;

public class Weapon
{
    public string Name { get; private set; }
    public double Damage { get; private set; }

    public Weapon(string weaponName, double weaponDamage)
    {
        Name = weaponName;
        Damage = weaponDamage;
    }
}
