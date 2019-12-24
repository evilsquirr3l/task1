using System;

namespace MatrixLibrary
{
    public class MatrixDimensionExeption : Exception
    {
        public MatrixDimensionExeption(string message) : base(message)
        {

        }
    }

    public class MatrixMultiplyExeption : Exception
    {
        public MatrixMultiplyExeption(string message) : base(message)
        {

        }

    }
}