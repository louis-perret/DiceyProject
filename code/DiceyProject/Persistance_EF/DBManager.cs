using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Modele.Business.ProfileFolder;
using Modele.Data;
using Persistance_EF.Entities;
using Persistance_EF.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

[assembly: InternalsVisibleTo("UT_Persistance_EF")]

namespace Persistance_EF
{
    /// <summary>
    /// Represents the manager of our database
    /// </summary>
    public class DBManager : ILoader, ISaver
    {
        /// <summary>
        /// Context of our database
        /// </summary>
        internal DiceyProject_DBContext? DiceyProjectDBContext { get; private set; }

        /// <summary>
        /// Optional options for our database context (useful for our unitests)
        /// </summary>
        internal DbContextOptions<DiceyProject_DBContext>? Options { get; private set; }

        /// <summary>
        /// If it's true, DBManager will use a data base with data in it. It's specially for our tests.
        /// </summary>
       internal bool UseDBWithStub { get; private set; } = false;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public DBManager() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="useBDWithStub">Boolean to konw if DBManager should use a data base with provided data</param>
        public DBManager(bool useBDWithStub)
        {
            UseDBWithStub = useBDWithStub;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">Options for the database, like the provider to use</param>
        public DBManager(DbContextOptions<DiceyProject_DBContext> options)
        {
            Options = options;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">Options for the database, like the provider to use</param>
        /// <param name="useBDWithStub">Boolean to konw if DBManager should use a data base with provided data</param>
        public DBManager(DbContextOptions<DiceyProject_DBContext> options, bool useBDWithStub)
        {
            Options = options;
            UseDBWithStub = useBDWithStub;
        }

        /// <summary>
        /// Get profiles by page containing the number of profiles that we want to get
        /// </summary>
        /// <param name="numberPage">number of the page</param>
        /// <param name="count">number of profile to get</param>
        /// <returns></returns>
        public Profile? GetProfileById(Guid id)
        {
            Profile? profile = null;
            OpenConnectionToDB();
            var p = DiceyProjectDBContext?.ProfilesSet.SingleOrDefault(p => p.Id.Equals(id));
            if(p != null)
            {
                profile = p.ToProfileModel();
            }

            DiceyProjectDBContext?.Dispose();
            return profile;
        }

        /// <summary>
        /// Get profiles by their name and their surname
        /// </summary>
        /// <param name="name">name of profiles</param>
        /// <param name="surname">surname of profiles</param>
        /// <returns></returns>

        public IList<Profile> GetProfileByName(string name, string surname)
        {
            IList<Profile> profileList = new List<Profile>();
            OpenConnectionToDB();
            var p = DiceyProjectDBContext?.ProfilesSet.Where(profile => profile.Name.Equals(name) && profile.Surname.Equals(surname)).ToList();
            if (p != null && p.Count > 0)
            {
                profileList = p.Select(profile => profile.ToProfileModel()).ToList();
            }

            DiceyProjectDBContext?.Dispose();
            return profileList;
        }

        /// <summary>
        /// Get profile by it's id
        /// </summary>
        /// <param name="id">profile's id</param>
        /// <returns></returns>
        public IList<Profile> GetProfileByPage(int numberPage, int count)
        {
            List<Profile>? profilesList = new List<Profile>();
            OpenConnectionToDB();
            if (numberPage > 0 && count > 0)
            {
                profilesList = DiceyProjectDBContext?.ProfilesSet.Skip(count * (numberPage - 1))
                                                               .Take(count)
                                                               .Select(profile => profile.ToProfileModel())
                                                               .ToList();
            }

            DiceyProjectDBContext?.Dispose();
            return profilesList;
        }

        /// <summary>
        /// Get all profiles which contains subString in their name or surname
        /// </summary>
        /// <param name="subString">substring entered by user</param>
        /// <returns></returns>
        public IList<Profile> GetProfileBySubString(string subString)
        {
            IList<Profile>? profilesList = new List<Profile>();
            OpenConnectionToDB();
            profilesList = DiceyProjectDBContext?.ProfilesSet.Where(p => p.Name.ToLower().Contains(subString.ToLower()) || p.Surname.ToLower().Contains(subString.ToLower()))
                                                                .Select(p => p.ToProfileModel())
                                                                .ToList();

            DiceyProjectDBContext?.Dispose();
            return profilesList;
        }

        /// <summary>
        /// Add profile
        /// </summary>
        /// <param name="profile">profile to add</param>
        /// <returns></returns>
        public bool AddProfile(Profile profile)
        {
            OpenConnectionToDB();
            var profileEntity = DiceyProjectDBContext?.ProfilesSet.SingleOrDefault(p => p.Equals(profile.ToProfileEntity()));
            if (profileEntity != null)
            {
                return false;
            }

            DiceyProjectDBContext?.ProfilesSet.Add(profile.ToProfileEntity());
            DiceyProjectDBContext?.SaveChanges();
            DiceyProjectDBContext?.Dispose();
            return true;
        }

        /// <summary>
        /// Remove profile
        /// </summary>
        /// <param name="profile">profile to remove</param>
        /// <returns></returns>
        public bool RemoveProfile(Profile profile)
        {
            OpenConnectionToDB();
            var profileEntity = DiceyProjectDBContext?.ProfilesSet.SingleOrDefault(p => p.Equals(profile.ToProfileEntity()));
            if (profileEntity == null)
            {
                return false;
            }
            DiceyProjectDBContext?.ProfilesSet.Remove(profileEntity);
            DiceyProjectDBContext?.SaveChanges();
            DiceyProjectDBContext?.Dispose();
            return true;
        }

        /// <summary>
        /// Modify profile's name
        /// </summary>
        /// <param name="profileId">profile's id to modify</param>
        /// <param name="name">new name</param>
        /// <returns></returns>
        public bool ModifyProfileName(Guid profileId, string name)
        {
            OpenConnectionToDB();
            bool ans = true;
            ProfileEntity? profile = DiceyProjectDBContext?.ProfilesSet.SingleOrDefault(p => p.Id.Equals(profileId));
            if (profile != null)
            {
                profile.Name = name;
                DiceyProjectDBContext?.SaveChanges();
            }
            else
            {
                ans = false;
            }
            DiceyProjectDBContext?.Dispose();
            return ans;
        }

        /// <summary>
        /// Modify profile's surname
        /// </summary>
        /// <param name="profileId">profile's id to modify</param>
        /// <param name="name">new surname</param>
        /// <returns></returns>
        public bool ModifyProfileSurname(Guid profileId, string surname)
        {
            OpenConnectionToDB();
            bool ans = true;
            ProfileEntity? profile = DiceyProjectDBContext?.ProfilesSet.SingleOrDefault(p => p.Id.Equals(profileId));
            if (profile != null)
            {
                profile.Surname = surname;
                DiceyProjectDBContext?.SaveChanges();
            }
            else
            {
                ans = false;
            }
            DiceyProjectDBContext?.Dispose();
            return ans;
        }

        /// <summary>
        /// Internal method which opens the connection to the database regarding to the Options and UseDBWithStub
        /// </summary>
        internal void OpenConnectionToDB()
        {
            if (Options == null)
            {
                if (UseDBWithStub) DiceyProjectDBContext = new DiceyProject_DBContext_WithStub();
                else DiceyProjectDBContext = new DiceyProject_DBContext();
            }
            else
            {
                if (UseDBWithStub) DiceyProjectDBContext = new DiceyProject_DBContext_WithStub(Options);
                else DiceyProjectDBContext = new DiceyProject_DBContext(Options);
            }

            DiceyProjectDBContext.Database.EnsureCreated();
        }

    }
}
