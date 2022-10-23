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

[assembly: InternalsVisibleTo("UT_Modele")]

namespace Modele.Manager.ManagerFolder
{
    public class Manager
    {
        internal DiceManager diceManager;

        internal ProfileManager profileManager;

        internal IDiceLauncher diceLauncher;

        public Manager(ISaver saver, ILoader loader)
        {
            profileManager = new SimpleProfileManager(loader, saver);
            diceManager = new SimpleDiceManager();
            diceLauncher = new SimpleDiceLauncher();
        }

        public bool AddProfile(string name, string surname)
        {
            return profileManager.AddProfile(name, surname);
        }

        public ReadOnlyCollection<Profile> GetProfilesByPage(int nbPage, int count)
        {
            return new ReadOnlyCollection<Profile>(profileManager.GetProfileByPage(nbPage,count));
        }

        public bool AddDice(int nbFaces)
        {
            return diceManager.AddDice(nbFaces);
        }

        public ReadOnlyCollection<Dice> GetAllDice()
        {
            return diceManager.DiceROC;
        }

        public bool LancerDés()
        {
            return diceLauncher.LaunchAllDice(GetAllDice());
        }
    }
}