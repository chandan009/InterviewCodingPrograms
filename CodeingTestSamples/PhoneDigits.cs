using System;
using System.Collections.Generic;
using System.Text;

namespace CodeingTestSamples
{
	public class PhoneDigits : IExecuter
	{
		// Question : Given phone digits, print all possible words that can be formed from them.
		public void Execute()
		{
			Console.WriteLine("Running Program print all possible words from Phone Digits..\n");

			bool IsCompleted = false;

			while (!IsCompleted)
			{
				Console.Write("Enter Phone Digits : ");
				var inputNum = Console.ReadLine();

				if (int.TryParse(inputNum, out int inputNumDigit))
				{
					if (inputNumDigit.ToString().Length != 0)
						Expand("", inputNumDigit.ToString());

					Console.WriteLine($"Output :: {sb.ToString()}");

					IsCompleted = true;
				}
				else
					Console.WriteLine("Invalid Input, Try Again..");
			}
		}

		StringBuilder sb = new StringBuilder();
		Dictionary<string, string> phone = new Dictionary<string, string>()
		{
			{"2", "abc" },
			{"3", "def"},
			{"4", "ghi" },
			{"5", "jkl"},
			{"6", "mno"},
			{"7", "pqrs"},
			{"8", "tuv"},
			{"9", "wxyz"}
		};

		public void Expand(string combination, string next_digits)
		{
			// if there is no more digits to check
			if (next_digits.Length == 0)
			{
				// the combination is done
				sb.Append(" " + combination);
			}
			// if there are still digits to check
			else
			{
				// iterate over all letters which map 
				// the next available digit
				string digit = next_digits[0].ToString();
				
				foreach(char letter in phone[digit])				
					Expand(combination + letter, next_digits.Substring(1));
			}
		}

	}
}
