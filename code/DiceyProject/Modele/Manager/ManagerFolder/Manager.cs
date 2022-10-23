// See https://aka.ms/new-console-template for more information



using Modele.Business.DiceFactoryFolder;
using Modele.Business.DiceFolder;
using Modele.Business.ProfileFolder;
using Modele.Data;
using Modele.Manager.DiceManagerFolder;
using Modele.Manager.ProfileManagerFolder;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

[assembly: InternalsVisibleTo("UT_Modele")]

namespace Modele.Manager.ManagerFolder
{
    public class Manager
    {
        private DiceManager diceManager;

        internal ProfileManager profileManager;

        public Manager(ISaver saver, ILoader loader)
        {
            profileManager = new SimpleProfileManager(loader, saver);
            diceManager = new SimpleDiceManager();
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
    }
}