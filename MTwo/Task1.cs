using System;
using System.Collections.Generic;
using System.Text;

namespace MTwo
{
	public class Task1
	{
		public static int InsertNumber(int numberSource, int numberIn, int i, int j)
		{
			numberIn = numberIn << (31 - (j - i + 1));
			numberIn = numberIn >> (31 - j - 1);
			if (numberIn < 0)
				numberIn = ~numberIn + 1;

			int res = numberIn | numberSource;

			return res;
		}
	}
}
