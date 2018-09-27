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
			int shiftDays = GetShiftDays(month);
			
			return (WeekDay)((day+shiftDays)%7);
		}

		private int GetShiftDays(int month)
		{
			int[] offsets = {0, 3, 3, 6, 1, 4, 6, 2, 5, 0, 3, 5};

			return offsets[month-1];
		}
		// different years
		// leap years
		// centuries
		// millenia
	}
}
