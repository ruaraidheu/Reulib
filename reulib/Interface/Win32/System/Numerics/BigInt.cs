using Ruaraidheulib.Interface.Win32.System.Numerics.Replacement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Interface.Win32.System.Numerics.Replacement
{
    public struct bigint
    {
        List<ulong> val;
        ulong mval;
        bool signed;
        public bigint(long t)
        {
            mval = 1000;
            val = new List<ulong>();
            signed = t < 0;
            val.Add((ulong)t.abs());
        }
        public bigint(bigint t)
        {
            mval = 1000;
            val = t.val;
            signed = t.signed;
        }
        public void Add(bigint bi)
        {
            if (val.Count < bi.val.Count)
            {
                for (int i = 0; i < bi.val.Count; i++)
                {
                    if (val.Count - 1 <= i)
                    {
                        val.Add(0);
                    }
                    val[i] += bi.val[i];
                    ProcessAdd(i);
                }
            }
            else
            {
                for (int i = 0; i < bi.val.Count; i++)
                {
                    val[i] += bi.val[i];
                    ProcessAdd(i);
                }
            }
        }
        public void ProcessAdd(int i)
        {
            bool proc = false;
            while (val[i] >= mval)
            {
                val[i] -= mval;
                if (val.Count > i + 1)
                {
                    val[i + 1] += 1;
                    proc = true;
                }
                else
                {
                    val.Add(1);
                }
            }
            if (proc)
            {
                ProcessAdd(i + 1);
            }
        }
        public void Subtract(bigint bi)
        {

        }
        public void Multiply(bigint bi)
        {

        }
        public void Divide(bigint bi)
        {

        }
        public override string ToString()
        {
            string ret = "";
            for (int i = val.Count - 1; i >= 0; i--)
            {
                ret += val[i].ToString();
            }
            return ret;
        }

        public static implicit operator bigint(long t)
        {
            return new bigint(t);
        }
        public static implicit operator long(bigint t)
        {
            ulong l = 0;
            if (t.val.Count >= 1)
            {
                l = t.val[0];
            }
            return (long)l;
        }
        public ulong this[int index]
        {
            get { return val[index]; }
            set { val[index] = value; }
        }
        public static bigint operator +(bigint first, bigint second)
        {
            bigint bi = new bigint(first);
            bi.Add(second);
            return bi;
        }
        public static bigint operator -(bigint first, bigint second)
        {
            bigint bi = new bigint(first);
            bi.Subtract(second);
            return bi;
        }
        public static bigint operator *(bigint first, bigint second)
        {
            bigint bi = new bigint(first);
            bi.Multiply(second);
            return bi;
        }
        public static bigint operator /(bigint first, bigint second)
        {
            bigint bi = new bigint(first);
            bi.Divide(second);
            return bi;
        }
    }
}