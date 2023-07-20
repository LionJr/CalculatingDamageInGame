using System;

namespace SomeGame
{
  class Program
  {
    static void Main(string[] args)
    {
      Random random = new Random();
      SwordDamage damage = new SwordDamage();

      while(true)
      {
        Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit: ");
        char key = Console.ReadKey().KeyChar;
      
        if(key != '0' && key != '1' && key != '2' && key != '3') return;
        int roll = random.Next(1,7) + random.Next(1,7) + random.Next(1,7);
        damage.Roll = roll;
        if(key=='1')
          damage.SetMagic(true);
        else if(key=='2')
          damage.SetFlaming(true);
        else if(key=='3')
        {
          damage.SetMagic(true);
          damage.SetFlaming(true);
        }
        else
          damage.SetMagic(false);
    
        Console.WriteLine($"\nRolled {roll} for {damage.Damage} HP\n");
      }
    }
  }

  class SwordDamage
  {
    public const int BASE_DAMAGE = 3;
    public const int FLAME_DAMAGE = 2;

    public int Roll;
    public decimal MagicMultiplier = 1M;
    public int Damage;

    public void CalculateDamage()
    {
      Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE;
    }

    public void SetMagic(bool isMagic)
    {
      if(isMagic)
        MagicMultiplier = 1.75M;
      else
        MagicMultiplier = 1M;

      CalculateDamage();
    }

    public void SetFlaming(bool isFlaming)
    {
      CalculateDamage();
      if(isFlaming)
        Damage += FLAME_DAMAGE;
    }
  }
}
  