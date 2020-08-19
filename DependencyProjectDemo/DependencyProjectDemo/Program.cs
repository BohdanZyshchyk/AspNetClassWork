using Autofac;
using DependencyProjectDemo.Utils;
using DependencyProjectDemo.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyProjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //custom IOC
            //Player p = new Player(Armory.GetWeapon());
            //p.Attack();

            var container = AutofacConfiguration.GetContainer();
            IWeapon weapon = container.Resolve<IWeapon>();
            Player p = new Player(weapon);
            p.Attack();
        }
    }
}
