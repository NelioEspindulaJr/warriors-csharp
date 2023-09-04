using System;

public class Armor
{
    public string Name { get; private set; }
    public double DefenseModifier { get; private set; }

    public Armor(string armorName, double armorDefenseModifier)
    {
        Name = armorName;
        DefenseModifier = armorDefenseModifier;
    }
}
