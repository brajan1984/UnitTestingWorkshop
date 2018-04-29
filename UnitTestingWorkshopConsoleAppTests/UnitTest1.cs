using System;
using FluentAssertions;
using UnitTestingWorkshopConsoleApp;
using UnitTestingWorkshopConsoleApp.Services;
using UnitTestingWorkshopConsoleApp.Services.Interfaces;
using Xunit;

namespace UnitTestingWorkshopConsoleAppTests
{
    public class UnitTest1
    {
        Solution _solutionImpl = new Solution(null, null);

        public UnitTest1()
        {
            IHourProcessor _hourProcessor = new HourProcessor();
            IUniqueNumberGenerator _numberGenerator = new TwoDigitsUniqueNumberGenerator();
            IHourPartialsGenerator _hourPartialsGenerator = new HourPartialsGenerator(_numberGenerator);
            IFullHoursGenerator _hoursGenerator = new FullHoursGenerator(_hourPartialsGenerator);

            _solutionImpl = new Solution(_hourProcessor, _hoursGenerator);
        }
        
        [Theory]
        [InlineData(1, 8, 3, 2, 6, 4, "12:36:48")]
        [InlineData(4, 4, 4, 4, 4, 4, "NOT POSSIBLE")]
        [InlineData(1, 9, 3, 5, 6, 8, "16:38:59")]
        [InlineData(4, 4, 3, 9, 6, 2, "23:46:49")]
        [InlineData(0, 2, 1, 3, 1, 2, "01:12:23")]
        [InlineData(1, 8, 0, 2, 0, 4, "00:12:48")]
        public void SolutionUnitTest(int A, int B, int C, int D, int E, int F, string expectedValue)
        {
            var result = _solutionImpl.solution(A, B, C, D, E, F);

            result.Should().Be(expectedValue);
        }
    }
}
