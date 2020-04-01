using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MTwo;

namespace MTwo.TestsNUnit
{
	[TestFixture]
	public class Task2TestNU
	{
		[TestCase(new int[] { 5 }, 5)]
		[TestCase(new int[] { 5, 1, 6, -8, 7, 0 }, 7)]
		[TestCase(new int[] { -5, -1, -6, -8, -7, }, -1)]
		public void ArrayMaxTests(int[] array, int expectedMax)
		{
			int res = Task2.ArrayMax(array);

			Assert.That(res, Is.EqualTo(expectedMax));
		}
	}
}
