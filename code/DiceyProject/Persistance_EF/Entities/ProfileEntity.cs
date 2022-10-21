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
    public class ProfileEntity : IEquatable<ProfileEntity?>
    {
        /// <summary>
        /// Id of profile
        /// </summary>
        public Guid Id { get; set; }

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
        public ProfileEntity(Guid id, string name, string surname) : this(name, surname)
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

        /// <summary>
        /// Return true if obj is equal to the calling object
        /// </summary>
        /// <param name="obj">Obj to compare</param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            return Equals(obj as ProfileEntity);
        }

        /// <summary>
        /// Return true if obj is equal to the calling object
        /// </summary>
        /// <param name="obj">Obj to compare</param>
        /// <returns></returns>
        public bool Equals(ProfileEntity? other)
        {
            return other is not null && Id == other.Id;
        }
    }
}
