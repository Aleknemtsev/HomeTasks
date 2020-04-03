using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace MThree.Tests
{
	[TestFixture]
	public class Task2Tests
	{
		int[,] testedArray = new int[3, 3] { { 4, 0, 6 }, { 1, 2, 3 }, { 5, 3, 7 } };

		[Test]
		public void BubbleSortTestAscSum()
		{
			int[,] expected = new int[,] { { 1, 2, 3 }, { 4, 0, 6 }, { 5, 3, 7 } };

			int[,] res = Task2.BubbleSort(testedArray, Task2.Orders.Ascending, Task2.Types.SumOfElementsOfRaw);

			CollectionAssert.AreEqual(expected, res);
		}

		[Test]
		public void BubbleSortTestAscMax()
		{
			int[,] expected = new int[,] { { 1, 2, 3 }, { 4, 0, 6 }, { 5, 3, 7 } };

			int[,] res = Task2.BubbleSort(testedArray, Task2.Orders.Ascending, Task2.Types.MaxOfRaw);

			CollectionAssert.AreEqual(expected, res);
		}

		[Test]
		public void BubbleSortTestAscMin()
		{
			int[,] expected = new int[,] { { 4, 0, 6 }, { 1, 2, 3 }, { 5, 3, 7 } };

			int[,] res = Task2.BubbleSort(testedArray, Task2.Orders.Ascending, Task2.Types.MinOfRaw);

			CollectionAssert.AreEqual(expected, res);
		}

		[Test]
		public void BubbleSortTestDesSum()
		{
			int[,] expected = new int[,] { { 5, 3, 7 }, { 4, 0, 6 }, { 1, 2, 3 } };

			int[,] res = Task2.BubbleSort(testedArray, Task2.Orders.Descending, Task2.Types.SumOfElementsOfRaw);

			CollectionAssert.AreEqual(expected, res);
		}

		[Test]
		public void BubbleSortTestDesMax()
		{
			int[,] expected = new int[,] { { 5, 3, 7 }, { 4, 0, 6 }, { 1, 2, 3 } };

			int[,] res = Task2.BubbleSort(testedArray, Task2.Orders.Descending, Task2.Types.MaxOfRaw);

			CollectionAssert.AreEqual(expected, res);
		}

		[Test]
		public void BubbleSortTestDesMin()
		{
			int[,] expected = new int[,] { { 5, 3, 7 }, { 1, 2, 3 }, { 4, 0, 6 } };

			int[,] res = Task2.BubbleSort(testedArray, Task2.Orders.Descending, Task2.Types.MinOfRaw);

			CollectionAssert.AreEqual(expected, res);
		}

	}
}
