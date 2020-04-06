using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MFour
{
	public class GCD
	{
		private int[] rawOfNumbers;

		public GCD(int[] rawOfNumbers)
		{
			this.rawOfNumbers = new int[rawOfNumbers.Length];

			for (int i = 0; i < rawOfNumbers.Length; i++)
			{
				this.rawOfNumbers[i] = Math.Abs(rawOfNumbers[i]);
			}
		}

		public int GetWorstTimeEuclid()
		{
			// Теорема Ламе.
			int minVal = rawOfNumbers.Min();
			int numOfDigits = minVal.ToString().Length;

			return numOfDigits * 5;
		}

		public int GetWorstTimeStein()
		{
			int maxVal = rawOfNumbers.Max();
			int i = 0;

			while (maxVal != 0)
			{
				maxVal = maxVal >> 1;
				i++;
			}

			return i * i;
		}

		public int GCDEuclid()
		{
			if (rawOfNumbers.Length == 2)
			{

				if (rawOfNumbers[1] == 0)
					return rawOfNumbers[0];

				else
				{
					int t = rawOfNumbers[0];
					rawOfNumbers[0] = rawOfNumbers[1];
					rawOfNumbers[1] = t % rawOfNumbers[0];
					return GCDEuclid();
				}
			}

			else
			{
				int[] array = new int[2];
				array[0] = rawOfNumbers[rawOfNumbers.Length - 1];
				Array.Resize(ref rawOfNumbers, rawOfNumbers.Length - 1);
				array[1] = GCDEuclid();
				return new GCD(array).GCDEuclid();
			}
		}

		public int GCD_Stein()
		{
			if (rawOfNumbers.Length == 2)
			{
				if (rawOfNumbers[0] == 0)
					return rawOfNumbers[1];

				else if (rawOfNumbers[1] == 0)
					return rawOfNumbers[0];

				else if (rawOfNumbers[0] == rawOfNumbers[1])
					return rawOfNumbers[0];


				bool n0IsEven = ((rawOfNumbers[0] & 1) == 0);
				bool n1IsEven = ((rawOfNumbers[1] & 1) == 0);

				if (n0IsEven && n1IsEven)
				{
					rawOfNumbers[0] = rawOfNumbers[0] >> 1;
					rawOfNumbers[1] = rawOfNumbers[1] >> 1;

					return GCD_Stein() << 1;
				}

				else if (n0IsEven && !n1IsEven)
				{
					rawOfNumbers[0] = rawOfNumbers[0] >> 1;
					return GCD_Stein();
				}

				else if (!n0IsEven && n1IsEven)
				{
					rawOfNumbers[1] = rawOfNumbers[1] >> 1;
					return GCD_Stein();
				}

				else
				{
					if(rawOfNumbers[0] > rawOfNumbers[1])
					{
						rawOfNumbers[0] = (rawOfNumbers[0] - rawOfNumbers[1]) >> 1;
						return GCD_Stein();
					}

					else
					{
						rawOfNumbers[1] = (rawOfNumbers[1] - rawOfNumbers[0]) >> 1;
						return GCD_Stein();
					}
				}
			}

			else
			{
				int[] array = new int[2];
				array[0] = rawOfNumbers[rawOfNumbers.Length - 1];
				Array.Resize(ref rawOfNumbers, rawOfNumbers.Length - 1);
				array[1] = GCD_Stein();
				return new GCD(array).GCD_Stein();
			}
		}
	}
}
