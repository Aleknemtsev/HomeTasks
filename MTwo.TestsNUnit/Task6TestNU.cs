using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;

namespace MTwo.TestsNUnit
{
	[TestFixture]
	class Task6TestNU
	{
		[Test]
		public void FindDigitTest()
		{
			string[] numbersStr = File.ReadAllLines(@"E:\Projects\HomeTasks\TestData.txt");
			string[] expectedStr = File.ReadAllLines(@"E:\Projects\HomeTasks\Expected.txt");
			int[] numbers = new int[numbersStr.Length];
			int[] expected = new int[expectedStr.Length];

			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = int.Parse(numbersStr[i]);
			}

			for (int i = 0; i < expected.Length; i++)
			{
				expected[i] = int.Parse(expectedStr[i]);
			}

			int[] res = Task6.FilterDigit(numbers, numbers[0]);

			CollectionAssert.AreEqual(res, expected);
		}
	}
}
