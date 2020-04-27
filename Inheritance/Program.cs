using System;

namespace Inheritance
{
	class Program
	{
		static void Main(string[] args)
		{
			ProgramConverter[] array = new ProgramConverter[3];
			array[0] = new ProgramHelper();
			array[1] = new ProgramConverter();
			array[2] = new ProgramHelper();

			string line = "A line of code";
			string lang = "CS";

			foreach (var item in array)
			{
				var o = item as ICodeChecker;

				if(o != null)
				{
					if (!o.CheckCodeSyntax(line, lang))
						Console.WriteLine(item.ConvertToCSharp(line));
				}

				else
				{
					Console.WriteLine(item.ConvertToCSharp(line));
					Console.WriteLine(item.ConvertToVB(line));
				}
			}
		}
	}
}
