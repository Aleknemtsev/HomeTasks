using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MTwo;

namespace MTwo.TestsNUnit
{
	[TestFixture]
	public class Task4TestNU
	{
		[TestCase("abbc", "dcebf", "abcdef")]
		public void ConcatTests(string string1, string string2, string expected)
		{
			string newString = Task4.Concat(string1, string2);

			Assert.That(newString, Is.EqualTo(expected));
		}

		[TestCase("01", "abc")]
		[TestCase("abc", "абв")]
		public void StringArgumentExeptionTest(string string1, string string2)
		{
			TestDelegate action = () => Task4.Concat(string1, string2);

			Assert.Throws<ArgumentException>(action);
		}
	}
}
