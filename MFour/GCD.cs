using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MFour
{
	public enum Algorithm
	{
		Euclid = 1,
		Stein = 2
	}

	public class GCD
	{
		public static int GetGCD(Algorithm algorithm, out TimeSpan elapsedTime, params int[] rawOfNumbers)
		{
			for(int i = 0; i < rawOfNumbers.Length; i++)
				rawOfNumbers[i] = Math.Abs(rawOfNumbers[i]);

			int gcd = 0;

			Stopwatch stopWatch = new Stopwatch();

			switch (algorithm)
			{
				case Algorithm.Euclid:

					stopWatch.Start();
					gcd = GCD_Euclid(rawOfNumbers);
					stopWatch.Stop();

					break;
				case Algorithm.Stein:

					stopWatch.Start();
					gcd = GCD_Stein(rawOfNumbers);
					stopWatch.Stop();

					break;
				default:
					break;
			}

			elapsedTime = stopWatch.Elapsed;

			return gcd;
		}


		private static int GCD_Euclid(params int[] rawOfNumbers)
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
					return GCD_Euclid(rawOfNumbers);
				}
			}

			else
			{
				int number1, number2;

				number1 = rawOfNumbers[rawOfNumbers.Length - 1];
				Array.Resize(ref rawOfNumbers, rawOfNumbers.Length - 1);
				number2 = GCD_Euclid(rawOfNumbers);
				return GCD_Euclid(number1, number2);
			}
		}

		private static int GCD_Stein(params int[] rawOfNumbers)
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

					return GCD_Stein(rawOfNumbers) << 1;
				}

				else if (n0IsEven && !n1IsEven)
				{
					rawOfNumbers[0] = rawOfNumbers[0] >> 1;
					return GCD_Stein(rawOfNumbers);
				}

				else if (!n0IsEven && n1IsEven)
				{
					rawOfNumbers[1] = rawOfNumbers[1] >> 1;
					return GCD_Stein(rawOfNumbers);
				}

				else
				{
					if(rawOfNumbers[0] > rawOfNumbers[1])
					{
						rawOfNumbers[0] = (rawOfNumbers[0] - rawOfNumbers[1]) >> 1;
						return GCD_Stein(rawOfNumbers);
					}

					else
					{
						rawOfNumbers[1] = (rawOfNumbers[1] - rawOfNumbers[0]) >> 1;
						return GCD_Stein(rawOfNumbers);
					}
				}
			}

			else
			{
				int number1, number2;

				number1 = rawOfNumbers[rawOfNumbers.Length - 1];
				Array.Resize(ref rawOfNumbers, rawOfNumbers.Length - 1);
				number2 = GCD_Stein(rawOfNumbers);
				return GCD_Stein(number1, number2);
			}
		}
	}
}
