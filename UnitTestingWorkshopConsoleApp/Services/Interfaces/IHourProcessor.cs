using System;
using System.Collections.Generic;
using UnitTestingWorkshopConsoleApp.Models;

namespace UnitTestingWorkshopConsoleApp.Services.Interfaces
{
    public interface IHourProcessor
    {
        string Process(IEnumerable<Hour24Model> hours);
    }
}
