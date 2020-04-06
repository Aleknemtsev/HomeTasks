using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace MFour.Tests
{
	[TestFixture]
	public class IsNullTests
	{
		[TestCase(null, true)]
		[TestCase(10, false)]
		public void IsNull_Int_Test(int? a, bool expected)
		{
			bool isNull = a.IsNull();

			Assert.That(isNull, Is.EqualTo(expected));
		}

		[TestCase(null, true)]
		[TestCase("abc", false)]
		public void IsNull_String_Test(string a, bool expected)
		{
			bool isNull = a.IsNull();

			Assert.That(isNull, Is.EqualTo(expected));
		}

	}
}
