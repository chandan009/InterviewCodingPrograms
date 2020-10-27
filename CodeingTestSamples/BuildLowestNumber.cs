using System;
using System.Collections.Generic;
using System.Text;

namespace CodeingTestSamples
{
	public class BuildLowestNumber : IExecuter
	{
		// Question : Given a string ‘str’ of digits and an integer ‘n’, 
		// build the lowest possible number by removing ‘n’ digits from the string and not changing the order of input digits.
		public void Execute()
		{
			Console.WriteLine("Executing program BuildLowestNumber\n");

			bool IsCompleted = false;
			string resultString = "";

			while (!IsCompleted)
			{
				Console.Write("Enter the string of digits : ");
				var inputString = Console.ReadLine();

				Console.Write("Enter the number of digits to remove : ");
				var inputNum = Console.ReadLine();

				if (double.TryParse(inputString, out double inputDigits) && int.TryParse(inputNum, out int inputNumDigit))
				{
					BuildLowestNumberRec(ref resultString, inputString.ToString(), inputNumDigit);
					
					Console.WriteLine("Lowest possible number : " + resultString);

					IsCompleted = true;
				}
				else
					Console.WriteLine("Invalid Input, Try Again..");
			}
		}

		private void BuildLowestNumberRec(ref string resultString, string inputStr, int inputNumDigit)
		{
			// If there are 0 characters to remove from str,  
			// append everything to result  
			if (inputNumDigit == 0)
			{
				resultString += inputStr;
				return;
			}

			// If there are more characters to  
			// remove than string length,  
			// then append nothing to result  
			if (inputStr.Length <= inputNumDigit)
				return;

			// Find the smallest character among  
			// first (n+1) characters of str.  
			int minIndex = 0;

			for (int i = 1; i <= inputNumDigit; i++)
				if (inputStr[i] < inputStr[minIndex])
					minIndex = i;

			// Append the smallest character to result  
			resultString += inputStr[minIndex];

			// substring starting from  
			// minIndex+1 to str.length() - 1.  
			String new_str = inputStr.Substring(minIndex + 1);

			// Recur for the above substring  
			// and n equals to n-minIndex  
			BuildLowestNumberRec(ref resultString, new_str, inputNumDigit - minIndex);
		}
	}
}
