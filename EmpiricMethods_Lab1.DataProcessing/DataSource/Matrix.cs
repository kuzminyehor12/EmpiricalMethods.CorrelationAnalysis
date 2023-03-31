using EmpiricMethods_Lab1.DataProcessing.Validation;
using System;
using System.Linq;

namespace EmpiricMethods_Lab1.DataProcessing.DataSource
{   
    public class Matrix : ICloneable
    {
        private readonly double[][] _array;
        public int Rows
        {
            get => _array.Length;
        }

        public int Columns
        {
            get => _array[0].Length;
        }

        public double[][] Array
        {
            get => _array;
        }
        
        public Matrix(int rows, int columns)
        {
            this._array = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                _array[i] = new double[columns];
            }
        }

        public Matrix(double[][] array)
        {
            this._array = array;
        }
        
        public double this[int row, int column]
        {
            get => this.Array[row][column];
            set => this.Array[row][column] = value;
        }

        public object Clone()
        {
            Matrix clone = new Matrix(this.Rows, this.Columns);

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    clone.Array[i][j] = this.Array[i][j];
                }
            }

            return clone;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            ValidateMatrices(matrix1, matrix2);
            return matrix1.Add(matrix2);
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            ValidateMatrices(matrix1, matrix2);
            return matrix1.Subtract(matrix2);
        }

        private static void ValidateMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 is null || matrix2 is null)
            {
                throw new ArgumentNullException("Matrix cannot be nullable", new Exception());
            }

            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new MatrixException();
            }
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 is null || matrix2 is null)
            {
                throw new ArgumentNullException("Matrix cannot be nullable", new Exception());
            }

            if (matrix1.Columns != matrix2.Rows)
            {
                throw new MatrixException();
            }

            return matrix1.Multiply(matrix2);
        }

        public Matrix Add(Matrix matrix)
        {
            ValidateMatrix(matrix);
            Matrix destination = new Matrix(this.Rows, this.Columns);

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    destination[i, j] = this[i, j] + matrix[i, j];
                }
            }

            return destination;
        }

        public Matrix Subtract(Matrix matrix)
        {
            ValidateMatrix(matrix);
            Matrix destination = new Matrix(this.Rows, this.Columns);

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    destination[i, j] = this[i, j] - matrix[i, j];
                }
            }

            return destination;
        }

        public Matrix Multiply(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException("Matrix cannot be nullable", new Exception());
            }

            if (this.Columns != matrix.Rows)
            {
                throw new MatrixException();
            }

            Matrix destination = new Matrix(this.Rows, matrix.Columns);

            for (int i = 0; i < destination.Rows; i++)
            {
                for (int j = 0; j < destination.Columns; j++)
                {
                    double sum = 0;

                    for (int k = 0; k < this.Columns; k++)
                    {
                        sum += this[i, k] * matrix[k, j];
                    }

                    destination[i, j] = sum;
                }
            }

            return destination;
        }

        public Matrix Multiply(double coefficient)
        {
            Matrix destination = new Matrix(Rows, Columns);

            for (int i = 0; i < destination.Rows; i++)
            {
                for (int j = 0; j < destination.Columns; j++)
                {
                    destination[i, j] = coefficient * Array[i][j];
                }
            }

            return destination;
        }

        public Matrix Transpose()
        {
            var resultMatrix = new double[Columns][];

            for (int i = 0; i < Columns; i++)
            {
                resultMatrix[i] = new double[Rows];
            }

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    resultMatrix[j][i] = Array[i][j];
                }
            }

            return new Matrix(resultMatrix);
        }

        public Matrix Invert()
        {
            var det = Det() ?? 
                throw new MatrixException("Determinant cannot be solved with n x m matrix if n not equal to m");
            return Transpose().Multiply(1 / det);
        }

        public double? Det()
        {
            if (Rows == Columns)
            {
                if (Rows == 2)
                {
                    return Array[0][0] * Array[1][1] - Array[0][1] * Array[1][0];
                }

                double sum = 0;

                for (int j = 0; j < Columns; j++)
                {
                    var det = AdditionalMinor(j)?.Det() ??
                        throw new MatrixException("Determinant cannot be solved with n x m matrix if n not equal to m");
                    sum += Math.Pow(-1, 1 + j) * Array[0][j] * det;
                }

                return sum;
            }

            return null;
        }

        public Matrix AdditionalMinor(int column)
        {
            var resultMatrix = new double[Rows - 1][];

            for (int i = 0; i < Rows - 1; i++)
            {
                resultMatrix[i] = new double[Columns - 1];
            }

            for (int i = 1; i < Array.Length; i++)
            {
                resultMatrix[i - 1] = Array[i];
                var listRow = resultMatrix[i - 1].ToList();
                listRow.RemoveAt(column);
                resultMatrix[i - 1] = listRow.ToArray();
            }

            return new Matrix(resultMatrix);
        }

        private void ValidateMatrix(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException("Matrix cannot be nullable", new Exception());
            }

            if (matrix.Rows != this.Rows || matrix.Columns != this.Columns)
            {
                throw new MatrixException();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if(obj is Matrix matrixToCompare)
            {
                for (int i = 0; i < Math.Min(matrixToCompare.Rows, this.Rows); i++)
                {
                    for (int j = 0; j < Math.Min(matrixToCompare.Columns, this.Columns); j++)
                    {
                        if (this[i, j] != matrixToCompare[i, j])
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
