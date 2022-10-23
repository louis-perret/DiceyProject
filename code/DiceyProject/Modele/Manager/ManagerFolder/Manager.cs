// See https://aka.ms/new-console-template for more information



using Modele.Business.ProfileFolder;
using Modele.Data;
using Modele.Manager.ProfileManagerFolder;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

[assembly: InternalsVisibleTo("UT_Modele")]

namespace Modele.Manager.ManagerFolder
{
    /// <summary>
    /// Our Facade which allows an extern application (like our Console App) to use our complex system
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Manager which manages our profiles
        /// </summary>
        internal ProfileManager profileManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="saver">Our saver of data</param>
        /// <param name="loader">Our loader of data</param>
        public Manager(ISaver saver, ILoader loader)
        {
            profileManager = new SimpleProfileManager(loader, saver);
        }

        /// <summary>
        /// Add a profile
        /// </summary>
        /// <param name="name">Name of new profile</param>
        /// <param name="surname">Surname of new profile</param>
        public void AddProfile(string name, string surname)
        {
            profileManager.AddProfile(name, surname);
        }

        /// <summary>
        /// Return a list of profiles which contains a subset of our all profiles based on a number of page and count
        /// </summary>
        /// <param name="nbPage">Number of page</param>
        /// <param name="count">Number of profiles to get</param>
        /// <returns></returns>
        public IReadOnlyCollection<Profile> GetProfilesByPage(int nbPage, int count)
        {
            return new ReadOnlyCollection<Profile>(profileManager.GetProfileByPage(nbPage,count));
        }
    }
}