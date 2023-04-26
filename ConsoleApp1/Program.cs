using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double[] scores = { 78, 56, 90 };
			Student josh = new Student("Josh.Wang", 18, scores);
			Console.WriteLine($"HI,{josh.Name}  您的年紀是:{josh.Age}   國英數成績分別是:{string.Join(", ", josh.Subjects)}");
			josh.TotalScore();
			josh.Average();
			josh.Best();
			josh.Low();
			Console.ReadKey();
		}
	}

	public class Student
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public double[] Subjects { get; set; }

		public Student(string name, int age, double[] subjects)
		{
			Name = name;
			Age = age;
			Subjects = subjects;
		}

		public void TotalScore()
		{
			double total = Subjects.Sum();
			Console.WriteLine("您的總分是:" + total);
		}

		public void Average()
		{
			double average = Subjects.Average();
			Console.WriteLine("您的平均成績是:" + average);
			Pass(average);
		}

		public void Pass(double sum)
		{
			if (sum >= 60) Console.WriteLine("此次測驗及格。");
			else Console.WriteLine("此次測驗不及格。");
		}

		public void Best()
		{
			double bestScore = Subjects.Max();
			int bestIndex = Array.IndexOf(Subjects, bestScore);
			string bestSubject = GetSubjectName(bestIndex);
			Console.WriteLine($"最高分的科目是: {bestSubject}，分數為: {bestScore}");
		}

		public void Low()
		{
			double lowScore = Subjects.Min();
			int lowIndex = Array.IndexOf(Subjects, lowScore);
			string lowSubject = GetSubjectName(lowIndex);
			Console.WriteLine($"最低分的科目是: {lowSubject}，分數為: {lowScore}");
		}

		private string GetSubjectName(int index)
		{
			string[] subjectNames = { "國文", "英文", "數學" };
			return subjectNames[index];
		}
	}
}
