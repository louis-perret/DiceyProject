using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalTest.Reader
{
    /// <summary>
    /// Manages the reading of inputs from console
    /// </summary>
    internal class Reader
    {
        /// <summary>
        /// Read and parse a string into an int
        /// </summary>
        /// <returns></returns>
        internal int ReadInt()
        {
            String? input = ReadLine();
            int ret = -1;
            if (input != null)
                try
                {
                    ret = int.Parse(input);
                }
                catch (Exception)
                {
                    ret = -1;
                }
            return ret;
        }

        /// <summary>
        /// Read the name of a profile
        /// </summary>
        /// <returns></returns>
        internal string ReadName()
        {
            Console.WriteLine("Entrez un nom :");
            return ReadLine();
        }

        /// <summary>
        /// Read the surname of a profile
        /// </summary>
        /// <returns></returns>
        internal string ReadSurname()
        {
            Console.WriteLine("Entrez un prénom :");
            return ReadLine();
        }

        /// <summary>
        /// Read a simple line
        /// </summary>
        /// <returns></returns>
        internal string ReadLine()
        {
            return Console.ReadLine();
        }

        internal int ReadChoicePersistance()
        {
            Console.WriteLine("Choisissez votre persistance : \n" +
                "0 - Stub\n" +
                "1 - EntityFramework\n");

            int ret = ReadInt();
            if(ret != 0 && ret != 1)
            {
                return ReadChoicePersistance();
            } 

            return ret;
        }

    }
}
