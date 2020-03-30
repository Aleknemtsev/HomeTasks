using System;
using System.Collections.Generic;
using System.Text;

namespace MTwo
{
	class Task6
	{
		public static int[] FilterDigit (int[] arr, int digit)
		{
			string[] arrStr = new string[arr.Length];

			for (int i = 0; i < arr.Length; i++)
			{
				arrStr[i] = arr[i].ToString();
			}

			var arrF = new List<int>();

			foreach (string item in arrStr)
			{
				if (item.Contains(digit.ToString()))
				{
					arrF.Add(int.Parse(item));
				}
			}

			return arrF.ToArray();
		}
	}
}
