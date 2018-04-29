using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using UnitTestingWorkshopConsoleApp.Extensions;
using UnitTestingWorkshopConsoleApp.Services;
using UnitTestingWorkshopConsoleApp.Services.Interfaces;

namespace UnitTestingWorkshopConsoleApp
{
    public class Solution
    {
        private readonly IHourProcessor _hourProcessor;
        private readonly IFullHoursGenerator _fullHoursGenerator;
        public Solution(IHourProcessor hourProcessor, IFullHoursGenerator fullHoursGenerator)
        {
            _fullHoursGenerator = fullHoursGenerator;
            _hourProcessor = hourProcessor;
        }
        public string solution(int A, int B, int C, int D, int E, int F)
        {
            var digits = new List<int>();
            digits.Add(A);
            digits.Add(B);
            digits.Add(C);
            digits.Add(D);
            digits.Add(E);
            digits.Add(F);

            var generatedHours = _fullHoursGenerator.GetAllPossibleHours(digits);

            // var explorationHelper = generatedHours.ParseHoursCollection();

            // Console.WriteLine(explorationHelper);
            // Console.Read();

            var result = _hourProcessor.Process(generatedHours);

            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IHourProcessor _hourProcessor = new HourProcessor();
            IUniqueNumberGenerator _numberGenerator = new TwoDigitsUniqueNumberGenerator();
            IHourPartialsGenerator _hourPartialsGenerator = new HourPartialsGenerator(_numberGenerator);
            IFullHoursGenerator _hoursGenerator = new FullHoursGenerator(_hourPartialsGenerator);

            var proc = new Solution(_hourProcessor, _hoursGenerator);
            
            var hour = proc.solution(1, 8, 3, 2, 6, 4);

            Console.WriteLine(hour);

            Console.ReadKey();
        }
    }
}
