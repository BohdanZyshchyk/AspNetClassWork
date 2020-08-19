using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//SOLID

namespace DependencyProjectDemo
{
    public class Player
    {
        private readonly IWeapon Weapon;
        // Dependency injection via ctor
        public Player(IWeapon weapon)
        {
            Weapon = weapon;
        }

        // Dependency injection via method
        //public void SetWeapon(IWeapon weapon)
        //{
        //    Weapon = weapon;
        //}
        public void Attack()
        {
            Weapon.MakeDamage();
        }
    }
}
