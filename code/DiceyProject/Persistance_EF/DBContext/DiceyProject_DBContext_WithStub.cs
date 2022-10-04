using Microsoft.EntityFrameworkCore;
using Modele.Business.ProfileFolder;
using Persistance_EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_EF.DBContext
{
    public class DiceyProject_DBContext_WithStub : DiceyProject_DBContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProfileEntity>().HasData(
                new ProfileEntity("Perret", "Louis"),
                new ProfileEntity("Malvezin", "Neitah"),
                new ProfileEntity("Grienenberger", "Côme"),
                new ProfileEntity("Perret", "Christele"),
                new ProfileEntity("Perret", "Bruno"),
                new ProfileEntity("Perret", "Antoine"),
                new ProfileEntity("Perret", "Mathilde"),
                new ProfileEntity("Kim", "Minji"),
                new ProfileEntity("Kim", "Bora"),
                new ProfileEntity("Lee", "Siyeon"),
                new ProfileEntity("Han", "Dong")
            );
        }
    }
}
