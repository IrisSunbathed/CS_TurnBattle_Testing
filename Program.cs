// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
/*enum EnemyNames
    {
    Magicius,
    Fatalicius,
    Babycius,
    Dipshit
    }*/
class Game
{
    static void Main(string[] args)
    {
        bool PlayerTurn = true;
        int turn = 1;
        int EnemyHealthTotal = 300;
        int EnemyAttackTotal = 50;
        Mage Magicius = new(EnemyHealthTotal, EnemyAttackTotal, "Mage");
        Player Iris = new();
        bool validInput = true;
        string? PlayerAction;
        int TotalRounds = 3;
        int defenseValue = 0;

        string[] EnemyNames = ["Magicius",
        "Fatalicius",
        "Babycius",
        "Dipshit"];

        /*Console.WriteLine("Magicious Health: " + Magicius.Health);
        Magicius.LevelUp();
        Console.WriteLine("Magicious Health: " + Magicius.Health);
        Magicius.Attack();
        Magicius.LevelUp();
        Console.WriteLine("Magicious Health: " + Magicius.Power);*/



        for (var i = 0; i < TotalRounds; i++)
        {
            if (Magicius.Health <= 0)
            {
                Console.WriteLine("A new enemy appears.");
                Magicius.Health = EnemyHealthTotal;
                Magicius.LevelUp();
                Iris.LevelUp();
            }
            if (Iris.Health <= 0)
            {
                break;
            }
            do
            {
                while (PlayerTurn & Iris.Health > 0 & Magicius.Health > 0)
                {
                    Console.WriteLine("Turn: " + turn + "\n Player health: " + Iris.Health + ". Player charge: " + Iris.Charge + "\n Enemy health: " + Magicius.Health + ". Enemy Charge: " + Magicius.Charge);
                    if (Magicius.Charge == 3)
                    {
                        Console.WriteLine("The enemy is preparing a powerful attack!");
                    }
                    if (Iris.Charge == 3)
                    { Console.WriteLine("Choose your action.\n A: Attack !! \n B: Defense \n Type \"A\" twice to double attack"); }
                    else
                    { Console.WriteLine($"Choose your action.\n A: Attack \n B: Defense"); }
                    if (Iris.canFireThunder && Iris.Charge == 3)
                    {
                        Console.WriteLine(" C: Special Attack");
                    }

                    do
                    {
                        if (defenseValue != 0)
                        {
                            Iris.Defense = -defenseValue;
                            defenseValue = 0;
                            Console.WriteLine("The player downs their guard.");
                        }
                        PlayerAction = Console.ReadLine();

                        switch (PlayerAction)
                        {
                            case "Attack":
                            case "A":
                                Iris.Attack(Magicius);
                                validInput = true;
                                break;
                                case "AA":
                                if (Iris.Charge == 3)
                                {
                                    Iris.Attack(Magicius, true);
                                
                                }
                                else
                                {
                                    Console.WriteLine("Not enough charge!");
                                    Console.WriteLine("Choose your action.\n A: Attack \n B: Defense");
                                    validInput = false;
                                    continue;
                                }
                                break;
                            case "Defend":
                            case "B":
                                defenseValue = Iris.Defend();
                                validInput = true;
                                break;
                            case "Special Attack":
                            case "C":
                                Console.WriteLine("A: Ice Thunder\nB: Back");
                                PlayerAction = Console.ReadLine();
                                switch (PlayerAction)
                                {
                                    case "A":
                                    case "Ice Thunder":
                                        Iris.IceThunder(Magicius);
                                        break;
                                    case "B":
                                    case "Back":
                                        Console.WriteLine("Choose your action.\n A: Attack \n B: Defense");
                                        if (Iris.canFireThunder && Iris.Charge == 3)
                                        {
                                            Console.WriteLine("C: Special Attack");
                                        }

                                        validInput = false;
                                        continue;
                                }

                                break;
                            default:

                                Console.WriteLine("Please, input a valid action.");
                                validInput = false;


                                break;

                        }
                    }
                    while (!validInput);



                    PlayerTurn = false;

                }
                Thread.Sleep(1500);
                while (!PlayerTurn & Iris.Health > 0 & Magicius.Health > 0)
                {

                    if (Magicius.Charge == 3)
                    {
                        Magicius.FireBall(Iris);
                    }
                    else
                    {
                        Magicius.Attack(Iris);
                    }



                    PlayerTurn = true;
                    turn++;

                }
                Thread.Sleep(1500);
            }

            while (Iris.Health > 0 & Magicius.Health > 0);
        }


        Console.WriteLine("Combat is over.");
        if (Iris.Health <= 0)
        {
            Console.WriteLine("Enemy Wins");
        }
        else if (Magicius.Health <= 0)
        {
            Console.WriteLine("Player Wins");
        }
        Console.WriteLine("Turn: " + turn + "\n Player health: " + Iris.Health + "\n Enemy health: " + Magicius.Health);
    }
}