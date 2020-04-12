using System;

namespace MFour
{
	class Program
	{
		static void Main(string[] args)
		{
			int n;
			int algorithm;
			int gcd;

			do
			{
				Console.WriteLine("Введите количество чисел. Количество чисел должно быть больше одного:");
				n = Int32.Parse(Console.ReadLine());

			} while (n < 2);

			int[] numbers = new int[n];

			for (int i = 0; i < n; i++)
			{
				Console.WriteLine($"Введите {i + 1}-ое число");
				numbers[i] = Int32.Parse(Console.ReadLine());
			}

			do
			{
				Console.WriteLine("Введите 1 для расчёта НОД методом Евклида или 2 для расчёта методом Стайна:");
				algorithm = Int32.Parse(Console.ReadLine());

			} while (algorithm != 1 && algorithm != 2);

			gcd = GCD.GetGCD((Algorithm)algorithm, out TimeSpan elapsedTime, numbers);

			Console.WriteLine($"НОД введённых чисел равен {gcd}. Время выполнения - 0.{elapsedTime:fffff} с.");
		}
	}
}
