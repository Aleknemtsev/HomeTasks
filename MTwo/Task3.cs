using System;
using System.Collections.Generic;
using System.Text;

namespace MTwo
{
	class Task3
	{
		public static int FindIndex (double[] arr)
		{
			if (arr.Length < 3)
				throw new ArgumentException("Length of arrray must be bigger than 3");
			else
			{
				int arrIndex = -1;

				for (int i = 1; i < arr.Length - 2; i++)
				{
					double s1 = 0;
					double s2 = 0;

					for (int k = 0; k < i; k++)
					{
						s1 += arr[k];
					}

					for (int k = i + 1; k < arr.Length; k++)
					{
						s2 += arr[k];
					}

					if (s1 == s2)
					{
						arrIndex = i;
						break;
					}
				}

				return arrIndex;
			}
		}

		
	}
}
