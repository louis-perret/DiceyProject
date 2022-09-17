using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ProfileFolder
{
    public abstract class Profile : IEquatable<Object>
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Profile(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public Profile(string name, string surname) : this(-1, name, surname)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Profile profile &&
                   Id == profile.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
