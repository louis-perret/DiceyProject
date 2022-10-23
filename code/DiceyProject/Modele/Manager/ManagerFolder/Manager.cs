// See https://aka.ms/new-console-template for more information



using Modele.Business.DiceFactoryFolder;
using Modele.Business.DiceFolder;
using Modele.Business.ProfileFolder;
using Modele.Data;
using Modele.Manager.DiceManagerFolder;
using Modele.Manager.ProfileManagerFolder;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Modele.Business.DiceLauncherFolder;
using Modele.Business.ThrowFolder;
using System.ComponentModel;
using DateTimeConverter = Modele.Business.ThrowFolder.DateTimeConverter;

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
        /// Manager which manages our dice
        /// </summary>
        internal DiceManager diceManager;

        /// <summary>
        /// Object which manages the launch of user's dice
        /// </summary>
        internal IDiceLauncher diceLauncher;

        internal IThrowHistory throwHistory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="saver">Our saver of data</param>
        /// <param name="loader">Our loader of data</param>

        public Manager(ISaver saver, ILoader loader)
        {
            profileManager = new SimpleProfileManager(loader, saver);
            diceManager = new SimpleDiceManager();
            diceLauncher = new SimpleDiceLauncher();
            throwHistory = new SimpleThrowHistory();
        }

        /// <summary>
        /// Add a profile
        /// </summary>
        /// <param name="name">Name of new profile</param>
        /// <param name="surname">Surname of new profile</param>
        public bool AddProfile(string name, string surname)
        {
            return profileManager.AddProfile(name, surname);
        }

        /// <summary>
        /// Return a list of profiles which contains a subset of our all profiles based on a number of page and count
        /// </summary>
        /// <param name="nbPage">Number of page</param>
        /// <param name="count">Number of profiles to get</param>
        /// <returns></returns>
        public ReadOnlyCollection<Profile> GetProfilesByPage(int nbPage, int count)
        {
            return new ReadOnlyCollection<Profile>(profileManager.GetProfileByPage(nbPage,count));
        }

        /// <summary>
        /// Add a dice to launch
        /// </summary>
        /// <param name="nbFaces">Dice's number of faces</param>
        /// <returns></returns>
        public bool AddDice(int nbFaces)
        {
            return diceManager.AddDice(nbFaces);
        }

        /// <summary>
        /// Return all dice to launch
        /// </summary>
        /// <returns></returns>
        public ReadOnlyCollection<Dice> GetAllDice()
        {
            return diceManager.DiceROC;
        }

        /// <summary>
        /// Launch all dice wanted by the user
        /// </summary>
        /// <returns></returns>
        public bool LaunchAllDice()
        {
            if(!diceLauncher.LaunchAllDice(GetAllDice()))
                return false;
            foreach (Dice dice in GetAllDice())
                throwHistory.AddThrow(DateTimeConverter.ConverToDateOnly(DateTime.Now), dice, profileManager.CurrentProfile.Id);
            return true;
        }
    }
}