using System;

namespace MatrixLibrary
{
    [Serializable]
    public struct Matrix : ICloneable
    {
        private int n;
        private int m;
        private double[,] array;


        public Matrix(int n, int m, double[,] array)
        {
            this.n = n;
            this.m = m;
            this.array = array;
        }

        public Matrix(Tuple<int, int, double[,]> tuple)
        {
            this.n = tuple.Item1;
            this.m = tuple.Item2;
            this.array = tuple.Item3;
        }

        public int Rows
        {
            get => n;
        }

        public int Columns
        {
            get => m;
        }

        public object Clone()
        {
            double[,] temparray = new double[this.n, this.m];
            temparray = (double[,])array.Clone();

            return new Matrix(this.n, this.m, temparray);
        }



        public void Show()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(array[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        public double this[int index1, int index2]
        {

            get
            {
                try
                {
                    return array[index1, index2];
                }
                catch
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            }
            private set
            {
                try
                {
                    array[index1, index2] = value;
                }
                catch
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            }
        }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            try
            {
                Matrix result = new Matrix(first.n, first.m, new double[first.n, first.m]);
                for (int i = 0; i < first.n; i++)
                {
                    for (int j = 0; j < first.m; j++)
                    {
                        result[i, j] = first[i, j] + second[i, j];
                    }
                }

                return result;
            }
            catch
            {
                throw new MatrixDimensionExeption("Dimensions are different.");
            }

        }

        public static Matrix operator -(Matrix first, Matrix second)
        {
            try
            {
                Matrix result = new Matrix(first.n, first.m, new double[first.n, first.m]);
                for (int i = 0; i < first.n; i++)
                {
                    for (int j = 0; j < first.m; j++)
                    {
                        result[i, j] = first[i, j] - second[i, j];
                    }
                }

                return result;
            }
            catch
            {
                throw new MatrixDimensionExeption("Dimensions are different.");
            }

        }

        public static Matrix operator *(Matrix first, Matrix second)
        {
            try
            {
                Matrix result = new Matrix(first.n, second.m, new double[first.n, first.m]);
                for (int i = 0; i < first.n; i++)
                {
                    for (int j = 0; j < second.m; j++)
                    {
                        result[i, j] = 0;

                        for (int k = 0; k < first.n; k++)
                        {
                            result[i, j] += first[i, k] * second[k, j];
                        }

                    }
                }

                return result;
            }
            catch
            {
                throw new MatrixDimensionExeption("Dimensions are different.");
            }
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) return false;

            Matrix matrix = (Matrix)obj;

            for (int i = 0; i < matrix.Rows; i++)

                for (int j = 0; j < matrix.Columns; j++)

                    if (matrix[i, j] != this[i, j])
                        return false;

            return true;
        }


    }
}