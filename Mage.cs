

class Mage : Enemy, IFireBallThrow
{

    public string EnemyType { get; set; }

    //The constructor is not inherited

    public Mage(int Health, int Power, string EnemyType = "enemy"/*, string AttackType = "Unknown"*/) : base(Health, Power)
    {
        this.EnemyType = EnemyType;
        this.Health = Health;
        this.Power = Power;
        Level = 1;/*;
        this.AttackType = AttackType;*/
    }
    public override void Attack(Player target)
    {
        Console.WriteLine($"The {EnemyType} attacks dealing {Power} damage to {target}");
        target.Health -= Power - target.Defense;
        Charge++;
    }
    public override void LevelUp()
    {
        Power += 30;
        Health += 200;
        Level++;/*
        Console.WriteLine($"The {EnemyType} has leveled up! The current level is " + Level);*/
    }

    public void FireBall(Player target)
    {
        target.Health -= Power + 10 - target.Defense;
        Charge = 0;
        Console.WriteLine($"The {EnemyType} attacks with a Fireball dealing {Power + 10} damage to {target}");
    }
    
}