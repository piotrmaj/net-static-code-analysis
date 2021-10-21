using System;

namespace Users.Api.Services
{
    public interface ITimeToNextBirthdayFormatter
    {
        string Format(DateOnly birthDate);
    }

    public class TimeToNextBirthdayFormatter : ITimeToNextBirthdayFormatter
    {
        public static int DaysLeftThreshold = 10;
        public static int LessThanAMonthThreashold = 30;
        public static int PickingGiftDaysThreshold = 90;

        public string Format(DateOnly birthDate)
        {
            if (birthDate == default)
            {
                throw new ArgumentException("Can't have default value", "birthDate");
            }

            var daysToNextBirthday = CalculateDaysToNextBirthday(birthDate);


            if (daysToNextBirthday == 0)
                return "Congratulations, today is your birthday. Enjoy!";
            else if (daysToNextBirthday == 1)
                return $"Your birthday is tomorrow, sleep well!";
            else if (daysToNextBirthday < DaysLeftThreshold)
                return $"Only {daysToNextBirthday} days left, be prepared!";
            else if (daysToNextBirthday < LessThanAMonthThreashold)
                return "Less than a month left to your birthday, better start invitin friends for the party";
            else if (daysToNextBirthday < PickingGiftDaysThreshold)
                return $"Still some time left, {daysToNextBirthday} days but maybe you should start picking out a gift";


            return $"You need to be patient {daysToNextBirthday/30} months and {daysToNextBirthday%30} days left until your birthday";
        }

        private int CalculateDaysToNextBirthday(DateOnly birthDate)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var d = birthDate.DayOfYear - today.DayOfYear;
            if (d == 0)
                return 0;
            var birthdayUpcomingThisYear = birthDate.DayOfYear - today.DayOfYear > 0;
            if (birthdayUpcomingThisYear)
                return birthDate.DayOfYear - today.DayOfYear;
            //birthday has already passed this year
            var nextYearBirthdate = new DateOnly(today.Year + 1, birthDate.Month, birthDate.Day);
            return nextYearBirthdate.DayNumber - today.DayNumber;
        }
    }
}
