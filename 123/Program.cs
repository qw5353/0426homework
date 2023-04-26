using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<string> strings = new List<string>() { "apple", "banana", "cherry", "date" };
			string longestString = strings.OrderByDescending(x => x.Length).First();
			Console.WriteLine("最長字符串的長度為 {0}，內容為 {1}", longestString.Length, longestString);//46454646545646464
		}
	}
}
