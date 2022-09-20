using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Manager.ProfileManagerFolder
{
    public abstract class ProfileManager
    {
        protected IList<Profile> _profiles;

        public IReadOnlyCollection<Profile> Profiles;

        private Profile _currentProfile;

        public Profile CurrentProfile
        {
            get => _currentProfile;
            private set => _currentProfile = value;
        }

        public ProfileManager() : this(new List<Profile>()){ }

        public ProfileManager(IList<Profile> profiles)
        {
            _profiles = new List<Profile>(profiles);
            Profiles = new ReadOnlyCollection<Profile>(_profiles);
            CurrentProfile = null;
        }

        public abstract bool AddProfile(string name, string surname);

        public abstract bool AddProfile(int id, string name, string surname);

        protected virtual bool AddProfile(Profile profile)
        {
            if (_profiles.Contains(profile))
                return false;
            else
                _profiles.Add(profile);
            return true;
        }

        public virtual bool RemoveProfile(int id)
        {
            Profile prof = GetProfile(id);
            if (prof != null)
            {
                _profiles.Remove(prof);
                return true;
            }

            return false;
        }

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

        public virtual bool ModifyProfile(int id, string newName, string newSurname)
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

        public virtual Profile GetProfile(int id)
        {
            Profile p = null;
            foreach (Profile prof in _profiles)
            {
                if (prof.Id == id) p = prof;
            }

            return p;
        }

        public virtual Profile GetProfile(string name, string surname)
        {
            Profile p = null;
            foreach (Profile prof in _profiles)
            {
                if (prof.Name == name && prof.Surname == surname) p = prof;
            }

            return p;
        }
    }
}
