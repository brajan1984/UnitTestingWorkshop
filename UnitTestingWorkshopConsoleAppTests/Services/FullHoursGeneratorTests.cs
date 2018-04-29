using System;
using Moq;
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

            //Act

            //Assert
            Assert.False(true);
        }
    }
}
