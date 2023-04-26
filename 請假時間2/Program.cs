using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 請假時間2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("請輸入請假開始時間: EX_2000,01,01 10:00:00");
			bool value = DateTime.TryParse(Console.ReadLine(), out DateTime date_start);
			Console.WriteLine("請輸入請假結束時間: EX_2000,01,01 12:00:00");
			bool value1 = DateTime.TryParse(Console.ReadLine(), out DateTime date_end);
			new LeaveHours().WorkingHours(date_start, date_end);
		}
	}
	public class LeaveHours
	{
		public void WorkingHours(DateTime hourStart, DateTime hourEnd)
		{

			if (!hourStart.BetweenDaysOfWeek(1, 5))
			{
				Console.WriteLine("請到假日囉~");
			}
			else
			{
				int start00 = hourStart.Hour;
				int end00 = hourEnd.Hour;
				if (IsReverseTime(start00, end00))
				{
					Console.WriteLine("您的請假時間為" + TimeResult(start00, end00));
				}				
				Console.ReadKey();
			}
		}
		public int TimeResult(int start, int end)
		{
			int total = end - start;
			if (start < 9 && end > 18)
			{
				return total = 8;
			}
			else if (start < 9)
			{
				start = 9;
				total = end - start;
				if (end > 13)
				{
					return total - 1;
				}
				else { return total; }
			}
			else if (end > 18)
			{
				end = 18;
				total = end - start;
				if (start < 12)
				{
					return total - 1;
				}
				else { return total; }
			}
			else if (start < 12 && end > 13)
			{
				return total - 1;
			}
			else
			{ return total; }
		}
		public bool IsReverseTime(int start, int end)
		{
			if (end < start)
			{
				Console.WriteLine($"時間寫反了兄弟。");
				return false;
			}
			else { return true; }
		}
	}
	public static class DateTimeExtensions
	{
		public static bool BetweenDaysOfWeek(this DateTime date, int begin, int end)
		{
			int weekday = (int)date.DayOfWeek;

			return (weekday >= begin && weekday <= end);
		}
	}
}
