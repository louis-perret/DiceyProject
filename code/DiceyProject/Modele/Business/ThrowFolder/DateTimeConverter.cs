using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Business.ThrowFolder
{
    /// <summary>
    /// Utility class that converts DateTime to DateOnly
    /// </summary>
    public class DateTimeConverter
    {

        /// <summary>
        /// Method that converts a DateTime to a DateOnly
        /// </summary>
        /// <param name="date">The DateTime to convert to DateOnly</param>
        /// <returns>The Date from the DateTime passed as parameter</returns>
        public static DateOnly ConverToDateOnly(DateTime date)
        {
            return new DateOnly(date.Year, date.Month , date.Day);
        }
    }
}
