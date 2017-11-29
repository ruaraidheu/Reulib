using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Interface.Obsolete
{
    public static class List
    {
        [Obsolete]
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
        [Obsolete]
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
        [Obsolete]
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
}
