using System;

namespace Shapes
{
	class Program
	{
		static void Main(string[] args)
		{
			double a, b, c;

			Console.WriteLine("Введите длину стороны a:");
			a = Double.Parse(Console.ReadLine());
			Console.WriteLine("Введите длину стороны b:");
			b = Double.Parse(Console.ReadLine());
			Console.WriteLine("Введите длину стороны c:");
			c = Double.Parse(Console.ReadLine());

			Triangle triangle = new Triangle(a, b, c);

			Console.WriteLine($"Периметр треугольника равен {triangle.Perimeter()}, площадь равна {triangle.Area()}.");
		}
	}
}
