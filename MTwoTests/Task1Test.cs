using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTwo;

namespace MTwo.Tests
{
	[TestClass]
	public class Task1Test
	{
		[TestMethod]
		public void InsertNumberTest1()
		{
			int numberIn = 15;
			int numberSource = 15;
			int i = 0;
			int j = 0;

			int res;

			res = Task1.InsertNumber(numberIn, numberSource, i, j);

			Assert.AreEqual(res, 15);
		}


		[TestMethod]
		public void InsertNumberTest2()
		{
			int numberIn = 8;
			int numberSource = 15;
			int i = 0;
			int j = 0;

			int res;

			res = Task1.InsertNumber(numberIn, numberSource, i, j);

			Assert.AreEqual(res, 9);
		}

		[TestMethod]
		public void InsertNumberTest3()
		{
			int numberIn = 8;
			int numberSource = 15;
			int i = 3;
			int j = 8;

			int res;

			res = Task1.InsertNumber(numberIn, numberSource, i, j);

			Assert.AreEqual(res, 120);
		}
	}
}
