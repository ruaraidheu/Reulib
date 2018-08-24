using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ruaraidheulib.Interface.Obsolete.List;
using Ruaraidheulib.Interface.Win32.System.Numerics.Replacement;
using System.Collections;
using System.Globalization;

namespace Ruaraidheulib
{
    public static class List
    {
        private static Random rng = new Random();
        /// <summary>
        /// Randomly orders contents of list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        /// <summary>
        /// Randomly orders contents of list using cryptographic RNG.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void CryptoShuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static bool FindDuplicates<T>(this IList<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (list[i].Equals(list[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
#pragma warning disable CS0618 // Type or member is obsolete
        public static bool FindDuplicates<T>(this IList<T> list, out List<Twoint> twoint)
        {
            List<Twoint> ti = new List<Twoint>();
            bool dup = false;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (list[i].Equals(list[j]))
                    {
                        ti.Add(new Twoint(i, j));
                        dup = true;
                    }
                }
            }
            twoint = ti;
            return dup;
        }
        public static List<T> To1DList<T>(this Multiarray<T> arr)
        {
            List<T> list = arr.Array.Cast<T>().ToList();
            return list;
        }
        public static bool FindDuplicates<T>(this Multiarray<T> list)
        {
            for (int i = 0; i < list.Array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (list[i].Equals(list[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool FindDuplicates<T>(this Multiarray<T> list, out List<Twoint> twoint)
        {
            List<Twoint> ti = new List<Twoint>();
            bool dup = false;
            for (int i = 0; i < list.Array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (list[i].Equals(list[j]))
                    {
                        ti.Add(new Twoint(i, j));
                        dup = true;
                    }
                }
            }
            twoint = ti;
            return dup;
        }

        public static T[] TrueConcat<T>(this T[] tarr, T[] arr)
        {
            T[] rout = new T[tarr.Length + arr.Length];
            tarr.CopyTo(rout, 0);
            arr.CopyTo(rout, tarr.Length);
            return rout;
        }
        public static List<T> To1DList<T>(this List<List<T>> arr)
        {
            List<T> list;
            list = new List<T>();
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr[i].Count; j++)
                {
                    list.Add(arr[i][j]);
                }
            }
            return list;
        }
        public static List<T> To1DList<T>(this List<List<List<T>>> arr)
        {
            List<T> list;
            list = new List<T>();
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr[i].Count; j++)
                {
                    for (int k = 0; k < arr[i][j].Count; k++)
                    {
                        list.Add(arr[i][j][k]);
                    }
                }
            }
            return list;
        }
        public static List<T> To1DList<T>(this T[] arr)
        {
            List<T> list = arr.Cast<T>().ToList();
            return list;
        }
        public static List<T> To1DList<T>(this T[,] arr)
        {
            List<T> list = arr.Cast<T>().ToList();
            return list;
        }
        public static List<T> To1DList<T>(this T[,,] arr)
        {
            List<T> list = arr.Cast<T>().ToList();
            return list;
        }
        public static List<T> To1DList<T>(this T[,,,] arr)
        {
            List<T> list = arr.Cast<T>().ToList();
            return list;
        }
        public static int Length<T>(this List<T> l)
        {
            return l.Count;
        }
        public static int Count<T>(this T[] l)
        {
            return l.Length;
        }
        public static T GetIndex<T>(this List<T> list, int index)
        {
            if (list.Count>index)
            {
                return list[index];
            }
            else
            {
                return default(T);
            }
        }
        public static void RemoveIndex<T>(this List<T> list, int index)
        {
            if (list.Count > index)
            {
                list.RemoveAt(index);
            }
        }
        [Obsolete("Replace with Interface.Obsolete.List")]
        public struct Twoint
        {
            public Twoint(int x, int y)
            {
                _x = x;
                _y = y;
            }
            public int _x;
            public int _y;
            public int X
            {
                get { return _x; }
                set { _x = value; }
            }
            public int Y
            {
                get { return _y; }
                set { _y = value; }
            }
        }
        [Obsolete("Replace with Interface.Obsolete.List")]
        public struct Threeint
        {
            public Threeint(int x, int y, int z)
            {
                _x = x;
                _y = y;
                _z = z;
            }
            public int _x;
            public int _y;
            public int _z;
            public int X
            {
                get { return _x; }
                set { _x = value; }
            }
            public int Y
            {
                get { return _y; }
                set { _y = value; }
            }
            public int Z
            {
                get { return _z; }
                set { _z = value; }
            }
        }
        [Obsolete("Replace with Interface.Obsolete.List")]
        public struct Fourint
        {
            public Fourint(int x, int y, int z, int w)
            {
                _x = x;
                _y = y;
                _z = z;
                _w = w;
            }
            public int _x;
            public int _y;
            public int _z;
            public int _w;
            public int X { get { return _x; } set { _x = value; } }
            public int Y { get { return _y; } set { _y = value; } }
            public int Z { get { return _z; } set { _z = value; } }
            public int W { get { return _w; } set { _w = value; } }
        }
    }
    public struct TwoT<T>
    {
        public TwoT(T x, T y)
        {
            _x = x;
            _y = y;
        }
        T _x;
        T _y;
        public T X { get { return _x; } set { _x = value; } }
        public T Y { get { return _y; } set { _y = value; } }
    }
    public struct ThreeT<T>
    {
        public ThreeT(T x, T y, T z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
        T _x;
        T _y;
        T _z;
        public T X { get { return _x; } set { _x = value; } }
        public T Y { get { return _y; } set { _y = value; } }
        public T Z { get { return _z; } set { _z = value; } }
    }
    public struct FourT<T>
    {
        public FourT(T x, T y, T z, T w)
        {
            _x = x;
            _y = y;
            _z = z;
            _w = w;
        }
        T _x;
        T _y;
        T _z;
        T _w;
        public T X { get { return _x; } set { _x = value; } }
        public T Y { get { return _y; } set { _y = value; } }
        public T Z { get { return _z; } set { _z = value; } }
        public T W { get { return _w; } set { _w = value; } }
    }
    public struct nt<T> : IEnumerator
    {
        public nt(params T[] vals)
        {
            l = vals.To1DList();
            pos = -1;
        }
        void set(int ind, T val)
        {
            l = l ?? new List<T>();

            if (l.Count > ind)
            {
                l[ind] = val;
            }
            else
            {
                while(l.Count <= ind)
                {
                    l.Add(default(T));
                }
                l[ind] = val;
            }
        }
        T get(int ind)
        {
            l = l ?? new List<T>();

            if (l.Count > ind)
            {
                return l[ind];
            }
            else
            {
                while (l.Count <= ind)
                {
                    l.Add(default(T));
                }
                return l[ind];
            }
        }
        public List<T> To1DList()
        { return l; }
        public void From1DList(List<T> list)
        { l = list; }
        public void Concat(T[] arr)
        {
            Concat(arr.To1DList());
        }
        public void Concat(List<T> list)
        {
            foreach(T i in list)
            {
                l.Add(i);
            }
        }
        public List<T> TrueConcat(List<T> list)
        {
            List<T> ret = new List<T>();
            foreach(T i in l)
            {
                ret.Add(i);
            }
            foreach (T i in list)
            {
                ret.Add(i);
            }
            return ret;
        }
        public bool FindDuplicates()
        {
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (l[i].Equals(l[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool FindDuplicates(out List<TwoT<int>> locations)
        {
            bool ans = false;
            locations = new List<TwoT<int>>();
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (l[i].Equals(l[j]))
                    {
                        ans = true;
                        locations.Add(new TwoT<int>(i, j));
                    }
                }
            }
            return ans;
        }
        public void Shuffle()
        {
            Random rng = new Random();
            int n = l.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = l[k];
                l[k] = l[n];
                l[n] = value;
            }
        }
        public void CryptoShuffle()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = l.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = l[k];
                l[k] = l[n];
                l[n] = value;
            }
        }
        public nt<T> Dupe()
        {
            nt<T> ret = new nt<T>();
            ret.pos = pos;
            ret.l.AddRange(l);
            return ret;
        }
        public int Count { get { return l.Count; } }
        public int Length { get { return l.Count; } }
        public void Add(T val)
        {
            l.Add(val);
        }
        public void AddRange(IEnumerable<T> col)
        {
            l.AddRange(col);
        }
        public void Empty()
        {
            l.Clear();
        }
        public void Clear()
        {
            l.Clear();
        }
        public void ClearTo(T val)
        {
            for (int i = 0; i < Length; i++)
            {
                l[i] = val;
            }
        }
        public List<T> Direct()
        {
            return l;
        }

        List<T> l;

        public T this[int index] { get { return get(index); } set { set(index, value); } }
        public static implicit operator nt<T>(List<T> t)
        {
            nt<T> ret = new nt<T>();
            ret.From1DList(t);
            return ret;
        }
        public static implicit operator List<T>(nt<T> t)
        {
            List<T> ret;
            ret = t.To1DList();
            return ret;
        }
        public static implicit operator nt<T>(T[] t)
        {
            return t.To1DList();
        }
        public static implicit operator T[](nt<T> t)
        {
            T[] arr = t.l.Cast<T>().ToArray();
            return arr;
        }
        public static bool operator ==(nt<T> le, nt<T> r)
        {
            return le.Equals(r);
        }
        public static bool operator !=(nt<T> le, nt<T> r)
        {
            return !(le == r);
        }
        public static nt<T> operator +(nt<T> le, nt<T> r)
        {
            return le.TrueConcat(r);
        }
        public static nt<T> operator -(nt<T> le, int r)
        {
            if (le.Count >= r)
            {
                nt<T> ret = new nt<T>();
                for (int i = 0; i < ret.Count-r; i ++)
                {
                    ret.l.Add(le.l[i]);
                }
                return ret;
            }
            else
            {
                return new nt<T>();
            }
        }

        public bool TEquals(nt<T> eq)
        {
            bool ans = true;
            if (eq.l.Count == l.Count)
            {
                for (int i = 0; i < l.Count; i++)
                {
                    if (l[i].Equals(eq.l[i]))
                    {

                    }
                    else
                    {
                        ans = false;
                        break;
                    }
                }
            }
            else
            {
                ans = false;
            }
            return ans;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() is nt<T>)
            {
                return TEquals((nt<T>)obj);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return l.GetHashCode();
        }
        public override string ToString()
        {
            string ret = "";
            foreach(T i in l)
            {
                ret += i.ToString()+", ";
            }
            ret = ret.IfEndAndRemove(", ");
            return ret;
        }
        public bool MoveNext()
        {
            pos++;
            return pos < l.Count;
        }
        int pos;
        public void Reset()
        {
            pos = -1;
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        public object Current { get { return l[pos]; } }
    }

    public struct vector
    {
        private nt<double> vals;
        private int length;

        public vector(int count)
        {
            vals = new nt<double>();
            length = count;
            if (count > 0)
            {
                vals[count - 1] = 0;
            }
        }
        public vector(params double[] values)
        {
            vals = new nt<double>(values);
            length = values.Length;
        }

        public int Length
        {
            get { return length; }
        }
        public vector Zero
        {
            get
            {
                return SZero(length);
            }
        }
        #region Static
        public static vector SZero(int length)
        {
            vector ret = new vector(length);
            return ret;
        }
        public static vector SOne(int length)
        {
            vector ret = new vector(length);
            ret.vals.ClearTo(1);
            return ret;
        }
        #endregion
        
    }
    public struct vector2 : IEquatable<vector2>
    {
        #region Private Fields

        private static vector2 zeroVector = new vector2(0f, 0f);
        private static vector2 unitVector = new vector2(1f, 1f);
        private static vector2 unitXVector = new vector2(1f, 0f);
        private static vector2 unitYVector = new vector2(0f, 1f);

        #endregion Private Fields


        #region Public Fields

        public double X;
        public double Y;

        #endregion Public Fields


        #region Properties

        public static vector2 Zero
        {
            get { return zeroVector; }
        }

        public static vector2 One
        {
            get { return unitVector; }
        }

        public static vector2 UnitX
        {
            get { return unitXVector; }
        }

        public static vector2 UnitY
        {
            get { return unitYVector; }
        }

        #endregion Properties


        #region Constructors

        public vector2(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public vector2(vector2 v2)
        {
            this.X = v2.X;
            this.Y = v2.Y;
        }

        public vector2(double value)
        {
            this.X = value;
            this.Y = value;
        }

        #endregion Constructors


        #region Public Methods

        public static vector2 Add(vector2 value1, vector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }

        public static void Add(ref vector2 value1, ref vector2 value2, out vector2 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
        }

        public static vector2 Barycentric(vector2 value1, vector2 value2, vector2 value3, float amount1, double amount2)
        {
            return new vector2(
                k.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                k.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2));
        }

        public static void Barycentric(ref vector2 value1, ref vector2 value2, ref vector2 value3, double amount1, double amount2, out vector2 result)
        {
            result = new vector2(
                k.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                k.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2));
        }

        public static vector2 CatmullRom(vector2 value1, vector2 value2, vector2 value3, vector2 value4, double amount)
        {
            return new vector2(
                k.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                k.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount));
        }

        public static void CatmullRom(ref vector2 value1, ref vector2 value2, ref vector2 value3, ref vector2 value4, double amount, out vector2 result)
        {
            result = new vector2(
                k.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                k.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount));
        }

        public static vector2 Clamp(vector2 value1, vector2 min, vector2 max)
        {
            return new vector2(
                k.Clamp(value1.X, min.X, max.X),
                k.Clamp(value1.Y, min.Y, max.Y));
        }

        public static void Clamp(ref vector2 value1, ref vector2 min, ref vector2 max, out vector2 result)
        {
            result = new vector2(
                k.Clamp(value1.X, min.X, max.X),
                k.Clamp(value1.Y, min.Y, max.Y));
        }

        public static double Distance(vector2 value1, vector2 value2)
        {
            double v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
            return Math.Sqrt((v1 * v1) + (v2 * v2));
        }

        public static void Distance(ref vector2 value1, ref vector2 value2, out double result)
        {
            double v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
            result = Math.Sqrt((v1 * v1) + (v2 * v2));
        }

        public static double DistanceSquared(vector2 value1, vector2 value2)
        {
            double v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
            return (v1 * v1) + (v2 * v2);
        }

        public static void DistanceSquared(ref vector2 value1, ref vector2 value2, out double result)
        {
            double v1 = value1.X - value2.X, v2 = value1.Y - value2.Y;
            result = (v1 * v1) + (v2 * v2);
        }

        public static vector2 Divide(vector2 value1, vector2 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            return value1;
        }

        public static void Divide(ref vector2 value1, ref vector2 value2, out vector2 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
        }

        public static vector2 Divide(vector2 value1, double divider)
        {
            double factor = 1 / divider;
            value1.X *= factor;
            value1.Y *= factor;
            return value1;
        }

        public static void Divide(ref vector2 value1, double divider, out vector2 result)
        {
            double factor = 1 / divider;
            result.X = value1.X * factor;
            result.Y = value1.Y * factor;
        }

        public static double Dot(vector2 value1, vector2 value2)
        {
            return (value1.X * value2.X) + (value1.Y * value2.Y);
        }

        public static void Dot(ref vector2 value1, ref vector2 value2, out double result)
        {
            result = (value1.X * value2.X) + (value1.Y * value2.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is vector2)
            {
                return Equals((vector2)this);
            }

            return false;
        }

        public bool Equals(vector2 other)
        {
            return (X == other.X) && (Y == other.Y);
        }

        public static vector2 Reflect(vector2 vector, vector2 normal)
        {
            vector2 result;
            double val = 2.0f * ((vector.X * normal.X) + (vector.Y * normal.Y));
            result.X = vector.X - (normal.X * val);
            result.Y = vector.Y - (normal.Y * val);
            return result;
        }

        public static void Reflect(ref vector2 vector, ref vector2 normal, out vector2 result)
        {
            double val = 2.0f * ((vector.X * normal.X) + (vector.Y * normal.Y));
            result.X = vector.X - (normal.X * val);
            result.Y = vector.Y - (normal.Y * val);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public static vector2 Hermite(vector2 value1, vector2 tangent1, vector2 value2, vector2 tangent2, double amount)
        {
            vector2 result = new vector2();
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            return result;
        }

        public static void Hermite(ref vector2 value1, ref vector2 tangent1, ref vector2 value2, ref vector2 tangent2, double amount, out vector2 result)
        {
            result.X = k.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
            result.Y = k.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
        }

        public double Length()
        {
            return Math.Sqrt((X * X) + (Y * Y));
        }

        public double LengthSquared()
        {
            return (X * X) + (Y * Y);
        }

        public static vector2 Lerp(vector2 value1, vector2 value2, double amount)
        {
            return new vector2(
                k.Lerp(value1.X, value2.X, amount),
                k.Lerp(value1.Y, value2.Y, amount));
        }

        public static void Lerp(ref vector2 value1, ref vector2 value2, double amount, out vector2 result)
        {
            result = new vector2(
                k.Lerp(value1.X, value2.X, amount),
                k.Lerp(value1.Y, value2.Y, amount));
        }

        public static vector2 Max(vector2 value1, vector2 value2)
        {
            return new vector2(value1.X > value2.X ? value1.X : value2.X,
                               value1.Y > value2.Y ? value1.Y : value2.Y);
        }

        public static void Max(ref vector2 value1, ref vector2 value2, out vector2 result)
        {
            result.X = value1.X > value2.X ? value1.X : value2.X;
            result.Y = value1.Y > value2.Y ? value1.Y : value2.Y;
        }

        public static vector2 Min(vector2 value1, vector2 value2)
        {
            return new vector2(value1.X < value2.X ? value1.X : value2.X,
                               value1.Y < value2.Y ? value1.Y : value2.Y);
        }

        public static void Min(ref vector2 value1, ref vector2 value2, out vector2 result)
        {
            result.X = value1.X < value2.X ? value1.X : value2.X;
            result.Y = value1.Y < value2.Y ? value1.Y : value2.Y;
        }

        public static vector2 Multiply(vector2 value1, vector2 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            return value1;
        }

        public static vector2 Multiply(vector2 value1, double scaleFactor)
        {
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            return value1;
        }

        public static void Multiply(ref vector2 value1, float scaleFactor, out vector2 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
        }

        public static void Multiply(ref vector2 value1, ref vector2 value2, out vector2 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
        }

        public static vector2 Negate(vector2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            return value;
        }

        public static void Negate(ref vector2 value, out vector2 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
        }

        public void Normalize()
        {
            double val = 1.0f / Math.Sqrt((X * X) + (Y * Y));
            X *= val;
            Y *= val;
        }

        public static vector2 Normalize(vector2 value)
        {
            double val = 1.0f / Math.Sqrt((value.X * value.X) + (value.Y * value.Y));
            value.X *= val;
            value.Y *= val;
            return value;
        }

        public static void Normalize(ref vector2 value, out vector2 result)
        {
            double val = 1.0f / Math.Sqrt((value.X * value.X) + (value.Y * value.Y));
            result.X = value.X * val;
            result.Y = value.Y * val;
        }

        public static vector2 SmoothStep(vector2 value1, vector2 value2, double amount)
        {
            return new vector2(
                k.SmoothStep(value1.X, value2.X, amount),
                k.SmoothStep(value1.Y, value2.Y, amount));
        }

        public static void SmoothStep(ref vector2 value1, ref vector2 value2, double amount, out vector2 result)
        {
            result = new vector2(
                k.SmoothStep(value1.X, value2.X, amount),
                k.SmoothStep(value1.Y, value2.Y, amount));
        }

        public static vector2 Subtract(vector2 value1, vector2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }

        public static void Subtract(ref vector2 value1, ref vector2 value2, out vector2 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
        }

        public static vector2 Transform(vector2 position, matrix matrix)
        {
            Transform(ref position, ref matrix, out position);
            return position;
        }

        public static void Transform(ref vector2 position, ref matrix matrix, out vector2 result)
        {
            result = new vector2((position.X * matrix.M11) + (position.Y * matrix.M21) + matrix.M41,
                                 (position.X * matrix.M12) + (position.Y * matrix.M22) + matrix.M42);
        }

        public static void Transform(
         vector2[] sourceArray,
         ref matrix matrix,
         vector2[] destinationArray)
        {
        }


        public static void Transform(
         vector2[] sourceArray,
         int sourceIndex,
         ref matrix matrix,
         vector2[] destinationArray,
         int destinationIndex,
         int length)
        {
        }

        public static vector2 TransformNormal(vector2 normal, matrix matrix)
        {
            vector2.TransformNormal(ref normal, ref matrix, out normal);
            return normal;
        }

        public static void TransformNormal(ref vector2 normal, ref matrix matrix, out vector2 result)
        {
            result = new vector2((normal.X * matrix.M11) + (normal.Y * matrix.M21),
                                 (normal.X * matrix.M12) + (normal.Y * matrix.M22));
        }

        public override string ToString()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            return string.Format(currentCulture, "{{X:{0} Y:{1}}}", new object[] {
                this.X.ToString(currentCulture), this.Y.ToString(currentCulture) });
        }

        #endregion Public Methods


        #region Operators

        public static vector2 operator -(vector2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            return value;
        }


        public static bool operator ==(vector2 value1, vector2 value2)
        {
            return value1.X == value2.X && value1.Y == value2.Y;
        }


        public static bool operator !=(vector2 value1, vector2 value2)
        {
            return value1.X != value2.X || value1.Y != value2.Y;
        }


        public static vector2 operator +(vector2 value1, vector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }


        public static vector2 operator -(vector2 value1, vector2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }


        public static vector2 operator *(vector2 value1, vector2 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            return value1;
        }


        public static vector2 operator *(vector2 value, double scaleFactor)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }


        public static vector2 operator *(double scaleFactor, vector2 value)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }


        public static vector2 operator /(vector2 value1, vector2 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            return value1;
        }


        public static vector2 operator /(vector2 value1, double divider)
        {
            double factor = 1 / divider;
            value1.X *= factor;
            value1.Y *= factor;
            return value1;
        }

        #endregion Operators  
    }
    public struct vector3 : IEquatable<vector3>
    {
        #region Private Fields

        private static vector3 zero = new vector3(0f, 0f, 0f);
        private static vector3 one = new vector3(1f, 1f, 1f);
        private static vector3 unitX = new vector3(1f, 0f, 0f);
        private static vector3 unitY = new vector3(0f, 1f, 0f);
        private static vector3 unitZ = new vector3(0f, 0f, 1f);
        private static vector3 up = new vector3(0f, 1f, 0f);
        private static vector3 down = new vector3(0f, -1f, 0f);
        private static vector3 right = new vector3(1f, 0f, 0f);
        private static vector3 left = new vector3(-1f, 0f, 0f);
        private static vector3 forward = new vector3(0f, 0f, -1f);
        private static vector3 backward = new vector3(0f, 0f, 1f);

        #endregion Private Fields


        #region Public Fields

        public double X;
        public double Y;
        public double Z;

        #endregion Public Fields


        #region Properties

        public static vector3 Zero
        {
            get { return zero; }
        }

        public static vector3 One
        {
            get { return one; }
        }

        public static vector3 UnitX
        {
            get { return unitX; }
        }

        public static vector3 UnitY
        {
            get { return unitY; }
        }

        public static vector3 UnitZ
        {
            get { return unitZ; }
        }

        public static vector3 Up
        {
            get { return up; }
        }

        public static vector3 Down
        {
            get { return down; }
        }

        public static vector3 Right
        {
            get { return right; }
        }

        public static vector3 Left
        {
            get { return left; }
        }

        public static vector3 Forward
        {
            get { return forward; }
        }

        public static vector3 Backward
        {
            get { return backward; }
        }

        #endregion Properties


        #region Constructors

        public vector3(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }


        public vector3(double value)
        {
            this.X = value;
            this.Y = value;
            this.Z = value;
        }


        public vector3(vector2 value, double z)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
        }


        #endregion Constructors


        #region Public Methods

        public static vector3 Add(vector3 value1, vector3 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

        public static void Add(ref vector3 value1, ref vector3 value2, out vector3 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
        }

        public static vector3 Barycentric(vector3 value1, vector3 value2, vector3 value3, double amount1, double amount2)
        {
            return new vector3(
                k.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                k.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                k.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2));
        }

        public static void Barycentric(ref vector3 value1, ref vector3 value2, ref vector3 value3, double amount1, double amount2, out vector3 result)
        {
            result = new vector3(
                k.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                k.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                k.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2));
        }

        public static vector3 CatmullRom(vector3 value1, vector3 value2, vector3 value3, vector3 value4, double amount)
        {
            return new vector3(
                k.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                k.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                k.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount));
        }

        public static void CatmullRom(ref vector3 value1, ref vector3 value2, ref vector3 value3, ref vector3 value4, double amount, out vector3 result)
        {
            result = new vector3(
                k.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                k.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                k.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount));
        }

        public static vector3 Clamp(vector3 value1, vector3 min, vector3 max)
        {
            return new vector3(
                k.Clamp(value1.X, min.X, max.X),
                k.Clamp(value1.Y, min.Y, max.Y),
                k.Clamp(value1.Z, min.Z, max.Z));
        }

        public static void Clamp(ref vector3 value1, ref vector3 min, ref vector3 max, out vector3 result)
        {
            result = new vector3(
                k.Clamp(value1.X, min.X, max.X),
                k.Clamp(value1.Y, min.Y, max.Y),
                k.Clamp(value1.Z, min.Z, max.Z));
        }

        public static vector3 Cross(vector3 vector1, vector3 vector2)
        {
            Cross(ref vector1, ref vector2, out vector1);
            return vector1;
        }

        public static void Cross(ref vector3 vector1, ref vector3 vector2, out vector3 result)
        {
            result = new vector3(vector1.Y * vector2.Z - vector2.Y * vector1.Z,
                                 -(vector1.X * vector2.Z - vector2.X * vector1.Z),
                                 vector1.X * vector2.Y - vector2.X * vector1.Y);
        }

        public static double Distance(vector3 vector1, vector3 vector2)
        {
            double result;
            DistanceSquared(ref vector1, ref vector2, out result);
            return Math.Sqrt(result);
        }

        public static void Distance(ref vector3 value1, ref vector3 value2, out double result)
        {
            DistanceSquared(ref value1, ref value2, out result);
            result = Math.Sqrt(result);
        }

        public static double DistanceSquared(vector3 value1, vector3 value2)
        {
            double result;
            DistanceSquared(ref value1, ref value2, out result);
            return result;
        }

        public static void DistanceSquared(ref vector3 value1, ref vector3 value2, out double result)
        {
            result = (value1.X - value2.X) * (value1.X - value2.X) +
                     (value1.Y - value2.Y) * (value1.Y - value2.Y) +
                     (value1.Z - value2.Z) * (value1.Z - value2.Z);
        }

        public static vector3 Divide(vector3 value1, vector3 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        public static vector3 Divide(vector3 value1, double value2)
        {
            double factor = 1 / value2;
            value1.X *= factor;
            value1.Y *= factor;
            value1.Z *= factor;
            return value1;
        }

        public static void Divide(ref vector3 value1, double divisor, out vector3 result)
        {
            double factor = 1 / divisor;
            result.X = value1.X * factor;
            result.Y = value1.Y * factor;
            result.Z = value1.Z * factor;
        }

        public static void Divide(ref vector3 value1, ref vector3 value2, out vector3 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
        }

        public static double Dot(vector3 vector1, vector3 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        public static void Dot(ref vector3 vector1, ref vector3 vector2, out double result)
        {
            result = vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        public override bool Equals(object obj)
        {
            return (obj is vector3) ? this == (vector3)obj : false;
        }

        public bool Equals(vector3 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            return (int)(this.X + this.Y + this.Z);
        }

        public static vector3 Hermite(vector3 value1, vector3 tangent1, vector3 value2, vector3 tangent2, double amount)
        {
            vector3 result = new vector3();
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            return result;
        }

        public static void Hermite(ref vector3 value1, ref vector3 tangent1, ref vector3 value2, ref vector3 tangent2, double amount, out vector3 result)
        {
            result.X = k.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
            result.Y = k.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
            result.Z = k.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
        }

        public double Length()
        {
            double result;
            DistanceSquared(ref this, ref zero, out result);
            return Math.Sqrt(result);
        }

        public double LengthSquared()
        {
            double result;
            DistanceSquared(ref this, ref zero, out result);
            return result;
        }

        public static vector3 Lerp(vector3 value1, vector3 value2, double amount)
        {
            return new vector3(
                k.Lerp(value1.X, value2.X, amount),
                k.Lerp(value1.Y, value2.Y, amount),
                k.Lerp(value1.Z, value2.Z, amount));
        }

        public static void Lerp(ref vector3 value1, ref vector3 value2, double amount, out vector3 result)
        {
            result = new vector3(
                k.Lerp(value1.X, value2.X, amount),
                k.Lerp(value1.Y, value2.Y, amount),
                k.Lerp(value1.Z, value2.Z, amount));
        }

        public static vector3 Max(vector3 value1, vector3 value2)
        {
            return new vector3(
                k.Max(value1.X, value2.X),
                k.Max(value1.Y, value2.Y),
                k.Max(value1.Z, value2.Z));
        }

        public static void Max(ref vector3 value1, ref vector3 value2, out vector3 result)
        {
            result = new vector3(
                k.Max(value1.X, value2.X),
                k.Max(value1.Y, value2.Y),
                k.Max(value1.Z, value2.Z));
        }

        public static vector3 Min(vector3 value1, vector3 value2)
        {
            return new vector3(
                k.Min(value1.X, value2.X),
                k.Min(value1.Y, value2.Y),
                k.Min(value1.Z, value2.Z));
        }

        public static void Min(ref vector3 value1, ref vector3 value2, out vector3 result)
        {
            result = new vector3(
                k.Min(value1.X, value2.X),
                k.Min(value1.Y, value2.Y),
                k.Min(value1.Z, value2.Z));
        }

        public static vector3 Multiply(vector3 value1, vector3 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        public static vector3 Multiply(vector3 value1, double scaleFactor)
        {
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            value1.Z *= scaleFactor;
            return value1;
        }

        public static void Multiply(ref vector3 value1, double scaleFactor, out vector3 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
            result.Z = value1.Z * scaleFactor;
        }

        public static void Multiply(ref vector3 value1, ref vector3 value2, out vector3 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
        }

        public static vector3 Negate(vector3 value)
        {
            value = new vector3(-value.X, -value.Y, -value.Z);
            return value;
        }

        public static void Negate(ref vector3 value, out vector3 result)
        {
            result = new vector3(-value.X, -value.Y, -value.Z);
        }

        public void Normalize()
        {
            Normalize(ref this, out this);
        }

        public static vector3 Normalize(vector3 vector)
        {
            Normalize(ref vector, out vector);
            return vector;
        }

        public static void Normalize(ref vector3 value, out vector3 result)
        {
            double factor;
            Distance(ref value, ref zero, out factor);
            factor = 1f / factor;
            result.X = value.X * factor;
            result.Y = value.Y * factor;
            result.Z = value.Z * factor;
        }

        public static vector3 Reflect(vector3 vector, vector3 normal)
        {
            // I is the original array
            // N is the normal of the incident plane
            // R = I - (2 * N * ( DotProduct[ I,N] ))
            vector3 reflectedVector;
            // inline the dotProduct here instead of calling method
            double dotProduct = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
            reflectedVector.X = vector.X - (2.0 * normal.X) * dotProduct;
            reflectedVector.Y = vector.Y - (2.0 * normal.Y) * dotProduct;
            reflectedVector.Z = vector.Z - (2.0 * normal.Z) * dotProduct;

            return reflectedVector;
        }

        public static void Reflect(ref vector3 vector, ref vector3 normal, out vector3 result)
        {
            // I is the original array
            // N is the normal of the incident plane
            // R = I - (2 * N * ( DotProduct[ I,N] ))

            // inline the dotProduct here instead of calling method
            double dotProduct = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
            result.X = vector.X - (2.0 * normal.X) * dotProduct;
            result.Y = vector.Y - (2.0 * normal.Y) * dotProduct;
            result.Z = vector.Z - (2.0 * normal.Z) * dotProduct;
        }

        public static vector3 SmoothStep(vector3 value1, vector3 value2, double amount)
        {
            return new vector3(
                k.SmoothStep(value1.X, value2.X, amount),
                k.SmoothStep(value1.Y, value2.Y, amount),
                k.SmoothStep(value1.Z, value2.Z, amount));
        }

        public static void SmoothStep(ref vector3 value1, ref vector3 value2, double amount, out vector3 result)
        {
            result = new vector3(
                k.SmoothStep(value1.X, value2.X, amount),
                k.SmoothStep(value1.Y, value2.Y, amount),
                k.SmoothStep(value1.Z, value2.Z, amount));
        }

        public static vector3 Subtract(vector3 value1, vector3 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            return value1;
        }

        public static void Subtract(ref vector3 value1, ref vector3 value2, out vector3 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(32);
            sb.Append("{X:");
            sb.Append(this.X);
            sb.Append(" Y:");
            sb.Append(this.Y);
            sb.Append(" Z:");
            sb.Append(this.Z);
            sb.Append("}");
            return sb.ToString();
        }

        public static vector3 Transform(vector3 position, matrix matrix)
        {
            Transform(ref position, ref matrix, out position);
            return position;
        }

        public static void Transform(ref vector3 position, ref matrix matrix, out vector3 result)
        {
            result = new vector3((position.X * matrix.M11) + (position.Y * matrix.M21) + (position.Z * matrix.M31) + matrix.M41,
                                 (position.X * matrix.M12) + (position.Y * matrix.M22) + (position.Z * matrix.M32) + matrix.M42,
                                 (position.X * matrix.M13) + (position.Y * matrix.M23) + (position.Z * matrix.M33) + matrix.M43);
        }

        public static vector3 Transform(vector3 value, quaternion rotation)
        {
            vector3 result;
            Transform(ref value, ref rotation, out result);
            return result;
        }

        public static void Transform(ref vector3 value, ref quaternion rotation, out vector3 result)
        {
            double x = 2 * (rotation.Y * value.Z - rotation.Z * value.Y);
            double y = 2 * (rotation.Z * value.X - rotation.X * value.Z);
            double z = 2 * (rotation.X * value.Y - rotation.Y * value.X);

            result.X = value.X + x * rotation.W + (rotation.Y * z - rotation.Z * y);
            result.Y = value.Y + y * rotation.W + (rotation.Z * x - rotation.X * z);
            result.Z = value.Z + z * rotation.W + (rotation.X * y - rotation.Y * x);
        }

        public static void Transform(vector3[] sourceArray, int sourceIndex, ref matrix matrix, vector3[] destinationArray, int destinationIndex, int length)
        {
            if (sourceArray == null)
                throw new ArgumentNullException("sourceArray");
            if (destinationArray == null)
                throw new ArgumentNullException("destinationArray");
            if (sourceArray.Length < sourceIndex + length)
                throw new ArgumentException("Source array length is lesser than sourceIndex + length");
            if (destinationArray.Length < destinationIndex + length)
                throw new ArgumentException("Destination array length is lesser than destinationIndex + length");

            // TODO: Are there options on some platforms to implement a vectorized version of this?

            for (int i = 0; i < length; i++)
            {
                vector3 position = sourceArray[sourceIndex + i];
                destinationArray[destinationIndex + i] =
                    new vector3(
                        (position.X * matrix.M11) + (position.Y * matrix.M21) + (position.Z * matrix.M31) + matrix.M41,
                        (position.X * matrix.M12) + (position.Y * matrix.M22) + (position.Z * matrix.M32) + matrix.M42,
                        (position.X * matrix.M13) + (position.Y * matrix.M23) + (position.Z * matrix.M33) + matrix.M43);
            }
        }
        
        public static void Transform(vector3[] sourceArray, int sourceIndex, ref quaternion rotation, vector3[] destinationArray, int destinationIndex, int length)
        {
            if (sourceArray == null)
                throw new ArgumentNullException("sourceArray");
            if (destinationArray == null)
                throw new ArgumentNullException("destinationArray");
            if (sourceArray.Length < sourceIndex + length)
                throw new ArgumentException("Source array length is lesser than sourceIndex + length");
            if (destinationArray.Length < destinationIndex + length)
                throw new ArgumentException("Destination array length is lesser than destinationIndex + length");

            // TODO: Are there options on some platforms to implement a vectorized version of this?

            for (int i = 0; i < length; i++)
            {
                vector3 position = sourceArray[sourceIndex + i];

                double x = 2 * (rotation.Y * position.Z - rotation.Z * position.Y);
                double y = 2 * (rotation.Z * position.X - rotation.X * position.Z);
                double z = 2 * (rotation.X * position.Y - rotation.Y * position.X);

                destinationArray[destinationIndex + i] =
                    new vector3(
                        position.X + x * rotation.W + (rotation.Y * z - rotation.Z * y),
                        position.Y + y * rotation.W + (rotation.Z * x - rotation.X * z),
                        position.Z + z * rotation.W + (rotation.X * y - rotation.Y * x));
            }
        }
        
        public static void Transform(vector3[] sourceArray, ref matrix matrix, vector3[] destinationArray)
        {
            if (sourceArray == null)
                throw new ArgumentNullException("sourceArray");
            if (destinationArray == null)
                throw new ArgumentNullException("destinationArray");
            if (destinationArray.Length < sourceArray.Length)
                throw new ArgumentException("Destination array length is lesser than source array length");

            // TODO: Are there options on some platforms to implement a vectorized version of this?

            for (int i = 0; i < sourceArray.Length; i++)
            {
                vector3 position = sourceArray[i];
                destinationArray[i] =
                    new vector3(
                        (position.X * matrix.M11) + (position.Y * matrix.M21) + (position.Z * matrix.M31) + matrix.M41,
                        (position.X * matrix.M12) + (position.Y * matrix.M22) + (position.Z * matrix.M32) + matrix.M42,
                        (position.X * matrix.M13) + (position.Y * matrix.M23) + (position.Z * matrix.M33) + matrix.M43);
            }
        }

        public static void Transform(vector3[] sourceArray, ref quaternion rotation, vector3[] destinationArray)
        {
            if (sourceArray == null)
                throw new ArgumentNullException("sourceArray");
            if (destinationArray == null)
                throw new ArgumentNullException("destinationArray");
            if (destinationArray.Length < sourceArray.Length)
                throw new ArgumentException("Destination array length is lesser than source array length");

            // TODO: Are there options on some platforms to implement a vectorized version of this?

            for (int i = 0; i < sourceArray.Length; i++)
            {
                vector3 position = sourceArray[i];

                double x = 2 * (rotation.Y * position.Z - rotation.Z * position.Y);
                double y = 2 * (rotation.Z * position.X - rotation.X * position.Z);
                double z = 2 * (rotation.X * position.Y - rotation.Y * position.X);

                destinationArray[i] =
                    new vector3(
                        position.X + x * rotation.W + (rotation.Y * z - rotation.Z * y),
                        position.Y + y * rotation.W + (rotation.Z * x - rotation.X * z),
                        position.Z + z * rotation.W + (rotation.X * y - rotation.Y * x));
            }
        }

        public static vector3 TransformNormal(vector3 normal, matrix matrix)
        {
            TransformNormal(ref normal, ref matrix, out normal);
            return normal;
        }

        public static void TransformNormal(ref vector3 normal, ref matrix matrix, out vector3 result)
        {
            result = new vector3((normal.X * matrix.M11) + (normal.Y * matrix.M21) + (normal.Z * matrix.M31),
                                 (normal.X * matrix.M12) + (normal.Y * matrix.M22) + (normal.Z * matrix.M32),
                                 (normal.X * matrix.M13) + (normal.Y * matrix.M23) + (normal.Z * matrix.M33));
        }

        #endregion Public methods


        #region Operators

        public static bool operator ==(vector3 value1, vector3 value2)
        {
            return value1.X == value2.X
                && value1.Y == value2.Y
                && value1.Z == value2.Z;
        }

        public static bool operator !=(vector3 value1, vector3 value2)
        {
            return !(value1 == value2);
        }

        public static vector3 operator +(vector3 value1, vector3 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

        public static vector3 operator -(vector3 value)
        {
            value = new vector3(-value.X, -value.Y, -value.Z);
            return value;
        }

        public static vector3 operator -(vector3 value1, vector3 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            return value1;
        }

        public static vector3 operator *(vector3 value1, vector3 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        public static vector3 operator *(vector3 value, double scaleFactor)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            value.Z *= scaleFactor;
            return value;
        }

        public static vector3 operator *(double scaleFactor, vector3 value)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            value.Z *= scaleFactor;
            return value;
        }

        public static vector3 operator /(vector3 value1, vector3 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        public static vector3 operator /(vector3 value, double divider)
        {
            double factor = 1 / divider;
            value.X *= factor;
            value.Y *= factor;
            value.Z *= factor;
            return value;
        }

        #endregion
    }
    public struct vector4 : IEquatable<vector4>
    {
        #region Private Fields

        private static vector4 zeroVector = new vector4();
        private static vector4 unitVector = new vector4(1, 1, 1, 1);
        private static vector4 unitXVector = new vector4(1, 0, 0, 0);
        private static vector4 unitYVector = new vector4(0, 1, 0, 0);
        private static vector4 unitZVector = new vector4(0, 0, 1, 0);
        private static vector4 unitWVector = new vector4(0, 0, 0, 1);

        #endregion Private Fields


        #region Public Fields

        public double X;
        public double Y;
        public double Z;
        public double W;

        #endregion Public Fields


        #region Properties

        public static vector4 Zero
        {
            get { return zeroVector; }
        }

        public static vector4 One
        {
            get { return unitVector; }
        }

        public static vector4 UnitX
        {
            get { return unitXVector; }
        }

        public static vector4 UnitY
        {
            get { return unitYVector; }
        }

        public static vector4 UnitZ
        {
            get { return unitZVector; }
        }

        public static vector4 UnitW
        {
            get { return unitWVector; }
        }

        #endregion Properties


        #region Constructors

        public vector4(double x, double y, double z, double w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public vector4(vector2 value, double z, double w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = z;
            this.W = w;
        }

        public vector4(vector3 value, double w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
            this.W = w;
        }

        public vector4(double value)
        {
            this.X = value;
            this.Y = value;
            this.Z = value;
            this.W = value;
        }

        #endregion


        #region Public Methods

        public static vector4 Add(vector4 value1, vector4 value2)
        {
            value1.W += value2.W;
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

        public static void Add(ref vector4 value1, ref vector4 value2, out vector4 result)
        {
            result.W = value1.W + value2.W;
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
            result.Z = value1.Z + value2.Z;
        }

        public static vector4 Barycentric(vector4 value1, vector4 value2, vector4 value3, double amount1, double amount2)
        {
            return new vector4(
                k.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                k.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                k.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2),
                k.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
        }

        public static void Barycentric(ref vector4 value1, ref vector4 value2, ref vector4 value3, double amount1, double amount2, out vector4 result)
        {
            result = new vector4(
                k.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                k.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                k.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2),
                k.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
        }

        public static vector4 CatmullRom(vector4 value1, vector4 value2, vector4 value3, vector4 value4, double amount)
        {
            return new vector4(
                k.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                k.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                k.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount),
                k.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
        }

        public static void CatmullRom(ref vector4 value1, ref vector4 value2, ref vector4 value3, ref vector4 value4, double amount, out vector4 result)
        {
            result = new vector4(
                k.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                k.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                k.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount),
                k.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
        }

        public static vector4 Clamp(vector4 value1, vector4 min, vector4 max)
        {
            return new vector4(
                k.Clamp(value1.X, min.X, max.X),
                k.Clamp(value1.Y, min.Y, max.Y),
                k.Clamp(value1.Z, min.Z, max.Z),
                k.Clamp(value1.W, min.W, max.W));
        }

        public static void Clamp(ref vector4 value1, ref vector4 min, ref vector4 max, out vector4 result)
        {
            result = new vector4(
                k.Clamp(value1.X, min.X, max.X),
                k.Clamp(value1.Y, min.Y, max.Y),
                k.Clamp(value1.Z, min.Z, max.Z),
                k.Clamp(value1.W, min.W, max.W));
        }

        public static double Distance(vector4 value1, vector4 value2)
        {
            return Math.Sqrt(DistanceSquared(value1, value2));
        }

        public static void Distance(ref vector4 value1, ref vector4 value2, out double result)
        {
            result = Math.Sqrt(DistanceSquared(value1, value2));
        }

        public static double DistanceSquared(vector4 value1, vector4 value2)
        {
            double result;
            DistanceSquared(ref value1, ref value2, out result);
            return result;
        }

        public static void DistanceSquared(ref vector4 value1, ref vector4 value2, out double result)
        {
            result = (value1.W - value2.W) * (value1.W - value2.W) +
                     (value1.X - value2.X) * (value1.X - value2.X) +
                     (value1.Y - value2.Y) * (value1.Y - value2.Y) +
                     (value1.Z - value2.Z) * (value1.Z - value2.Z);
        }

        public static vector4 Divide(vector4 value1, vector4 value2)
        {
            value1.W /= value2.W;
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        public static vector4 Divide(vector4 value1, double divider)
        {
            double factor = 1d / divider;
            value1.W *= factor;
            value1.X *= factor;
            value1.Y *= factor;
            value1.Z *= factor;
            return value1;
        }

        public static void Divide(ref vector4 value1, double divider, out vector4 result)
        {
            double factor = 1d / divider;
            result.W = value1.W * factor;
            result.X = value1.X * factor;
            result.Y = value1.Y * factor;
            result.Z = value1.Z * factor;
        }

        public static void Divide(ref vector4 value1, ref vector4 value2, out vector4 result)
        {
            result.W = value1.W / value2.W;
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
            result.Z = value1.Z / value2.Z;
        }

        public static double Dot(vector4 vector1, vector4 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z + vector1.W * vector2.W;
        }

        public static void Dot(ref vector4 vector1, ref vector4 vector2, out double result)
        {
            result = vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z + vector1.W * vector2.W;
        }

        public override bool Equals(object obj)
        {
            return (obj is vector4) ? this == (vector4)obj : false;
        }

        public bool Equals(vector4 other)
        {
            return this.W == other.W
                && this.X == other.X
                && this.Y == other.Y
                && this.Z == other.Z;
        }

        public override int GetHashCode()
        {
            return (int)(this.W + this.X + this.Y + this.Y);
        }

        public static vector4 Hermite(vector4 value1, vector4 tangent1, vector4 value2, vector4 tangent2, double amount)
        {
            vector4 result = new vector4();
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
            return result;
        }

        public static void Hermite(ref vector4 value1, ref vector4 tangent1, ref vector4 value2, ref vector4 tangent2, double amount, out vector4 result)
        {
            result.W = k.Hermite(value1.W, tangent1.W, value2.W, tangent2.W, amount);
            result.X = k.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
            result.Y = k.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
            result.Z = k.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
        }

        public double Length()
        {
            double result;
            DistanceSquared(ref this, ref zeroVector, out result);
            return Math.Sqrt(result);
        }

        public double LengthSquared()
        {
            double result;
            DistanceSquared(ref this, ref zeroVector, out result);
            return result;
        }

        public static vector4 Lerp(vector4 value1, vector4 value2, double amount)
        {
            return new vector4(
                k.Lerp(value1.X, value2.X, amount),
                k.Lerp(value1.Y, value2.Y, amount),
                k.Lerp(value1.Z, value2.Z, amount),
                k.Lerp(value1.W, value2.W, amount));
        }

        public static void Lerp(ref vector4 value1, ref vector4 value2, double amount, out vector4 result)
        {
            result = new vector4(
                k.Lerp(value1.X, value2.X, amount),
                k.Lerp(value1.Y, value2.Y, amount),
                k.Lerp(value1.Z, value2.Z, amount),
                k.Lerp(value1.W, value2.W, amount));
        }

        public static vector4 Max(vector4 value1, vector4 value2)
        {
            return new vector4(
               k.Max(value1.X, value2.X),
               k.Max(value1.Y, value2.Y),
               k.Max(value1.Z, value2.Z),
               k.Max(value1.W, value2.W));
        }

        public static void Max(ref vector4 value1, ref vector4 value2, out vector4 result)
        {
            result = new vector4(
               k.Max(value1.X, value2.X),
               k.Max(value1.Y, value2.Y),
               k.Max(value1.Z, value2.Z),
               k.Max(value1.W, value2.W));
        }

        public static vector4 Min(vector4 value1, vector4 value2)
        {
            return new vector4(
               k.Min(value1.X, value2.X),
               k.Min(value1.Y, value2.Y),
               k.Min(value1.Z, value2.Z),
               k.Min(value1.W, value2.W));
        }

        public static void Min(ref vector4 value1, ref vector4 value2, out vector4 result)
        {
            result = new vector4(
               k.Min(value1.X, value2.X),
               k.Min(value1.Y, value2.Y),
               k.Min(value1.Z, value2.Z),
               k.Min(value1.W, value2.W));
        }

        public static vector4 Multiply(vector4 value1, vector4 value2)
        {
            value1.W *= value2.W;
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        public static vector4 Multiply(vector4 value1, double scaleFactor)
        {
            value1.W *= scaleFactor;
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            value1.Z *= scaleFactor;
            return value1;
        }

        public static void Multiply(ref vector4 value1, double scaleFactor, out vector4 result)
        {
            result.W = value1.W * scaleFactor;
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
            result.Z = value1.Z * scaleFactor;
        }

        public static void Multiply(ref vector4 value1, ref vector4 value2, out vector4 result)
        {
            result.W = value1.W * value2.W;
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
            result.Z = value1.Z * value2.Z;
        }

        public static vector4 Negate(vector4 value)
        {
            value = new vector4(-value.X, -value.Y, -value.Z, -value.W);
            return value;
        }

        public static void Negate(ref vector4 value, out vector4 result)
        {
            result = new vector4(-value.X, -value.Y, -value.Z, -value.W);
        }

        public void Normalize()
        {
            Normalize(ref this, out this);
        }

        public static vector4 Normalize(vector4 vector)
        {
            Normalize(ref vector, out vector);
            return vector;
        }

        public static void Normalize(ref vector4 vector, out vector4 result)
        {
            double factor;
            DistanceSquared(ref vector, ref zeroVector, out factor);
            factor = 1d / Math.Sqrt(factor);

            result.W = vector.W * factor;
            result.X = vector.X * factor;
            result.Y = vector.Y * factor;
            result.Z = vector.Z * factor;
        }

        public static vector4 SmoothStep(vector4 value1, vector4 value2, float amount)
        {
            return new vector4(
                k.SmoothStep(value1.X, value2.X, amount),
                k.SmoothStep(value1.Y, value2.Y, amount),
                k.SmoothStep(value1.Z, value2.Z, amount),
                k.SmoothStep(value1.W, value2.W, amount));
        }

        public static void SmoothStep(ref vector4 value1, ref vector4 value2, double amount, out vector4 result)
        {
            result = new vector4(
                k.SmoothStep(value1.X, value2.X, amount),
                k.SmoothStep(value1.Y, value2.Y, amount),
                k.SmoothStep(value1.Z, value2.Z, amount),
                k.SmoothStep(value1.W, value2.W, amount));
        }

        public static vector4 Subtract(vector4 value1, vector4 value2)
        {
            value1.W -= value2.W;
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            return value1;
        }

        public static void Subtract(ref vector4 value1, ref vector4 value2, out vector4 result)
        {
            result.W = value1.W - value2.W;
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
            result.Z = value1.Z - value2.Z;
        }

        public static vector4 Transform(vector2 position, matrix matrix)
        {
            vector4 result;
            Transform(ref position, ref matrix, out result);
            return result;
        }

        public static vector4 Transform(vector3 position, matrix matrix)
        {
            vector4 result;
            Transform(ref position, ref matrix, out result);
            return result;
        }

        public static vector4 Transform(vector4 vector, matrix matrix)
        {
            Transform(ref vector, ref matrix, out vector);
            return vector;
        }

        public static void Transform(ref vector2 position, ref matrix matrix, out vector4 result)
        {
            result = new vector4((position.X * matrix.M11) + (position.Y * matrix.M21) + matrix.M41,
                                 (position.X * matrix.M12) + (position.Y * matrix.M22) + matrix.M42,
                                 (position.X * matrix.M13) + (position.Y * matrix.M23) + matrix.M43,
                                 (position.X * matrix.M14) + (position.Y * matrix.M24) + matrix.M44);
        }

        public static void Transform(ref vector3 position, ref matrix matrix, out vector4 result)
        {
            result = new vector4((position.X * matrix.M11) + (position.Y * matrix.M21) + (position.Z * matrix.M31) + matrix.M41,
                                 (position.X * matrix.M12) + (position.Y * matrix.M22) + (position.Z * matrix.M32) + matrix.M42,
                                 (position.X * matrix.M13) + (position.Y * matrix.M23) + (position.Z * matrix.M33) + matrix.M43,
                                 (position.X * matrix.M14) + (position.Y * matrix.M24) + (position.Z * matrix.M34) + matrix.M44);
        }

        public static void Transform(ref vector4 vector, ref matrix matrix, out vector4 result)
        {
            result = new vector4((vector.X * matrix.M11) + (vector.Y * matrix.M21) + (vector.Z * matrix.M31) + (vector.W * matrix.M41),
                                 (vector.X * matrix.M12) + (vector.Y * matrix.M22) + (vector.Z * matrix.M32) + (vector.W * matrix.M42),
                                 (vector.X * matrix.M13) + (vector.Y * matrix.M23) + (vector.Z * matrix.M33) + (vector.W * matrix.M43),
                                 (vector.X * matrix.M14) + (vector.Y * matrix.M24) + (vector.Z * matrix.M34) + (vector.W * matrix.M44));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(32);
            sb.Append("{X:");
            sb.Append(this.X);
            sb.Append(" Y:");
            sb.Append(this.Y);
            sb.Append(" Z:");
            sb.Append(this.Z);
            sb.Append(" W:");
            sb.Append(this.W);
            sb.Append("}");
            return sb.ToString();
        }

        #endregion Public Methods


        #region Operators

        public static vector4 operator -(vector4 value)
        {
            return new vector4(-value.X, -value.Y, -value.Z, -value.W);
        }

        public static bool operator ==(vector4 value1, vector4 value2)
        {
            return value1.W == value2.W
                && value1.X == value2.X
                && value1.Y == value2.Y
                && value1.Z == value2.Z;
        }

        public static bool operator !=(vector4 value1, vector4 value2)
        {
            return !(value1 == value2);
        }

        public static vector4 operator +(vector4 value1, vector4 value2)
        {
            value1.W += value2.W;
            value1.X += value2.X;
            value1.Y += value2.Y;
            value1.Z += value2.Z;
            return value1;
        }

        public static vector4 operator -(vector4 value1, vector4 value2)
        {
            value1.W -= value2.W;
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            value1.Z -= value2.Z;
            return value1;
        }

        public static vector4 operator *(vector4 value1, vector4 value2)
        {
            value1.W *= value2.W;
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            value1.Z *= value2.Z;
            return value1;
        }

        public static vector4 operator *(vector4 value1, double scaleFactor)
        {
            value1.W *= scaleFactor;
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            value1.Z *= scaleFactor;
            return value1;
        }

        public static vector4 operator *(double scaleFactor, vector4 value1)
        {
            value1.W *= scaleFactor;
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            value1.Z *= scaleFactor;
            return value1;
        }

        public static vector4 operator /(vector4 value1, vector4 value2)
        {
            value1.W /= value2.W;
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            value1.Z /= value2.Z;
            return value1;
        }

        public static vector4 operator /(vector4 value1, double divider)
        {
            double factor = 1d / divider;
            value1.W *= factor;
            value1.X *= factor;
            value1.Y *= factor;
            value1.Z *= factor;
            return value1;
        }

        #endregion Operators
    }

    #region Loops
    public static class Loop
    {
        public static void For(Action<int> method, int loops, int start = 0)
        {
            for (int i = 0; i < loops; i++)
            {
                method(i);
            }
        }
        public static void For(Action method, int loops, int start = 0)
        {
            for (int i = 0; i < loops; i++)
            {
                method();
            }
        }

        public static void While(Func<bool> b, Action<int> method)
        {
            int i = 0;
            while (b())
            {
                method(i);
                i++;
            }
        }
        public static void While(Func<bool, int, bool> method)
        {
            bool b = true;
            int i = 0;
            while (b)
            {
                b = method(b, i);
                i++;
            }
        }

        public static void Foreach<T>(T[] array, Func<T, int, T> method)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = method(array[i], i);
            }
        }
        public static void Foreach<T>(List<T> list, Func<T, int, T> method)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = method(list[i], i);
            }
        }
        public static void Foreach<T>(T[] array, Func<T, T> method)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = method(array[i]);
            }
        }
        public static void Foreach<T>(List<T> list, Func<T, T> method)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = method(list[i]);
            }
        }
        public static void Foreach<T>(T[] array, Action<T, int> method)
        {
            for (int i = 0; i < array.Length; i++)
            {
                method(array[i], i);
            }
        }
        public static void Foreach<T>(List<T> list, Action<T, int> method)
        {
            for (int i = 0; i < list.Count; i++)
            {
                method(list[i], i);
            }
        }
        public static void Foreach<T>(T[] array, Action<T> method)
        {
            for (int i = 0; i < array.Length; i++)
            {
                method(array[i]);
            }
        }
        public static void Foreach<T>(List<T> list, Action<T> method)
        {
            for (int i = 0; i < list.Count; i++)
            {
                method(list[i]);
            }
        }
        public static void Foreach<T>(T[] array, Action method)
        {
            for (int i = 0; i < array.Length; i++)
            {
                method();
            }
        }
        public static void Foreach<T>(List<T> list, Action method)
        {
            for (int i = 0; i < list.Count; i++)
            {
                method();
            }
        }
    }
    #endregion

    public static class String
    {
        /// <summary>
        /// Converts string to Int32.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt32(this string str)
        {
            Int32.TryParse(str, out int a);
            return a;
        }
        /// <summary>
        /// Converts string to Int64.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long ToInt64(this string str)
        {
            Int64.TryParse(str, out long a);
            return a;
        }
        /// <summary>
        /// Converts string to Bool.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ToBool(this string str)
        {
            Boolean.TryParse(str, out bool a);
            return a;
        }
        /// <summary>
        /// Converts string to Float.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float ToFloat(this string str)
        {
            Single.TryParse(str, out float a);
            return a;
        }
        /// <summary>
        /// Converts string to Double.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ToDouble(this string str)
        {
            System.Double.TryParse(str, out double a);
            return a;
        }
        public static string[] Split(this string str, params string[] split)
        {
            return str.Split(split, StringSplitOptions.None);
        }
        public static string[] Split(this string str, string split, StringSplitOptions options)
        {
            return str.Split(options, split);
        }
        public static string[] Split(this string str, StringSplitOptions options, params string[] split)
        {
            return str.Split(split, options);
        }
        public static string IfStartAndRemove(this string s, string target)
        {
            if (s.StartsWith(target))
            {
                return s.Remove(0, target.Length);
            }
            return s;
        }
        public static string IfEndAndRemove(this string s, string target)
        {
            if (s.EndsWith(target))
            {
                return s.Remove(s.Length - target.Length, target.Length);
            }
            return s;
        }
        public static bool IsStartAndRemove(this string s, out string str, string target)
        {
            if (s.StartsWith(target))
            {
                str = s.Remove(0, target.Length);
                return true;
            }
            str = s;
            return false;
        }
        public static bool IsEndAndRemove(this string s, out string str, string target)
        {
            if (s.EndsWith(target))
            {
                str = s.Remove(s.Length - target.Length, target.Length);
                return true;
            }
            str = s;
            return false;
        }
        public static string TwoCharHex(this string s)
        {
            if (s.Length == 1)
            {
                return "0" + s;
            }
            else if (s.Length == 0)
            {
                return "00";
            }
            else
            {
                return s;
            }
        }
    }
    #region Numbers
    public struct k
    {
        #region MathHelper
        public const decimal E = 2.7182818284590452353602874713527M;
        public const decimal Log10E = 0.43429448190325182765112891891661M;
        public const decimal Log2E = 1.4426950408889634073599246810019M;
        public const decimal Pi = 3.1415926535897932384626433832795M;
        public const decimal PiOver2 = 1.5707963267948966192313216916398M;
        public const decimal PiOver4 = 0.78539816339744830961566084581988M;
        public const decimal Tau = 6.2831853071795864769252867665590M;
        public const decimal Root2 = 1.4142135623730950488016887242097M;
        public const decimal Phi = 1.6180339887498948482045868343656M;
        public const double doub_E = 2.7182818284590452353602874713527;
        public const double Log10E_d = 0.43429448190325182765112891891661;
        public const double Log2E_d = 1.4426950408889634073599246810019;
        public const double Pi_d = 3.1415926535897932384626433832795;
        public const double PiOver2_d = 1.5707963267948966192313216916398;
        public const double PiOver4_d = 0.78539816339744830961566084581988;
        public const double Tau_d = 6.2831853071795864769252867665590;
        public const double Root2_d = 1.4142135623730950488016887242097;
        public const double Phi_d = 1.6180339887498948482045868343656;

        public static double Hermite(double value1, double tangent1, double value2, double tangent2, double amount)
        {
            double v1 = value1, v2 = value2, t1 = tangent1, t2 = tangent2, s = amount, result;
            double sCubed = s * s * s;
            double sSquared = s * s;

            if (amount == 0)
                result = value1;
            else if (amount == 1)
                result = value2;
            else
                result = (2 * v1 - 2 * v2 + t2 + t1) * sCubed +
                    (3 * v2 - 3 * v1 - 2 * t1 - t2) * sSquared +
                    t1 * s +
                    v1;
            return result;
        }
        public static double Barycentric(double value1, double value2, double value3, double amount1, double amount2)
        {
            return value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;
        }
        public static double CatmullRom(double value1, double value2, double value3, double value4, double amount)
        {
            double amountSquared = amount * amount;
            double amountCubed = amountSquared * amount;
            return (0.5 * (2.0 * value2 +
                (value3 - value1) * amount +
                (2.0 * value1 - 5.0 * value2 + 4.0 * value3 - value4) * amountSquared +
                (3.0 * value2 - value1 - 3.0 * value3 + value4) * amountCubed));
        }
        public static double Distance(double value1, double value2)
        {
            return abs(value1 - value2);
        }
        public static double Lerp(double value1, double value2, double amount)
        {
            return value1 + ((value2 - value1) * amount);
        }
        public static double CLerp(double value1, double value2, double amount)
        {
            return value1 + ((value2 - value1) * Clamp(amount, 0, 1));
        }
        private DateTime start;
        private TimeSpan len;
        private double v0;
        private double v1;
        public void LerpTimeStart(double value1, double value2, TimeSpan length)
        {
            start = DateTime.Now;
            len = length;
            v0 = value1;
            v1 = value2;
        }
        public double GetLerpTime()
        {
            TimeSpan ts = DateTime.Now - start;
            double amt = ts.TotalMilliseconds/len.TotalMilliseconds;
            return CLerp(v0, v1, amt);
        }
        public static double Max(double value1, double value2)
        {
            return value1 < value2 ? value2 : value1;
        }
        public static double Max(double value1, double value2, params double[] values)
        {
            double max = Max(value1, value2);
            foreach(double m in values)
            {
                if (m > max)
                {
                    max = m;
                }
            }
            return max;
        }
        public static double Min(double value1, double value2)
        {
            return value1 > value2 ? value2 : value1;
        }
        public static double Min(double value1, double value2, params double[] values)
        {
            double min = Min(value1, value2);
            foreach (double m in values)
            {
                if (m > min)
                {
                    min = m;
                }
            }
            return min;
        }
        public static double SmoothStep(double value1, double value2, double amount)
        {
            double result = Clamp(amount, 0, 1);
            result = Hermite(value1, 0, value2, 0, result);
            return result;
        }
        public static double ToDegrees(double radians)
        {
            return radians* 57.295779513082320876798154814105;
        }
        public static double ToRadians(double degrees)
        {
            return degrees * 0.017453292519943295769236907684886;
        }
        public static double ToGrads(double degrees)
        {
            return degrees / 0.9;
        }
        public static double GradsToDegrees(double grads)
        {
            return grads * 0.9;
        }
        public static bool CloseTo(double val, double target)
        {
            if (val == target)
            {
                return true;
            }
            else if ((Abstotarget(val, target)-target) < 0.00000000001)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double Abstotarget(double val, double target)
        {
            return val = val < target ? ((target-val)+target) : val;
        }
        #endregion
        #region Clamp
        public static long Clamp(long val, long min, long max)
        {
            long ret = val;
            ret = val < min ? min : ret;
            ret = val > max ? max : ret;
            return ret;
        }
        public static void Clampval(ref long val, long min, long max)
        {
            val = val < min ? min : val;
            val = val > max ? max : val;
        }
        public static int Clamp(int val, int min, int max)
        {
            int ret = val;
            ret = val < min ? min : ret;
            ret = val > max ? max : ret;
            return ret;
        }
        public static void Clampval(ref int val, int min, int max)
        {
            val = val < min ? min : val;
            val = val > max ? max : val;
        }
        public static double Clamp(double val, double min, double max)
        {
            double ret = val;
            ret = val < min ? min : ret;
            ret = val > max ? max : ret;
            return ret;
        }
        public static void Clampval(ref double val, double min, double max)
        {
            val = val < min ? min : val;
            val = val > max ? max : val;
        }
        public static decimal Clamp(decimal val, decimal min, decimal max)
        {
            decimal ret = val;
            ret = val < min ? min : ret;
            ret = val > max ? max : ret;
            return ret;
        }
        public static void Clampval(ref decimal val, decimal min, decimal max)
        {
            val = val < min ? min : val;
            val = val > max ? max : val;
        }
        public static bigint Clamp(bigint val, bigint min, bigint max)
        {
            bigint ret = val;
            ret = val < min ? min : ret;
            ret = val > max ? max : ret;
            return ret;
        }
        public static void Clampval(ref bigint val, bigint min, bigint max)
        {
            val = val < min ? min : val;
            val = val > max ? max : val;
        }
        #endregion
        #region Console
        public static void w(bool b)
        {
            Console.WriteLine(b);
        }
        public static void w(long b)
        {
            Console.WriteLine(b);
        }
        public static void w(double b)
        {
            Console.WriteLine(b);
        }
        public static void w(decimal b)
        {
            Console.WriteLine(b);
        }
        public static void w(ulong b)
        {
            Console.WriteLine(b);
        }
        public static void w(object b)
        {
            Console.WriteLine(b);
        }
        public static void w(char b)
        {
            Console.WriteLine(b);
        }
        public static void w(char[] b)
        {
            Console.WriteLine(b);
        }
        public static void w(string s)
        {
            Console.WriteLine(s);
        }
        public static void w(string s, params object[] arg)
        {
            Console.WriteLine(s, arg);
        }
        public static void w(string[] s)
        {
            foreach (string st in s)
            {
                Console.WriteLine(st);
            }
        }
        public static void w(List<string> s)
        {
            foreach (string st in s)
            {
                Console.WriteLine(st);
            }
        }
        public static void wr(bool b)
        {
            Console.Write(b);
        }
        public static void wr(long b)
        {
            Console.Write(b);
        }
        public static void wr(double b)
        {
            Console.Write(b);
        }
        public static void wr(decimal b)
        {
            Console.Write(b);
        }
        public static void wr(ulong b)
        {
            Console.Write(b);
        }
        public static void wr(object b)
        {
            Console.Write(b);
        }
        public static void wr(char b)
        {
            Console.Write(b);
        }
        public static void wr(char[] b)
        {
            Console.Write(b);
        }
        public static void wr(string s)
        {
            Console.Write(s);
        }
        public static void wr(string s, params object[] arg)
        {
            Console.Write(s, arg);
        }
        public static void wr(string[] s)
        {
            foreach (string st in s)
            {
                Console.Write(st);
            }
        }
        public static void wr(List<string> s)
        {
            foreach (string st in s)
            {
                Console.Write(st);
            }
        }
        #endregion
        #region Rand
        public static Random rng = new Random();
        public static ulong GetCryptoRand()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] b = new byte[8];
            ulong ret = 0;
            provider.GetBytes(b);
            ret = BitConverter.ToUInt64(b, 0);
            return ret;
        }
        public static ulong GetCryptoRand(ulong max)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] b = new byte[8];
            ulong ret = 0;
            while (ret == 0)
            {
                provider.GetBytes(b);
                ret = BitConverter.ToUInt64(b, 0);
            }
            return ret % max;
        }
        public static ulong GetCryptoRand(ulong min, ulong max)
        {
            if (min >= max)
            {
                throw new ArgumentOutOfRangeException();
            }
            ulong dif = max - min;
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] b = new byte[8];
            ulong ret = 0;
            while (ret == 0)
            {
                provider.GetBytes(b);
                ret = BitConverter.ToUInt64(b, 0);
            }
            return (ret % dif) + min;
        }
        public static double GetCryptoRandD()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] b = new byte[8];
            ulong ui = 0;
            provider.GetBytes(b);
            ui = BitConverter.ToUInt64(b, 0);
            ui &= ((1UL << 53) - 1);
            double ret = (double)ui / (double)(1UL << 53);
            return ret;
        }
        public static int GetRand()
        {
            return rng.Next();
        }
        public static int GetRand(int max)
        {
            return rng.Next(max);
        }
        public static int GetRand(int min, int max)
        {
            return rng.Next(min, max);
        }
        public static double GetRandD()
        {
            return rng.NextDouble();
        }
        public static List<int> CreateStableRandList(int max, int nonums, int target)
        {
#warning Incomplete Method
            int min = 0;
            int total = max * nonums;
            int lmin = min;
            int lmax = max;
            int remains = target;
            if (target >= total || target < 0) { throw new Exception("Target out of bounds."); }
            List<int> ret = new List<int>();
            for (int i = 1; i <= nonums; i++)
            {
                lmax = remains - ((nonums - i) * min);
                if (lmax > max)
                    lmax = max;

                lmin = remains - ((nonums - i) * max);
                if (lmin > min)
                    lmin = min;

                int nextDigit = k.GetRand(lmin, lmax);
                ret.Add(nextDigit);
                remains -= nextDigit;
            }
            ret.Shuffle();
            int tot=0;
            foreach(int j in ret)
            {
                tot += j;
                k.wr(j+", ");
            }
            k.w("Add: " +tot);
            return ret;
        }
        #endregion
        #region Abs
        public static int abs(int t)
        {
            return t = t < 0 ? -t : t;
        }
        public static long abs(long t)
        {
            return t = t < 0 ? -t : t;
        }
        public static float abs(float t)
        {
            return t = t < 0 ? -t : t;
        }
        public static double abs(double t)
        {
            return t = t < 0 ? -t : t;
        }
        public static decimal abs(decimal t)
        {
            return t = t < 0 ? -t : t;
        }
        //public Decimalq abs(Decimalq t)
        //{
        //    return new Decimalq(t).abs();
        //}
        #endregion
    }
    public struct ic
    {
        byte b;
        public ic(int t)
        {
            b = (byte)t;
        }
        public static implicit operator ic(int t)
        {
            return new ic(t);
        }
        public static implicit operator bool(ic i)
        {
            if (i.b == 0)
                return false;
            else
                return true;
        }
        public static implicit operator int(ic i)
        {
            return i.b;
        }
    }
    public static class Int
    {
        public static int abs(this int t)
        {
            return t = t < 0 ? -t : t;
        }
        public static string PadToString(this int num, int front, int end)
        {
            string s = ".";
            for (int i = 0; i < front; i++)
            {
                s = "0" + s;
            }
            for (int i = 0; i < end; i++)
            {
                s = s + "0";
            }
            return num.ToString(s);
        }
        public static void SetValue(this int num, int value)
        {
            num = value;
        }
        public static string ConvertToBaseString(this int value, int toBase)
        {
            string result = string.Empty;
            
            while (value > 0)
            {
                result = "0123456789ABCDEF"[value % toBase] + result;
                value /= toBase;
            }

            return result;
        }
        public static void ConvertToBase(this int value, int toBase)
        {
            string result = string.Empty;

            while (value > 0)
            {
                result = "0123456789ABCDEF"[value % toBase] + result;
                value /= toBase;
            }
            
            value = result.ToInt32();
        }
    }
    public static class Long
    {
        public static long abs(this long t)
        {
            return t = t < 0 ? -t : t;
        }
        public static string PadToString(this long num, int front, int end)
        {
            string s = ".";
            for (int i = 0; i < front; i++)
            {
                s = "0" + s;
            }
            for (int i = 0; i < end; i++)
            {
                s = s + "0";
            }
            return num.ToString(s);
        }
    }
    public static class Float
    {
        public static float abs(this float t)
        {
            return t = t < 0 ? -t : t;
        }
        public static float Floor(this float t)
        {
            return (float)Math.Floor(t);
        }
        public static int Floori(this float t)
        {
            return (int)Math.Floor(t);
        }
        public static string PadToString(this float num, int front, int end)
        {
            string s = ".";
            for (int i = 0; i < front; i++)
            {
                s = "0" + s;
            }
            for (int i = 0; i < end; i++)
            {
                s = s + "0";
            }
            return num.ToString(s);
        }
    }
    public static class Double
    {
        public static double abs(this double t)
        {
            return t = t < 0 ? -t : t;
        }
        public static string PadToString(this double num, int front, int end)
        {
            string s = ".";
            for (int i = 0; i < front; i++)
            {
                s = "0" + s;
            }
            for (int i = 0; i < end; i++)
            {
                s = s + "0";
            }
            return num.ToString(s);
        }
    }
    public static class Decimal
    {
        public static decimal abs(this decimal t)
        {
            return t = t < 0 ? -t : t;
        }
    }
    #endregion
}
