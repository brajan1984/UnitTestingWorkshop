using System;
using System.Collections.Generic;
using UnitTestingWorkshopConsoleApp.Models;

namespace UnitTestingWorkshopConsoleApp.Services.Interfaces
{
    public interface IFullHoursGenerator
    {
        IEnumerable<Hour24Model> GetAllPossibleHours(IEnumerable<int> digits);
    }
}
