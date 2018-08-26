using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ruaraidheulib.Winforms
{
    public struct relativepoint : IEquatable<dpoint>
    {
        #region Private Fields

        private static readonly point zeroPoint = new point();
        private static readonly point fiftyPoint = new point(50, 50);

        #endregion

        #region Public Fields

        /// <summary>
        /// The x coordinate of this <see cref="point"/>.
        /// </summary>
        public double X;

        /// <summary>
        /// The y coordinate of this <see cref="point"/>.
        /// </summary>
        public double Y;

        #endregion

        #region Properties

        /// <summary>
        /// Returns a <see cref="point"/> with coordinates 0, 0.
        /// </summary>
        public static point Zero
        {
            get { return zeroPoint; }
        }

        public static point Center
        {
            get { return fiftyPoint; }
        }

        #endregion

        #region Internal Properties

        internal string DebugDisplayString
        {
            get
            {
                return string.Concat(
                    this.X.ToString(), "  ",
                    this.Y.ToString()
                );
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a point with X and Y from two values.
        /// </summary>
        /// <param name="x">The x coordinate in 2d-space.</param>
        /// <param name="y">The y coordinate in 2d-space.</param>
        public relativepoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Constructs a point with X and Y set to the same value.
        /// </summary>
        /// <param name="value">The x and y coordinates in 2d-space.</param>
        public relativepoint(double value)
        {
            this.X = value;
            this.Y = value;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adds two points.
        /// </summary>
        /// <param name="value1">Source <see cref="Point"/> on the left of the add sign.</param>
        /// <param name="value2">Source <see cref="Point"/> on the right of the add sign.</param>
        /// <returns>Sum of the points.</returns>
        public static relativepoint operator +(relativepoint value1, relativepoint value2)
        {
            return new relativepoint(value1.X + value2.X, value1.Y + value2.Y);
        }

        /// <summary>
        /// Subtracts a <see cref="Point"/> from a <see cref="Point"/>.
        /// </summary>
        /// <param name="value1">Source <see cref="Point"/> on the left of the sub sign.</param>
        /// <param name="value2">Source <see cref="Point"/> on the right of the sub sign.</param>
        /// <returns>Result of the subtraction.</returns>
        public static relativepoint operator -(relativepoint value1, relativepoint value2)
        {
            return new relativepoint(value1.X - value2.X, value1.Y - value2.Y);
        }

        /// <summary>
        /// Multiplies the components of two points by each other.
        /// </summary>
        /// <param name="value1">Source <see cref="Point"/> on the left of the mul sign.</param>
        /// <param name="value2">Source <see cref="Point"/> on the right of the mul sign.</param>
        /// <returns>Result of the multiplication.</returns>
        public static relativepoint operator *(relativepoint value1, relativepoint value2)
        {
            return new relativepoint(value1.X * value2.X, value1.Y * value2.Y);
        }

        /// <summary>
        /// Divides the components of a <see cref="Point"/> by the components of another <see cref="Point"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Point"/> on the left of the div sign.</param>
        /// <param name="divisor">Divisor <see cref="Point"/> on the right of the div sign.</param>
        /// <returns>The result of dividing the points.</returns>
        public static relativepoint operator /(relativepoint source, relativepoint divisor)
        {
            return new relativepoint(source.X / divisor.X, source.Y / divisor.Y);
        }

        /// <summary>
        /// Compares whether two <see cref="Point"/> instances are equal.
        /// </summary>
        /// <param name="a"><see cref="Point"/> instance on the left of the equal sign.</param>
        /// <param name="b"><see cref="Point"/> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(relativepoint a, relativepoint b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares whether two <see cref="Point"/> instances are not equal.
        /// </summary>
        /// <param name="a"><see cref="Point"/> instance on the left of the not equal sign.</param>
        /// <param name="b"><see cref="Point"/> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>	
        public static bool operator !=(relativepoint a, relativepoint b)
        {
            return !a.Equals(b);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return (obj is dpoint) && Equals((dpoint)obj);
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="point"/>.
        /// </summary>
        /// <param name="other">The <see cref="point"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(dpoint other)
        {
            return ((X == other.X) && (Y == other.Y));
        }

        /// <summary>
        /// Gets the hash code of this <see cref="Point"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="Point"/>.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }

        }

        /// <summary>
        /// Returns a <see cref="String"/> representation of this <see cref="point"/> in the format:
        /// {X:[<see cref="X"/>] Y:[<see cref="Y"/>]}
        /// </summary>
        /// <returns><see cref="String"/> representation of this <see cref="point"/>.</returns>
        public override string ToString()
        {
            return "{X:" + X + " Y:" + Y + "}";
        }

        /// <summary>
        /// Gets a <see cref="Vector2"/> representation for this object.
        /// </summary>
        /// <returns>A <see cref="Vector2"/> representation for this object.</returns>
        public vector2 ToVector2()
        {
            return new vector2(X, Y);
        }

        #endregion
    }
    public struct container
    {
        point loc;
        size siz;
        public container(point location, size size)
        {
            loc = location;
            siz = size;
        }
    }
    public interface IComputeEngine : IDisposable, ICloneable
    {
        void Center();
        void Center(container parent);
        void Center(relativepoint origin);
        void Center(relativepoint origin, container parent);
        void Center(Form f, container parent);
        void Center(Form f, relativepoint origin, container parent);
        void Center(Form f, relativepoint origin, size parentcontainer);
        void Center(UserControl uc, container parent);
        void Center(UserControl uc, relativepoint origin, container parent);
        void Center(UserControl uc, relativepoint origin, size parentcontainer);

        void Position(relativepoint position);
        void Position(relativepoint position, relativepoint origin);
        void Position(relativepoint position, relativepoint origin, container parent);
        void Position(Form f, relativepoint position);
        void Position(Form f, relativepoint position, relativepoint origin);
        void Position(Form f, relativepoint position, relativepoint origin, container parent);
        void Position(UserControl uc, relativepoint position);
        void Position(UserControl uc, relativepoint position, relativepoint origin);
        void Position(UserControl uc, relativepoint position, relativepoint origin, container parent);
    }
}
