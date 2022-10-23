// See https://aka.ms/new-console-template for more information



using Modele.Business.ProfileFolder;
using Modele.Manager.ProfileManagerFolder;

public class Manager
{
    private ProfileManager profileManager;
    public Manager()
    {
        profileManager = new SimpleProfileManager();
    }
    public void AddProfile(string name, string surname)
    {
        profileManager.AddProfile(name, surname);
    }

    public IReadOnlyCollection<Profile> getAllProfiles()
    {
        return profileManager.Profiles;
    }
}