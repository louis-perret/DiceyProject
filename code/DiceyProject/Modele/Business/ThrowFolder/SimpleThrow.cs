using Modele.Business.DiceFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{

    /// <summary>
    /// Implémentation simple de la classe Throw.
    /// </summary>
    public class SimpleThrow : Throw, IEqualityComparer<SimpleThrow>
    {
        /// <summary>
        /// Appel au constructeur de la classe mère.
        /// </summary>
        /// <param name="profileId"> Id du profil ayant lancer le dé. </param>
        /// <param name="dice"> Dé lancé par le profil. </param>
        public SimpleThrow(Guid profileId, Dice dice) : base(profileId, dice)
        {
        }

        /// <summary>
        /// Appel la méthode d'égalité de sa mère.
        /// </summary>
        /// <param name="other"> Objet à comparer. </param>
        /// <returns> Vrai si les deux objets sont égal, faux autrement. </returns>
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Implémentation de IEqualityComparer. Appel la procédure d'égalité de sa classe mère.
        /// </summary>
        /// <param name="x"> Premièr objet de la procédure d'égalité. </param>
        /// <param name="y"> Deuxième objet de la procédure d'égalité. </param>
        /// <returns></returns>
        public bool Equals(SimpleThrow? x, SimpleThrow? y)
        {
            return base.Equals(x, y);
        }

        /// <summary>
        /// Implémentation de IEqualityComparer. Appel la procédure de hashCode de sa classe mère.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetHashCode([DisallowNull] SimpleThrow obj)
        {
            return base.GetHashCode(obj);
        }

    }
}
