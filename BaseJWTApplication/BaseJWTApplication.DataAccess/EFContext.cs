﻿using BaseJWTApplication.DataAccess.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWTApplication.DataAccess
{
    public class EFContext: IdentityDbContext<User>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<UserAdditionalInfo> UserAdditionalInfos{ get; set; }
        public EFContext(DbContextOptions<EFContext> dbContext):base(dbContext){}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.UserAdditionalInfo)
                .WithOne(t => t.User)
                .HasForeignKey<UserAdditionalInfo>(r => r.Id);
            base.OnModelCreating(builder);
        }
    }
}
