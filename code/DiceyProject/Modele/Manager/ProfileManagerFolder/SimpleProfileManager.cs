using Modele.Business.ProfileFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Manager.ProfileManagerFolder
{
    public class SimpleProfileManager : ProfileManager
    {
        public override bool AddProfile(string name, string surname)
        {
            Profile prof = new SimpleProfile(name, surname);
            return AddProfile(prof);
        }

        public override bool AddProfile(int id, string name, string surname)
        {
            Profile prof = new SimpleProfile(id, name, surname);
            return AddProfile(prof);
        }
    }
}
