using NUnit.Framework;
using System;

namespace Vectors.Tests
{
	[TestFixture]
	public class VectorTests
	{
		private Vector vectorA;
		private Vector vectorB;

		[SetUp]
		public void Setup()
		{
			vectorA = new Vector(3, 4, 12);
			vectorB = new Vector(3, 4, 4);
		}

		[TearDown]
		public void Teardown()
		{
			vectorA = null;
			vectorB = null;
		}

		[Test]
		public void VectorA_Length_Returns_13_Test()
		{
			Assert.That(vectorA.GetLength(), Is.EqualTo(13));
		}

		[Test]
		public void Operator_Equality_Test()
		{
			Vector vectorC = vectorA;

			bool isEqual = (vectorA == vectorC);

			Assert.That(isEqual, Is.True);
		}

		[Test]
		public void Operator_Not_Equal_Test()
		{
			bool notEqual = (vectorA != vectorB);

			Assert.That(notEqual, Is.True);
		}

		[Test]
		public void Operator_Plus_Overload_Returns_Vector_6_8_16_Test()
		{
			Vector expected = new Vector(6, 8, 16);

			Vector sum = vectorA + vectorB;

			Assert.That(sum, Is.EqualTo(expected));
		}

		[Test]
		public void Operator_Minus_Overload_Returns_0_0_8_Test()
		{
			Vector expected = new Vector(0, 0, 8);

			Vector difference = vectorA - vectorB;

			Assert.That(difference, Is.EqualTo(expected));
		}

		[Test]
		public void VectorA_Multiply_2_Returns_Vector_6_8_24_Test()
		{
			Vector expected = new Vector(6, 8, 24);
			
			Vector multiplication = vectorA.ScalarMultiplication(2);

			Assert.That(multiplication, Is.EqualTo(expected));
		}

		[Test]
		public void GetDotProduct_A_B_Returns_73_Test()
		{
			double expected = 73;

			double dotProduct = Vector.GetDotProduct(vectorA, vectorB);

			Assert.That(dotProduct, Is.EqualTo(expected));
		}

		[Test]
		public void AreOrthogonal_Test()
		{
			Vector vectorC = new Vector(3, 0, 4);
			Vector vectorD = new Vector(0, 5, 0);

			bool areOrthogonal = Vector.AreOrthogonal(vectorC, vectorD);
			
			Assert.That(areOrthogonal, Is.True);
		}

		[Test]
		public void GetAngle_VectorC_VectorD_Returns_PId2_Test()
		{
			Vector vectorC = new Vector(3, 0, 4);
			Vector vectorD = new Vector(0, 5, 0);

			double angle = Vector.GetAngle(vectorC, vectorD);
			double expected = Math.PI / 2;
			
			Assert.That(angle, Is.EqualTo(expected).Within(0.01));
		}

		[Test]
		public void ScalarProjection_B_In_Direction_A_Returns_5_61_Test()
		{
			double projection = vectorB.ScalarProjection(vectorA);
			double expected = 5.62;
			
			Assert.That(projection, Is.EqualTo(expected).Within(0.01));
		}

		[Test]
		public void Index_Test()
		{
			Assert.That(vectorA[2], Is.EqualTo(12));
		}

		[Test]
		public void Foreach_Sum_Test()
		{
			double sum = 0;
			double expected = 19;

			foreach (double item in vectorA)
			{
				sum += item;
			}

			Assert.That(sum, Is.EqualTo(expected));
		}

		[Test]
		public void CTOR_For_Array_Test()
		{
			double[] array = { 3, 4, 12 };

			Vector vector = new Vector(array);

			Assert.That(vector, Is.EqualTo(vectorA));
		}

		[Test]
		public void CTOR_For_Array_Exeption_Test()
		{
			double[] array = { 3, 4 };

			TestDelegate action = () => new Vector(array);

			Assert.Throws<ArgumentOutOfRangeException>(action);
		}

		[Test]
		public void CTOR_For_Vector_Test()
		{
			Vector vector = new Vector(vectorA);

			Assert.That(vector, Is.EqualTo(vectorA));
		}

		[Test]
		public void GetVectorProduct_A_B_Returns_minus32_24_0()
		{
			Vector vectorProduct = Vector.GetVectorProduct(vectorA, vectorB);
			Vector expected = new Vector(-32, 24, 0);

			Assert.That(vectorProduct, Is.EqualTo(expected));
		}

		[Test]
		public void AreCollinear_A_B_Returns_False_Test()
		{
			bool areCollinear = Vector.AreCollinear(vectorA, vectorB);

			Assert.That(areCollinear, Is.False);
		}

		[Test]
		public void AreCollinear_Returns_True()
		{
			Vector vectorC = new Vector(1, 2, 2);
			Vector vectorD = new Vector(2, 4, 4);

			bool areCollinear = Vector.AreCollinear(vectorC, vectorD);

			Assert.That(areCollinear, Is.True);
		}

		[Test]
		public void GetScalarTripleProduct_Returns_minus8()
		{
			Vector vectorC = new Vector(1, 1, 1);
			double expected = -8;

			double sTP = Vector.GetScalarTripleProduct(vectorC, vectorA, vectorB);

			Assert.That(sTP, Is.EqualTo(expected));
		}

		[Test]
		public void AreCoplanar_Returns_False_Test()
		{
			Vector vectorC = new Vector(1, 1, 1);

			bool areCoplanar = Vector.AreCoplanar(vectorC, vectorA, vectorB);

			Assert.That(areCoplanar, Is.False);
		}
	}
}