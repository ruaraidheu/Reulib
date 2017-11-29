using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Games
{
    public class Money
    {
        long val = 0;
        string symb = "$";
        string div = ",";
        public Money()
        {

        }
        public Money(string symbol, string dividor = ",")
        {
            symb = symbol;
            div = dividor;
        }

        public void Add(long value)
        {
            val += value;
        }
        public void Add(int value)
        {
            val += (long)value;
        }

        public void Set(long value)
        {
            val = value;
        }
        public void Set(int value)
        {
            val = (long)value;
        }

        public long GetVal()
        {
            return val;
        }
        public int GetInt32()
        {
            return (int)val;
        }
        public string GetString(string dividor)
        {
            string s;
            if (val < 0)
            {
                s = "-" + symb + string.Format("{0:n2}", Math.Abs(val));
            }
            else if (val == 0)
            {
                s = symb + val.PadToString(1, 2);
            }
            s = symb + string.Format("{0:n2}", val);
            return s.Replace(",", dividor);
        }
        public string GetString()
        {
            return GetString(div);
        }

        public override string ToString()
        {
            return GetString();
        }
        public string ToString(string format)
        {
            if (val < 0)
            {
                return "-" + symb + Math.Abs(val).ToString();
            }
            return symb + val.ToString(format);
        }
    }
}
