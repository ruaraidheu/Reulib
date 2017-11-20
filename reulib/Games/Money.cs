using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Games
{
    public class Money
    {
        long val;
        string symb = "$";
        public Money()
        {

        }
        public Money(string symbol)
        {
            symb = symbol;
        }
        public string Getstring()
        {
            return symb + val.PadToString(0, 2);
        }
    }
}
