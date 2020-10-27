using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeingTestSamples
{
	// Question: You are given an array of integers. Return an array of the same size where the element at each index is the product of all 
	//	the elements in the original array except for the element at that index. 
	//	For example, an input of [1, 2, 3, 4, 5] should return [120, 60, 40, 30, 24]. You cannot use division in this problem.
	class ArrayofIntegers : IExecuter
	{
		public void Execute()
		{
			Console.WriteLine("Running Program Array of Integers..\n");

			bool IsCompleted = false;

			while (!IsCompleted)
			{
				Console.Write("Enter array of integers(with space) : ");
				var inputNum = Console.ReadLine();

				var inputArray = inputNum.Split().Where(a => int.TryParse(a, out int value)).Select(b => Convert.ToInt32(b)).ToArray();

				if (inputArray.Length > 0)
				{
					int[] outputArray = new int[inputArray.Length];

					FormattedArray(inputArray, 0, ref outputArray);

					Console.WriteLine($"Input Array : [{string.Join(",", inputArray)}]");
					Console.WriteLine($"Output Array : [{string.Join(",", outputArray)}]");

					IsCompleted = true;
				}
				else
					Console.WriteLine("Invalid Input, Try Again..");
			}
		}

		private void FormattedArray(int[] inputArray, int currentIndex, ref int[] outputArray)
		{
			if (inputArray == null || inputArray.Length == 0)
				return;

			if (currentIndex + 1 > inputArray.Length)
				return;

			var result = 1;

			for (int i = 0; i < inputArray.Length; i++)
			{
				if (i != currentIndex)
					result *= inputArray[i];
			}

			outputArray[currentIndex] = result;

			FormattedArray(inputArray, currentIndex+1, ref outputArray);
		}
	}
}
