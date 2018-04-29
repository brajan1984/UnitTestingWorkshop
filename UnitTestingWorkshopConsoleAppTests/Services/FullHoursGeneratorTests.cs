using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using UnitTestingWorkshopConsoleApp.Models;
using UnitTestingWorkshopConsoleApp.Services;
using UnitTestingWorkshopConsoleApp.Services.Interfaces;
using Xunit;

namespace UnitTestingWorkshopConsoleAppTests.Services
{
    public class FullHoursGeneratorTests
    {
        private readonly FullHoursGenerator _hourGenerator;
        private readonly Mock<IHourPartialsGenerator> _hourPartialsGenerator = new Mock<IHourPartialsGenerator>();

        public FullHoursGeneratorTests()
        {
            _hourGenerator = new FullHoursGenerator(_hourPartialsGenerator.Object);
        }

        [Fact]
        public void GetAllPossibleHours_PassingSomeDigits_FlowIsCorrect()
        {
            //Arrange
            var allDigits = new List<int>();
            var hours = new List<Hour24Model>();
            var hoursWMinutes = new List<Hour24Model>();
            var fullHours = new List<Hour24Model>();

            var myDigits = new List<int>();

            _hourPartialsGenerator.Setup(h => h.FillAllHours(allDigits)).Returns(hours);
            _hourPartialsGenerator.Setup(h => h.FillAllMinutes(allDigits, hours)).Returns(hoursWMinutes);
            _hourPartialsGenerator.Setup(h => h.FillAllSeconds(allDigits, hoursWMinutes)).Returns(hoursWMinutes);

            //Act
            var result = _hourGenerator.GetAllPossibleHours(allDigits);

            //Assert
            _hourPartialsGenerator.Verify(h => h.FillAllHours(It.Is<List<int>>(o => o == allDigits)), Times.Once);
            _hourPartialsGenerator.Verify(h => h.FillAllMinutes(It.Is<List<int>>(o => o == allDigits), It.Is<List<Hour24Model>>(o => o == hours)), Times.Once);
            _hourPartialsGenerator.Verify(h => h.FillAllSeconds(It.Is<List<int>>(o => o == allDigits), It.Is<List<Hour24Model>>(o => o == hoursWMinutes)), Times.Once);

            result.Should().Equal(fullHours);
        }
    }
}
