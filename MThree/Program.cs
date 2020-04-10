using System;

namespace MThree
{
	class Program
	{
		static void Main(string[] args)
		{
			string prog;

			do
			{
				Console.WriteLine("Введите 1 для вычисления корня n-ой степени числа.");
				Console.WriteLine("Введите 2 для конвертации неотрицательного числа в двоичный формат.");

				prog = Console.ReadLine();
			} while (prog == "1" && prog == "2");

			switch (prog)
			{
				case "1":

					double numberA;
					double n;
					double eps;
					double result;
					double mathPowResult;

					Console.WriteLine("Введите чило A:");
					numberA = Double.Parse(Console.ReadLine());

					Console.WriteLine("Введите степень извлекаемого корня n, натуальное число:");
					n = Double.Parse(Console.ReadLine());

					Console.WriteLine("Введите точность eps:");
					eps = Double.Parse(Console.ReadLine());

					result = Task1.FindNthRoot(numberA, n, eps);
					mathPowResult = Math.Pow(numberA, (1 / n));

					Console.WriteLine($"Корень {n} - ой степени числа {numberA} равен {result} c точностью {eps}.");
					Console.WriteLine($"Резльтат, полученный методом MAth.Pow() - {mathPowResult}");

					break;

				case "2":

					int number;
					do
					{
						Console.WriteLine("Введите целое неотрицательное число:");
						number = int.Parse(Console.ReadLine());

						if(number < 0)
							Console.WriteLine("Число должно быть больше 0.");

					} while (number < 0);

					string numberBin = Task3.ToBin(number);
					string converted = Convert.ToString(number, 2);

					Console.WriteLine($"{number} в десятиричной системе = {numberBin} в двоичной системе.");
					Console.WriteLine($"С использованием класса Convert - {converted} в двоичной системе.");

					break;

				default:
					break;
			}

			
		}
	}
}
