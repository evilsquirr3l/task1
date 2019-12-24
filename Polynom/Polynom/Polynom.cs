using System;
using System.Text;

namespace Polynom
{
    [Serializable]
    public class Polynom : ICloneable
    {
        private double[] coeffs;

        public Polynom(params double[] coeffs)
        {
            this.coeffs = coeffs;
        }

        public double this[int index]
        {
            get
            {
                try
                {
                    return coeffs[index];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            }
            private set
            {
                try
                {
                    coeffs[index] = value;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            }
        }

        public int MaxDegree { get => coeffs.Length; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.MaxDegree; i++)
            {
                if (this[i] == 0 && i != 0) continue;
                if (i == 0)
                {
                    sb.Append(this[i] + " ");
                    continue;
                }
                if (this[i] > 0) sb.Append('+');
                if (i == 1)
                {
                    sb.Append(this[i] + "*x ");
                    continue;
                }

                sb.Append(this[i] + "*x^" + i + ' ');
            }

            return sb.ToString();
        }

        public object Clone()
        {
            var tempCoeffs = new double[this.MaxDegree];
            tempCoeffs = (double[])coeffs.Clone();

            return new Polynom(tempCoeffs);


        }

        public static Polynom operator +(Polynom first, Polynom second)
        {
            int items = Math.Max(first.MaxDegree, second.MaxDegree);
            double[] result = new double[items];

            for (int i = 0; i < items; i++)
            {
                double a = 0;
                double b = 0;

                if (i < first.MaxDegree)
                {
                    a = first[i];
                }

                if (i < second.MaxDegree)
                {
                    b = second[i];
                }

                result[i] = a + b;
            }

            return new Polynom(result);
        }

        public static Polynom operator -(Polynom first, Polynom second)
        {
            int items = Math.Max(first.MaxDegree, second.MaxDegree);
            double[] result = new double[items];

            for (int i = 0; i < items; i++)
            {
                double a = 0;
                double b = 0;

                if (i < first.MaxDegree)
                {
                    a = first[i];
                }

                if (i < second.MaxDegree)
                {
                    b = second[i];
                }

                result[i] = a - b;
            }

            return new Polynom(result);
        }

        public static Polynom operator *(Polynom first, Polynom second)
        {
            int items = first.MaxDegree + second.MaxDegree;
            double[] result = new double[items];

            for (int i = 0; i < first.MaxDegree; i++)
            {
                for (int j = 0; j < second.MaxDegree; j++)
                {
                    result[i + j] += first[i] * second[j];
                }
            }
            return new Polynom(result);
        }

        public static bool operator >(Polynom first, Polynom second)
        {
            int items = Math.Max(first.MaxDegree, second.MaxDegree);

            if (first.MaxDegree == second.MaxDegree)
            {
                return first.coeffs[items - 1] > second.coeffs[items - 1];
            }

            else if (first.MaxDegree == items)
            {
                return true;
            }

            else return false;

        }

        public static bool operator <(Polynom first, Polynom second)
        {
            int items = Math.Max(first.MaxDegree, second.MaxDegree);

            if (first.MaxDegree == second.MaxDegree)
            {
                return first.coeffs[items - 1] < second.coeffs[items - 1];
            }

            else if (second.MaxDegree == items)
            {
                return true;
            }

            else return false;
        }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || this.GetType() != obj.GetType()) return false;

            Polynom poly = (Polynom)obj;

            for (int i = 0; i < poly.MaxDegree; i++)
            {
                if (this.coeffs[i] != poly.coeffs[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}