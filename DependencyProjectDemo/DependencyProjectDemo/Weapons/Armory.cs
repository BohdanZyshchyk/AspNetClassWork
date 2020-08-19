using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyProjectDemo.Weapons
{
    static class Armory
    {
        //IOC container
        public static IWeapon GetWeapon()
        {
            var weapon = ConfigurationManager.AppSettings["weapon"];
            switch (weapon)
            {
                case "Sword": return new Sword();
                case "Bow": return new Bow();
                case "Gun": return new Gun();
                default:
                    return null;
            }
        }
    }
}
