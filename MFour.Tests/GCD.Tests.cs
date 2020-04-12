using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace MFour.Tests
{
	[TestFixture]
	public class GCD_Tests
	{

		[TestCase(new int[] { 17, 7 }, 1, Algorithm.Euclid)]
		[TestCase(new int[] { 5, 10 }, 5, Algorithm.Euclid)]
		[TestCase(new int[] { -5, -10, 100, 0, -45 }, 5, Algorithm.Euclid)]
		[TestCase(new int[] { 5, -10, 100, 1, -45 }, 1, Algorithm.Euclid)]
		[TestCase(new int[] { 17, 7 }, 1, Algorithm.Stein)]
		[TestCase(new int[] { 5, 10 }, 5, Algorithm.Stein)]
		[TestCase(new int[] { -5, -10, 100, 0, -45 }, 5, Algorithm.Stein)]
		[TestCase(new int[] { 5, -10, 100, 1, -45 }, 1, Algorithm.Stein)]
		[TestCase(new int[] { 5, -10, 100, 1, -45 }, 1, (Algorithm)1)]
		public void GCDTests(int[] numbers, int expected, Algorithm algorithm)
		{
			int gcd = GCD.GetGCD(algorithm, out _, numbers);

			Assert.That(gcd, Is.EqualTo(expected));
		}

		[Test]
		public void GetElapsedTime_Test()
		{
			_ = GCD.GetGCD(Algorithm.Euclid, out TimeSpan elapsedTime, 100, 200, 50000);

			Assert.That(elapsedTime.Ticks, Is.GreaterThan(0));
		}

		//[TestCase(new int[] { 17, 7 }, 1)]
		//[TestCase(new int[] { 5, 10 }, 5)]
		//[TestCase(new int[] { 5, -10, 100, -45 }, 5)]
		//public void GCD_Stein_Tests(int[] numbers, int expected)
		//{
		//	var gcdInstance = new GCD(numbers);

		//	int gcd = .GCD_Stein();

		//	Assert.That(gcd, Is.EqualTo(expected));
		//}

	}
}
