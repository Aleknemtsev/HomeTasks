using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MThree
{
	public class Task3
	{
		public static string ToBin(int number)
		{
			string numberBin = "";

			do
			{
				int remainder = number % 2;
				numberBin += remainder.ToString();
				number /= 2;
			}
			while (number != 0);

			numberBin = StringReverse(numberBin);

			return numberBin;
		}

		private static string StringReverse(string number)
		{
			char[] array = number.ToArray();
			Array.Reverse(array);

			return new String(array);
		}

	}
}
