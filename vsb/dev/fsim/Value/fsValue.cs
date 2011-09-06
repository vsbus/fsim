using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using AGLibrary;

namespace Value
{
    public struct fsValue : IComparable
    {
        public bool defined;
        public double value;
        
        private static string UndefinedValue = "";
        public static int outputPrecision = 3;

        public static fsValue Infinity()
        {
            return new fsValue(1e100);
        }

        public fsValue(double x)
        {
            defined = true;
            value = x;
        }

        public fsValue(double x, bool d)
        {
            defined = d;
            value = x;
        }

        public fsValue(fsValue val)
        {
            defined = val.defined;
            value = val.value;
        }

        public fsValue Round(int precision)
        {
            var result = new fsValue(0, defined);

            if (value == 0 || double.IsInfinity(value))
            {
                return result;
            }

            double pMin = Math.Pow(10, precision - 1);
            double pMax = Math.Pow(10, precision);
            double factor = 1;
            const double eps = 1e-8;

            result.value = value;

            while (Math.Abs(result.value) < pMin - eps)
            {
                result.value *= 10;
                factor *= 10;
            }

            while (Math.Abs(result.value) >= pMax - eps)
            {
                result.value /= 10;
                factor /= 10;
            }

            result.value = Math.Floor(result.value + 0.5 + eps);
            result.value /= factor;
            return result;
        }

        public override string ToString()
        {
            return ToString(outputPrecision);
        }

        public string ToString(int precision)
        {
            fsValue val = Round(precision);
            string res = Convert.ToString(val.value);
            res = val.defined ? res : UndefinedValue;
            return res;
        }

