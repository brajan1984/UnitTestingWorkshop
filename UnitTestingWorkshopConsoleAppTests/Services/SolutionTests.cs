using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using UnitTestingWorkshopConsoleApp;
using UnitTestingWorkshopConsoleApp.Models;
using UnitTestingWorkshopConsoleApp.Services.Interfaces;
using Xunit;

namespace UnitTestingWorkshopConsoleAppTests.Services
{
    public class SolutionTests
    {
        private readonly Solution _solutionImpl;
        private readonly Mock<IHourProcessor> _hourProcessor = new Mock<IHourProcessor>();
        private readonly Mock<IFullHoursGenerator> _hourGenerator = new Mock<IFullHoursGenerator>();

        public SolutionTests()
        {
            _solutionImpl = new Solution(_hourProcessor.Object, _hourGenerator.Object);
        }

        [Fact]
        public void Solution_PassingSomeDigits_FlowIsCorrect()
        {
            //Arrange
            var digits = new List<int>() { 1, 2, 3, 4, 5, 6 };
            var generatedHours = new List<Hour24Model>();
            var expectedResult = "choosenHour";
            
            _hourGenerator.Setup(g => g.GetAllPossibleHours(digits))
                .Returns(generatedHours);
            
            _hourProcessor.Setup(p => p.Process(generatedHours))
                .Returns(expectedResult);

            //Act
            var testResult = _solutionImpl.solution(digits[0], digits[1], digits[2], digits[3], digits[4], digits[5]);

            //Assert
            _hourGenerator.Verify(g => g.GetAllPossibleHours(It.Is<IEnumerable<int>>(param => param.Except(digits).Count() == 0)), Times.Once);
            _hourProcessor.Verify(p => p.Process(It.Is<IEnumerable<Hour24Model>>(param => param == generatedHours)), Times.Once);

            testResult.Should().Be(expectedResult);
        }
    }
}
