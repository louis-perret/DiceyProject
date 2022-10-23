using Modele.Business.ProfileFolder;
using Modele.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("UT_Modele")]

namespace Modele.Manager.ProfileManagerFolder
{
    /// <summary>
    /// Class that manages a List of Profiles
    /// </summary>
    public abstract class ProfileManager
    {
        /// <summary>
        /// List of Profiles
        /// </summary>
        protected IList<Profile> _profiles;

        /// <summary>
        /// Encapsulation of _profiles in a property
        /// </summary>
        public IReadOnlyCollection<Profile> Profiles;

        /// <summary>
        /// The current Profile playing on the application
        /// </summary>
        private Profile _currentProfile;

        /// <summary>
        /// Encapsulation of _currentProfile in a property
        /// </summary>
        public Profile CurrentProfile
        {
            get => _currentProfile;
            private set => _currentProfile = value;
        }

        internal ILoader _loader;

        internal ISaver _saver;

        public ProfileManager(ILoader loader, ISaver saver)
        {
            _loader = loader;
            _saver = saver;
            _profiles = new List<Profile>();
            Profiles= new ObservableCollection<Profile>();
            CurrentProfile = null;
        }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="profiles">List of profiles copied in _profiles when this constructor is called</param>
        public ProfileManager(ILoader loader, ISaver saver, IList<Profile> profiles) : this(loader, saver)
        {
            _profiles = new List<Profile>(profiles);
            Profiles = new ObservableCollection<Profile>(_profiles);
        }

        /// <summary>
        /// Method that adds a Profile to the list of profiles
        /// </summary>
        /// <param name="name">name of the new profile</param>
        /// <param name="surname">surname of the new profile</param>
        /// <returns>true if the profile could be added, false otherwise</returns>
        public abstract bool AddProfile(string name, string surname);

        /// <summary>
        /// Method that adds a Profile to the list of profiles
        /// </summary>
        /// <param name="id">the Id of the profile</param>
        /// <param name="name">name of the new profile</param>
        /// <param name="surname">surname of the new profile</param>
        /// <returns>true if the profile could be added, false otherwise</returns>
        public abstract bool AddProfile(Guid id, string name, string surname);

        /// <summary>
        /// Method that adds a Profile to the list of profiles
        /// </summary>
        /// <param name="profile">The profile to add to the list</param>
        /// <returns>true if the profile could be added, false otherwise</returns>
        protected virtual bool AddProfile(Profile profile)
        {
            return _saver.AddProfile(profile);
        }

        /// <summary>
        /// Method that removes a profile from the list of Profiles
        /// </summary>
        /// <param name="id">the Id of the profile to remove</param>
        /// <returns>true if the profile could be removed, false otherwise</returns>
        public virtual bool RemoveProfile(Guid id)
        {
            return _saver.RemoveProfile(GetProfile(id));
        }

        /// <summary>
        /// Method that removes a profile from the list of Profiles
        /// </summary>
        /// <param name="name">name of the profile to remove</param>
        /// <param name="surname">surname of the profile to remove</param>
        /// <returns>true if the profile could be removed, false otherwise</returns>
        public virtual bool RemoveProfile(string name, string surname)
        {
            return _saver.RemoveProfile(GetProfile(name, surname));
        }

        /// <summary>
        /// Method that modifies the data of a profile from the list
        /// </summary>
        /// <param name="id">Id of the profile to modify</param>
        /// <param name="newName">new name of the profile that is changed</param>
        /// <param name="newSurname">new surname of the profile that is changed</param>
        /// <returns>true if the profile has been modified, false otherwise</returns>
        public virtual bool ModifyProfile(Guid id, string newName, string newSurname)
        {
            bool ans1 = _saver.ModifyProfileName(id, newName);
            bool ans2 = _saver.ModifyProfileSurname(id, newSurname);
            return ans1 && ans2;

        }

        /// <summary>
        /// Method that returns a profile from the list
        /// </summary>
        /// <param name="id">Id of the profile to return</param>
        /// <returns>The profile if it has been found, null otherwise</returns>
        public virtual Profile? GetProfile(Guid id)
        {
            return _loader.GetProfileById(id);
        }

        /// <summary>
        /// Method that returns a profile from the list
        /// </summary>
        /// <param name="name">Name of the profile to return</param>
        /// <param name="surname">Surname of the profile to return</param>
        /// <returns>The profile if it has been found, null otherwise</returns>
        public virtual Profile? GetProfile(string name, string surname)
        {
            return _loader.GetProfileByName(name, surname).FirstOrDefault();
        }

        /// <summary>
        /// Method that returns a list of x profile regarding to the number of the page
        /// </summary>
        /// <param name="numberPage">number of the page</param>
        /// <param name="count">number of profiles to get</param>
        /// <returns></returns>
        public virtual IList<Profile> GetProfileByPage(int numberPage, int count)
        {
            return _loader.GetProfileByPage(numberPage, count);
        }
        
        /// <summary>
        /// Method that returns a list of x profiles where their name or surname contains substring
        /// </summary>
        /// <param name="subString">substring to look for in all profiles</param>
        /// <returns></returns>
        public virtual IList<Profile> GetProfileBySubString(string subString)
        {
            return _loader.GetProfileBySubString(subString);
        }
    }
}
