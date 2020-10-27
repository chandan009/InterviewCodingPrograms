using System;
using System.Collections.Generic;
using System.Text;

namespace CodeingTestSamples
{
	public class VirusInfaction : IExecuter
	{
		public void Execute()
		{
			VirusInfactionProgram();
		}

		public static void VirusInfactionProgram()
		{
			Console.WriteLine("Started VirusInfaction Program...\n");

			Console.Write("Enter No of Test Cases : ");
			int testcases = Convert.ToInt32(Console.ReadLine());

			for (int testcount = 0; testcount < testcases; testcount++)
			{
				bool IsAdjusentCellsInfacted = true;
				int noOfDays = 0;

				Console.Write($"Enter number of rows and columns for test {testcount + 1} : ");
				string[] inputs = Console.ReadLine().Split();

				int rows = Convert.ToInt32(inputs[0]);
				int columns = Convert.ToInt32(inputs[1]);

				string[,] TransmissionTable = new string[rows, columns];

				Console.Write("Enter Row values : ");
				for (int i = 0; i < rows; i++)
				{
					char[] values = Console.ReadLine().ToCharArray();

					for (int j = 0; j < columns; j++)
					{
						TransmissionTable[i, j] = values[j].ToString();
					}
				}

				if (IsHealthyCellsFound(ref TransmissionTable))
				{

					while (IsAdjusentCellsInfacted)
					{
						IsAdjusentCellsInfacted = false;
						List<string> InfactedCellsToday = new List<string>();

						noOfDays++;

						for (int i = 0; i < rows; i++)
						{
							for (int j = 0; j < columns; j++)
							{
								if (!InfactedCellsToday.Contains(i + "," + j))
								{
									var result = InfactAdjusentCells(ref TransmissionTable, ref InfactedCellsToday, i, j);

									if (result)
										IsAdjusentCellsInfacted = result;
								}
							}
						}

						if (!IsHealthyCellsFound(ref TransmissionTable))
							break;
					}

					if (IsHealthyCellsFound(ref TransmissionTable))
						Console.WriteLine("Not possible to infact complete cells :: -1");
					else
						Console.WriteLine("Number of days for complete cell infaction :: " + noOfDays);
				}
				else
					Console.WriteLine("No healthy cells to infact :: 0");
			}
		}

		private static bool IsHealthyCellsFound(ref string[,] TransmissionTable)
		{
			bool IsHealthyCellsFound = false;
			for (int i = 0; i < TransmissionTable.GetLength(0); i++)
			{
				for (int j = 0; j < TransmissionTable.GetLength(1); j++)
				{
					if (TransmissionTable[i, j] == "1" || TransmissionTable[i, j] == "2")
					{
						IsHealthyCellsFound = true;
						break;
					}
				}
			}

			return IsHealthyCellsFound;
		}

		private static bool InfactAdjusentCells(ref string[,] TransmissionTable, ref List<string> InfactedCellsToday, int row, int column)
		{
			var currentCellStatus = TransmissionTable[row, column];

			if (currentCellStatus != "0")
				return false;

			if (InfactedCellsToday == null)
				InfactedCellsToday = new List<string>();

			bool isAdjusentCellsInfacted = false;

			for (int currentRow = row - 1; currentRow <= row + 1; currentRow++)
			{
				if (currentRow < 0 || currentRow >= TransmissionTable.GetLength(0))
					continue;

				for (int currentCol = column - 1; currentCol <= column + 1; currentCol++)
				{
					if (currentCol < 0 || currentCol >= TransmissionTable.GetLength(1) || (currentRow != row && currentCol != column) || (currentRow == row && currentCol == column))
						continue;

					string value = TransmissionTable[currentRow, currentCol];

					if (value == "0" || value == "_" || InfactedCellsToday.Contains(currentRow + "," + currentCol))
						continue;

					if (value == "1")
						TransmissionTable[currentRow, currentCol] = "0";
					else if (value == "2")
						TransmissionTable[currentRow, currentCol] = "1";

					InfactedCellsToday.Add(currentRow + "," + currentCol);

					isAdjusentCellsInfacted = true;
				}
			}

			return isAdjusentCellsInfacted;
		}		
	}
}
