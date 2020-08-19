using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyProjectDemo
{
    public interface IWeapon
    {
        int Damage { get; set; }
        void MakeDamage();
    }
}
