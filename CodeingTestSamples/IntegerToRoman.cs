using System;
using System.Collections.Generic;
using System.Text;

namespace CodeingTestSamples
{
	public class IntegerToRoman : IExecuter
	{
		public void Execute()
		{
			Console.WriteLine("Running Program Integer to Roman..\n");

			bool IsCompleted = false;

			while (!IsCompleted)
			{
				Console.Write("Enter number to convert into roman : ");
				var inputNum = Console.ReadLine();

				if (int.TryParse(inputNum, out int inputNumDigit))
				{
					Console.WriteLine($"Roman value : {IntToRoman(inputNumDigit)}\n");
					IsCompleted = true;
				}
				else
					Console.WriteLine("Invalid Input, Try Again..");
			}
		}


		private string IntToRoman(int num)
		{
			// storing roman values of digits from 0-9  
			// when placed at different places 
			string[] m = { "", "M", "MM", "MMM" };
			string[] c = {"", "C", "CC", "CCC", "CD", "D",
							"DC", "DCC", "DCCC", "CM"};
			string[] x = {"", "X", "XX", "XXX", "XL", "L",
							"LX", "LXX", "LXXX", "XC"};
			string[] i = {"", "I", "II", "III", "IV", "V",
							"VI", "VII", "VIII", "IX"};

			// Converting to roman 
			string thousands = m[num / 1000];
			string hundereds = c[(num % 1000) / 100];
			string tens = x[(num % 100) / 10];
			string ones = i[num % 10];

			string ans = thousands + hundereds + tens + ones;

			return ans;
		}
	}
}
