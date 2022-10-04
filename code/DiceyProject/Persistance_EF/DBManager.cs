using Modele.Business.ProfileFolder;
using Modele.Data;
using Persistance_EF.DBContext;
using Persistance_EF.Entities;
using Persistance_EF.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_EF
{
    /// <summary>
    /// Represents the manager of our database
    /// </summary>
    public class DBManager : IDataManager
    {
        /// <summary>
        /// Context of our database
        /// </summary>
        public DiceyProject_DBContext DiceyProjectDBContext { get; private set; }

        /// <summary>
        /// Load the list of profiles from our database
        /// </summary>
        /// <returns></returns>
        public IList<Profile> Load()
        {
            IList<Profile> list = new List<Profile>();
            using (DiceyProjectDBContext = new DiceyProject_DBContext())
            {
                list = DiceyProjectDBContext.ProfilesSet.ToList().ToProfileModels().ToList();
            }

            return list;
        }


        /// <summary>
        /// Save changement in database
        /// </summary>
        /// <param name="profiles"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Save(IList<Profile> profiles)
        {
            throw new NotImplementedException();
        }
    }
}
