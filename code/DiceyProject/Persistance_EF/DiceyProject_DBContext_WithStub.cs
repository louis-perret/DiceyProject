using Microsoft.EntityFrameworkCore;
using Modele.Business.ProfileFolder;
using Persistance_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_EF
{
    /// <summary>
    /// Allow us to do have a stub in our data base when this latter is created
    /// </summary>
    public class DiceyProject_DBContext_WithStub : DiceyProject_DBContext
    {
        /// <summary>
        /// Empty constructor
        /// </summary>
        public DiceyProject_DBContext_WithStub() { }

        /// <summary>
        /// Constructor with optional options
        /// </summary>
        /// <param name="options">optional options, especially for the database provider that we want to use</param>
        public DiceyProject_DBContext_WithStub(DbContextOptions<DiceyProject_DBContext> options) : base(options) { }

        /// <summary>
        /// Method called when the database is created. Allow us to set a data set in it.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProfileEntity>().HasData(
                new ProfileEntity(1, "Perret", "Louis"),
                new ProfileEntity(2, "Malvezin", "Neitah"),
                new ProfileEntity(3, "Grienenberger", "Côme"),
                new ProfileEntity(4, "Perret", "Christele"),
                new ProfileEntity(5, "Perret", "Bruno"),
                new ProfileEntity(6, "Perret", "Antoine"),
                new ProfileEntity(7, "Perret", "Mathilde"),
                new ProfileEntity(8, "Kim", "Minji"),
                new ProfileEntity(9, "Kim", "Bora"),
                new ProfileEntity(10, "Lee", "Siyeon"),
                new ProfileEntity(11, "Han", "Dong")
            );
        }
    }
}
