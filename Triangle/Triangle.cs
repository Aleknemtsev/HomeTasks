using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
	public	class Triangle
	{
		public readonly double a;
		public readonly double b;
		public readonly double c;

		public Triangle(double a, double b, double c)
		{
			if (a <= 0 || b <= 0 || c <= 0)
				throw new ArgumentOutOfRangeException("Длины сторон треугольника не могут быть меньше или равны нулю");

			if ((a + b) < c || (a + c) < b || (b + c) < a)
				throw new ArgumentException("Треугольник не может существовать, поскольку " +
					"сумма длин двух любых сторон должна быть меньше длины третьей");

			this.a = a;
			this.b = b;
			this.c = c;
		}


		/// <summary>
		/// Определение периметра треугольника исходя из понятия периметра.
		/// </summary>
		/// <returns></returns>
		public double Perimeter() => a + b + c;


		/// <summary>
		/// Расчёт площади треугольника по формуле Герона
		/// </summary>
		/// <returns></returns>
		public double Area()
		{
			double semiPerimeter = Perimeter() / 2;
			double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

			return area;
		}
	}
}
