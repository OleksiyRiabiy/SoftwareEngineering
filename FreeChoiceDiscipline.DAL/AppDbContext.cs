using FreeChoiceDiscipline.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeChoiceDiscipline.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(options: dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
