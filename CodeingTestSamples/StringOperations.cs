using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeingTestSamples
{
	public class StringOperations : IExecuter
	{
		public void Execute()
		{
			while (true)
			{
				Console.WriteLine("Select an option - \n 1. Search a string in a big file/string\n 2. Count occurrence of a word in a file/string\n 3. Exit");

				string inputstring =  Console.ReadLine();

				int input = 0;
				if (!int.TryParse(inputstring, out input))
				{
					Console.WriteLine("\nInvalid Input! Try Again");
					continue;
				}

				switch (input)
				{
					case 1:
						SearchStringinBigFile();
						break;
					case 2:
						CountStringinBigFile();
						break;
					case 3:
						return;
					default:
						break;
				}
			}
		}

		private void SearchStringinBigFile()
		{
			Console.Write("Enter file text : ");
			var inputFile = Console.ReadLine() ?? "";

			Console.Write("\nEnter word to search : ");
			var keyword = Console.ReadLine() ?? "";

			MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(inputFile));

			int linecounter = 0;
			string lineContent = string.Empty;
			int keywordIndex = -1;

			using (var sr = new StreamReader(stream))
			{
				while (!sr.EndOfStream)
				{
					linecounter++;

					lineContent = sr.ReadLine();
					if (String.IsNullOrEmpty(lineContent)) continue;

					keywordIndex = lineContent.IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase);

					if (keywordIndex >= 0)
					{
						Console.WriteLine($"Found in line number {linecounter}, index {keywordIndex}");
					}
				}
			}
		}

		private void CountStringinBigFile()
		{
			Console.Write("Enter file text : ");
			var inputFile = Console.ReadLine() ?? "";

			Console.Write("\nEnter word to search : ");
			var keyword = Console.ReadLine() ?? "";

			var keywordLength = keyword.Length;
			var inputLength = inputFile.Length;

			var newfile = inputFile.Replace(keyword, string.Empty, StringComparison.OrdinalIgnoreCase);

			if (inputLength == newfile.Length)
			{
				Console.WriteLine($"{keyword} not found in file!!");
				return;
			}

			var keywordCountInFile = (inputLength - newfile.Length) / keywordLength;

			Console.WriteLine($"{keyword} found {keywordCountInFile} times in file!!");
		}
	}
}
