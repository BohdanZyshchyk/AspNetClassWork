using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _04_PlanerProject.Entity
{
    public class EFContext: DbContext
    {
        public EFContext():base("DefaultConnection")
        {
        }

        public DbSet<PlanerEvent> Events { get; set; }
    }
}