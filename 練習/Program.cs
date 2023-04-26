using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 練習
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
				int total = end00 - start00;

				if (end00 < start00)
				{
					Console.WriteLine($"時間寫反了兄弟。");
				}
				else if (start00 < 9 && end00 > 18)
				{
					Console.WriteLine($"您的請假時數為: 8小時。哪有人請超過時間的，不過算了就這樣吧。");
				}
				else if (start00 < 9)
				{
					start00 = 9;
					total = end00 - start00;
					if ( end00 > 13)
					{
						Console.WriteLine($"您的請假時數為: {total - 1}。哪有人請超過時間的，不過算了就這樣吧。還幫你扣一小時午休><");
					}
					else { Console.WriteLine($"您的請假時數為: {total}。哪有人請超過時間的，不過算了就這樣吧。"); }
				}
				else if (end00 > 18)
				{
					end00 = 18;
					total = end00 - start00;
					if ( start00 < 12)
					{
						Console.WriteLine($"您的請假時數為: {total - 1}。哪有人請超過時間的，不過算了就這樣吧。還幫你扣一小時午休><");
					}
					else {Console.WriteLine($"您的請假時數為: {total}。哪有人請超過時間的，不過算了就這樣吧。");}
				}
				else if (start00 < 12 && end00 > 13)
				{
					total = total - 1;
					Console.WriteLine($"您的請假時數為: {total} 小時。(中午休息時間扣一小時<3)");
				}
				else
				{ Console.WriteLine($"您的請假時數為: {total} 小時。"); }
			}
			Console.ReadKey();
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

