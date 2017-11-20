using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Games
{
    public class Dice
    {
        int sides;
        int dice;
        Random rand;
        public Dice(int sides_, int dice_)
        {
            sides = sides_;
            dice = dice_;
            rand = new Random();
        }

        public int nextRoll()
        {
            return (int)Math.Ceiling(rand.NextDouble() * sides);
        }

        public int[] nextRolls()
        {
            int[] val = new int[dice];
            for (int i = 0; i < dice; i++)
            {
                val[i] = nextRoll();
            }

            return val;
        }

        public int[,] nextRolls(int norolls)
        {
            int[,] val = new int[dice, norolls];
            for (int i = 0; i < norolls; i++)
            {
                int[] vallower = nextRolls();
                for (int j = 0; j < vallower.Length; j++)
                {
                    val[j, i] = vallower[j];
                }
            }

            return val;
        }

        public double getAvg(int[] rolls)
        {
            double tot = 0;
            for (int i = 0; i < rolls.Length; i++)
            {
                tot += rolls[i];
            }

            if (rolls.Length != 0)
            {
                tot /= (double)rolls.Length;
            }

            return tot;
        }

        public double getAvg(double[] rolls)
        {
            double tot = 0;
            for (int i = 0; i < rolls.Length; i++)
            {
                tot += rolls[i];
            }

            if (rolls.Length != 0)
            {
                tot /= (double)rolls.Length;
            }

            return tot;
        }
    }
}
