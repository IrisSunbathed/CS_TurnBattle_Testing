

public class Enemy
{
//test edit
   
    public int Health { get; set; }
   
   
    public int Level { get; set; }
   
    public int Power { get; set; }
    
    public int Charge { get; set; }
    public enum EnergyTypes
    { Fire, Ice, Air, Bark, Unknown }
    public EnergyTypes attackType;


    public EnergyTypes AttackType
    {
        get { return attackType; }
        set { attackType = value; }
    }

    public Enemy(int Health, int Power/*, string AttackType = "Unknown"*/)
    {
        this.Health = 30;
        this.Power = 30;/*;
        this.AttackType = AttackType;*/
    }

    public virtual void Attack(Player target)
    {
        Console.WriteLine($"The enemy attacks with {Power} damage to {target}");
        target.Health -= Power;
    }
    public virtual void LevelUp()
    {
      Power += 30;
        Health +=50;
        Level ++;
        Console.WriteLine("The enemy has leveled up! The current level is " + Level);
    }

}
