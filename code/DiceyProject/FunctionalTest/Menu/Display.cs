using Modele.Business.DiceFolder;
using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalTest.Menu
{
    internal class Display
    {
        internal void ShowMenu()
        {
            Console.WriteLine("Bienvenue sur l'application Dicey !");
            Console.WriteLine("Choix des options : \n" +
                "1 - Ajouter un Profil\n" +
                "2 - Afficher tous les Profils\n" +
                "3 - Ajouter un Dé\n" +
                "4 - Afficher les Dés\n" +
                "0 - Quitter");
        }

        internal void AfficheProfiles(ReadOnlyCollection<Profile> profiles)
        {
            foreach(Profile profile in profiles)
            {
                Console.WriteLine("{0} {1} {2}", profile.Name, profile.Surname,profile.Id.ToString());
            }
        }

        internal void AfficheDice(ReadOnlyCollection<Dice> dices)
        {
            foreach(Dice dice in dices)
            {
                Console.WriteLine("{0}", dice.NbFaces);
            }
        }
    }
}
