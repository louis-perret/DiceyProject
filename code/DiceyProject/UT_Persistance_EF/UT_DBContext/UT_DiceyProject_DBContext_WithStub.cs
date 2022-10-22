using Microsoft.EntityFrameworkCore;
using Persistance_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT_Persistance_EF.UT_DBContext
{
    public class UT_DiceyProject_DBContext_WithStub
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Test_Constructor(bool isOptions)
        {
            DiceyProject_DBContext_WithStub dbContext;
            if (isOptions)
            {
                dbContext = new DiceyProject_DBContext_WithStub(new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database_Constructor")
                        .Options);
            }
            else
            {
                dbContext = new DiceyProject_DBContext_WithStub();
            }

            Assert.NotNull(dbContext);
            dbContext.Database.EnsureCreated();
            if(isOptions) Assert.Equal(14, dbContext.ProfilesSet.Count());
            dbContext.Dispose();
        }
    }
}
