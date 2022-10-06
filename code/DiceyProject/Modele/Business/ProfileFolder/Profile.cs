using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ProfileFolder
{
    /// <summary>
    /// Represent a player's profile
    /// </summary>
    public abstract class Profile : IEquatable<Profile>
    {
        /// <summary>
        /// Palyer's id
        /// </summary>
        public int Id { get; private set; }


        /// <summary>
        /// Player's name
        /// </summary>
        public string Name 
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name));
                }
                _name = value;
            }
        }
        private string _name;


        

        /// <summary>
        /// Player's surname
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name));
                }
                _surname = value;
            }
        }
        private string _surname;

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="id">player's id</param>
        /// <param name="name">player's name</param>
        /// <param name="surname">player's surname</param>
        /// <exception cref="ArgumentException"></exception>
        public Profile(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public Profile(string name, string surname) : this(-1, name, surname)
        {
        }

        public bool Equals(Profile? other)
        {
            if (other == null) return false;

            return Id == other.Id;

        }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj == this) return true;
            if(!GetType().Equals(obj.GetType())) return false;

            return Equals((Profile)obj);
        }



        public override int GetHashCode()
        {
            return Id;
        }

    }
}
