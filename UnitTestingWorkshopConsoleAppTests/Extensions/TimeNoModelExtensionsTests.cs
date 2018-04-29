using System;
using FluentAssertions;
using UnitTestingWorkshopConsoleApp.Extensions;
using UnitTestingWorkshopConsoleApp.Models;
using Xunit;

namespace UnitTestingWorkshopConsoleAppTests.Extensions
{
    public class TimeNoModelExtensionsTests
    {
        [Theory]
        [InlineData("06", new int[] { 0, 6 })]
        [InlineData("00", new int[] { 0, 0 })]
        [InlineData("12", new int[] { 1, 2 })]
        [InlineData("23", new int[] { 2, 3 })]
        public void ToDoubleDigitString_ParseHoursToStringFormat_Success(string expectedResult, int[] testNoData)
        {
            //Arrange
            var testNo = new TimeNoModel { first = testNoData[0], second = testNoData[1] };

            //Act
            var testResult = testNo.ToDoubleDigitString();

            //Assert
            testResult.Should().Be(expectedResult);
        }
    }
}
