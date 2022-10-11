using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    public class DateTimeConverter
    {

        protected DateTimeConverter()
        {

        }

        public static DateOnly ConverToDateOnly(DateTime date)
        {
            return new DateOnly(date.Year, date.Month , date.Day);
        }
    }
}
