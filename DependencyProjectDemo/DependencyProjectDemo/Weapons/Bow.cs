using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyProjectDemo
{
    public class Bow : IWeapon
    {
        public int Damage { get ; set ; }

        public Bow()
        {
            Damage = 10;
        }
        public void MakeDamage()
        {
            Console.WriteLine($"Bow make damage {Damage}");
        }
    }
}
