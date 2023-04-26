using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 子元哥
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int start = -20;
			int end = 18;

			Leave leave = new Leave(start, end);

			Console.WriteLine($"總請假時數: {leave.LeaveTotalHours}");
			Console.Read();
		}
	}

	public class Leave
	{
		private static readonly DateTime today = DateTime.Today;

		private DateTime _lunchBreakStart = new DateTime(today.Year, today.Month, today.Day, 12, 0, 0);
		private DateTime _lunchBreakEnd = new DateTime(today.Year, today.Month, today.Day, 13, 0, 0);

		private DateTime _workStart = new DateTime(today.Year, today.Month, today.Day, 9, 0, 0);
		private DateTime _workEnd = new DateTime(today.Year, today.Month, today.Day, 18, 0, 0);

		public DateTime Start { get; private set; }
		public DateTime End { get; private set; }

		private TimeSpan _duration;
		public double LeaveTotalHours => _duration.TotalHours;


		public Leave(int start, int end)
		{
			if (start >= end) throw new ArgumentException("請假開始時間點不得晚於結束時間點!");
			if (!HourHelper.IsValidHour(start)) throw new ArgumentException("開始時間錯誤!");
			if (!HourHelper.IsValidHour(end)) throw new ArgumentException("結束時間錯誤!");

			Start = new DateTime(today.Year, today.Month, today.Day, start, 0, 0);
			End = new DateTime(today.Year, today.Month, today.Day, end, 0, 0);


			ExcludeNotWorkingTime();
			CalcLeaveDuration();
			ExcludeLunchBreak();
		}

		private void CalcLeaveDuration()
		{
			_duration = End - Start;
		}
		/// <summary>
		/// 調整開始結束, 如果有需要. (排除非上班時間)
		/// </summary>
		private void ExcludeNotWorkingTime()
		{

			if (Start < _workStart)
			{
				Start = _workStart;
			}

			if (End > _workEnd)
			{
				End = _workEnd;
			}
		}

		/// <summary>
		/// 扣除午休時間
		/// </summary>
		private void ExcludeLunchBreak()
		{
			if (Start <= _lunchBreakStart && End >= _lunchBreakEnd)
			{
				_duration -= (_lunchBreakEnd - _lunchBreakStart);
			}
		}
	}

	public static class HourHelper
	{
		public static bool IsValidHour(this int hour)
		{
			return hour >= 0 && hour <= 23;
		}
	}
}
