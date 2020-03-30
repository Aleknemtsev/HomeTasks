using System;
using System.Collections.Generic;
using System.Text;

namespace MTwo
{
	class Task2
	{
		public static int ArrayMax (int[] array)
		{
			
			if (array.Length == 2)
			{
				if (array[0] > array[1])
					return array[0];
				else
					return array[1];
			}

			else

			{
				int t;
				t = array[array.Length - 1];
				Array.Resize(ref array, (array.Length - 1));
				if (t > ArrayMax(array))
					return t;
				else
					return ArrayMax(array);
			}
		}
	}
}
