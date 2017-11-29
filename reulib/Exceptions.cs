using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib
{
    public class LoopLengthException : Exception
    {
        public LoopLengthException() : base("Loop is recursive or has looped too long.")
        {

        }
        public LoopLengthException(string msg) : base (msg)
        {

        }
    }
}
