using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruaraidheulib.Interface.reulib64.GameObjects
{
    public interface IWorldObject:IDrawable
    {
        vector3 Location { get; }
        vector3 Rotation { get; }
        vector3 Scale { get; }
    }
    public interface I2DWorldObject : IDrawable
    {
        vector2 Location { get; }
        vector2 Rotation { get; }
        vector2 Scale { get; }
        rectangle Size { get; }
    }
    public interface IDrawable
    {
        void Draw(IGraphicsManager graphics);
    }
    public interface IGraphicsManager
    {
        void Draw2D();
        void Draw3D();
        void Draw(IDrawable obj);
    }

    public class Object2D : I2DWorldObject
    {
        vector2 location;
        vector2 rotation;
        vector2 scale;
        rectangle size;

        public vector2 Location { get { return location; } }

        public vector2 Rotation { get { return rotation; } }

        public vector2 Scale { get { return scale; } }

        public rectangle Size { get { return size; } }

        public void Draw(IGraphicsManager graphics)
        {
            graphics.Draw2D();
        }
    }

    public class Object : IWorldObject
    {
        vector3 location;
        vector3 rotation;
        vector3 scale;

        public vector3 Location { get { return location; } }

        public vector3 Rotation { get { return rotation; } }

        public vector3 Scale { get { return scale; } }

        public void Draw(IGraphicsManager graphics)
        {
            graphics.Draw3D();
        }
    }
}
