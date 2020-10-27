using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeingTestSamples
{
	class Program
	{
		static void Main(string[] args)
		{			
			Dictionary<int, Type> programList = new Dictionary<int, Type>()
			{
				{ 1, typeof(VirusInfaction) },
				{ 2, typeof(FindThePair) },
				{ 3, typeof(BuildLowestNumber) },
				{ 4, typeof(IntegerToRoman) },
				{ 5, typeof(ReverseLinkedList) },
				{ 6, typeof(PhoneDigits) },
				{ 7, typeof(ArrayofIntegers) },
				{ 8, typeof(TraverseLinkedList)},
				{ 9, typeof(FlattenTheArray)},
				{ 10, typeof(StringOperations)},
				{ 11, typeof(BalancedParentheses)},
				{ 12, typeof(TreeSort)}
			};

			foreach (var item in programList)
			{
				Console.WriteLine($"{item.Key} - {item.Value.Name}");
			}
			Console.WriteLine("0 - Exit\n");

			while (true)
			{
				Console.Write("\nSelect a program to execute :");

				int input = -1;
				var inputchar = Console.ReadLine();

				if (int.TryParse(inputchar, out input))
				{
					if (programList.ContainsKey(input))
					{
						var type = programList[input];

						if (type != null)
						{
							object testInstance = Activator.CreateInstance(type);

							MethodInfo toInvoke = type.GetMethod("Execute");
							toInvoke.Invoke(testInstance, null);
						}
						else
							Console.WriteLine("Null Type to invoke..\n");
					}
					else if (input == 0)
						break;
					else
						Console.WriteLine("Invalid Input, Try Again..\n");
				}
				else
					Console.WriteLine("Invalid Input, Try Again..\n");
			}
		}
	}
}

