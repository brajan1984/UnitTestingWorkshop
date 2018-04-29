using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingWorkshopConsoleApp.Models;
using UnitTestingWorkshopConsoleApp.Services.Interfaces;

namespace UnitTestingWorkshopConsoleApp.Services
{
    public class FullHoursGenerator : IFullHoursGenerator
    {
        public IEnumerable<Hour24Model> GetAllPossibleHours(IEnumerable<int> digits)
        {
            var correctHour = new List<int>();

            var hours = new List<Hour24Model>();

            for (int first = 0; first < 6; first++)
            {
                var testDigits = digits.ToList();

                int firstNo = testDigits[first];
                testDigits.Remove(firstNo);

                foreach (var secondNo in testDigits)
                {
                    var hour = new TimeNoModel() { first = firstNo, second = secondNo };

                    if (ValidateHour(hour))
                    {
                        hours.Add(new Hour24Model { hour = hour });
                    }
                }
            }

            var hoursWithMinutes = new List<Hour24Model>();

            foreach (var hour in hours)
            {
                var testDigits = digits.ToList();
                testDigits.Remove(hour.hour.first);
                testDigits.Remove(hour.hour.second);

                for (int first = 0; first < testDigits.Count(); first++)
                {
                    var digitsForNext = testDigits.ToList();

                    int firstNo = digitsForNext[first];
                    digitsForNext.Remove(firstNo);

                    foreach (var secondNo in digitsForNext)
                    {

                        var minute = new TimeNoModel() { first = firstNo, second = secondNo };
                        var hourcpy = new Hour24Model
                        {
                            hour = hour.hour,
                            minutes = hour.minutes,
                            seconds = hour.seconds
                        };
                        if (ValidateMinSec(minute))
                        {
                            hourcpy.minutes = minute;
                            hoursWithMinutes.Add(hourcpy);
                        }
                    }
                }
            }

            var correctHours = new List<Hour24Model>();

            foreach (var hour in hoursWithMinutes)
            {
                var testDigits = digits.ToList();
                testDigits.Remove(hour.hour.first);
                testDigits.Remove(hour.hour.second);
                testDigits.Remove(hour.minutes.first);
                testDigits.Remove(hour.minutes.second);
                
                for (int first = 0; first < testDigits.Count(); first++)
                {
                    var digitsForNext = testDigits.ToList();

                    int firstNo = digitsForNext[first];
                    digitsForNext.Remove(firstNo);

                    foreach (var secondNo in digitsForNext)
                    {

                        var seconds = new TimeNoModel() { first = firstNo, second = secondNo };

                        if (ValidateMinSec(seconds))
                        {

                            var hourcpy = new Hour24Model
                            {
                                hour = hour.hour,
                                minutes = hour.minutes,
                                seconds = hour.seconds
                            };
                            hourcpy.seconds = seconds;
                            correctHours.Add(hourcpy);
                        }
                    }
                }
            }

            return correctHours;
        }

        private static bool ValidateHour(TimeNoModel hour)
        {
            return hour.fullNo >= 0 && hour.fullNo <= 24;
        }

        private static bool ValidateMinSec(TimeNoModel hour)
        {
            return hour.fullNo >= 0 && hour.fullNo <= 60;
        }
    }
}
