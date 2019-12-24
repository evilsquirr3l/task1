using System;

namespace Polynom
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynom poly1 = new Polynom(1, 3, 6, 4, 2);
            Polynom poly2 = new Polynom(3, 2, 5, 2);

            Polynom poly3 = poly1 + poly1 + poly1;

            Polynom clone = (Polynom)poly1.Clone();

            Console.WriteLine(poly1 > poly2);
        }
    }
}
