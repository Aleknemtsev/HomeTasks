using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MThree
{
	public class Task2
	{
		public enum Orders
		{
			Ascending,
			Descending
		}

		public enum Types
		{
			SumOfElementsOfRaw,
			MaxOfRaw,
			MinOfRaw
		}


		public static int[,] BubbleSort(int[,] array, Orders orderBy, Types typeOfSort)
		{
			int numOfRaws = array.GetUpperBound(0) + 1;
			int numOfColumns = array.GetUpperBound(1) + 1;

			int[] buffer = new int[numOfColumns];
			int[] columnOf = new int[numOfRaws];
			int[,] sortedArray = new int[numOfRaws, numOfColumns];

			switch (typeOfSort)
			{
				case Types.SumOfElementsOfRaw:

					for (int i = 0; i < columnOf.Length; i++)
					{
						buffer = SelectStringOfArray(array, i);
						columnOf[i] = SumOfArray(buffer);
					}

					break;

				case Types.MaxOfRaw:

					for (int i = 0; i < columnOf.Length; i++)
					{
						buffer = SelectStringOfArray(array, i);
						columnOf[i] = MaxOfArray(buffer);
					}

					break;

				case Types.MinOfRaw:

					for (int i = 0; i < columnOf.Length; i++)
					{
						buffer = SelectStringOfArray(array, i);
						columnOf[i] = MinOfArray(buffer);
					}

					break;

				default:
					break;
			}

			switch (orderBy)
			{
				case Orders.Ascending:

					sortedArray = AscendingSort(array, columnOf);

					break;

				case Orders.Descending:

					sortedArray = DescendingSort(array, columnOf);

					break;

				default:
					break;
			}

			return sortedArray;
		}

		private static int[] SelectStringOfArray(int[,] array, int n)
		{
			int numOfColumns = array.GetUpperBound(1) + 1;
			int[] stringOfArray = new int[numOfColumns];

			for (int i = 0; i < stringOfArray.Length; i++)
			{
				stringOfArray[i] = array[n, i];
			}

			return stringOfArray;
		}

		private static int SumOfArray(int[] array)
		{

			if (array.Length == 1)
				return array[0];

			else
			{
				int t;
				t = array[array.Length - 1];

				Array.Resize(ref array, (array.Length - 1));

				return t + SumOfArray(array);
			}
		}

		private static int MaxOfArray(int[] array)
		{

			if (array.Length == 1)
				return array[0];

			else
			{
				int t;
				t = array[array.Length - 1];

				Array.Resize(ref array, (array.Length - 1));

				if (t > MaxOfArray(array))
					return t;

				else
					return MaxOfArray(array);
			}
		}

		private static int MinOfArray(int[] array)
		{

			if (array.Length == 1)
				return array[0];

			else
			{
				int t;
				t = array[array.Length - 1];

				Array.Resize(ref array, (array.Length - 1));

				if (t < MinOfArray(array))
					return t;

				else
					return MinOfArray(array);
			}
		}

		private static int[,] AscendingSort(int [,] array, int [] columnOf)
		{
			int numOfColumns = array.GetUpperBound(1) + 1;
			int[] buffer = new int[numOfColumns];

			for (int i = 1; i < columnOf.Length; i++)
			{
				for (int j = 0; j < (columnOf.Length - i); j++)
				{
					int t;

					if(columnOf[j] > columnOf[j + 1])
					{
						t = columnOf[j];
						columnOf[j] = columnOf[j + 1];
						columnOf[j + 1] = t;

						buffer = SelectStringOfArray(array, j);

						for (int k = 0; k < buffer.Length; k++)
						{
							array[j, k] = array[j + 1, k];
							array[j + 1, k] = buffer[k];
						}
					}
				}
			}

			return array;
		}

		private static int[,] DescendingSort(int[,] array, int[] columnOf)
		{
			int numOfColumns = array.GetUpperBound(1) + 1;
			int[] buffer = new int[numOfColumns];

			for (int i = 1; i < columnOf.Length; i++)
			{
				for (int j = 0; j < (columnOf.Length - i); j++)
				{
					int t;

					if (columnOf[j] < columnOf[j + 1])
					{
						t = columnOf[j];
						columnOf[j] = columnOf[j + 1];
						columnOf[j + 1] = t;

						buffer = SelectStringOfArray(array, j);

						for (int k = 0; k < buffer.Length; k++)
						{
							array[j, k] = array[j + 1, k];
							array[j + 1, k] = buffer[k];
						}
					}
				}
			}

			return array;
		}
	}
}
