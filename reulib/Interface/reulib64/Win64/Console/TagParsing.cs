using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Interface.reulib64.Win64.Console
{
    public class InvalidTagConfigurationException : Exception
    {
        public InvalidTagConfigurationException() : base("Tags don't match.")
        {
        }
        public InvalidTagConfigurationException(string msg) : base(msg)
        {
        }
    }
    public static class TagDecoder
    {
        public static string[] Tags(string data, string tag)
        {
            string[] dat1 = data.Split(new string[] { "<" + tag + ">", "</" + tag + ">" }, StringSplitOptions.None);
            string[] ret;
            if (dat1.Length <= 1)
            {
                ret = new string[] { data };
            }
            else
            {
                if (dat1.Length % 2 == 0)
                {
                    ret = new string[(dat1.Length) / 2];
                    Loop.For((i) =>
                    {
                        ret[i] = dat1[(i * 2) + 1];
                    }
                    , ret.Length);
                }
                else
                {
                    ret = new string[(dat1.Length - 1) / 2];
                    Loop.For((i) =>
                    {
                        ret[i] = dat1[(i * 2) + 1];
                    }
                    , ret.Length);
                }
            }
            return ret;
        }
        public static string[] CTags(string data, string ftag, string etag)
        {
            string[] dat1 = data.Split(new string[] { ftag, etag }, StringSplitOptions.None);
            string[] ret;
            if (dat1.Length <= 1)
            {
                ret = new string[] { data };
            }
            else
            {
                if (dat1.Length % 2 == 0)
                {
                    ret = new string[(dat1.Length) / 2];
                    Loop.For((i) =>
                    {
                        ret[i] = dat1[(i * 2) + 1];
                    }
                    , ret.Length);
                }
                else
                {
                    ret = new string[(dat1.Length - 1) / 2];
                    Loop.For((i) =>
                    {
                        ret[i] = dat1[(i * 2) + 1];
                    }
                    , ret.Length);
                }
            }
            return ret;
        }
        public static string CWTags(string[] data, bool isdiv, string div = "|")
        {
            string[] add = data;
            string ret = "";
            Loop.For((i) =>
            {
                if (i == 0)
                {
                    ret += add[i];
                }
                else if (isdiv)
                {
                    ret += (div + add[i]);
                }
                else
                {
                    ret += add[i];
                }
            }
            , add.Length);
            return ret;
        }
        public static string WTags(string data, string tag, bool isdiv, string div = "|")
        {
            string[] add = Tags(data, tag);
            string ret = "";
            Loop.For((i) =>
            {
                if (i == 0)
                {
                    ret += add[i];
                }
                else if (isdiv)
                {
                    ret += (div + add[i]);
                }
                else
                {
                    ret += add[i];
                }
            }
            , add.Length);
            return ret;
        }
        public static string WTags(string data, string tag)
        {
            return WTags(data, tag, false);
        }
        public static string StripTags(string data, string tag)
        {
            string[] dat1 = data.Split(new string[] { "<" + tag + ">", "</" + tag + ">" }, StringSplitOptions.None);
            string ret = "";
            if (dat1.Length <= 1)
            {
                ret = data;
            }
            else
            {
                if (dat1.Length % 2 == 0)
                {
                    Loop.For((i) =>
                    {
                        ret += dat1[(i * 2)];
                    }
                    , ((dat1.Length) / 2));
                }
                else
                {
                    Loop.For((i) =>
                    {
                        ret += dat1[(i * 2)];
                    }
                    , ((dat1.Length - 1) / 2)+1);
                }
            }
            return ret;
        }
        /// <summary>
        /// Splits a string into a list of tags.
        /// </summary>
        /// <param name="data">String with tags.</param>
        /// <param name="tag">The tag that you want the data from.</param>
        /// <exception cref="InvalidTagConfigurationException">Thrown when...</exception>
        /// <returns>stuff</returns>
        public static List<string> OrderedTags(string data, string tag)
        {
            string[] dat1 = data.Split("<" + tag + ">");
            List<string> output = new List<string>();
            Loop.For((i) =>
            {
                if (i != 0)
                {
                    string[] tmp = dat1[i].Split("</" + tag + ">");
                    if (tmp.Length > 1)
                    {
                        if (tmp[0].Split("<" + tag + ">").Length > 1)
                        {
                            throw new InvalidTagConfigurationException();
                        }
                        output.Add(tmp[0]);
                    }
                    else
                    {
                        throw new InvalidTagConfigurationException();
                    }
                }
                else if (dat1.Length <= 1)
                {
                    output.Add(data);
                }
            }
            , dat1.Length);
            return output;
        }
        public static string OrderedWTags(string data, string tag, bool isdiv, string div = "|")
        {
            List<string> add = OrderedTags(data, tag);
            string ret = "";
            Loop.For((i) =>
            {
                if (i == 0)
                {
                    ret += add[i];
                }
                else if (isdiv)
                {
                    ret += (div + add[i]);
                }
                else
                {
                    ret += add[i];
                }
            }
            , add.Count);
            return ret;
        }
        public static string OrderedWTags(string data, string tag)
        {
            return OrderedWTags(data, tag, false);
        }
        public static bool IsTag(string data, string tag)
        {
            string[] dat1 = data.Split(new string[] { "<" + tag + ">", "</" + tag + ">" }, StringSplitOptions.None);
            if (dat1.Length <= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsOTag(string data, string tag)
        {
            string[] dat1 = data.Split("<" + tag + ">");
            List<string> output = new List<string>();
            for (int i = 0; i < dat1.Length; i++)
            {
                if (i != 0)
                {
                    string[] tmp = dat1[i].Split("</" + tag + ">");
                    if (tmp.Length > 1)
                    {
                        if (tmp[0].Split("<" + tag + ">").Length > 1)
                        {
                            return false;
                        }
                        output.Add(tmp[0]);
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (dat1.Length <= 1)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<List<string>> OctoTag(string data, string def = "#")
        {
            List<List<string>> ret = new List<List<string>>();
            string[] s0 = data.Split(def);
            foreach (string s in s0)
            {
                ret.Add(new List<string>());
                string[] s1 = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (string ss in s1)
                {
                    ret.Last().Add(ss);
                }
            }
            return ret;
        }

        public static Dictionary<string, List<string>> OctoDTag(string data, string def = "#", string space = " ")
        {
            Dictionary<string, List<string>> ret = new Dictionary<string, List<string>>();
            string[] s0 = data.Split(def);
            foreach (string s in s0)
            {
                List<string> tmp = new List<string>();
                string[] s1 = s.Split(space, StringSplitOptions.RemoveEmptyEntries);
                foreach (string ss in s1)
                {
                    tmp.Add(ss);
                }
                string t = tmp.GetIndex(0);
                tmp.RemoveIndex(0);
                ret.Add(t, tmp);
            }
            return ret;
        }
        public static List<string> OctoSingleTag(string data, string def = "#")
        {
            List<string> ret = new List<string>();
            string[] s0 = data.Split(def, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in s0)
            {
                ret.Add(s);
            }
            return ret;
        }
    }
}
