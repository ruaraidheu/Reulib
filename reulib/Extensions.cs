using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ruaraidheulib.Interface.Obsolete.List;

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
    }
    #region Numbers
    public static class Int
    {
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
    #endregion
}
