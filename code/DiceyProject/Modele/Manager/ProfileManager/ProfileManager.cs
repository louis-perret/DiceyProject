using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Manager.ProfileManager
{
    public abstract class ProfileManager
    {
        private List<Profile> _profiles;
        private Profile _currentProfile;

        public ProfileManager()
        {
            _profiles = new List<Profile>();
        }

        public bool AddProfile(String name, String surname)
        {
            Profile prof = new SimpleProfile(name, surname);
            if (_profiles.Contains(prof))
                return false;
            else
                _profiles.Add(prof);
            return true;
        }

        public bool RemoveProfile(int id)
        {
            foreach (Profile prof in _profiles)
            {
                if (prof.Id == id)
                {
                    _profiles.Remove(prof);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveProfile(string name, string surname)
        {
            foreach (Profile prof in _profiles)
            {
                if (prof.Name == name && prof.Surname == surname)
                {
                    _profiles.Remove(prof);
                    return true;
                }
            }
            return false;
        }

        public bool ModifyProfile(int id, string newName, string newSurname)
        {
            foreach (Profile prof in _profiles)
            {
                if (prof.Id == id)
                {
                    prof.Name = newName;
                    prof.Surname = newSurname;
                    return true;
                }
            }
            return false;
        }

        public ReadOnlyCollection<Profile> getProfiles()
        {
            return _profiles.AsReadOnly();
        }
    }
}
