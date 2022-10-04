// See https://aka.ms/new-console-template for more information
using Modele.Business.ProfileFolder;
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

    //db.ProfilesSet.Add(profile1.ToEntity());
    db.ProfilesSet.Add(profile2.ToProfileEntity());
    db.ProfilesSet.Add(profile3.ToProfileEntity());

    db.SaveChanges();
}*/

IDataManager dataManager = new DBManager();
IList<Profile> listProfiles = dataManager.Load();

Console.WriteLine("Contenu de la base : ");
foreach (var profile in listProfiles)
{
    Console.WriteLine("Prénom : " + profile.Name);
    Console.WriteLine("Nom " + profile.Surname);
    Console.WriteLine("Id : " + profile.Id);
}


/*using(DiceyProject_DBContext db = new DiceyProject_DBContext())
{
    if(db.ProfilesSet.Count() > 0)
    {
        Console.WriteLine("Contenu de la base : ");
        foreach(var profile in db.ProfilesSet)
        {
            Console.WriteLine("Prénom : " + profile.Name);
            Console.WriteLine("Nom " + profile.Surname);
            Console.WriteLine("Id : " + profile.Id);
        }

        System.Console.WriteLine("Début du nettoyage");
        /*foreach(var profile in db.ProfilesSet)
        {
            Console.WriteLine($"Suppression de {profile.Name}");
            db.ProfilesSet.Remove(profile);
        }

        db.SaveChanges();
    }
}*/


