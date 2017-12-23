using Ruaraidheulib.Interface.reulib64.Win64.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Interface.reulib64.GameObjects
{
    /// <summary>
    /// Base Color Class, Inherit from ColorTypes
    /// </summary>
    public class Color
    {
        public byte r = 0;
        public byte g = 0;
        public byte b = 0;
        public byte a = 255;
        public Color(){}
        public Color(byte red, byte green, byte blue, byte alpha = 255) { r = red; g = green; b = blue; a = alpha; }
        public ColorTypes AsColorType { get { return new ColorTypes(r,g,b,a); } set { r = value.r; g = value.g; b = value.b; a = value.a; } }
        public ChainObj AsChain<ChainObj>() where ChainObj : Color, new()
        {
            ChainObj obj = new ChainObj();
            obj.r = r;
            obj.g = g;
            obj.b = b;
            obj.a = a;
            return obj;
        }
        public Color FromChain()
        {
            Color c = new Color();
            c.r = r;
            c.g = g;
            c.b = b;
            c.a = a;
            return c;
        }
        public void FromChain<ChainObj>(ChainObj obj) where ChainObj : Color
        {
            r = obj.r;
            g = obj.g;
            b = obj.b;
            a = obj.a;
        }
        public static Color SFromChain<ChainObj>(ChainObj obj) where ChainObj : Color
        {
            Color c = new Color();
            c.r = obj.r;
            c.g = obj.g;
            c.b = obj.b;
            c.a = obj.a;
            return c;
        }
        public vector4 Double
        {
            get { return new vector4(r / 255.0, g / 255.0, b / 255.0, a / 255.0); }
            set
            {
                r = (byte)(value.X * 255);
                g = (byte)(value.Y * 255);
                b = (byte)(value.Z * 255);
                a = (byte)(value.W * 255);
            }
        }
        public byte RedComponent   { get { return r; } set { r = value; } }
        public byte GreenComponent { get { return g; } set { g = value; } }
        public byte BlueComponent  { get { return b; } set { b = value; } }
        public byte AlphaComponent { get { return a; } set { a = value; } }
        public override string ToString()
        {
            return "Red:"+r+" Green:"+g+" Blue:"+b+" Alpha:"+a;
        }

        public static Color Red              { get { return new Color(255, 000, 000, 255); } }
        public static Color Green            { get { return new Color(000, 255, 000, 255); } }
        public static Color Blue             { get { return new Color(000, 000, 255, 255); } }
        public static Color Black            { get { return new Color(000, 000, 000, 255); } }
        public static Color White            { get { return new Color(255, 255, 255, 255); } }
        public static Color Grey             { get { return new Color(128, 128, 128, 255); } }
        public static Color Transparent      { get { return new Color(000, 000, 000, 000); } }
        public static Color Yellow           { get { return new Color(255, 255, 000, 255); } }
        public static Color Magenta          { get { return new Color(255, 000, 255, 255); } }
        public static Color Cyan             { get { return new Color(000, 255, 255, 255); } }
        public static Color CornflowerBlue   { get { return new Color(100, 149, 237, 255); } }
    }
    /// <summary>
    /// Color Extention Class
    /// </summary>
    public class Colors : Color
    {
        public Colors(byte red, byte green, byte blue, byte alpha = 255) : base(red, green, blue, alpha){ }
        public Colors() { }

        public static Color DarkGrey         { get { return new Color(051, 051, 051, 255); } }
        public static Color LightGrey        { get { return new Color(200, 200, 200, 255); } }
        public static Color SkyBlue          { get { return new Color(000, 174, 255, 255); } }
        public static Color Purple           { get { return new Color(118, 000, 204, 255); } }
        public static Color Orange           { get { return new Color(255, 146, 005, 255); } }
        public static Color Crimson          { get { return new Color(216, 046, 004, 255); } }
        public static Color Lime             { get { return new Color(145, 216, 002, 255); } }
    }
    /// <summary>
    /// Color Extention Class, Inherit from this
    /// </summary>
    public class ColorTypes : Colors
    {
        public ColorTypes(byte red, byte green, byte blue, byte alpha = 255) : base(red, green, blue, alpha){ }
        public ColorTypes() { }

        public vector4 CYMK
        {
            get
            {
                vector4 tmp = Double;
                double kv = 1 - k.Max(tmp.X, tmp.Y, tmp.Z);
                return new vector4((1-tmp.X-kv) / (1 - kv), (1-tmp.Y-kv) / (1 - kv), (1-tmp.Z-kv) / (1 - kv), kv);
            }
            set
            {
                Double = new vector4((1 - value.X) * (1 - value.W), (1 - value.Y) * (1 - value.W), (1 - value.Z) * (1 - value.W), 1);
            }
        }

        public string HEX
        {
            get
            {
                return "#" + r.ToString("X").TwoCharHex() +g.ToString("X").TwoCharHex() + b.ToString("X").TwoCharHex();
            }
            set
            {
                string s = TagDecoder.OctoSingleTag(value).GetIndex(0);
                if (s.Length == 6)
                {
                    string s0 = "" + s[0] + s[1];
                    string s1 = "" + s[2] + s[3];
                    string s2 = "" + s[4] + s[5];
                    r = byte.Parse(s0, System.Globalization.NumberStyles.HexNumber);
                    g = byte.Parse(s1, System.Globalization.NumberStyles.HexNumber);
                    b = byte.Parse(s2, System.Globalization.NumberStyles.HexNumber);
                }
            }
        }
        public string HEXA
        {
            get
            {
                return "#" + r.ToString("X").TwoCharHex() + g.ToString("X").TwoCharHex() + b.ToString("X").TwoCharHex() + a.ToString("X").TwoCharHex();
            }
            set
            {
                string s = TagDecoder.OctoSingleTag(value).GetIndex(0);
                if (s.Length == 8)
                {
                    string s0 = "" + s[0] + s[1];
                    string s1 = "" + s[2] + s[3];
                    string s2 = "" + s[4] + s[5];
                    string s3 = "" + s[6] + s[7];
                    r = byte.Parse(s0, System.Globalization.NumberStyles.HexNumber);
                    g = byte.Parse(s1, System.Globalization.NumberStyles.HexNumber);
                    b = byte.Parse(s2, System.Globalization.NumberStyles.HexNumber);
                    a = byte.Parse(s3, System.Globalization.NumberStyles.HexNumber);
                }

            }
        }
    }
    public enum DimentionType
    {
        TwoD, ThreeD, FourD
    }
    public enum MovementType
    {
        Strict, Loose
    }
    public enum ColBoxType
    {
        Box, Sphere
    }

    public interface I3DWorldObject:IDrawable
    {
        vector3 Location { get; }
        vector3 Rotation { get; }
        vector3 Scale { get; }
    }
    public interface I2DWorldObject
    {
        vector2 Location { get; }
        double Rotation { get; }
        vector2 Scale { get; }
        drectangle ColBox { get; }
        bool collide { get; }
        ColBoxType CType { get; }
        double MoveSpeed { get; }
        void LookAt(vector2 target);
        void Teleport(vector2 location);
        I2DWorldManager Tracked { get; set; }
        List<I2DWorldObject> SubObjects { get; set; }
    }
    public interface I2DWorldManager
    {
        void StartMovementLinear(I2DWorldObject obj, vector2 dir);
        void StartMovementParabolic(I2DWorldObject obj, double up, double height);
        void Update(TimeSpan timedifference);
        void Track(I2DWorldObject obj);
        void TrackAll(I2DWorldObject obj);
    }

    public interface ISprite : I2DWorldObject,IDrawable2D
    {

    }

    public interface I2DCamera : I2DWorldObject
    {
        vector2 Size { get; }
    }

    public interface ITexture
    {
        size Size { get; }
        Color[,] Data { get; }
    }
    public interface IModel
    {
        ITexture Texture { get; }
    }

    public interface IDrawable2D : IDrawable
    {
        ITexture Texture { get; }
        drectangle Size { get; }
        Color Color { get; }
        I2DCamera Camera { get; }
    }
    public interface IDrawable3D : IDrawable
    {
    }

    public interface IDrawable
    {
        void Draw(IGraphicsManager graphics);
        bool DrawOverride { get; }
        bool Visible { get; }
    }

    public interface IGraphicsManager
    {
        void Draw2D(ITexture texture);
        void Draw2D(ITexture texture, vector2 location);
        void Draw2D(ITexture texture, vector2 location, vector2 size);
        void Draw2D(ITexture texture, drectangle lsize);
        void Draw2D(ITexture texture, drectangle lsize, Color color);
        void Draw2D(drectangle lsize, Color color);
        void Draw3D();
        void Draw(IDrawable obj);
        void Draw(IDrawable2D obj);
        void Draw(IDrawable3D obj);
    }
    public class Texture : ITexture
    {
        Color[,] data;
        size size;
        public size Size { get { return size; } }
        public Color[,] Data { get { return data; } }

        public Texture(int width, int height)
        {
            data = new Color[width, height];
            size = new size(width, height);
        }
    }

    public class GraphicsManager : IGraphicsManager
    {
        public void Draw(IDrawable2D obj)
        {
            if (obj.DrawOverride)
            {
                Draw(obj);
            }
            else
            {
                Draw2D(obj.Texture, obj.Size, obj.Color);
            }
        }
        public void Draw(IDrawable3D obj)
        {
            if (obj.DrawOverride)
            {
                Draw(obj);
            }
            else
            {
                Draw3D();
            }
        }

        public void Draw(IDrawable obj)
        {
            obj.Draw(this);
        }

        public void Draw2D(ITexture texture)
        {
            Draw2D(texture, vector2.Zero);
        }

        public void Draw2D(ITexture texture, vector2 location)
        {
            Draw2D(texture, new drectangle(location, texture.Size.ToVector2()));
        }

        public void Draw2D(ITexture texture, vector2 location, vector2 size)
        {
            Draw2D(texture, new drectangle(location, size));
        }

        public void Draw2D(ITexture texture, drectangle lsize)
        {
            Draw2D(texture, lsize, Color.White);
        }

        public void Draw2D(drectangle lsize, Color color)
        {
            Draw2D(null, lsize, color);
        }

        //end of the line
        public void Draw2D(ITexture texture, drectangle lsize, Color color)
        {

        }

        public void Draw3D()
        {
            throw new NotImplementedException();
        }
    }

    //public class Sprite : ISprite
    //{
    //    vector2 location = vector2.Zero;
    //    vector2 rotation = vector2.Zero;
    //    vector2 scale = vector2.One;

    //    ITexture tex;
    //    rectangle size;

    //    public Sprite(ITexture texture)
    //    {
    //        tex = texture;
    //        size = tex.Size;
    //    }

    //    public rectangle Size { get { return size; } }

    //    public ITexture Texture { get{ return tex; } }

    //    public vector2 Location { get { return location; } }

    //    public vector2 Rotation { get { return rotation; } }

    //    public vector2 Scale { get { return scale; } }

    //    public DimentionType DimType { get { return DimentionType.TwoD; } }

    //    public void Draw(IGraphicsManager graphics)
    //    {
    //        graphics.Draw2D(new drectangle(), Color.Black);
    //    }
    //}

    //public class PrimitiveObject2D : I2DWorldObject
    //{
    //    vector2 location = vector2.Zero;
    //    vector2 rotation = vector2.Zero;
    //    vector2 scale = vector2.One;

    //    public vector2 Location { get { return location; } }

    //    public vector2 Rotation { get { return rotation; } }

    //    public vector2 Scale { get { return scale; } }

    //    public DimentionType DimType { get { return DimentionType.TwoD; } }

    //    public void Draw(IGraphicsManager graphics)
    //    {
    //        graphics.Draw2D(new drectangle(), Color.Black);
    //    }
    //}

    //public class PrimitiveObject : IWorldObject
    //{
    //    vector3 location = vector3.Zero;
    //    vector3 rotation = vector3.Zero;
    //    vector3 scale = vector3.One;

    //    public vector3 Location { get { return location; } }

    //    public vector3 Rotation { get { return rotation; } }

    //    public vector3 Scale { get { return scale; } }

    //    public DimentionType DimType { get { return DimentionType.ThreeD; } }

    //    public void Draw(IGraphicsManager graphics)
    //    {
    //        graphics.Draw3D();
    //    }
    //}
}
