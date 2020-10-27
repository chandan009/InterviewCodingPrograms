using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeingTestSamples
{
	class FindThePair : IExecuter
	{
		// Question : Given an array of distinct elements and a number x, find if there is a pair with product equal to x
		public void Execute()
		{
			Console.Write("Enter integer array by space : ");
			string inputArray = Console.ReadLine();
			int[] arr = inputArray.Split().Select(int.Parse).ToArray();

			bool IsCompleted = false;

			while (IsCompleted == false)
			{
				Console.Write("\nEnter element to find pair : ");
				var x = Console.ReadLine();

				if (int.TryParse(x, out int valueToFind))
				{

					if (isProduct(arr, arr.Length, valueToFind))
					{
						Console.WriteLine("Yes");
					}
					else
					{
						Console.WriteLine("No");
					}

					IsCompleted = true;
				}
				else
				{
					Console.WriteLine("Invalid Input.. Try Again");
				}
			}
		}

		// Returns true if there is a pair 
		// in arr[0..n-1] with product equal to x. 
		public static bool isProduct(int[] arr, int n, int x)
		{
			// Create an empty set and insert 
			// first element into it 
			HashSet<int> hset = new HashSet<int>();

			if (n < 2)
			{
				return false;
			}

			// Traverse remaining elements 
			for (int i = 0; i < n; i++)
			{
				// 0 case must be handles explicitly 
				// as x % 0 is undefined 
				if (arr[i] == 0)
				{
					if (x == 0)
					{
						return true;
					}
					else
					{
						continue;
					}
				}

				// x/arr[i] exists in hash, then 
				// we found a pair 
				if (x % arr[i] == 0)
				{
					if (hset.Contains(x / arr[i]))
					{
						return true;
					}

					// Insert arr[i] 
					hset.Add(arr[i]);
				}
			}
			return false;
		}		
	}
}
