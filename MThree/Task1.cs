using System;
using System.Collections.Generic;
using System.Text;

namespace MThree
{
	public class Task1
	{
		public static double FindNthRoot (double a, double n, double eps)
		{
			if (n < 1)
				throw new ArgumentOutOfRangeException("Число n должно быть натуральным числом.");

			else if ((a < 0) && (n % 2 == 0))
				throw new ArgumentOutOfRangeException("Из отрицательного числа a можно извлечь только корень нечётной степени n.");

			else if (eps < 0)
				throw new ArgumentOutOfRangeException("Точность eps не может быть отрицательной.");

			if (a == 1)
				return 1;

			else
			{
				double x0; // Начальное приближение.
				double x1; // Следующее приближение.

				if (Math.Abs(a) > 1)
					x0 = a / 2;

				else
					x0 = 0.5;

				x1 = 1 / n * ((n - 1) * x0 + (a / Math.Pow(x0, (n - 1))));

				while(Math.Abs(x1 - x0) > eps)
				{
					x0 = x1;

					x1 = 1 / n * ((n - 1) * x0 + (a / Math.Pow(x0, (n - 1))));
				}

				return x1;
			}
		}

	}
}
