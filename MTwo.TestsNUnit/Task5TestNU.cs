using System;
using System.Collections.Generic;
using System.Text;
using MTwo;
using NUnit.Framework;

namespace MTwo.TestsNUnit
{
	[TestFixture]
	public class Task5TestNU
	{
		public Task5 findNBI;

		[Test]
		public void QuickSortTest()
		{
			string stringToSort = "adfirebjzl5463121";
			string expected = "1123456abdefijlrz";

			string sorted = Task5.QuickSort(stringToSort);

			Assert.That(sorted, Is.EqualTo(expected));
		}

		[SetUp]
		public void Setup()
		{
			findNBI = new Task5();
		}

		[TearDown]
		public void Teardown()
		{
			findNBI = null;
		}

		[TestCase(12, 21)]
		[TestCase(513, 531)]
		[TestCase(2017, 2071)]
		[TestCase(414, 441)]
		[TestCase(144, 414)]
		[TestCase(1234321, 1241233)]
		[TestCase(1234126, 1234162)]
		[TestCase(3456432, 3462345)]
		[TestCase(10, -1)]
		[TestCase(20, -1)]
		public void FindNextBiggerIntergerTest(int num, int expected)
		{
			int nBI = findNBI.FindNextBiggerInteger(num);

			Assert.That(nBI, Is.EqualTo(expected));
		}

		[Test]
		public void ElapsedTimeTest()
		{
			int num = 2017;

			int nBI = findNBI.FindNextBiggerInteger(num);
			long eT = findNBI.ElapsedTime;

			Assert.That(eT, Is.GreaterThanOrEqualTo(0));
		}
	}
}
