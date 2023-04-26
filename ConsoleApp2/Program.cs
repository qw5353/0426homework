using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var sam = new Student("Sam", 80, 100, 90, 95);
			Console.WriteLine(sam.Imformation());

		}
		public class Student
		{
			public string Name { get; set; }
			public int EnglishScore { get; set; }
			public int MathScore { get; set; }
			public int ChineseScore { get; set; }
			public int ScinceScore { get; set; }

			public Student(string name, int engScore, int matScore, int chnScore, int sciScore)
			{
				Name = name;
				EnglishScore = engScore;
				MathScore = matScore;
				ChineseScore = chnScore;
				ScinceScore = sciScore;
			}
			public string Imformation()
			{
				return $"姓名{Name}英文成績:{EnglishScore}分\n\r數學成績:{MathScore}分\n\r國文成績:{ChineseScore}分\n\r自然成績:{ScinceScore}分\n\r總成績:{CalcSum()}\n\r平均分數{CalcAverage()}\n\r最高分成績是{MaxScore()}\n\r最低分成績是{MinScore()}\n\r";
			}
			public int CalcSum() => (EnglishScore + MathScore + ChineseScore + ScinceScore);

			public int CalcAverage() => CalcSum() / 4;
			public int MaxScore()
			{
				int max = Math.Max(Math.Max(EnglishScore, MathScore), Math.Max(ChineseScore, ScinceScore));
				return max;
			}
			public int MinScore()
			{
				int min = Math.Min(Math.Min(EnglishScore, MathScore), Math.Min(ChineseScore, ScinceScore));
				return min;
			}
		}
	}
}
