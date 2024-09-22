using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Convertor
{
	public static class DateConvertor
	{
		public static string ToShamsi(this DateTime dateTime)
		{
			PersianCalendar persianCalendar = new();
			int year = persianCalendar.GetYear(dateTime);
			int month = persianCalendar.GetMonth(dateTime);
			int day = persianCalendar.GetDayOfMonth(dateTime);
			return $"{year}/{month.ToString("00")}/{day.ToString("00")}";
		}

		public static string ToShamsiWithTime(this DateTime dateTime)
		{
			PersianCalendar persianCalendar = new();
			int year = persianCalendar.GetYear(dateTime);
			int month = persianCalendar.GetMonth(dateTime);
			int day = persianCalendar.GetDayOfMonth(dateTime);
			return $"{year}/{month.ToString("00")}/{day.ToString("00")} {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
		}
	}
}
