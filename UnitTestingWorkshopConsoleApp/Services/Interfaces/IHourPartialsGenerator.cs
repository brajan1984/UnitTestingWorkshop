using System;
using System.Collections.Generic;
using UnitTestingWorkshopConsoleApp.Models;

namespace UnitTestingWorkshopConsoleApp.Services.Interfaces
{
    public interface IHourPartialsGenerator
    {
        IEnumerable<Hour24Model> FillAllHours(IEnumerable<int> digits);
        IEnumerable<Hour24Model> FillAllMinutes(IEnumerable<int> digits, IEnumerable<Hour24Model> modelsWithHour);
        IEnumerable<Hour24Model> FillAllSeconds(IEnumerable<int> digits, IEnumerable<Hour24Model> modelsWithHour);
    }
}
