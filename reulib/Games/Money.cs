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
        public Money(long m)
        {
            val = m;
        }
        public Money(long m, string symbol, string dividor = ",")
        {
            val = m;
            symb = symbol;
            div = dividor;
        }
        public Money(Money m)
        {
            val = m.val;
            symb = m.symb;
            div = m.div;
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
        public static Money operator+(Money m, Money m2)
        {
            Money m3 = new Money(m);
            m3.Add(m2.val);
            return m3;
        }
        public static Money operator +(Money m, long m2)
        {
            return new Money(m.val+m2, m.symb, m.div);
        }
    }
    public class AMoney
    {
        decimal val = 0;
        string symb = "$";
        string div = ",";
        public AMoney()
        {

        }
        public AMoney(string symbol, string dividor = ",")
        {
            symb = symbol;
            div = dividor;
        }
        public AMoney(decimal m)
        {
            val = m;
        }
        public AMoney(decimal m, string symbol, string dividor = ",")
        {
            val = m;
            symb = symbol;
            div = dividor;
        }
        public AMoney(AMoney m)
        {
            val = m.val;
            symb = m.symb;
            div = m.div;
        }

        public void Add(decimal value)
        {
            val += value;
        }
        public void Add(int value)
        {
            val += (long)value;
        }

        public void Set(decimal value)
        {
            val = value;
        }
        public void Set(int value)
        {
            val = (long)value;
        }

        public decimal GetVal()
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
                s = "-" + symb + string.Format("{0:n2}", val);
            }
            else if (val == 0)
            {
                s = symb + "0" + string.Format("{0:n2}", val);
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
                return "-" + symb + val.ToString(format).IfStartAndRemove("-");
            }
            return symb + val.ToString(format);
        }
        public static AMoney operator +(AMoney m, AMoney m2)
        {
            AMoney m3 = new AMoney(m);
            m3.Add(m2.val);
            return m3;
        }
        public static AMoney operator +(AMoney m, long m2)
        {
            return new AMoney(m.val + m2, m.symb, m.div);
        }
    }



    public class BigMoney
    {
        System.Numerics.BigInteger val = 0;
        string symb = "$";
        string div = ",";
        public BigMoney()
        {
            val = new System.Numerics.BigInteger();
        }
        public BigMoney(string symbol, string dividor = ",")
        {
            symb = symbol;
            div = dividor;
        }
        public BigMoney(System.Numerics.BigInteger m)
        {
            val = m;
        }
        public BigMoney(System.Numerics.BigInteger m, string symbol, string dividor = ",")
        {
            val = m;
            symb = symbol;
            div = dividor;
        }
        public BigMoney(long m)
        {
            val = m;
        }
        public BigMoney(long m, string symbol, string dividor = ",")
        {
            val = m;
            symb = symbol;
            div = dividor;
        }
        public BigMoney(BigMoney m)
        {
            val = m.val;
            symb = m.symb;
            div = m.div;
        }

        public void Add(System.Numerics.BigInteger value)
        {
            val += value;
        }
        public void Add(int value)
        {
            val += value;
        }

        public void Set(System.Numerics.BigInteger value)
        {
            val = value;
        }
        public void Set(int value)
        {
            val = value;
        }

        public System.Numerics.BigInteger GetVal()
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
                s = "-" + symb + string.Format("{0:n2}", val);
            }
            else if (val == 0)
            {
                s = symb + "0"+string.Format("{0:n2}", val);
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
                return "-" + symb + val.ToString(format).IfStartAndRemove("-");
            }
            return symb + val.ToString(format);
        }
        public static BigMoney operator +(BigMoney m, BigMoney m2)
        {
            BigMoney m3 = new BigMoney(m);
            m3.Add(m2.val);
            return m3;
        }
        public static BigMoney operator +(BigMoney m, long m2)
        {
            BigMoney mr = new BigMoney(m.val, m.symb, m.div);
            mr.Add(m2);
            return mr;
        }
    }
}
