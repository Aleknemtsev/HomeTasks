using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MTwo
{
	public class Task5
	{
		public long ElapsedTime { get; private set; } = 0;

		public int FindNextBiggerInteger(int num)
		{
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();

			int nBI = -1;
			string nBIStr = "";

			string numString = num.ToString();

			for (int i = numString.Length - 1; i > 0; i--)
			{
				if(numString[i] > numString[i - 1])
				{
					numString = string.Concat(numString.Substring(0, (i - 1)), numString[i], numString[i - 1], numString.Substring(i + 1));

					if (i == (numString.Length - 1))
						nBIStr = numString;
					else
						nBIStr = String.Concat(numString.Substring(0, (i)), QuickSort(numString.Substring(i)));

					nBI = int.Parse(nBIStr);

					break;
				}
			}

			stopWatch.Stop();
			ElapsedTime = stopWatch.ElapsedMilliseconds;

			return nBI;
		}

		public static string QuickSort (string num)
		{
			if (num.Length < 2)
				return num;
			else
			{
				Random rand = new Random();
				int index = rand.Next(0, num.Length);
				char supElem = num[index];
				string less = "";
				string greater = "";
				string newNum = "";

				for (int i = 0; i < num.Length; i++)
				{
					if (i == index)
						continue;
					else if (num[i] <= supElem)
						less += num[i];
					else
						greater += num[i];
				}

				newNum = string.Concat(QuickSort(less), supElem, QuickSort(greater));

				return newNum;
			}
		}
	}
}
