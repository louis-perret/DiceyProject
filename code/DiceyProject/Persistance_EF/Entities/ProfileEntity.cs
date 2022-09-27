using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_EF.Entities
{
    public class ProfileEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public ProfileEntity(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public ProfileEntity(string name, string surname) : this(0, name, surname) { }
    }
}
