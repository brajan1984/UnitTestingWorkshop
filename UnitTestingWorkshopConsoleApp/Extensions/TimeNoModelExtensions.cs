using System;
using UnitTestingWorkshopConsoleApp.Models;

namespace UnitTestingWorkshopConsoleApp.Extensions
{
    public static class TimeNoModelExtensions
    {
        public static string ToDoubleDigitString(this TimeNoModel model)
        {
            return model.first.ToString() + model.second.ToString();
        }
    }
}
