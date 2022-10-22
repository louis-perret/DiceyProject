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
        /// Constructor with optional Options
        /// </summary>
        /// <param name="options">optional Options, especially for the database provider that we want to use</param>
        public DiceyProject_DBContext_WithStub(DbContextOptions<DiceyProject_DBContext> options) : base(options) { }

        /// <summary>
        /// Method called when the database is created. Allow us to set a data set in it.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProfileEntity>().HasData(
                new ProfileEntity(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Perret", "Louis"),
                new ProfileEntity(Guid.NewGuid(), "Malvezin", "Neitah"),
                new ProfileEntity(Guid.NewGuid(), "Grienenberger", "Côme"),
                new ProfileEntity(Guid.NewGuid(), "Perret", "Christele"),
                new ProfileEntity(Guid.NewGuid(), "Perret", "Bruno"),
                new ProfileEntity(Guid.NewGuid(), "Perret", "Antoine"),
                new ProfileEntity(Guid.NewGuid(), "Perret", "Mathilde"),
                new ProfileEntity(Guid.NewGuid(), "Kim", "Minji"),
                new ProfileEntity(Guid.NewGuid(), "Kim", "Bora"),
                new ProfileEntity(Guid.NewGuid(), "Lee", "Siyeon"),
                new ProfileEntity(Guid.NewGuid(), "Han", "Dong"),
                new ProfileEntity(Guid.NewGuid(), "Kim", "Yoohyeon"),
                new ProfileEntity(Guid.NewGuid(), "Lee", "Yubin"),
                new ProfileEntity(Guid.NewGuid(), "Lee", "Gahyeon")
            );

        }
    }
}
