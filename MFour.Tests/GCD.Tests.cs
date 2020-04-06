using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace MFour.Tests
{
	[TestFixture]
	public class GCD_Tests
	{

		[TestCase(new int[] { 17, 7 }, 1)]
		[TestCase(new int[] { 5, 10 }, 5)]
		[TestCase(new int[] { 5, -10, 100, -45 }, 5)]
		public void GCDEuclid_Tests(int[] numbers, int expected)
		{
			var gcdInstance = new GCD(numbers);

			int gcd = gcdInstance.GCDEuclid();

			Assert.That(gcd, Is.EqualTo(expected));
		}

		[Test]
		public void GetWorstTimeEuclid_Test()
		{
			int[] numbers = { -100, 200, 50000 };
			int expected = 15;

			var gcdInstance = new GCD(numbers);
			int time = gcdInstance.GetWorstTimeEuclid();

			Assert.That(time, Is.EqualTo(expected));
		}

		[TestCase(new int[] { 17, 7 }, 1)]
		[TestCase(new int[] { 5, 10 }, 5)]
		[TestCase(new int[] { 5, -10, 100, -45 }, 5)]
		public void GCD_Stein_Tests(int[] numbers, int expected)
		{
			var gcdInstance = new GCD(numbers);

			int gcd = gcdInstance.GCD_Stein();

			Assert.That(gcd, Is.EqualTo(expected));
		}

		[Test]
		public void GetWorstTimeStein_Test()
		{
			int[] numbers = { -100, 200, 50000 };
			int expected = 256;

			var gcdInstance = new GCD(numbers);
			int time = gcdInstance.GetWorstTimeStein();

			Assert.That(time, Is.EqualTo(expected));
		}
	}
}
