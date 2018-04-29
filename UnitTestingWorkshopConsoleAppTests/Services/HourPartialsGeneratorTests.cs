using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using UnitTestingWorkshopConsoleApp.Models;
using UnitTestingWorkshopConsoleApp.Services;
using UnitTestingWorkshopConsoleApp.Services.Interfaces;
using Xunit;

namespace UnitTestingWorkshopConsoleAppTests.Services
{
    public class HourPartialsGeneratorTests
    {
        Mock<IUniqueNumberGenerator> _numberGeneratorMock = new Mock<IUniqueNumberGenerator>();
        HourPartialsGenerator _hourPartialsGeneratorImpl;

        public HourPartialsGeneratorTests()
        {
            _hourPartialsGeneratorImpl = new HourPartialsGenerator(_numberGeneratorMock.Object);
        }
        
        [Theory]
        [InlineData(new int[] { 1, 8, 3, 2 }, 18, new int[] { 1, 8 }, new int[] { 32, 23 }, new int[] { 32, 23 })]
        [InlineData(new int[] { 1, 8, 9, 2 }, 18, new int[] { 1, 8 }, new int[] { 92, 29 }, new int[] { 29 })]
        [InlineData(new int[] { 1, 8, 9, 9 }, 18, new int[] { 1, 8 }, new int[] { 99, 99 }, new int[] { })]
        public void FillAllMinutes_GetsSetWithFilledHours_ReturnsHoursWithMinutes(int[] digits, int hour, int[] hourDigits, int[] allPossibleMinutes, int[] expectedResult)
        {
            Assert.False(true);
        }

        [Theory]
        [InlineData(new int[] { 1, 8, 3, 2, 6, 4 }, 18, 32, new int[] { 1, 8, 3, 2 }, new int[] { 46 }, new int[] { 46 })]
        [InlineData(new int[] { 4, 4, 3, 9, 6, 2 }, 23, 46, new int[] { 2, 3, 4, 6 }, new int[] { 49, 94 }, new int[] { 49 })]
        public void FillAllSeconds_GetsSetWithoutSeconds_ReturnsHoursWithMinutesAndSeconds(int[] digits, int hour, int minutes, int[] usedDigits, int[] allPossibleSeconds, int[] expectedResult)
        {
            Assert.False(true);
        }

        [Theory]
        [InlineData(new int[] { 1, 8, 3, 2, 6, 4 }, new int[] { 18, 13, 12, 16, 14, 21, 23, 24, 81, 83, 82, 86, 84, 31 }, new int[] { 18, 13, 12, 16, 14, 21, 23, 24 })]
        public void FillAllHours_HoursAreFilteredByProperRange_CorrectHoursCollection(int[] inputData, int[] allCombinations, int[] expectedResultData)
        {
            Assert.False(true);
        }
    }
}
