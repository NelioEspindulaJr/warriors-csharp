using System;
using System.Collections.Generic;
class Program
{
    public static void Main(string[] args)
    {
        Weapon goodGuyWeapon = new Weapon("Steel Sword", 10);
        Weapon badGuyWeapon = new Weapon("War Hammer", 10);

        Armor goodGuyArmor = new Armor("Chainmail Armor", 0.15);
        Armor badGuyArmor = new Armor("Iron Shield", 0.15);

        Warrior goodGuy = new Warrior("John", goodGuyWeapon, goodGuyArmor, Faction.goodGuy);
        Warrior badGuy = new Warrior("William", badGuyWeapon, badGuyArmor, Faction.badGuy);

        Random random = new Random();

        int round = 1;
        int whoIsAttacking = random.Next(2);

        while (goodGuy.IsAlive && badGuy.IsAlive)
        {
            if (whoIsAttacking == 0)
            {
                goodGuy.Attack(badGuy);
                badGuy.Attack(goodGuy);
            }
            else
            {
                badGuy.Attack(goodGuy);
                goodGuy.Attack(badGuy);
            }

            if (!goodGuy.IsAlive || !badGuy.IsAlive)
            {
                break;
            }

            Console.WriteLine($"\n------ ROUND {round} -------");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{goodGuy.Name}'s health: {goodGuy.Health}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{badGuy.Name}'s health: {badGuy.Health}");
            Console.ResetColor();
            Console.WriteLine($"------ ROUND {round} -------\n");

            round++;
        }
    }
}