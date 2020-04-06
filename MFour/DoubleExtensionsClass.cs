using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MFour
{
	public static class DoubleExtensionsClass
	{

		public static string IEEE754(this double doubleNumber)
		{
			string numberIEEE = "";

			double minusZeroCheck = Math.CopySign(1, doubleNumber); // Копирование знака числа для -0

			// Сравнение NaN и NaN

			if (Double.NaN.Equals(doubleNumber))
			{
				for (int i = 0; i < 64; i++)
				{
					if (i < 13)
						numberIEEE += '1';

					else
						numberIEEE += '0';
				}
			}

			else if (doubleNumber == double.NegativeInfinity)
			{
				for (int i = 0; i < 64; i++)
				{
					if (i < 12)
						numberIEEE += '1';

					else
						numberIEEE += '0';
				}
			}

			else if (doubleNumber == double.PositiveInfinity)
			{
				for (int i = 0; i < 64; i++)
				{
					if (i < 12 && i != 0)
						numberIEEE += '1';

					else
						numberIEEE += '0';
				}
			}

			else if (doubleNumber == 0 && minusZeroCheck != -1)
			{
				for (int i = 0; i < 64; i++)
				{
					numberIEEE += "0";
				}
			}

			else if (doubleNumber == 0 && minusZeroCheck == -1)
			{
				numberIEEE += '1';

				for (int i = 1; i < 64; i++)
				{
					numberIEEE += "0";
				}
			}

			else if (doubleNumber == double.Epsilon)
			{
				for (int i = 0; i < 63; i++)
				{
					numberIEEE += '0';
				}

				numberIEEE += '1';
			}

			else if (doubleNumber == double.MaxValue)
			{
				for (int i = 0; i < 64; i++)
				{
					if (i == 0 || i == 11)
						numberIEEE += '0';

					else
						numberIEEE += '1';
				}
			}

			else if (doubleNumber == double.MinValue)
			{
				for (int i = 0; i < 64; i++)
				{
					if (i == 11)
						numberIEEE += '0';

					else
						numberIEEE += '1';
				}
			}

			else
			{
				if (doubleNumber < 0)
					numberIEEE += '1';

				else
					numberIEEE += '0';

				string mantiss = ToBin(Math.Abs(doubleNumber));

				int exp = 1023;
				int indexOf1 = mantiss.IndexOf('1');

				if (indexOf1 == 0) // Алгоритм преобразования чисел, которые по модулю >= 17
				{
					int commaPos = mantiss.IndexOf(',');

					if (commaPos != -1) // Если число содержит дробную часть.
						mantiss = mantiss.Remove(commaPos, 1);

					else               // Если число целое.
						commaPos = mantiss.Length;

					mantiss = mantiss.Remove(0, 1);

					exp = exp + commaPos - 1;
				}

				else // Преобразование чисел, которые по модулю < 1.
				{
					mantiss = mantiss.Remove(0, indexOf1 + 1);

					exp = exp - (indexOf1 - 1);
				}

				string expBin = ToBin(exp);

				for (int i = expBin.Length; i < 11; i++)
				{
					expBin = String.Concat("0", expBin); // Добавление ведущих нулей в экспоненту до 11 бит.
				}

				numberIEEE = numberIEEE + expBin + mantiss;

				for (int i = numberIEEE.Length; i < 64; i++)
				{
					numberIEEE += '0'; // Добавление нулей в мантиссу до 52 бит.
				}
			}

			return numberIEEE;
		}

		public static string ToBin(double doubleNumber)
		{
			string numberString = doubleNumber.ToString();
			string numberBin = "";

			if (numberString.Contains(',') == false)
			{
				long intNumber = (long)doubleNumber;

				do
				{
					long remainder = intNumber % 2;
					numberBin += remainder.ToString();
					intNumber /= 2;
				}
				while (intNumber != 0);

				numberBin = StringReverse(numberBin);
			}

			else
			{
				int commaPos = numberString.IndexOf(',');
				int integerPart = int.Parse(numberString.Substring(0, commaPos));

				string integer = ToBin(integerPart);
				numberBin = String.Concat(integer, ',');

				string fraction = String.Concat("0,", numberString.Substring(commaPos + 1));
				double fractionDouble = Double.Parse(fraction);

				int accuracy = 52 - (integer.Length - 1);

				for (int i = 0; i < accuracy; i++)
				{
					fractionDouble *= 2;
					char digit = Char.Parse(fractionDouble.ToString().Substring(0, 1));
					numberBin += digit;

					if (digit == '1')
						fractionDouble -= 1;

					if (fractionDouble == 0)
						break;
				}
			}

			return numberBin;
		}

		public static string StringReverse(string number)
		{
			char[] array = number.ToArray();
			Array.Reverse(array);

			return new String(array);
		}
	}
}
