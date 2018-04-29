using System;
using System.Collections.Generic;

namespace UnitTestingWorkshopConsoleApp.Services.Interfaces
{
    public interface IUniqueNumberGenerator
    {
        List<int> GenerateUniqueNumbersExcluding(IEnumerable<int> digits, IEnumerable<int> exclude);
        List<int> GenerateUniqueNumbers(IEnumerable<int> digits);
    }
}
