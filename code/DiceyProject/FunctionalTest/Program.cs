// See https://aka.ms/new-console-template for more information



using Modele.Business.DiceFolder;
using Microsoft.Extensions.Logging;
using LoggingConfig.LogConfig;
using Modele.Manager;
using NLog.Extensions.Logging;
using FunctionalTest.Menu;
using FunctionalTest.Reader;

LoggerConfig.SetModelConfig();

int choix = 0;
Display display = new Display();
Reader read = new Reader();
Manager manager = new();

while(choix != 9)
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
            display.AfficheProfiles(manager.getAllProfiles());
            break;
        default: break;
    }
}