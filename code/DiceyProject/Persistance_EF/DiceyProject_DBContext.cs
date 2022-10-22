using Microsoft.EntityFrameworkCore;
using Persistance_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_EF
{
    /// <summary>
    /// Context of our database. It allows us to access to our data and to apply changement on local to the database
    /// </summary>
    public class DiceyProject_DBContext : DbContext
    {
        /// <summary>
        /// List of profiles on database
        /// </summary>
        public DbSet<ProfileEntity> ProfilesSet { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public DiceyProject_DBContext() { }

        /// <summary>
        /// Constructor with optional Options
        /// </summary>
        /// <param name="options"></param>
        public DiceyProject_DBContext(DbContextOptions<DiceyProject_DBContext> options) : base(options) { }

        /// <summary>
        /// Etablish the connection to the database
        /// </summary>
        /// <param name="optionsBuilder">optional Options, especially for the database provider that we want to use</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DiceyProject.mdf;Trusted_Connection=True;");
            }
        }
    }
}
