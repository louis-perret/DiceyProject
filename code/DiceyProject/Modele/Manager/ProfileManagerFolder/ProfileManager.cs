using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProfileManager() : this(new List<Profile>()){ }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="profiles">List of profiles copied in _profiles when this constructor is called</param>
        public ProfileManager(IList<Profile> profiles)
        {
            _profiles = new List<Profile>(profiles);
            Profiles = new ReadOnlyCollection<Profile>(_profiles);
            CurrentProfile = null;
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
            if (_profiles.Contains(profile))
                return false;
            else
                _profiles.Add(profile);
            return true;
        }

        /// <summary>
        /// Method that removes a profile from the list of Profiles
        /// </summary>
        /// <param name="id">the Id of the profile to remove</param>
        /// <returns>true if the profile could be removed, false otherwise</returns>
        public virtual bool RemoveProfile(Guid id)
        {
            Profile prof = GetProfile(id);
            if (prof != null)
            {
                _profiles.Remove(prof);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method that removes a profile from the list of Profiles
        /// </summary>
        /// <param name="name">name of the profile to remove</param>
        /// <param name="surname">surname of the profile to remove</param>
        /// <returns>true if the profile could be removed, false otherwise</returns>
        public virtual bool RemoveProfile(string name, string surname)
        {
            Profile prof = GetProfile(name, surname);
            if (prof != null)
            {
                _profiles.Remove(prof);
                return true;
            }

            return false;
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
            Profile prof = GetProfile(id);
            if (prof != null)
            {
                prof.Name = newName;
                prof.Surname = newSurname;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method that returns a profile from the list
        /// </summary>
        /// <param name="id">Id of the profile to return</param>
        /// <returns>The profile if it has been found, null otherwise</returns>
        public virtual Profile GetProfile(Guid id)
        {
            Profile p = null;
            foreach (Profile prof in _profiles)
            {
                if (prof.Id == id) p = prof;
            }

            return p;
        }

        /// <summary>
        /// Method that returns a profile from the list
        /// </summary>
        /// <param name="name">Name of the profile to return</param>
        /// <param name="surname">Surname of the profile to return</param>
        /// <returns>The profile if it has been found, null otherwise</returns>
        public virtual Profile GetProfile(string name, string surname)
        {
            Profile p = null;
            foreach (Profile prof in _profiles)
            {
                if (prof.Name.Equals(name) && prof.Surname.Equals(surname)) p = prof;
            }

            return p;
        }
    }
}
