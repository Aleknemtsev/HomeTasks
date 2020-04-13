using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Shapes;

namespace MFour.Tests
{
	[TestFixture]
	public class TriangleTests
	{

		[Test]
		public void Perimeter_Test_For_Triangle_3_4_5_Returns_12()
		{
			Shapes.Triangle triangle = new Shapes.Triangle(3, 4, 5);
			double perimeter;
			
			perimeter = triangle.Perimeter();

			Assert.That(perimeter, Is.EqualTo(12));
		}

		[Test]
		public void Area_Test_For_Triangle_3_4_5_Returns_6()
		{
			Shapes.Triangle triangle = new Shapes.Triangle(3, 4, 5);
			double area;
			
			area = triangle.Area();
			
			Assert.That(area, Is.EqualTo(6));
		}

		[Test]
		public void Triangle_Cannot_Exist_Exeption()
		{
			int a = 3;
			int b = 3;
			int c = 7;

			TestDelegate action = () => new Shapes.Triangle(a, b, c);
			
			Assert.Throws<ArgumentException>(action);
		}

		[Test]
		public void Length_Less_Or_Equal_Zero_Exeption()
		{
			int a = 3;
			int b = 3;
			int c = 0;

			TestDelegate action = () => new Shapes.Triangle(a, b, c);

			Assert.Throws<ArgumentOutOfRangeException>(action);
		}
	}
}
