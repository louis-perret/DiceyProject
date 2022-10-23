using Modele.Business.DiceFolder;
using Modele.Business.ProfileFolder;
using Modele.Business.ThrowFolder;
using System.Collections.ObjectModel;


namespace FunctionalTest.Menu
{
    /// <summary>
    /// Manages the display of all information we want to show to the current user
    /// </summary>
    internal class Display
    {
        /// <summary>
        /// Display the menu
        /// </summary>
        internal void ShowMenu()
        {
            Console.WriteLine("Bienvenue sur l'application DiceyProject !");
            Console.WriteLine("Choix des options : \n" +
                "1 - Ajouter un Profil\n" +
                "2 - Afficher tous les Profils\n" +
                "3 - Ajouter un Dé\n" +
                "4 - Afficher les Dés\n" +
                "5 - Lancer les Dés\n" +
                "6 - Afficher l'historique des lancers\n" +
                "7 - Afficher l'historique de vos lancers\n" +
                "8 - Supprimer un profil\n" +
                "0 - Quitter");
        }

        /// <summary>
        /// Display profiles
        /// </summary>
        /// <param name="profiles"></param>
        internal void DisplayProfiles(ReadOnlyCollection<Profile> profiles)
        {
            Console.WriteLine("\nAffichage des profils : ");
            foreach (Profile profile in profiles)
            {
                Console.WriteLine("{0} {1} {2}", profile.Name, profile.Surname,profile.Id.ToString());
            }
        }

        /// <summary>
        /// Display all dice created by the current user
        /// </summary>
        /// <param name="dices"></param>
        internal void DisplayDice(ReadOnlyCollection<Dice> dices)
        {
            Console.WriteLine("\nAffichage des dés ajoutés : ");
            foreach (Dice dice in dices)
            {
                Console.WriteLine("{0}", dice.NbFaces);
            }
        }

        /// <summary>
        /// Display the result of each launched dice
        /// </summary>
        /// <param name="dices"></param>
        internal void DisplayResults(ReadOnlyCollection<Dice> dices)
        {
            Console.WriteLine("\nLancement des dés !");
            foreach (Dice dice in dices)
            {
                Console.WriteLine("NbFaces : {0} Result :{1}", dice.NbFaces, dice.Result);
            }
        }

        /// <summary>
        /// Display throws
        /// </summary>
        /// <param name="readOnlyDictionary">Dictionnary which contains a list of throws per date</param>
        internal void DisplayThrow(ReadOnlyDictionary<DateOnly, ListThrowEncapsulation> readOnlyDictionary)
        {
            foreach(var key in readOnlyDictionary.Keys)
            {
                Console.WriteLine($"Date du jour : {key}");
                foreach (var value in readOnlyDictionary[key].ThrowsROC)
                    Console.WriteLine("NbFaces : {0}, Result :{1}",value.Dice.NbFaces, value.Dice.Result);
            }
        }
    }
}
