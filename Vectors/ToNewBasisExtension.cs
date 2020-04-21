using System;
using System.Collections.Generic;
using System.Text;

namespace Vectors
{
	public static class ToNewBasisExtension
	{
		/// <summary>
		/// Возвращает вектор в новом базисе. Векторы базиса записываются в столбцы масссива.
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="basis"></param>
		/// <returns></returns>
		public static Vector ToNewBasis(this Vector vector, double[,] basis)
		{
			if (Vector.Determinant(basis) == 0)
				throw new ArgumentException("Determinant of the matrix of vectors is equal to 0." +
					"Vectors cannot be basis");

			else
			{
				double[,] invertMatrix = Vector.InvertibleMatrix(basis);

				double[] newVector = Vector.MatrixMultiplication(invertMatrix, vector);

				return new Vector(newVector);
			}
		}
	}
}
