using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MTwo;

namespace MTwo.TestsNUnit
{
	[TestFixture]
	class Task3TestNU
	{
		[TestCase(new double[] { 7, 8, 5, 8, 7 }, 2)]
		[TestCase(new double[] { 7, 8, 5, 8, 6 }, -1)]
		[TestCase(new double[] { 7.1, 7.9, 5, 8.3, 6.7 }, 2)]
		public void FindIndexTests(double[] array, int expectedIndex)
		{
			int index = Task3.FindIndex(array);

			Assert.That(index, Is.EqualTo(expectedIndex));
		}

		[Test]
		public void LengthOfArrayExeptionTest()
		{
			double[] array = new double[] { 7.3, 8 };

			TestDelegate action = () => Task3.FindIndex(array);

			Assert.Throws<ArgumentException>(action);
		}
	}
}
