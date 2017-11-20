using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib
{
    public class Multiarray<T>
    {
        T[] arr;
        public T[] Array
        {
            get { return arr; }
        }
        int[] dim;
        public int[] Dimensions
        {
            get { return dim; }
        }
        //public Multiarray(int width, int height)
        //{
        //    dim = new int[2];
        //    dim[0] = width;
        //    dim[1] = height;
        //    arr = new T[dim[0] * dim[1]];
        //}
        public Multiarray(int width, params int[] dimensions)
        {
            dim = new int[1 + dimensions.Length];
            new int[] { width }.CopyTo(dim, 0);
            dimensions.CopyTo(dim, 1);

            int tot = 1;
            for (int i = 0; i < dim.Length; i++)
            {
                tot *= dim[i];
            }
            arr = new T[tot];
        }
        //public T this[int x, int y]
        //{
        //    get { return arr[(dim[0] * y) + x]; }
        //    set { arr[(dim[0] * y) + x] = value; }
        //}
        public T this[int min, params int[] dimensions]
        {
            get
            {
                int[] inp = new int[1 + dimensions.Length];
                new int[] { min }.CopyTo(inp, 0);
                dimensions.CopyTo(inp, 1);

                int val = 0;
                for (int i = 0; i < dim.Length; i++)
                {
                    int dval = 1;
                    for (int j = 0; j < i; j++)
                    {
                        dval *= dim[j];
                    }
                    val += inp[i] * dval;
                }
                return arr[val];
            }
            set
            {
                int[] inp = new int[1 + dimensions.Length];
                new int[] { min }.CopyTo(inp, 0);
                dimensions.CopyTo(inp, 1);

                int val = 0;
                if (inp.Length < dim.Length)
                {
                    int[] tmp = new int[dim.Length];
                    inp.CopyTo(tmp, 0);
                    inp = tmp;
                }
                for (int i = 0; i < dim.Length; i++)
                {
                    int dval = 1;
                    for (int j = 0; j < i; j++)
                    {
                        dval *= dim[j];
                    }
                    val += inp[i] * dval;
                }
                arr[val] = value;
            }
        }
    }
    public class MultiList
    {
        public MultiList()
        {

        }
    }
}
