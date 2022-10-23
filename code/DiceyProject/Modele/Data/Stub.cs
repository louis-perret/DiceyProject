using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Data
{
    /// <summary>
    /// Simulates a loading and a saving of our data. For the saving, when the application will restart, all data entered by the user will be deleted.
    /// </summary>
    public class Stub : ILoader, ISaver
    {

        /// <summary>
        /// List of profiles
        /// </summary>
        private IList<Profile> _profiles;

        /// <summary>
        /// ReadOnlyCollection our profiles
        /// </summary>
        public ReadOnlyCollection<Profile> Profiles { get; private set; }

        /// <summary>
        /// Empty constructor which just creates our data
        /// </summary>
        public Stub()
        {
            CreateDataSet();
            Profiles = new ReadOnlyCollection<Profile>(_profiles);
        }

        /// <summary>
        /// Create our data set (currently juste a list of Profile, but in the future, there will be a list od Dice, a list of Throw and a list of Session
        /// </summary>
        private void CreateDataSet()
        {
            _profiles = new List<Profile>()
            {
                new SimpleProfile(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Perret", "Louis"),
                new SimpleProfile(Guid.NewGuid(), "Malvezin", "Neitah"),
                new SimpleProfile(Guid.NewGuid(), "Grienenberger", "Côme"),
                new SimpleProfile(Guid.NewGuid(), "Perret", "Christele"),
                new SimpleProfile(Guid.NewGuid(), "Perret", "Bruno"),
                new SimpleProfile(Guid.NewGuid(), "Perret", "Antoine"),
                new SimpleProfile(Guid.NewGuid(), "Perret", "Mathilde"),
                new SimpleProfile(Guid.NewGuid(), "Kim", "Minji"),
                new SimpleProfile(Guid.NewGuid(), "Kim", "Bora"),
                new SimpleProfile(Guid.NewGuid(), "Lee", "Siyeon"),
                new SimpleProfile(Guid.NewGuid(), "Han", "Dong"),
                new SimpleProfile(Guid.NewGuid(), "Kim", "Yoohyeon"),
                new SimpleProfile(Guid.NewGuid(), "Lee", "Yubin"),
                new SimpleProfile(Guid.NewGuid(), "Lee", "Gahyeon")
            };

        }

        /// <summary>
        /// Get profile by it's id
        /// </summary>
        /// <param name="id">profile's id</param>
        /// <returns></returns>
        public Profile? GetProfileById(Guid id)
        {
            return _profiles.SingleOrDefault(p => p.Id.Equals(id));
        }

        /// <summary>
        /// Get profiles by their name
        /// </summary>
        /// <param name="name">name of profiles</param>
        /// <param name="surname">surname of profiles</param>
        /// <returns></returns>
        public IList<Profile> GetProfileByName(string name, string surname)
        {
            return _profiles.Where(profile => profile.Name.Equals(name) && profile.Surname.Equals(surname)).ToList();
        }

        /// <summary>
        /// Get profiles by page containing the number of profiles that we want to get
        /// </summary>
        /// <param name="numberPage">number of the page</param>
        /// <param name="count">number of profile to get</param>
        /// <returns></returns>
        public IList<Profile> GetProfileByPage(int numberPage, int count)
        {
            List<Profile>? profilesList = new List<Profile>();
            if (numberPage > 0 && count > 0)
            {
                profilesList = _profiles.Skip(count * (numberPage - 1))
                                                               .Take(count)
                                                               .ToList();
            }
            return profilesList;
        }

        /// <summary>
        /// Get all profiles which contains subString in their name or surname
        /// </summary>
        /// <param name="subString">substring entered by user</param>
        /// <returns></returns>
        public IList<Profile> GetProfileBySubString(string subString)
        {
            return _profiles.Where(p => p.Name.ToLower().Contains(subString.ToLower()) || p.Surname.ToLower().Contains(subString.ToLower()))
                            .ToList();
        }

        // <summary>
        /// Add profile
        /// </summary>
        /// <param name="profile">profile to add</param>
        /// <returns></returns>
        public bool AddProfile(Profile profile)
        {
            var profileEntity = _profiles.SingleOrDefault(p => p.Equals(profile));
            if (profileEntity != null)
            {
                return false;
            }

            _profiles.Add(profile);
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
            bool ans = true;
            Profile? profile = _profiles.SingleOrDefault(p => p.Id.Equals(profileId));
            if (profile != null)
            {
                profile.Name = name;
            }
            else
            {
                ans = false;
            }
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
            bool ans = true;
            Profile? profile = _profiles.SingleOrDefault(p => p.Id.Equals(profileId));
            if (profile != null)
            {
                profile.Surname = surname;
            }
            else
            {
                ans = false;
            }
            return ans;
        }

        /// <summary>
        /// Remove profile
        /// </summary>
        /// <param name="profile">profile to remove</param>
        /// <returns></returns>
        public bool RemoveProfile(Profile profile)
        {
            var p = _profiles.SingleOrDefault(p => p.Equals(profile));
            if (p == null)
            {
                return false;
            }
            _profiles.Remove(p);
            return true;
        }
    }
}
