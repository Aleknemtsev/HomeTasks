using System;
using System.Collections;


namespace Vectors
{
	public class Vector : IEnumerable
	{
		private double[] vector;

		public int Dimensions { get; private set; }
		public double[,] Basis { get; private set; }


		public Vector(params double[] array)
		{
			if (array.Length != 3)
				throw new ArgumentOutOfRangeException("Vector must have only 3 dimensions.");

			else
			{
				Initialization(array);
			}
		}

		public Vector(Vector vectorB)
		{
			double[] array = new double[vectorB.Dimensions];

			for (int i = 0; i < array.Length; i++)
			{
				array[i] = vectorB[i];
			}

			Initialization(array);
		}

		private void Initialization(params double[] array)
		{
			Dimensions = array.Length;
			vector = new double[Dimensions];

			for (int i = 0; i < Dimensions; i++)
				vector[i] = array[i];

			Basis = new double[Dimensions, Dimensions];

			for (int i = 0; i < Dimensions; i++)
			{
				for (int j = 0; j < Dimensions; j++)
				{
					if (i == j)
						Basis[i, j] = 1;

					else
						Basis[i, j] = 0;
				}
			}
		}

		private static void CheckDimensions(Vector vectorA, Vector vectorB)
		{
			if (vectorA.Dimensions != vectorB.Dimensions)
				throw new ArgumentException("Dimensions of vectors must be equal;");
		}

		public double this[int dimension]
		{
			get
			{
				if (dimension > 2 || dimension < 0)
					throw new ArgumentOutOfRangeException("Number of the dimension must be between 0 and 2");

				else
					return vector[dimension];
			}
		}

		public double GetLength()
		{
			double sum = 0;

			foreach (double item in vector)
			{
				sum += (item * item);
			}

			return Math.Sqrt(sum);
		}

		public Vector Add(Vector vectorB)
		{
			CheckDimensions(this, vectorB);

			double[] newVector = new double[Dimensions];

			for (int i = 0; i < newVector.Length; i++)
			{
				newVector[i] = vector[i] + vectorB[i];
			}
			
			return new Vector(newVector);
		}

		public Vector Substract(Vector vectorB)
		{
			CheckDimensions(this, vectorB);

			double[] newVector = new double[Dimensions];

			for (int i = 0; i < newVector.Length; i++)
			{
				newVector[i] = vector[i] - vectorB[i];
			}

			return new Vector(newVector);
		}

		public Vector ScalarMultiplication(double number)
		{
			double[] newVector = new double[Dimensions];

			for (int i = 0; i < newVector.Length; i++)
			{
				newVector[i] = vector[i] * number;
			}

			return new Vector(newVector);
		}

		public static double GetDotProduct(Vector vectorA, Vector vectorB)
		{
			CheckDimensions(vectorA, vectorB);
			
			double sum = 0;

			for (int i = 0; i < vectorA.Dimensions; i++)
			{
				sum += vectorA[i] * vectorB[i];
			}

			return sum;
			
		}

		public static Vector GetVectorProduct(Vector vectorA, Vector vectorB)
		{
			CheckDimensions(vectorA, vectorB);

			double[,] matrix = new double[vectorA.Dimensions, vectorB.Dimensions];

			for (int i = 0; i < vectorA.Dimensions; i++)
				matrix[0, i] = 1;

			for (int i = 0; i < vectorA.Dimensions; i++)
				matrix[1, i] = vectorA[i];

			for (int i = 0; i < vectorB.Dimensions; i++)
				matrix[2, i] = vectorB[i];

			double[] newVector = new double[vectorA.Dimensions];

			for (int i = 0; i < vectorA.Dimensions; i++)
				newVector[i] = Cofactor(matrix, 0, i);

			return new Vector(newVector);
			
		}

		public static double GetScalarTripleProduct(Vector vectorA, Vector vectorB, Vector vectorC)
		{
			CheckDimensions(vectorA, vectorB);
			CheckDimensions(vectorC, vectorB);

			double[,] matrix = new double[vectorA.Dimensions, vectorA.Dimensions];

			for (int i = 0; i < vectorA.Dimensions; i++)
				matrix[0, i] = vectorA[i];

			for (int i = 0; i < vectorA.Dimensions; i++)
				matrix[1, i] = vectorB[i];

			for (int i = 0; i < vectorB.Dimensions; i++)
				matrix[2, i] = vectorC[i];

			return Determinant(matrix);
			
		}

		public static bool AreCollinear(Vector vectorA, Vector vectorB)
		{
			double[] zeroVector = new double[vectorA.Dimensions];

			for (int i = 0; i < vectorA.Dimensions; i++)
			{
				zeroVector[i] = 0;
			}

			if (GetVectorProduct(vectorA, vectorB) == new Vector(zeroVector))
				return true;
			else
				return false;
		}

		public static bool AreCoplanar(Vector vectorA, Vector vectorB, Vector vectorC)
		{
			if (GetScalarTripleProduct(vectorA, vectorB, vectorC) == 0)
				return true;

			else
				return false;
		}

