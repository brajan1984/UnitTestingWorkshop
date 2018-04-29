using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingWorkshopConsoleApp.Models;

namespace UnitTestingWorkshopConsoleApp.Extensions
{
    public static class Hour24ModelExtensions
    {
        public static string To24HourFormatString(this Hour24Model model)
        {
            return $"{model.hour.ToDoubleDigitString()}:{model.minutes.ToDoubleDigitString()}:{model.seconds.ToDoubleDigitString()}";
        }
        public static string ParseHoursCollection(this IEnumerable<Hour24Model> correctHours)
        {
            return "new string[] {" + correctHours.Select(h => "\"" + h.To24HourFormatString() + "\"").Aggregate((c, n) => $"{c}, {n}") + "}";
        }
        public static Hour24Model Copy(this Hour24Model toCopy)
        {
            return new Hour24Model
            {
                hour = toCopy.hour,
                minutes = toCopy.minutes,
                seconds = toCopy.seconds
            };
        }
    }
}
