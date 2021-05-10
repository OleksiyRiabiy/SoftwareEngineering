using FreeChoiceDiscipline.DAL.Configuration;
using FreeChoiceDiscipline.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeChoiceDiscipline.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        //public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());


        }
    }
}
