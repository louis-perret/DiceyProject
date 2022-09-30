// See https://aka.ms/new-console-template for more information
using Modele.Business.ProfileFolder;
using Persistance_EF;
using Persistance_EF.DBContext;
using Persistance_EF.Extensions;

Console.WriteLine("Hello, World!");

using (DiceyProject_DBContext db = new DiceyProject_DBContext())
{
    Profile profile1 = new SimpleProfile("Perret", "Louis");
    Profile profile2 = new SimpleProfile("Malvezin", "Neitah");
    Profile profile3 = new SimpleProfile("Grienenberger", "Côme");

    db.ProfilesSet.Add(profile1.ToEntity());
    //db.ProfilesSet.Add(profile2.ToEntity());
    //db.ProfilesSet.Add(profile3.ToEntity());

    db.SaveChanges();
}