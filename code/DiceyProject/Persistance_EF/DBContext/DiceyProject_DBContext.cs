using Microsoft.EntityFrameworkCore;
using Persistance_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_EF.DBContext
{
    public class DiceyProject_DBContext : DbContext
    {
        public DbSet<ProfileEntity> ProfilesSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DiceyProject.mdf;Trusted_Connection=True;");
        }
    }
}
