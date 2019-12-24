using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MatrixLibrary
{
    //разные типы сериализации
    public static class Serializator
    {
        private static BinaryFormatter formatter;

        public static void Serialize(Matrix matrix)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("matrix.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, matrix);

                Console.WriteLine("Объект сериализован");
            }
        }

        public static Matrix Deserialize()
        {
            using (FileStream fs = new FileStream("matrix.dat", FileMode.OpenOrCreate))
            {
                Matrix matrix = (Matrix)formatter.Deserialize(fs);

                return matrix;
            }
        }

    }
}