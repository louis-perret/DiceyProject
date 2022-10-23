// See https://aka.ms/new-console-template for more information



using Modele.Business.ProfileFolder;
using Modele.Data;
using Modele.Manager.ProfileManagerFolder;
using System.Collections.ObjectModel;

namespace Modele.Manager.ManagerFolder
{
    public class Manager
    {
        private ProfileManager profileManager;

        public Manager(ISaver saver, ILoader loader)
        {
            profileManager = new SimpleProfileManager(loader, saver);
        }

        public void AddProfile(string name, string surname)
        {
            profileManager.AddProfile(name, surname);
        }

        public IReadOnlyCollection<Profile> GetProfilesByPage(int nbPage, int count)
        {
            return new ReadOnlyCollection<Profile>(profileManager.GetProfileByPage(nbPage,count));
        }
    }
}