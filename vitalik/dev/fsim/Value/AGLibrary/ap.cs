using System;

namespace AGLibrary
{
    /********************************************************************
    Class defining a complex number with double precision.
    ********************************************************************/

    public struct Complex
    {
        public double x;
        public double y;

        public Complex(double _x)
        {
            x = _x;
            y = 0;
        }

        public Complex(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public static implicit operator Complex(double _x)
        {
            return new Complex(_x);
        }

        public override bool Equals(object obj)
        {
            var other = (Complex) obj;
            return x == other.x
                   && y == other.y;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Complex lhs, Complex rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Complex lhs, Complex rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static Complex operator +(Complex lhs)
        {
            return lhs;
        }

        public static Complex operator -(Complex lhs)
        {
            return new Complex(-lhs.x, -lhs.y);
        }

        public static Complex operator +(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Complex operator -(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Complex operator *(Complex lhs, Complex rhs)
        {
            return new Complex(lhs.x * rhs.x - lhs.y * rhs.y, lhs.x * rhs.y + lhs.y * rhs.x);
        }

        public static Complex operator /(Complex lhs, Complex rhs)
        {
            Complex result;
            double e;
            double f;
            if (Math.Abs(rhs.y) < Math.Abs(rhs.x))
            {
                e = rhs.y / rhs.x;
                f = rhs.x + rhs.y * e;
                result.x = (lhs.x + lhs.y * e) / f;
                result.y = (lhs.y - lhs.x * e) / f;
            }
            else
            {
                e = rhs.x / rhs.y;
                f = rhs.y + rhs.x * e;
                result.x = (lhs.y + lhs.x * e) / f;
                result.y = (-lhs.x + lhs.y * e) / f;
            }
            return result;
        }
    }

    /********************************************************************
	AP math namespace
	********************************************************************/

    public struct rcommstate
    {
        public bool[] ba;
        public Complex[] ca;
        public int[] ia;
        public double[] ra;
        public int stage;
    } ;

    /********************************************************************
    AP math namespace
    ********************************************************************/

    public class ApMath
    {
        public const double MachineEpsilon = 5E-16;
        public const double MaxRealNumber = 1E300;
        public const double MinRealNumber = 1E-300;
        public static Random RndObject = new Random(DateTime.Now.Millisecond);

        public static double RandomReal()
        {
            double r = 0;
            lock (RndObject)
            {
                r = RndObject.NextDouble();
            }
            return r;
        }

        public static int RandomInteger(int N)
        {
            int r = 0;
            lock (RndObject)
            {
                r = RndObject.Next(N);
            }
            return r;
        }

        public static double Sqr(double X)
        {
            return X * X;
        }

        public static double AbsComplex(Complex z)
        {
            double w;
            double xabs;
            double yabs;
            double v;

            xabs = Math.Abs(z.x);
            yabs = Math.Abs(z.y);
            w = xabs > yabs ? xabs : yabs;
            v = xabs < yabs ? xabs : yabs;
            if (v == 0)
                return w;
            else
            {
                double t = v / w;
                return w * Math.Sqrt(1 + t * t);
            }
        }

        public static Complex Conj(Complex z)
        {
            return new Complex(z.x, -z.y);
        }

        public static Complex CSqr(Complex z)
        {
            return new Complex(z.x * z.x - z.y * z.y, 2 * z.x * z.y);
        }
    }
}