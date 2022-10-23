// See https://aka.ms/new-console-template for more information



using Modele.Business.DiceFolder;
using Microsoft.Extensions.Logging;
using LoggingConfig.LogConfig;
using Modele.Manager;
using NLog.Extensions.Logging;
using FunctionalTest.Menu;
using FunctionalTest.Reader;
using Modele.Data;
using Modele.Manager.ManagerFolder;
using System.Runtime.CompilerServices;

LoggerConfig.SetModelConfig();

int choix = -1;
Display display = new Display();
Reader read = new Reader();
Stub stub = new Stub();
Manager manager = new Manager(stub,stub);

while(choix != 0)
{ 
    display.ShowMenu();
    choix = read.ReadInt();
    switch (choix)
    {
        case 1: 
            String name = read.ReadName();
            String surname = read.ReadSurname();
            manager.AddProfile(name, surname);
            break;
        case 2:
            Console.WriteLine("Entrer le numéro de la page : ");
            int nbPage = read.ReadInt();
            Console.WriteLine("Entrer le nombre de profils par page : ");
            int count = read.ReadInt();
            display.AfficheProfiles(manager.GetProfilesByPage(nbPage,count));
            break;
        default: break;
    }
}