		public static bool AreOrthogonal(Vector vectorA, Vector vectorB)
		{
			if (Vector.GetDotProduct(vectorA, vectorB) == 0)
				return true;

			else
				return false;
		}

		public static double GetAngle(Vector vectorA, Vector vectorB)
		{
			double cosTheta = GetDotProduct(vectorA, vectorB) / (vectorA.GetLength() * vectorB.GetLength());

			double theta = Math.Acos(cosTheta);

			return theta;
		}

		public double ScalarProjection(Vector vectorB)
		{
			return GetDotProduct(this, vectorB) / vectorB.GetLength();
		}

		public override bool Equals(object obj)
		{
			

			Vector vectorB = (Vector)obj;

			if (Dimensions != vectorB.Dimensions)
				return false;

			else
			{
				bool equality = true;

				for (int i = 0; i < Dimensions; i++)
				{
					equality = (vector[i] == vectorB[i]) && equality;
				}

				return equality;
			}
		}

		public override string ToString()
		{
			return $"{vector[0]}, {vector[1]}, {vector[2]}";
		}


		public IEnumerator GetEnumerator()
		{
			return vector.GetEnumerator();
		}

		#region Operators_Overloads

		public static bool operator ==(Vector vectorA, Vector vectorB) => vectorA.Equals(vectorB);

		public static bool operator !=(Vector vectorA, Vector vectorB) => !vectorA.Equals(vectorB);

		public static Vector operator +(Vector vectorA, Vector vectorB) => vectorA.Add(vectorB);

		public static Vector operator -(Vector vectorA, Vector vectorB) => vectorA.Substract(vectorB);

		#endregion

		#region Matrix_Operations

		private static double[,] SubMatrix(double[,] array, int m, int n)
		{
			int numOfDimensions = array.GetUpperBound(0);

			double[,] subMatrix = new double[numOfDimensions, numOfDimensions];

			for (int i = 0; i <= numOfDimensions; i++)
			{
				if (i == m)
					continue;

				for (int j = 0; j <= numOfDimensions; j++)
				{
					if (j == n)
						continue;

					if (i < m && j < n)
						subMatrix[i, j] = array[i, j];
					else if (i > m && j < n)
						subMatrix[i - 1, j] = array[i, j];
					else if (i < m && j > n)
						subMatrix[i, j - 1] = array[i, j];
					else if (i > m && j > n)
						subMatrix[i - 1, j - 1] = array[i, j];
				}
			}

			return subMatrix;
		}

		internal static double Determinant(double[,] array)
		{
			int numOfDimensions = array.GetUpperBound(0) + 1;

			if (numOfDimensions == 1)
				return array[0, 0];
			else
			{
				double det = 0;

				for (int i = 0; i < numOfDimensions; i++)
				{
					det += Cofactor(array, 0, i) * array[0, i];
				}

				return det;
			}
		}

		private static double Cofactor(double[,] array, int m, int n) => Minor(array, m, n) * Math.Pow(-1, m + n);

		private static double Minor(double[,] array, int m, int n)
		{
			double[,] subMatrix = SubMatrix(array, m, n);

			return Determinant(subMatrix);
		}

		private static double[,] Transpositon(double[,] array)
		{
			int size = array.GetUpperBound(0) + 1;

			double[,] transMatrix = new double[size, size];

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
					transMatrix[j, i] = array[i, j];
			}

			return transMatrix;
		}

		private static double[,] AdjugateMatrix(double[,] array)
		{
			int size = array.GetUpperBound(0) + 1;

			double[,] cofactorMatrix = new double[size, size];
			double[,] adjugateMatrix = new double[size, size];

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					cofactorMatrix[i, j] = Cofactor(array, i, j);
				}
			}

			adjugateMatrix = Transpositon(cofactorMatrix);

			return adjugateMatrix;
		}

		internal static double[,] InvertibleMatrix(double[,] array)
		{
			int size = array.GetUpperBound(0) + 1;
			double[,] adjMatrix = AdjugateMatrix(array);
			double det = Determinant(array);

			double[,] newMatrix = new double[size, size];

			newMatrix = ScalarMultiplication(adjMatrix, 1 / det);

			return newMatrix;
		}

		private static double[,] ScalarMultiplication( double[,] array, double number)
		{
			int size = array.GetUpperBound(0) + 1;

			double[,] newMatrix = new double[size, size];

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					newMatrix[i, j] = array[i, j] * number;
				}
			}

			return newMatrix;
		}

		internal static double[] MatrixMultiplication(double[,] matrix, Vector vector)
		{
			int size = vector.Dimensions;

			double[] newVector = new double[size];

			for (int i = 0; i < size; i++)
			{
				double sum = 0;

				for (int k = 0; k < size; k++)
					sum += matrix[i, k] * vector[k];

				newVector[i] = sum;	
			}

			return newVector;
		}

		#endregion
	}
}
