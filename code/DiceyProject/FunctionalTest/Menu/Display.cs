﻿using Modele.Business.DiceFolder;
using Modele.Business.ProfileFolder;
using Modele.Business.ThrowFolder;
using System.Collections.ObjectModel;


namespace FunctionalTest.Menu
{
    internal class Display
    {
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

        internal void AfficheResults(ReadOnlyCollection<Dice> dices)
        {
            foreach (Dice dice in dices)
            {
                Console.WriteLine("NbFaces : {0} Result :{1}", dice.NbFaces, dice.Result);
            }
        }

        internal void AfficheThrow(ReadOnlyDictionary<DateOnly, ListThrowEncapsulation> readOnlyDictionary)
        {
            foreach(var key in readOnlyDictionary.Keys)
            {
                Console.WriteLine(key);
                foreach (var value in readOnlyDictionary[key].ThrowsROC)
                    Console.WriteLine("nbFaces : {0], Result :{1}",value.Dice.NbFaces, value.Dice.Result);
            }
        }
    }
}
