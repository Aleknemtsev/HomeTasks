using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MTwo;

namespace MTwo.Tests
{
	[TestFixture]
	public class Task1NU
	{
		[TestCase(15, 15, 0, 0, 15)]
		[TestCase(8, 15, 0, 0, 9)]
		[TestCase(8, 15, 3, 8, 120)]
		public void InsertNumberTest1(int numberIn, int numberSource, int i, int j, int expected)
		{
			int res;

			res = Task1.InsertNumber(numberIn, numberSource, i, j);

			Assert.That(res, Is.EqualTo(expected));
		}

	}
}
