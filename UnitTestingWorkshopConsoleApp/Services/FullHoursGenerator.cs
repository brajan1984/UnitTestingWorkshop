using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingWorkshopConsoleApp.Models;
using UnitTestingWorkshopConsoleApp.Services.Interfaces;

namespace UnitTestingWorkshopConsoleApp.Services
{
    public class FullHoursGenerator : IFullHoursGenerator
    {
        private readonly IHourPartialsGenerator _partialsGenerator;
        public FullHoursGenerator(IHourPartialsGenerator partialsGenerator)
        {
            _partialsGenerator = partialsGenerator;
        }
        public IEnumerable<Hour24Model> GetAllPossibleHours(IEnumerable<int> digits)
        {
            var correctHour = new List<int>();

            var hours = _partialsGenerator.FillAllHours(digits);
            var hoursWithMinutes = _partialsGenerator.FillAllMinutes(digits, hours);
            var hoursWithMinutesAndSeconds = _partialsGenerator.FillAllSeconds(digits, hoursWithMinutes);

            return hoursWithMinutesAndSeconds;
        }
    }
}
