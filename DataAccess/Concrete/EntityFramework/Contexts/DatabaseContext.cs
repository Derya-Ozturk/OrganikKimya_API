using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-0K32BU9; database=OrganikKimyaProject; integrated security=true; TrustServerCertificate=True");
        }

        public DbSet<User> User { get; set; }
        public DbSet<Fixture> Fixture { get; set; }
    }
}
