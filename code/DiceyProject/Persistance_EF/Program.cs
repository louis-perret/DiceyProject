// See https://aka.ms/new-console-template for more information
/*using Modele.Business.ProfileFolder;
using Modele.Data;
using Persistance_EF;
using Persistance_EF.DBContext;
using Persistance_EF.Extensions;

Console.WriteLine("Hello, World!");

/*using (DiceyProject_DBContext db = new DiceyProject_DBContext())
{
    Profile profile1 = new SimpleProfile("Perret", "Louis");
    Profile profile2 = new SimpleProfile("Malvezin", "Neitah");
    Profile profile3 = new SimpleProfile("Grienenberger", "Côme");
    Profile profile4 = new SimpleProfile("Perret", "Christele");
    Profile profile5 = new SimpleProfile("Perret", "Bruno");
    Profile profile6 = new SimpleProfile("Perret", "Antoine");
    Profile profile7 = new SimpleProfile("Perret", "Mathilde");
    Profile profile8 = new SimpleProfile("Kim", "Minji");
    Profile profile9 = new SimpleProfile("Kim", "Bora");
    Profile profile10 = new SimpleProfile("Lee", "Siyeon");
    Profile profile11 = new SimpleProfile("Han", "Dong");

    db.ProfilesSet.Add(profile1.ToProfileEntity());
    db.ProfilesSet.Add(profile2.ToProfileEntity());
    db.ProfilesSet.Add(profile3.ToProfileEntity());
    db.ProfilesSet.Add(profile4.ToProfileEntity());
    db.ProfilesSet.Add(profile5.ToProfileEntity());
    db.ProfilesSet.Add(profile6.ToProfileEntity());
    db.ProfilesSet.Add(profile7.ToProfileEntity());
    db.ProfilesSet.Add(profile8.ToProfileEntity());
    db.ProfilesSet.Add(profile9.ToProfileEntity());
    db.ProfilesSet.Add(profile10.ToProfileEntity());
    db.ProfilesSet.Add(profile11.ToProfileEntity());


    db.SaveChanges();
}

ILoader dataManager = new DBManager();

Profile profile = dataManager.getProfileById(5);
Console.WriteLine($"Profile récupéré : {profile.Name} {profile.Surname} {profile.Id}");

IList<Profile> listProfiles = dataManager.getProfileByName("Perret", "Louis");

Console.WriteLine("Profiles récupérés : ");
foreach (var p in listProfiles)
{
    Console.WriteLine("Prénom : " + p.Name);
    Console.WriteLine("Nom " + p.Surname);
    Console.WriteLine("Id : " + p.Id);
}

listProfiles = dataManager.getProfileByPage(1, 5);

Console.WriteLine("Profiles récupérés : ");
foreach (var p in listProfiles)
{
    Console.WriteLine("Prénom : " + p.Name);
    Console.WriteLine("Nom " + p.Surname);
    Console.WriteLine("Id : " + p.Id);
}

/*
using(DiceyProject_DBContext db = new DiceyProject_DBContext())
{
    if(db.ProfilesSet.Count() > 0)
    {
        Console.WriteLine("Contenu de la base : ");
        foreach(var p in db.ProfilesSet)
        {
            Console.WriteLine("Prénom : " + p.Name);
            Console.WriteLine("Nom " + p.Surname);
            Console.WriteLine("Id : " + p.Id);
        }

        System.Console.WriteLine("Début du nettoyage");
        foreach(var p in db.ProfilesSet)
        {
            Console.WriteLine($"Suppression de {p.Name}");
            db.ProfilesSet.Remove(p);
        }

        db.SaveChanges();
    }
}*/


