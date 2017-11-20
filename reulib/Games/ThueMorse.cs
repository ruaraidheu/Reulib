using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Games
{
    public class ThueMorse
    {
        int turn = 0;
        int noplayers = 2;

        public ThueMorse()
        {

        }
        public ThueMorse(int player = 2, int startturn = 0)
        {
            turn = startturn;
            noplayers = player;
        }
        public int Currentplayer()
        {
            int tmp = (turn-1).ConvertToBaseString(noplayers).ToInt32();
            int sum = 0;
            while (tmp != 0)
            {
                int remainder;
                tmp = Math.DivRem(tmp, 10, out remainder);
                sum += remainder;
            }
            return sum % noplayers;
        }

        public int Nextplayer()
        {
            int tmp = turn.ConvertToBaseString(noplayers).ToInt32();
            int sum = 0;
            while (tmp != 0)
            {
                int remainder;
                tmp = Math.DivRem(tmp, 10, out remainder);
                sum += remainder;
            }
            turn++;
            return sum%noplayers;

            //string tmp = Convert.ToString(turn, 2);
            //turn++;
            //int count = tmp.Split('1').Length - 1;
            //if (count % 2 == 0)
            //{
            //    return 1;
            //}
            //return 0;
        }
    }
}
