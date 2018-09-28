using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeekDay
{
	[TestClass]
	public class WeekDayTest
	{
		[TestMethod]
		public void DaysToWeekDays()
		{
			AssertWeekDay(1, WeekDay.Monday);
			AssertWeekDay(2, WeekDay.Tuesday);
			AssertWeekDay(3, WeekDay.Wednesday);
			AssertWeekDay(4, WeekDay.Thursday);
			AssertWeekDay(5, WeekDay.Friday);
			AssertWeekDay(6, WeekDay.Saturday);
			AssertWeekDay(7, WeekDay.Sunday);
			AssertWeekDay(8, WeekDay.Monday);
		}

		[TestMethod]
		public void DaysAndMonthsToWeekDays()
		{
			AssertWeekDayAndMonth(2, 1, WeekDay.Thursday);
			AssertWeekDayAndMonth(2, 2, WeekDay.Friday);
			AssertWeekDayAndMonth(2, 3, WeekDay.Saturday);
			
			AssertWeekDayAndMonth(3, 1, WeekDay.Thursday);
			
			AssertWeekDayAndMonth(4, 1, WeekDay.Sunday);

			AssertWeekDayAndMonth(5, 1, WeekDay.Tuesday);
			
			AssertWeekDayAndMonth(6, 1, WeekDay.Friday);
			AssertWeekDayAndMonth(7, 1, WeekDay.Sunday);
			AssertWeekDayAndMonth(8, 1, WeekDay.Wednesday);
			AssertWeekDayAndMonth(9, 1, WeekDay.Saturday);
			AssertWeekDayAndMonth(10, 1, WeekDay.Monday);
			AssertWeekDayAndMonth(11, 1, WeekDay.Thursday);
			AssertWeekDayAndMonth(12, 1, WeekDay.Saturday);
		}

		[TestMethod]
		public void DaysAndMonthsAndYearsToWeekDays()
		{
			AssertWeekDayAndMonthAndYear(2015, 1, 1, WeekDay.Thursday);
			AssertWeekDayAndMonthAndYear(2015, 12, 31, WeekDay.Thursday);
			AssertWeekDayAndMonthAndYear(2016, 1, 1, WeekDay.Friday);
			AssertWeekDayAndMonthAndYear(2016, 12, 31, WeekDay.Saturday);
			AssertWeekDayAndMonthAndYear(2017, 1, 1, WeekDay.Sunday);
			AssertWeekDayAndMonthAndYear(2017, 12, 31, WeekDay.Sunday);

		}

		private void AssertWeekDayAndMonthAndYear(int year, int month, int day, WeekDay expected) {
			Assert.AreEqual(expected, CalculateDayOfWeek(year, month, day));
		}



		
		private void AssertWeekDayAndMonth(int month, int day, WeekDay expected)
		{
			Assert.AreEqual(expected, CalculateDayOfWeek(2018, month, day));
		}

		private void AssertWeekDay(int day, WeekDay expected)
		{
			Assert.AreEqual(expected, CalculateDayOfWeek(2018, 1, day));
		}

		private WeekDay CalculateDayOfWeek(int year, int month, int day)
		{
			int shiftDays = GetShiftDaysMonths(month);

			shiftDays += GetShiftDaysYears(year, month);

			return (WeekDay)((day+shiftDays)%7);
		}

		private int GetShiftDaysMonths(int month)
		{
			int[] offsets = {0, 3, 3, 6, 1, 4, 6, 2, 5, 0, 3, 5};

			return offsets[month-1];
		}

		private int GetShiftDaysYears(int year, int month)
		{
			// wir sind im refactoring schritt -> das gehoert u.a. in GetShiftDaysMonths
			// 
			
			int shiftDays = 0;

			if (IsLeapYear(year) && month > 2) {
				shiftDays+=1;
			}

			if (year == 2017)
			{
				shiftDays+=6;
			}

			if (year == 2016)
			{
				shiftDays+=4;
			}
			

			if (year == 2015) {
				shiftDays+=3;
			}

			return shiftDays;
		}

		private bool IsLeapYear(int year)
        {
            return (year % 4 == 0
                    && year % 100 != 0)
                || year % 400 == 0;
        }

		// different years - doing this
		// leap years
		// centuries
		// millenia
	}
}
