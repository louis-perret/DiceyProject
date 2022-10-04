using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance_EF.Entities
{
    /// <summary>
    /// Represents the entity Profile on our database
    /// </summary>
    public class ProfileEntity
    {
        /// <summary>
        /// Id of profile
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of profile
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// Surname of profile
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">id of profile</param>
        /// <param name="name">name of profile</param>
        /// <param name="surname">surname of profile</param>
        public ProfileEntity(int id, string name, string surname) : this(name, surname)
        {
            Id = id;
        }

        /// <summary>
        /// Constructor without id
        /// </summary>
        /// <param name="name">name of profile</param>
        /// <param name="surname">surname of profile</param>
        public ProfileEntity(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
