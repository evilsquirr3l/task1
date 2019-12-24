using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Polynom
{
    public static class Serializator
    {
        static BinaryFormatter formatter = new BinaryFormatter();
        static XmlSerializer serializer = new XmlSerializer(typeof(Polynom));


        public static void BinarySerialize(Polynom poly)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("poly.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, poly);

                Console.WriteLine("Объект сериализован, binary");
            }
        }

        public static Polynom BinaryDeserialize()
        {
            using (FileStream fs = new FileStream("poly.dat", FileMode.OpenOrCreate))
            {
                Polynom polynom = (Polynom)formatter.Deserialize(fs);

                return polynom;
            }
        }

        public static void XmlSerialize(Polynom poly)
        {
            using (FileStream fs = new FileStream("poly.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, poly);

                Console.WriteLine("Объект сериализован, XML");
            }
        }

        public static Polynom XmlDeserialize()
        {
            using (FileStream fs = new FileStream("poly.xml", FileMode.OpenOrCreate))
            {
                Polynom poly = (Polynom)formatter.Deserialize(fs);
                return poly;
            }
        }
    }
}