using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    [Obsolete("Use Winforms.Relative")]
    public class LRelative
    {
        int _x, _y, _width, _height, _contwidth, _contheight;
        double relx, rely, relw, relh;

        public LRelative(int x, int y, int width, int height, int contwidth, int contheight)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _contwidth = contwidth;
            _contheight = contheight;
            relx = (double)_x / (double)_contwidth;
            rely = (double)_y / (double)_contheight;
            relw = (double)_width / (double)_contwidth;
            relh = (double)_height / (double)_contheight;
        }
        public void UpdateObject(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }
        public void CastOut()
        {
            _x = (int)(relx * _contwidth);
            _y = (int)(rely * _contheight);
            _width = (int)(relw * _contwidth);
            _height = (int)(relh * _contheight);
        }
        public void CastIn()
        {
            relx = (double)_x / (double)_contwidth;
            rely = (double)_y / (double)_contheight;
            relw = (double)_width / (double)_contwidth;
            relh = (double)_height / (double)_contheight;
        }
        public void UpdateContainer(int contwidth, int contheight)
        {
            _contwidth = contwidth;
            _contheight = contheight;
        }
        public void GetObject(out int x, out int y, out int width, out int height)
        {
            x = (int)(relx * _contwidth);
            y = (int)(rely * _contheight);
            width = (int)(relw * _contwidth);
            height = (int)(relh * _contheight);
        }
        public void GetValues(out int x, out int y, out int width, out int height)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }
    }
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
