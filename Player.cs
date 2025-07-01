

public class Player : IIceThunder
{

    private int baseHealth;

    private int basePower;
    private int baseDefense;
    public double health;
    public double Health { get { return health; } set { if (value < 0) { health = 0; } else { health = value; } } }

    public int Defense { get; set; }
    public int Level { get; set; }
    public bool canFireThunder = false;
    public int Charge { get; set; }
    public double Power { get; set; }
    public enum EnergyTypes
    { Fire, Ice, Air, Bark, Unknown }
    public EnergyTypes attackType;


    public EnergyTypes AttackType
    {
        get { return attackType; }
        set { attackType = value; }
    }

    public Player(int Health = 500, double Power = 30, int Defense = 5)
    {
        this.Health = Health;
        this.Power = Power;
        this.Defense = Defense;
        baseHealth = Health;
        basePower = (int)Power;
        baseDefense = Defense;
        Level = 1;
    }


    public int Defend()
    {

        Defense += 5;
        Console.WriteLine("The player guards!");
        return 5;

        //After the turn, take the value off of Defense
    }

    //@todo add new skill when LevelUp: special attack (deals more damage)

    public void Attack(Enemy target, bool arternateAction = false)
    {
        if (arternateAction)
        {
            Console.WriteLine($"Wamp! Double Attack. The player deals {Power * 2} damage");
            target.Health -= (int)Power * 2;
            Charge = 0;
        }
        else
        { Console.WriteLine($"The player attacks dealing {Power} damage"); target.Health -= (int)Power; }
        
        if (Charge < 3)
        { Charge++; }
        ;
    }
    //@todo adjust leveling up. When attacking, it should be rounded up to avoid double
    public void LevelUp()
    {
        Power += Math.Ceiling(basePower * 1.25); //keep values round
        basePower = (int)Power;
        Health = baseHealth * 1.25;
        baseHealth = (int)Health;
        Level++;
        Defense++;
        Charge = 3;
        if (Level == 2)
        {
            canFireThunder = true;
        }
        Console.WriteLine("The player has leveled up! The current level is " + Level);
    }

    public void IceThunder(Enemy target)
    {
        int IceThunderPower = (int)Power + 30;
        target.Health -= IceThunderPower;
        Console.WriteLine($"The player eyes turn white as they rise their hands to the sky.\n The clouds gather around them, making the scene cold. A lighting bolt goes into their arms. In an instant, they scream and throw a lighting bold that hits the enemy dealing {IceThunderPower} damage");
        Charge = 0;
    }


}