using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19._09._20_Overloading
{
	class Date
	{

		private int[] _arr = new int[13] { 29, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

		private int _year;
		private int _month;
		private int _day;

		//public static DateTime operator +(DateTime d, TimeSpan t);	
		//public static TimeSpan operator -(DateTime d1, DateTime d2);
		//public static DateTime operator -(DateTime d, TimeSpan t);	
		//public static bool operator ==(DateTime d1, DateTime d2);
		//public static bool operator !=(DateTime d1, DateTime d2);
		//public static bool operator <(DateTime t1, DateTime t2);		
		//public static bool operator >(DateTime t1, DateTime t2);	
		//public static bool operator <=(DateTime t1, DateTime t2);
		//public static bool operator >=(DateTime t1, DateTime t2);

		public static Date operator +(Date d, TimeSpan t)
        {
			DateTime temp = new DateTime(d.Year, d.Month, d.Day);
			DateTime result = temp.Add(t);

			return new Date(result.Year, result.Month, result.Day);
		}
		public static TimeSpan operator -(Date d1, Date d2)
        {
			DateTime temp1 = new DateTime(d1.Year, d1.Month, d1.Day);
			DateTime temp2 = new DateTime(d2.Year, d2.Month, d2.Day);
			TimeSpan result = temp1.Subtract(temp2);

			return result;
		}
		public static Date operator -(Date d, TimeSpan t)
        {
			DateTime temp1 = new DateTime(d.Year, d.Month, d.Day);
			DateTime result = temp1.Subtract(t);

			return new Date(result.Year, result.Month, result.Day);
		}
		public static bool operator ==(Date d1, Date d2)
        {
			return d1.Equals(d2);
		}
		public static bool operator !=(Date d1, Date d2)
		{
			return !d1.Equals(d2);
		}
		public static bool operator <(Date t1, Date t2)
        {
			DateTime d1 = new DateTime(t1.Year, t1.Month, t1.Day);
			DateTime d2 = new DateTime(t2.Year, t2.Month, t2.Day);

			int result = DateTime.Compare(d1, d2);
			if (result < 0)
			{
				return true;
			}
			return false;
		}
		public static bool operator >(Date t1, Date t2)
        {
			DateTime d1 = new DateTime(t1.Year, t1.Month, t1.Day);
			DateTime d2 = new DateTime(t2.Year, t2.Month, t2.Day);

			int result = DateTime.Compare(d1, d2);
			if (result < 0)
			{
				return false;
			}
			return true;
		}
		public static bool operator <=(Date t1, Date t2)
        {
			DateTime d1 = new DateTime(t1.Year, t1.Month, t1.Day);
			DateTime d2 = new DateTime(t2.Year, t2.Month, t2.Day);

			int result = DateTime.Compare(d1, d2);
			if (result <= 0)
			{
				return true;
			}
			return false;
		}
		public static bool operator >=(Date t1, Date t2)
		{
			DateTime d1 = new DateTime(t1.Year, t1.Month, t1.Day);
			DateTime d2 = new DateTime(t2.Year, t2.Month, t2.Day);

			int result = DateTime.Compare(d1, d2);
			if (result <= 0)
			{
				return false;
			}
			return true;
		}
		public override bool Equals(object obj)
		{
            if (obj == null || !(obj is Date))
            {
                return false;
            }

			Date date = obj as Date;
			return this.Year == date.Year && this.Month == date.Month && this.Day == date.Day;
		}
        public override int GetHashCode()
        {
			return ((Year + Month) << 2) ^ Day;
		}
		public static bool operator true(Date date)
		{
			return date != null;
		}
		public static bool operator false(Date date)
		{
			return date == null;
		}

		public Date()
		{
			_year = 0;
			_month = 1;
			_day = 1;
		}
		public Date(int year, int month, int day = 1)
		{
			_year = year;
			_month = month;
			_day = day;
		}
		public int Year
        {
			get => _year;
			set
            {
				try
				{
					if (value >= 0 && Month > 0)
					{
						if (!isLeapYear(value))
						{
							if (Day <= _arr[Month])
							{
								_year = value;
								return;
							}
						}
						else
						{
							if (Month == 2 && Day <= _arr[0])
							{
								_year = value;
								return;
							}
							else if (Month != 2 && Day <= _arr[Month])
							{
								_year = value;
								return;
							}
						}
					}
					throw new ArgumentException("Error: incorrect value in the year variable.");
				}
				catch (ArgumentException message)
				{
					Console.WriteLine(message);
				}
			}
        }
		public int Month
		{
			get => _month;
			set
			{
				try
				{
					if (Year >= 0 && (value > 0 && value < 13))
					{
						if (!isLeapYear(Year))
						{
							if (Day <= _arr[value])
							{
								_month = value;
								return;
							}
						}
						else
						{
							if (value == 2 && Day <= _arr[0])
							{
								_month = value;
								return;
							}
							else if (value != 2 && Day <= _arr[value])
							{
								_month = value;
								return;
							}
						}
					}
					throw new ArgumentException("Error: the month must be between 1 and 12.");
				}
				catch (ArgumentException message)
				{
					Console.WriteLine(message);
				}
			}
		}
		public int Day
		{
			get => _day;
			set
			{
				try
				{
					if (Month != 0)
					{
						if (!isLeapYear(Year))
						{
							if (value > 0 && value <= _arr[Month])
							{
								_day = value;
								return;
							}
						}
						else
						{
							if (Month != 2 && (value > 0 && value <= _arr[Month]))
							{
								_day = value;
								return;
							}
							else if (Month == 2 && (value > 0 && value <= _arr[0]))
							{
								_day = value;
								return;
							}
						}
					}
					throw new ArgumentException("Error: incorrect value in the day variable.");
				}
				catch (ArgumentException message)
				{
					Console.WriteLine(message);
				}
			}
		}
		public bool isLeapYear(int year)
		{
			return (year % 4 == 0 && year % 100 != 0 || year % 400 == 0);
		}
		public void AddDays(int days)
		{
			_day += days;

			ConvertDays();
			if (isLeapYear(Year))
			{
				if (Month == 2 && Day > _arr[0])
				{
					_day -= _arr[0];
					Month++;
				}
				else if (Month != 2 && Day > _arr[Month])
				{
					_day -= _arr[Month];
					Month++;
				}
			}
		}
		public void AddMonths(int months)
		{
			Month += months;
			ConvertDays();
		}
		public void AddYears(int years)
		{
			Year += years;
			ConvertDays();
		}
		public static Date getCurrentDate()
		{
			DateTime date = new DateTime();
			date = DateTime.Now;

			return new Date(date.Year, date.Month, date.Day);
		}
		private void ConvertDays()
		{
			if (!isLeapYear(Year))
			{
				if (Day > _arr[Month])
				{
					_day -= _arr[Month];
					Month++;
				}
			}
		}
		public void printTime()
		{
			Console.Write($"Date: {Year}.");

			if (Month > 9)
			{
				Console.Write($"{Month}.");
			}
			else
			{
				Console.Write($"0{Month}.");
			}

			if (Day > 9)
			{
				Console.WriteLine($"{Day}");
			}
			else
			{
				Console.WriteLine($"0{Day}");
			}
		}
		public override string ToString()
		{
			return $"Date: {Year}/{Month}/{Day}";
		}
	}
}
