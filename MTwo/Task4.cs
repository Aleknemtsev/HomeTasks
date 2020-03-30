using System;
using System.Collections.Generic;
using System.Text;

namespace MTwo
{
	class Task4
	{
		public static string Concat(string string1, string string2)
		{
			for (int i = 0; i < string1.Length; i++)
			{
				if (((int)string1[i] < 65) || ((int)string1[i] > 90 && (int)string1[i] < 97) || ((int)string1[i] > 122))
					throw new ArgumentException("Строки должны содержать только символы латинского алфавита.");
			}

			for (int i = 0; i < string2.Length; i++)
			{
				if (((int)string2[i] < 65) || ((int)string2[i] > 90 && (int)string2[i] < 97) || ((int)string2[i] > 122))
					throw new ArgumentException("Строки должны содержать только символы латинского алфавита.");
			}

			string newString = string.Concat(string1, string2);

			for (int i = 0; i < newString.Length; i++)
			{
				//int lI = newString.LastIndexOf(newString[i]);

				while (newString.IndexOf(newString[i]) != newString.LastIndexOf(newString[i]))
					newString = newString.Remove(newString.LastIndexOf(newString[i]), 1);
			}

			return newString;
		}
	}
}
