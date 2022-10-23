using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalTest.Menu
{
    internal class Display
    {
        public void ShowMenu()
        {
            Console.WriteLine("Bienvenue sur l'application Dicey !");
            Console.WriteLine("Choix des options : \n" +
                "1 - Ajouter un Profil\n" +
                "2 - Afficher tous les Profils\n" +
                "9 - Quitter" +
                "" +
                "" +
                "");
        }

        internal void AfficheProfiles(IReadOnlyCollection<Profile> profiles)
        {
            foreach(Profile profile in profiles)
            {
                Console.WriteLine("{0} {1} {2}", profile.Name, profile.Surname,profile.Id.ToString());
            }
        }
    }
}
