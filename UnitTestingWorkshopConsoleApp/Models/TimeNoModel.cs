using System;

namespace UnitTestingWorkshopConsoleApp.Models
{
    public class TimeNoModel
    {
        public int first;
        public int second;

        public int fullNo
        {
            get
            {
                return int.Parse(string.Format("{0}{1}", first, second));
            }
        }
    }
}
