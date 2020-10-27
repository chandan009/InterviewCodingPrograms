using System;
using System.Collections.Generic;
using System.Text;

namespace CodeingTestSamples
{
	class FlattenTheArray : IExecuter
	{
		List<int> output = new List<int>();
		public void Execute()
		{
			List<int> OutputArray = new List<int>();

			Console.WriteLine("Running Program Flatten the Array..\n");

			var inputArray = new int[][,]
			{
					new int[, ] {{ 6, 4, 7 }, { 9, 5, 4 }},
					new int[, ] {{ 2, 4, 8 }, { 2, 2, 7 }},
					new int[, ] {{ 9, 0, 7, 1 }, { 9, 3, 1, 8}}
			};

			foreach (var item in inputArray)
			{
				FlattenArray(item);
			}

			Console.WriteLine($"Output : [{string.Join(", ", output)}]");
		}

		private void FlattenArray(int[,] inputArray)
		{
			for (int i = 0; i < inputArray.GetLength(0); i++)
			{
				for (int j = 0; j < inputArray.GetLength(1); j++)
				{
					output.Add(inputArray[i,j]);
				}
			}
		}
	}
}
