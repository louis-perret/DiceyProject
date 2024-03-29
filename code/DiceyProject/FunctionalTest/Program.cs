﻿// See https://aka.ms/new-console-template for more information



using Modele.Business.DiceFolder;
using Microsoft.Extensions.Logging;
using LoggingConfig.LogConfig;
using Modele.Manager;
using NLog.Extensions.Logging;
using FunctionalTest.Menu;
using FunctionalTest.Reader;
using Modele.Data;
using Modele.Manager.ManagerFolder;
using Persistance_EF;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

/**
 * Represents our fonctional test for our app, currently it doesn't exposed all our features (like Session) 
 * because these latter are not yet implemented, but soon it will do.
 * */

LoggerConfig.SetModelConfig();

int choix = -1;
Display display = new Display();
Reader read = new Reader();
ILoader load;
ISaver save;
int choixPers = read.ReadChoicePersistance();
switch (choixPers)
{
    case 1:
        DBManager dbManager = new DBManager(new DbContextOptionsBuilder<DiceyProject_DBContext>()
                        .UseInMemoryDatabase(databaseName: "Test_database")
                        .Options, true);
        load = dbManager;
        save = dbManager;
        break;

    default:
        Stub stub = new Stub();
        load = stub;
        save = stub;
        break;

}

Manager manager = new Manager(save, load);

Console.WriteLine("Avant de lancer l'application, entrez le nom et votre surnom de votre profil (si vous n'en avez pas, tapé le nom et le prénom que vous souhaité à la place");
String name = read.ReadName();
String surname = read.ReadSurname();
while (!manager.Connect(name, surname))
{
    Console.WriteLine("Ce profil n'existe pas, voulez-vous en créer un nouveau ? (o/n)");
    String choice = read.ReadLine();
    if(choice.Equals("o"))
    {
        manager.AddProfile(Guid.NewGuid(), name, surname);
    }
    else
    {
        name = read.ReadName();
        surname = read.ReadSurname();
    }
}

while (choix != 0)
{ 
    display.ShowMenu();
    choix = read.ReadInt();
    switch (choix)
    {
        case 1: 
            String newname = read.ReadName();
            String newsurname = read.ReadSurname();
            if(choixPers == 0)
                if (manager.AddProfile(Guid.NewGuid(), newname, newsurname))
                    Console.WriteLine("Le profil a été ajouté correctement");
                else
                    Console.WriteLine("Le profil n'a pas pu être ajouté");
            else
                if (manager.AddProfile(newname, newsurname))
                Console.WriteLine("Le profil a été ajouté correctement");
            else
                Console.WriteLine("Le profil n'a pas pu être ajouté");
            break;
        case 2:
            Console.WriteLine("Entrer le numéro de la page : ");
            int nbPage = read.ReadInt();
            Console.WriteLine("Entrer le nombre de profils par page : ");
            int count = read.ReadInt();
            display.DisplayProfiles(manager.GetProfilesByPage(nbPage,count));
            break;
        case 3:
            Console.WriteLine("Entrer le nombre de faces du dé :");
            int nbFaces = read.ReadInt();
            manager.AddDice(nbFaces);
            break;
        case 4:
            display.DisplayDice(manager.GetAllDice());
            break;
        case 5:
            manager.LaunchAllDice();
            display.DisplayResults(manager.GetAllDice());
            break;
        case 6:
            display.DisplayThrow(manager.GetHistory());
            break;
        case 7:
            display.DisplayThrow(manager.GetHistoryProfile(manager.GetCurrentProfileId()));
            break;
        case 8:
            String nom = read.ReadName();
            String prenom = read.ReadSurname();
            if (manager.RemoveProfile(nom, prenom))
            {
                Console.WriteLine("Profil supprimé");
            }
            else
            {
                Console.WriteLine("Ce profil n'existe pas");
            }
            break;
        default: break;
    }
}