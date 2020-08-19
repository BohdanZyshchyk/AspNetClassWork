using System;

namespace DependencyProjectDemo.Weapons
{
    internal class Gun : IWeapon
    {
        public int Damage { get; set; }

        public Gun()
        {
            Damage = 50;
        }
        public void MakeDamage()
        {
            Console.WriteLine($"Gun make damage {Damage}");
        }
    }
}