        public static bool IsValueString(String s)
        {
            try
            {
                Convert.ToDouble(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public void WriteToStream(StreamWriter sw)
        {
            sw.WriteLine(defined);
            sw.WriteLine(value);
        }

        public void ReadFromStream(StreamReader sr)
        {
            defined = Convert.ToBoolean(sr.ReadLine());
            value = Convert.ToDouble(sr.ReadLine());
        }

        public static fsValue StringToValue(String s)
        {
            var res = new fsValue();
            res.defined = double.TryParse(s, out res.value);
            return res;
        }

        public static fsValue ObjectToValue(object obj)
        {
            if (obj == null)
            {
                return new fsValue();
            }

            if (obj.GetType() == typeof(string))
            {
                return StringToValue(Convert.ToString(obj));
            }

            if (obj.GetType() == typeof(fsValue))
            {
                return (fsValue)obj;
            }

            if (obj.GetType() == typeof(double))
            {
                return new fsValue((double)obj);
            }

            throw new Exception("Can't convert object to fmValue");
        }

        public static bool operator <(fsValue op1, fsValue op2)
        {
            if (!op1.defined && !op2.defined)
                return false;
            if (!op1.defined)
                return true;
            if (!op2.defined)
                return false;
            return op1.value < op2.value;
        }

        public static bool operator <=(fsValue op1, fsValue op2)
        {
            if (!op1.defined && !op2.defined)
                return false;
            if (!op1.defined)
                return true;
            if (!op2.defined)
                return false;
            return op1.value <= op2.value;
        }

        public static bool operator >(fsValue op1, fsValue op2)
        {
            return op2 < op1;
        }

        public static bool operator >=(fsValue op1, fsValue op2)
        {
            return op2 <= op1;
        }

        public static bool operator ==(fsValue op1, fsValue op2)
        {
            return op1.Equals(op2);
        }

        public static bool operator !=(fsValue op1, fsValue op2)
        {
            return !op1.Equals(op2);
        }

        public static fsValue operator -(fsValue op)
        {
            var res = new fsValue(-op.value, op.defined);
            return res;
        }

        public static fsValue operator +(fsValue op1, fsValue op2)
        {
            var res = new fsValue(op1.value + op2.value, op1.defined && op2.defined);
            return res;
        }

        public static fsValue operator +(fsValue op1, double op2)
        {
            var res = new fsValue(op1.value + op2, op1.defined);
            return res;
        }

        public static fsValue operator +(double op1, fsValue op2)
        {
            var res = new fsValue(op1 + op2.value, op2.defined);
            return res;
        }

        public static fsValue operator -(fsValue op1, fsValue op2)
        {
            var res = new fsValue(op1.value - op2.value, op1.defined && op2.defined);
            return res;
        }

        public static fsValue operator -(fsValue op1, double op2)
        {
            var res = new fsValue(op1.value - op2, op1.defined);
            return res;
        }

        public static fsValue operator -(double op1, fsValue op2)
        {
            var res = new fsValue(op1 - op2.value, op2.defined);
            return res;
        }

        public static fsValue operator *(fsValue op1, fsValue op2)
        {
            var res = new fsValue(op1.value * op2.value, op1.defined && op2.defined);
            return res;
        }

        public static fsValue operator *(fsValue op1, double op2)
        {
            var res = new fsValue(op1.value * op2, op1.defined);
            return res;
        }

        public static fsValue operator *(double op1, fsValue op2)
        {
            var res = new fsValue(op1 * op2.value, op2.defined);
            return res;
        }

        public static fsValue operator /(fsValue op1, fsValue op2)
        {
            var res = new fsValue
            {
                defined = op1.defined && op2.defined && (op2.value != 0.0)
            };
            res.value = res.defined ? op1.value / op2.value : 1;
            return res;
        }

        public static fsValue operator /(fsValue op1, double op2)
        {
            var res = new fsValue { defined = op1.defined && (op2 != 0.0) };
            res.value = res.defined ? op1.value / op2 : 1;
            return res;
        }

        public static fsValue operator /(double op1, fsValue op2)
        {
            var res = new fsValue { defined = op2.defined && (op2.value != 0.0) };
            res.value = res.defined ? op1 / op2.value : 1;
            return res;
        }

        public static fsValue Abs(fsValue op)
        {
            op.value = Math.Abs(op.value);
            return op;
        }

        public static fsValue LambertW(fsValue x)
        {
            if (x.value < -Math.Exp(-1.0) || x.defined == false)
            {
                return new fsValue();
            }
            if (x.value > 0)
            {
                double y = 0.5 * x.value, dy = 0.25 * x.value;
                while (dy > 1e-9)
                {
                    double f = y * Math.Exp(y);
                    if (f > x.value) y -= dy; else y += dy;
                    dy *= 0.5;
                }
                return new fsValue(y);
            }
            else
            {
                double y = 0.5, dy = 0.25;
                while (dy > 1e-9)
                {
                    double f = -y * Math.Exp(-y);
                    if (f < x.value) y -= dy; else y += dy;
                    dy *= 0.5;
                }
                return new fsValue(-y);
            }
        }

        public static fsValue Exp(fsValue op)
        {
            var res = new fsValue { defined = op.defined };
            res.value = res.defined ? Math.Exp(op.value) : 1;
            return res;
        }

        public static fsValue Log(fsValue op)
        {
            var res = new fsValue { defined = op.defined && op.value > 0 };
            res.value = res.defined ? Math.Log(op.value) : 1;
            return res;
        }

        public static fsValue Pow(fsValue op1, fsValue degree)
        {
            var res = new fsValue
            {
                defined =
                    op1.defined && degree.defined && (op1.value > 0 || op1.value == 0 && degree.value > 0)
            };
            res.value = res.defined ? Math.Pow(op1.value, degree.value) : 1;
            return res;
        }

        public static fsValue Pow(fsValue op1, double degree)
        {
            var res = new fsValue { defined = op1.defined && op1.value > 0 };
            res.value = res.defined ? Math.Pow(op1.value, degree) : 1;
            return res;
        }

        public static fsValue Sqrt(fsValue op1)
        {
            var res = new fsValue { defined = op1.defined && op1.value > 0 };
            res.value = res.defined ? Math.Sqrt(op1.value) : 1;
            return res;
        }

        public static fsValue Sqr(fsValue op)
        {
            var res = new fsValue(op);
            res = res * op;
            return res;
        }

        public static fsValue Erf(fsValue op)
        {
            var res = new fsValue { defined = op.defined };
            res.value = res.defined ? normaldistr.erf(op.value) : 1;
            return res;
        }

        public bool Equals(fsValue obj)
        {
            return (!defined && !obj.defined || defined && obj.defined && obj.value == value);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(fsValue)) return false;
            return Equals((fsValue)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (value.GetHashCode() * 397) ^ defined.GetHashCode();
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is fsValue)
            {
                var temp = (fsValue)obj;

                if (this < temp) return -1;
                if (this > temp) return 1;
                return 0;
            }

            throw new ArgumentException("object is not a fmValue");
        }


        public static fsValue Max(fsValue a, fsValue b)
        {
            return a > b ? a : b;
        }

        public static bool Less(fsValue a, fsValue b)
        {
            var eps = new fsValue(1e-9 * Math.Max(Math.Abs(a.value), Math.Abs(b.value)));
            return a < b - eps;
        }

        public static bool Greater(fsValue a, fsValue b)
        {
            return Less(b, a);
        }

        public static fsValue Sign(fsValue beginValue, fsValue eps)
        {
            return new fsValue(Math.Abs(beginValue.value) <= eps.value ? 0 : beginValue.value > 0 ? 1 : -1, beginValue.defined && eps.defined);
        }

        public fsValue RoundUp(fsValue x, int precision)
        {
            if (x.value == 0)
                return x;

            double factor = GetFactor(x, precision);
            x.value *= factor;
            x.value = Math.Ceiling(x.value - 1e-12);
            x.value /= factor;
            return x;
        }

        public fsValue RoundDown(fsValue x, int precision)
        {
            if (x.value == 0)
                return x;

            double factor = GetFactor(x, precision);
            x.value *= factor;
            x.value = Math.Floor(x.value + 1e-12);
            x.value /= factor;
            return x;
        }

        private static double GetFactor(fsValue x, int precision)
        {
            double pMin = Math.Pow(10, precision - 1);
            double pMax = Math.Pow(10, precision);
            double factor = 1;
            fsValue result = x;

            while (Math.Abs(result.value) < pMin)
            {
                result.value *= 10;
                factor *= 10;
            }

            while (Math.Abs(result.value) >= pMax)
            {
                result.value /= 10;
                factor /= 10;
            }

            return factor;
        }

        public static fsValue Min(fsValue a, fsValue b)
        {
            return a < b ? a : b;
        }

        public static int EpsCompare(double x, double y, double eps)
        {
            double a = Math.Max(Math.Abs(x), Math.Abs(y));
            eps = Math.Max(eps, eps * a);
            if (Math.Abs(x - y) <= eps)
            {
                return 0;
            }
            return x < y ? -1 : 1;
        }

        public static fsValue One = new fsValue(1);
        public static fsValue Zero = new fsValue(0);
    }
}
