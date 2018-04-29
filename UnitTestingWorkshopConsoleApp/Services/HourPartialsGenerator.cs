using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingWorkshopConsoleApp.Models;
using UnitTestingWorkshopConsoleApp.Services.Interfaces;

namespace UnitTestingWorkshopConsoleApp.Services
{
    public class HourPartialsGenerator : IHourPartialsGenerator
    {
        public IEnumerable<Hour24Model> FillAllHours(IEnumerable<int> digits)
        {
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

            return hours;
        }

        private static bool ValidateHour(TimeNoModel hour)
        {
            return hour.fullNo >= 0 && hour.fullNo <= 24;
        }

        public IEnumerable<Hour24Model> FillAllMinutes(IEnumerable<int> digits, IEnumerable<Hour24Model> modelsWithHour)
        {
            var hoursWithMinutes = new List<Hour24Model>();

            foreach (var hour in modelsWithHour)
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

            return hoursWithMinutes;
        }
        
        private static bool ValidateMinSec(TimeNoModel hour)
        {
            return hour.fullNo >= 0 && hour.fullNo <= 60;
        }

        public IEnumerable<Hour24Model> FillAllSeconds(IEnumerable<int> digits, IEnumerable<Hour24Model> modelsWithHour)
        {
            var correctHours = new List<Hour24Model>();

            foreach (var hour in modelsWithHour)
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
    }
}
