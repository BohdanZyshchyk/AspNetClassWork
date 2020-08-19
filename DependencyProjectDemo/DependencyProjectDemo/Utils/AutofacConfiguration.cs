using Autofac;
using DependencyProjectDemo.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyProjectDemo.Utils
{
    public static class AutofacConfiguration
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            // get Sword when ask IWeapon
            builder.RegisterType<Gun>().As<IWeapon>();

            return builder.Build();
        }
    }
}
