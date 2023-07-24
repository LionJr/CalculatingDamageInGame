using System;

namespace SomeGame
{
  class Program
  {
    static Random random = new Random();
    static void Main(string[] args)
    {
      SwordDamage swordDamage = new SwordDamage(RollDice());

      while(true)
      {
        Console.Write("0 for no flaming/magic, 1 for magic, 2 for flaming, 3 for both, anything else to quit: ");
        char key = Console.ReadKey().KeyChar;
        if(key!='0' && key!='1' && key!='2' && key!='3') return;
        swordDamage.Roll = RollDice();
        swordDamage.Magic = (key == '1' || key == '3');
        swordDamage.Flaming = (key == '2' || key == '3');
        Console.WriteLine($"\nRolled {swordDamage.Roll} for {swordDamage.Damage} HP\n");
      }
    }
    private static int RollDice()
    {
      return random.Next(1,7) + random.Next(1,7) + random.Next(1,7);
    }
  }
  class SwordDamage
  {
    const int BASE_DAMAGE = 3;
    const int FLAME_DAMAGE = 2;

    ///<summary>
    /// Contains the calculated damage.
    ///</summary>
    public int Damage {get; private set;}
    private int roll;
    ///<summary>
    /// Sets or gets the 3d6 roll.
    ///</summary>
    public int Roll
    {
      get {return roll;}
      set
      {
        roll=value;
        CalculateDamage();
      }
    }
    private bool magic;
    ///<summary>
    ///If true sword is magic, else if false not magic
    ///</summary>
    public bool Magic
    {
      get {return magic;}
      set
      {
        magic=value;
        CalculateDamage();
      }
    }
    private bool flaming;
    ///<summary>
    ///If true sword if flaming, else if false not flaming
    ///</summary>
    public bool Flaming
    {
      get {return flaming;}
      set
      {
        flaming=value;
        CalculateDamage();
      }
    }
    ///<summary>
    ///Calculates damage based on current value of properties
    ///</summary>
    private void CalculateDamage()
    {
      decimal magicMultiplier = 1M;
      if(Magic) magicMultiplier = 1.75M;

      Damage = (int)(Roll*magicMultiplier) + BASE_DAMAGE;
      if(flaming) Damage += FLAME_DAMAGE;
    }
    ///<summary>
    ///Constructor calculates base damage basing on default value of Flaming and Magic properties, 
    ///and value of roll by given args.
    ///</summary>
    ///<param name="startingRoll">First roll of 3d6 dices </param>
    public SwordDamage(int startingRoll)
    {
      roll = startingRoll;
      CalculateDamage();
    }
  }
} 
