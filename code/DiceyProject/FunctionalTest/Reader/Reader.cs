using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalTest.Reader
{
    internal class Reader
    {
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

        internal string ReadName()
        {
            Console.WriteLine("Enter a name :");
            return ReadLine();
        }

        internal string ReadSurname()
        {
            Console.WriteLine("Enter a surname :");
            return ReadLine();
        }

        private string? ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
