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
			List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
			List<int> result = numbers.Select(x => x + 1).OrderByDescending(x => x).Take(3).ToList();
			foreach (int num in result)
			{
				Console.WriteLine(num);
			}
		}
	}
}
