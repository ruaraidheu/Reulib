using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Ruaraidheulib
{
    /// <summary>
    /// Represents the right-handed 4x4 floating point matrix, which can store translation, scale and rotation information.
    /// </summary>
    public struct matrix : IEquatable<matrix>
    {
        #region Public Constructors

        /// <summary>
        /// Constructs a matrix.
        /// </summary>
        /// <param name="m11">A first row and first column value.</param>
        /// <param name="m12">A first row and second column value.</param>
        /// <param name="m13">A first row and third column value.</param>
        /// <param name="m14">A first row and fourth column value.</param>
        /// <param name="m21">A second row and first column value.</param>
        /// <param name="m22">A second row and second column value.</param>
        /// <param name="m23">A second row and third column value.</param>
        /// <param name="m24">A second row and fourth column value.</param>
        /// <param name="m31">A third row and first column value.</param>
        /// <param name="m32">A third row and second column value.</param>
        /// <param name="m33">A third row and third column value.</param>
        /// <param name="m34">A third row and fourth column value.</param>
        /// <param name="m41">A fourth row and first column value.</param>
        /// <param name="m42">A fourth row and second column value.</param>
        /// <param name="m43">A fourth row and third column value.</param>
        /// <param name="m44">A fourth row and fourth column value.</param>
        public matrix(double m11, double m12, double m13, double m14, double m21, double m22, double m23, double m24, double m31,
                      double m32, double m33, double m34, double m41, double m42, double m43, double m44)
        {
            this.M11 = m11;
            this.M12 = m12;
            this.M13 = m13;
            this.M14 = m14;
            this.M21 = m21;
            this.M22 = m22;
            this.M23 = m23;
            this.M24 = m24;
            this.M31 = m31;
            this.M32 = m32;
            this.M33 = m33;
            this.M34 = m34;
            this.M41 = m41;
            this.M42 = m42;
            this.M43 = m43;
            this.M44 = m44;
        }

        /// <summary>
        /// Constructs a matrix.
        /// </summary>
        /// <param name="row1">A first row of the created matrix.</param>
        /// <param name="row2">A second row of the created matrix.</param>
        /// <param name="row3">A third row of the created matrix.</param>
        /// <param name="row4">A fourth row of the created matrix.</param>
        public matrix(vector4 row1, vector4 row2, vector4 row3, vector4 row4)
        {
            this.M11 = row1.X;
            this.M12 = row1.Y;
            this.M13 = row1.Z;
            this.M14 = row1.W;
            this.M21 = row2.X;
            this.M22 = row2.Y;
            this.M23 = row2.Z;
            this.M24 = row2.W;
            this.M31 = row3.X;
            this.M32 = row3.Y;
            this.M33 = row3.Z;
            this.M34 = row3.W;
            this.M41 = row4.X;
            this.M42 = row4.Y;
            this.M43 = row4.Z;
            this.M44 = row4.W;
        }

        #endregion

        #region Public Fields

        /// <summary>
        /// A first row and first column value.
        /// </summary>
        public double M11;

        /// <summary>
        /// A first row and second column value.
        /// </summary>
        public double M12;

        /// <summary>
        /// A first row and third column value.
        /// </summary>
        public double M13;

        /// <summary>
        /// A first row and fourth column value.
        /// </summary>
        public double M14;

        /// <summary>
        /// A second row and first column value.
        /// </summary>
        public double M21;

        /// <summary>
        /// A second row and second column value.
        /// </summary>
        public double M22;

        /// <summary>
        /// A second row and third column value.
        /// </summary>
        public double M23;

        /// <summary>
        /// A second row and fourth column value.
        /// </summary>
        public double M24;

        /// <summary>
        /// A third row and first column value.
        /// </summary>
        public double M31;

        /// <summary>
        /// A third row and second column value.
        /// </summary>
        public double M32;

        /// <summary>
        /// A third row and third column value.
        /// </summary>
        public double M33;

        /// <summary>
        /// A third row and fourth column value.
        /// </summary>
        public double M34;

        /// <summary>
        /// A fourth row and first column value.
        /// </summary>
        public double M41;

        /// <summary>
        /// A fourth row and second column value.
        /// </summary>
        public double M42;

        /// <summary>
        /// A fourth row and third column value.
        /// </summary>
        public double M43;

        /// <summary>
        /// A fourth row and fourth column value.
        /// </summary>
        public double M44;

        #endregion

        #region Indexers

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return M11;
                    case 1: return M12;
                    case 2: return M13;
                    case 3: return M14;
                    case 4: return M21;
                    case 5: return M22;
                    case 6: return M23;
                    case 7: return M24;
                    case 8: return M31;
                    case 9: return M32;
                    case 10: return M33;
                    case 11: return M34;
                    case 12: return M41;
                    case 13: return M42;
                    case 14: return M43;
                    case 15: return M44;
                }
                throw new ArgumentOutOfRangeException();
            }

            set
            {
                switch (index)
                {
                    case 0: M11 = value; break;
                    case 1: M12 = value; break;
                    case 2: M13 = value; break;
                    case 3: M14 = value; break;
                    case 4: M21 = value; break;
                    case 5: M22 = value; break;
                    case 6: M23 = value; break;
                    case 7: M24 = value; break;
                    case 8: M31 = value; break;
                    case 9: M32 = value; break;
                    case 10: M33 = value; break;
                    case 11: M34 = value; break;
                    case 12: M41 = value; break;
                    case 13: M42 = value; break;
                    case 14: M43 = value; break;
                    case 15: M44 = value; break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }

        public double this[int row, int column]
        {
            get
            {
                return this[(row * 4) + column];
            }

            set
            {
                this[(row * 4) + column] = value;
            }
        }

        #endregion

        #region Private Members
        private static matrix identity = new matrix(1, 0, 0, 0,
                                                    0, 1, 0, 0,
                                                    0, 0, 1, 0,
                                                    0, 0, 0, 1);
        #endregion

        #region Public Properties

        /// <summary>
        /// The backward vector formed from the third row M31, M32, M33 elements.
        /// </summary>
        public vector3 Backward
        {
            get
            {
                return new vector3(this.M31, this.M32, this.M33);
            }
            set
            {
                this.M31 = value.X;
                this.M32 = value.Y;
                this.M33 = value.Z;
            }
        }

        /// <summary>
        /// The down vector formed from the second row -M21, -M22, -M23 elements.
        /// </summary>
        public vector3 Down
        {
            get
            {
                return new vector3(-this.M21, -this.M22, -this.M23);
            }
            set
            {
                this.M21 = -value.X;
                this.M22 = -value.Y;
                this.M23 = -value.Z;
            }
        }

        /// <summary>
        /// The forward vector formed from the third row -M31, -M32, -M33 elements.
        /// </summary>
        public vector3 Forward
        {
            get
            {
                return new vector3(-this.M31, -this.M32, -this.M33);
            }
            set
            {
                this.M31 = -value.X;
                this.M32 = -value.Y;
                this.M33 = -value.Z;
            }
        }

        /// <summary>
        /// Returns the identity matrix.
        /// </summary>
        public static matrix Identity
        {
            get { return identity; }
        }

        /// <summary>
        /// The left vector formed from the first row -M11, -M12, -M13 elements.
        /// </summary>
        public vector3 Left
        {
            get
            {
                return new vector3(-this.M11, -this.M12, -this.M13);
            }
            set
            {
                this.M11 = -value.X;
                this.M12 = -value.Y;
                this.M13 = -value.Z;
            }
        }

        /// <summary>
        /// The right vector formed from the first row M11, M12, M13 elements.
        /// </summary>
        public vector3 Right
        {
            get
            {
                return new vector3(this.M11, this.M12, this.M13);
            }
            set
            {
                this.M11 = value.X;
                this.M12 = value.Y;
                this.M13 = value.Z;
            }
        }

        /// <summary>
        /// Position stored in this matrix.
        /// </summary>
        public vector3 Translation
        {
            get
            {
                return new vector3(this.M41, this.M42, this.M43);
            }
            set
            {
                this.M41 = value.X;
                this.M42 = value.Y;
                this.M43 = value.Z;
            }
        }

        /// <summary>
        /// The upper vector formed from the second row M21, M22, M23 elements.
        /// </summary>
        public vector3 Up
        {
            get
            {
                return new vector3(this.M21, this.M22, this.M23);
            }
            set
            {
                this.M21 = value.X;
                this.M22 = value.Y;
                this.M23 = value.Z;
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new <see cref="matrix"/> which contains sum of two matrixes.
        /// </summary>
        /// <param name="matrix1">The first matrix to add.</param>
        /// <param name="matrix2">The second matrix to add.</param>
        /// <returns>The result of the matrix addition.</returns>
        public static matrix Add(matrix matrix1, matrix matrix2)
        {
            matrix1.M11 += matrix2.M11;
            matrix1.M12 += matrix2.M12;
            matrix1.M13 += matrix2.M13;
            matrix1.M14 += matrix2.M14;
            matrix1.M21 += matrix2.M21;
            matrix1.M22 += matrix2.M22;
            matrix1.M23 += matrix2.M23;
            matrix1.M24 += matrix2.M24;
            matrix1.M31 += matrix2.M31;
            matrix1.M32 += matrix2.M32;
            matrix1.M33 += matrix2.M33;
            matrix1.M34 += matrix2.M34;
            matrix1.M41 += matrix2.M41;
            matrix1.M42 += matrix2.M42;
            matrix1.M43 += matrix2.M43;
            matrix1.M44 += matrix2.M44;
            return matrix1;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> which contains sum of two matrixes.
        /// </summary>
        /// <param name="matrix1">The first matrix to add.</param>
        /// <param name="matrix2">The second matrix to add.</param>
        /// <param name="result">The result of the matrix addition as an output parameter.</param>
        public static void Add(ref matrix matrix1, ref matrix matrix2, out matrix result)
        {
            result.M11 = matrix1.M11 + matrix2.M11;
            result.M12 = matrix1.M12 + matrix2.M12;
            result.M13 = matrix1.M13 + matrix2.M13;
            result.M14 = matrix1.M14 + matrix2.M14;
            result.M21 = matrix1.M21 + matrix2.M21;
            result.M22 = matrix1.M22 + matrix2.M22;
            result.M23 = matrix1.M23 + matrix2.M23;
            result.M24 = matrix1.M24 + matrix2.M24;
            result.M31 = matrix1.M31 + matrix2.M31;
            result.M32 = matrix1.M32 + matrix2.M32;
            result.M33 = matrix1.M33 + matrix2.M33;
            result.M34 = matrix1.M34 + matrix2.M34;
            result.M41 = matrix1.M41 + matrix2.M41;
            result.M42 = matrix1.M42 + matrix2.M42;
            result.M43 = matrix1.M43 + matrix2.M43;
            result.M44 = matrix1.M44 + matrix2.M44;

        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> for spherical billboarding that rotates around specified object position.
        /// </summary>
        /// <param name="objectPosition">Position of billboard object. It will rotate around that vector.</param>
        /// <param name="cameraPosition">The camera position.</param>
        /// <param name="cameraUpVector">The camera up vector.</param>
        /// <param name="cameraForwardVector">Optional camera forward vector.</param>
        /// <returns>The <see cref="matrix"/> for spherical billboarding.</returns>
        public static matrix CreateBillboard(vector3 objectPosition, vector3 cameraPosition,
            vector3 cameraUpVector, Nullable<vector3> cameraForwardVector)
        {
            matrix result;

            // Delegate to the other overload of the function to do the work
            CreateBillboard(ref objectPosition, ref cameraPosition, ref cameraUpVector, cameraForwardVector, out result);

            return result;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> for spherical billboarding that rotates around specified object position.
        /// </summary>
        /// <param name="objectPosition">Position of billboard object. It will rotate around that vector.</param>
        /// <param name="cameraPosition">The camera position.</param>
        /// <param name="cameraUpVector">The camera up vector.</param>
        /// <param name="cameraForwardVector">Optional camera forward vector.</param>
        /// <param name="result">The <see cref="matrix"/> for spherical billboarding as an output parameter.</param>
        public static void CreateBillboard(ref vector3 objectPosition, ref vector3 cameraPosition,
            ref vector3 cameraUpVector, vector3? cameraForwardVector, out matrix result)
        {
            vector3 v1;
            vector3 v2;
            vector3 v3;
            v1.X = objectPosition.X - cameraPosition.X;
            v1.Y = objectPosition.Y - cameraPosition.Y;
            v1.Z = objectPosition.Z - cameraPosition.Z;
            double num = v1.LengthSquared();
            if (num < 0.0001)
            {
                v1 = cameraForwardVector.HasValue ? -cameraForwardVector.Value : vector3.Forward;
            }
            else
            {
                vector3.Multiply(ref v1, (1d / (Math.Sqrt(num))), out v1);
            }
            vector3.Cross(ref cameraUpVector, ref v1, out v3);
            v3.Normalize();
            vector3.Cross(ref v1, ref v3, out v2);
            result.M11 = v3.X;
            result.M12 = v3.Y;
            result.M13 = v3.Z;
            result.M14 = 0;
            result.M21 = v2.X;
            result.M22 = v2.Y;
            result.M23 = v2.Z;
            result.M24 = 0;
            result.M31 = v1.X;
            result.M32 = v1.Y;
            result.M33 = v1.Z;
            result.M34 = 0;
            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> for cylindrical billboarding that rotates around specified axis.
        /// </summary>
        /// <param name="objectPosition">Object position the billboard will rotate around.</param>
        /// <param name="cameraPosition">Camera position.</param>
        /// <param name="rotateAxis">Axis of billboard for rotation.</param>
        /// <param name="cameraForwardVector">Optional camera forward vector.</param>
        /// <param name="objectForwardVector">Optional object forward vector.</param>
        /// <returns>The <see cref="matrix"/> for cylindrical billboarding.</returns>
        public static matrix CreateConstrainedBillboard(vector3 objectPosition, vector3 cameraPosition,
            vector3 rotateAxis, Nullable<vector3> cameraForwardVector, Nullable<vector3> objectForwardVector)
        {
            matrix result;
            CreateConstrainedBillboard(ref objectPosition, ref cameraPosition, ref rotateAxis,
                cameraForwardVector, objectForwardVector, out result);
            return result;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> for cylindrical billboarding that rotates around specified axis.
        /// </summary>
        /// <param name="objectPosition">Object position the billboard will rotate around.</param>
        /// <param name="cameraPosition">Camera position.</param>
        /// <param name="rotateAxis">Axis of billboard for rotation.</param>
        /// <param name="cameraForwardVector">Optional camera forward vector.</param>
        /// <param name="objectForwardVector">Optional object forward vector.</param>
        /// <param name="result">The <see cref="matrix"/> for cylindrical billboarding as an output parameter.</param>
        public static void CreateConstrainedBillboard(ref vector3 objectPosition, ref vector3 cameraPosition,
            ref vector3 rotateAxis, vector3? cameraForwardVector, vector3? objectForwardVector, out matrix result)
        {
            double num;
            vector3 vector;
            vector3 vector2;
            vector3 vector3;
            vector2.X = objectPosition.X - cameraPosition.X;
            vector2.Y = objectPosition.Y - cameraPosition.Y;
            vector2.Z = objectPosition.Z - cameraPosition.Z;
            double num2 = vector2.LengthSquared();
            if (num2 < 0.0001)
            {
                vector2 = cameraForwardVector.HasValue ? -cameraForwardVector.Value : vector3.Forward;
            }
            else
            {
                vector3.Multiply(ref vector2, (1d / (Math.Sqrt(num2))), out vector2);
            }
            vector3 vector4 = rotateAxis;
            vector3.Dot(ref rotateAxis, ref vector2, out num);
            if (Math.Abs(num) > 0.9982547)
            {
                if (objectForwardVector.HasValue)
                {
                    vector = objectForwardVector.Value;
                    vector3.Dot(ref rotateAxis, ref vector, out num);
                    if (Math.Abs(num) > 0.9982547)
                    {
                        num = ((rotateAxis.X * vector3.Forward.X) + (rotateAxis.Y * vector3.Forward.Y)) + (rotateAxis.Z * vector3.Forward.Z);
                        vector = (Math.Abs(num) > 0.9982547) ? vector3.Right : vector3.Forward;
                    }
                }
                else
                {
                    num = ((rotateAxis.X * vector3.Forward.X) + (rotateAxis.Y * vector3.Forward.Y)) + (rotateAxis.Z * vector3.Forward.Z);
                    vector = (Math.Abs(num) > 0.9982547) ? vector3.Right : vector3.Forward;
                }
                vector3.Cross(ref rotateAxis, ref vector, out vector3);
                vector3.Normalize();
                vector3.Cross(ref vector3, ref rotateAxis, out vector);
                vector.Normalize();
            }
            else
            {
                vector3.Cross(ref rotateAxis, ref vector2, out vector3);
                vector3.Normalize();
                vector3.Cross(ref vector3, ref vector4, out vector);
                vector.Normalize();
            }
            result.M11 = vector3.X;
            result.M12 = vector3.Y;
            result.M13 = vector3.Z;
            result.M14 = 0;
            result.M21 = vector4.X;
            result.M22 = vector4.Y;
            result.M23 = vector4.Z;
            result.M24 = 0;
            result.M31 = vector.X;
            result.M32 = vector.Y;
            result.M33 = vector.Z;
            result.M34 = 0;
            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1;

        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> which contains the rotation moment around specified axis.
        /// </summary>
        /// <param name="axis">The axis of rotation.</param>
        /// <param name="angle">The angle of rotation in radians.</param>
        /// <returns>The rotation <see cref="matrix"/>.</returns>
        public static matrix CreateFromAxisAngle(vector3 axis, double angle)
        {
            matrix result;
            CreateFromAxisAngle(ref axis, angle, out result);
            return result;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> which contains the rotation moment around specified axis.
        /// </summary>
        /// <param name="axis">The axis of rotation.</param>
        /// <param name="angle">The angle of rotation in radians.</param>
        /// <param name="result">The rotation <see cref="matrix"/> as an output parameter.</param>
        public static void CreateFromAxisAngle(ref vector3 axis, double angle, out matrix result)
        {
            double x = axis.X;
            double y = axis.Y;
            double z = axis.Z;
            double num2 = Math.Sin(angle);
            double num = Math.Cos(angle);
            double num11 = x * x;
            double num10 = y * y;
            double num9 = z * z;
            double num8 = x * y;
            double num7 = x * z;
            double num6 = y * z;
            result.M11 = num11 + (num * (1d - num11));
            result.M12 = (num8 - (num * num8)) + (num2 * z);
            result.M13 = (num7 - (num * num7)) - (num2 * y);
            result.M14 = 0;
            result.M21 = (num8 - (num * num8)) - (num2 * z);
            result.M22 = num10 + (num * (1d - num10));
            result.M23 = (num6 - (num * num6)) + (num2 * x);
            result.M24 = 0;
            result.M31 = (num7 - (num * num7)) + (num2 * y);
            result.M32 = (num6 - (num * num6)) - (num2 * x);
            result.M33 = num9 + (num * (1d - num9));
            result.M34 = 0;
            result.M41 = 0;
            result.M42 = 0;
            result.M43 = 0;
            result.M44 = 1;
        }

        /// <summary>
        /// Creates a new rotation <see cref="matrix"/> from a <see cref="Quaternion"/>.
        /// </summary>
        /// <param name="quaternion"><see cref="Quaternion"/> of rotation moment.</param>
        /// <returns>The rotation <see cref="matrix"/>.</returns>
        public static matrix CreateFromQuaternion(quaternion quaternion)
        {
            matrix result;
            CreateFromQuaternion(ref quaternion, out result);
            return result;
        }

        /// <summary>
        /// Creates a new rotation <see cref="matrix"/> from a <see cref="Quaternion"/>.
        /// </summary>
        /// <param name="quaternion"><see cref="Quaternion"/> of rotation moment.</param>
        /// <param name="result">The rotation <see cref="matrix"/> as an output parameter.</param>
        public static void CreateFromQuaternion(ref quaternion quaternion, out matrix result)
        {
            double num9 = quaternion.X * quaternion.X;
            double num8 = quaternion.Y * quaternion.Y;
            double num7 = quaternion.Z * quaternion.Z;
            double num6 = quaternion.X * quaternion.Y;
            double num5 = quaternion.Z * quaternion.W;
            double num4 = quaternion.Z * quaternion.X;
            double num3 = quaternion.Y * quaternion.W;
            double num2 = quaternion.Y * quaternion.Z;
            double num = quaternion.X * quaternion.W;
            result.M11 = 1d - (2d * (num8 + num7));
            result.M12 = 2d * (num6 + num5);
            result.M13 = 2d * (num4 - num3);
            result.M14 = 0d;
            result.M21 = 2d * (num6 - num5);
            result.M22 = 1d - (2d * (num7 + num9));
            result.M23 = 2d * (num2 + num);
            result.M24 = 0d;
            result.M31 = 2d * (num4 + num3);
            result.M32 = 2d * (num2 - num);
            result.M33 = 1d - (2d * (num8 + num9));
            result.M34 = 0d;
            result.M41 = 0d;
            result.M42 = 0d;
            result.M43 = 0d;
            result.M44 = 1d;
        }

        /// <summary>
        /// Creates a new rotation <see cref="matrix"/> from the specified yaw, pitch and roll values.
        /// </summary>
        /// <param name="yaw">The yaw rotation value in radians.</param>
        /// <param name="pitch">The pitch rotation value in radians.</param>
        /// <param name="roll">The roll rotation value in radians.</param>
        /// <returns>The rotation <see cref="matrix"/>.</returns>
        /// <remarks>For more information about yaw, pitch and roll visit http://en.wikipedia.org/wiki/Euler_angles.
        /// </remarks>
        public static matrix CreateFromYawPitchRoll(double yaw, double pitch, double roll)
        {
            matrix matrix;
            CreateFromYawPitchRoll(yaw, pitch, roll, out matrix);
            return matrix;
        }

        /// <summary>
        /// Creates a new rotation <see cref="matrix"/> from the specified yaw, pitch and roll values.
        /// </summary>
        /// <param name="yaw">The yaw rotation value in radians.</param>
        /// <param name="pitch">The pitch rotation value in radians.</param>
        /// <param name="roll">The roll rotation value in radians.</param>
        /// <param name="result">The rotation <see cref="matrix"/> as an output parameter.</param>
        /// <remarks>For more information about yaw, pitch and roll visit http://en.wikipedia.org/wiki/Euler_angles.
        /// </remarks>
        public static void CreateFromYawPitchRoll(double yaw, double pitch, double roll, out matrix result)
        {
            quaternion quaternion;
            quaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out quaternion);
            CreateFromQuaternion(ref quaternion, out result);
        }

        /// <summary>
        /// Creates a new viewing <see cref="matrix"/>.
        /// </summary>
        /// <param name="cameraPosition">Position of the camera.</param>
        /// <param name="cameraTarget">Lookup vector of the camera.</param>
        /// <param name="cameraUpVector">The direction of the upper edge of the camera.</param>
        /// <returns>The viewing <see cref="matrix"/>.</returns>
        public static matrix CreateLookAt(vector3 cameraPosition, vector3 cameraTarget, vector3 cameraUpVector)
        {
            matrix matrix;
            CreateLookAt(ref cameraPosition, ref cameraTarget, ref cameraUpVector, out matrix);
            return matrix;
        }

        /// <summary>
        /// Creates a new viewing <see cref="matrix"/>.
        /// </summary>
        /// <param name="cameraPosition">Position of the camera.</param>
        /// <param name="cameraTarget">Lookup vector of the camera.</param>
        /// <param name="cameraUpVector">The direction of the upper edge of the camera.</param>
        /// <param name="result">The viewing <see cref="matrix"/> as an output parameter.</param>
        public static void CreateLookAt(ref vector3 cameraPosition, ref vector3 cameraTarget, ref vector3 cameraUpVector, out matrix result)
        {
            vector3 v0 = vector3.Normalize(cameraPosition - cameraTarget);
            vector3 v1 = vector3.Normalize(vector3.Cross(cameraUpVector, v0));
            vector3 v2 = vector3.Cross(v0, v1);
            result.M11 = v1.X;
            result.M12 = v2.X;
            result.M13 = v0.X;
            result.M14 = 0d;
            result.M21 = v1.Y;
            result.M22 = v2.Y;
            result.M23 = v0.Y;
            result.M24 = 0d;
            result.M31 = v1.Z;
            result.M32 = v2.Z;
            result.M33 = v0.Z;
            result.M34 = 0d;
            result.M41 = -vector3.Dot(v1, cameraPosition);
            result.M42 = -vector3.Dot(v2, cameraPosition);
            result.M43 = -vector3.Dot(v0, cameraPosition);
            result.M44 = 1d;
        }

        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for orthographic view.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="zNearPlane">Depth of the near plane.</param>
        /// <param name="zFarPlane">Depth of the far plane.</param>
        /// <returns>The new projection <see cref="matrix"/> for orthographic view.</returns>
        public static matrix CreateOrthographic(double width, double height, double zNearPlane, double zFarPlane)
        {
            matrix matrix;
            CreateOrthographic(width, height, zNearPlane, zFarPlane, out matrix);
            return matrix;
        }

        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for orthographic view.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="zNearPlane">Depth of the near plane.</param>
        /// <param name="zFarPlane">Depth of the far plane.</param>
        /// <param name="result">The new projection <see cref="matrix"/> for orthographic view as an output parameter.</param>
        public static void CreateOrthographic(double width, double height, double zNearPlane, double zFarPlane, out matrix result)
        {
            result.M11 = 2d / width;
            result.M12 = result.M13 = result.M14 = 0d;
            result.M22 = 2d / height;
            result.M21 = result.M23 = result.M24 = 0d;
            result.M33 = 1d / (zNearPlane - zFarPlane);
            result.M31 = result.M32 = result.M34 = 0d;
            result.M41 = result.M42 = 0d;
            result.M43 = zNearPlane / (zNearPlane - zFarPlane);
            result.M44 = 1d;
        }

        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for customized orthographic view.
        /// </summary>
        /// <param name="left">Lower x-value at the near plane.</param>
        /// <param name="right">Upper x-value at the near plane.</param>
        /// <param name="bottom">Lower y-coordinate at the near plane.</param>
        /// <param name="top">Upper y-value at the near plane.</param>
        /// <param name="zNearPlane">Depth of the near plane.</param>
        /// <param name="zFarPlane">Depth of the far plane.</param>
        /// <returns>The new projection <see cref="matrix"/> for customized orthographic view.</returns>
        public static matrix CreateOrthographicOffCenter(double left, double right, double bottom, double top, double zNearPlane, double zFarPlane)
        {
            matrix matrix;
            CreateOrthographicOffCenter(left, right, bottom, top, zNearPlane, zFarPlane, out matrix);
            return matrix;
        }

        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for customized orthographic view.
        /// </summary>
        /// <param name="viewingVolume">The viewing volume.</param>
        /// <param name="zNearPlane">Depth of the near plane.</param>
        /// <param name="zFarPlane">Depth of the far plane.</param>
        /// <returns>The new projection <see cref="matrix"/> for customized orthographic view.</returns>
        public static matrix CreateOrthographicOffCenter(rectangle viewingVolume, double zNearPlane, double zFarPlane)
        {
            matrix matrix;
            CreateOrthographicOffCenter(viewingVolume.Left, viewingVolume.Right, viewingVolume.Bottom, viewingVolume.Top, zNearPlane, zFarPlane, out matrix);
            return matrix;
        }

        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for customized orthographic view.
        /// </summary>
        /// <param name="left">Lower x-value at the near plane.</param>
        /// <param name="right">Upper x-value at the near plane.</param>
        /// <param name="bottom">Lower y-coordinate at the near plane.</param>
        /// <param name="top">Upper y-value at the near plane.</param>
        /// <param name="zNearPlane">Depth of the near plane.</param>
        /// <param name="zFarPlane">Depth of the far plane.</param>
        /// <param name="result">The new projection <see cref="matrix"/> for customized orthographic view as an output parameter.</param>
        public static void CreateOrthographicOffCenter(double left, double right, double bottom, double top, double zNearPlane, double zFarPlane, out matrix result)
        {
            result.M11 = (2.0 / (right - left));
            result.M12 = 0.0;
            result.M13 = 0.0;
            result.M14 = 0.0;
            result.M21 = 0.0;
            result.M22 = (2.0 / (top - bottom));
            result.M23 = 0.0;
            result.M24 = 0.0;
            result.M31 = 0.0;
            result.M32 = 0.0;
            result.M33 = (1.0 / (zNearPlane - zFarPlane));
            result.M34 = 0.0;
            result.M41 = ((left + right) / (left - right));
            result.M42 = ((top + bottom) / (bottom - top));
            result.M43 = (zNearPlane / (zNearPlane - zFarPlane));
            result.M44 = 1.0;
        }

        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for perspective view.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="nearPlaneDistance">Distance to the near plane.</param>
        /// <param name="farPlaneDistance">Distance to the far plane.</param>
        /// <returns>The new projection <see cref="matrix"/> for perspective view.</returns>
        public static matrix CreatePerspective(double width, double height, double nearPlaneDistance, double farPlaneDistance)
        {
            matrix matrix;
            CreatePerspective(width, height, nearPlaneDistance, farPlaneDistance, out matrix);
            return matrix;
        }

        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for perspective view.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="nearPlaneDistance">Distance to the near plane.</param>
        /// <param name="farPlaneDistance">Distance to the far plane.</param>
        /// <param name="result">The new projection <see cref="matrix"/> for perspective view as an output parameter.</param>
        public static void CreatePerspective(double width, double height, double nearPlaneDistance, double farPlaneDistance, out matrix result)
        {
            if (nearPlaneDistance <= 0d)
            {
                throw new ArgumentException("nearPlaneDistance <= 0");
            }
            if (farPlaneDistance <= 0d)
            {
                throw new ArgumentException("farPlaneDistance <= 0");
            }
            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
            }
            result.M11 = (2d * nearPlaneDistance) / width;
            result.M12 = result.M13 = result.M14 = 0d;
            result.M22 = (2d * nearPlaneDistance) / height;
            result.M21 = result.M23 = result.M24 = 0d;
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M31 = result.M32 = 0d;
            result.M34 = -1d;
            result.M41 = result.M42 = result.M44 = 0d;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
        }

        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for perspective view with field of view.
        /// </summary>
        /// <param name="fieldOfView">Field of view in the y direction in radians.</param>
        /// <param name="aspectRatio">Width divided by height of the viewing volume.</param>
        /// <param name="nearPlaneDistance">Distance to the near plane.</param>
        /// <param name="farPlaneDistance">Distance to the far plane.</param>
        /// <returns>The new projection <see cref="matrix"/> for perspective view with FOV.</returns>
        public static matrix CreatePerspectiveFieldOfView(double fieldOfView, double aspectRatio, double nearPlaneDistance, double farPlaneDistance)
        {
            matrix result;
            CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance, out result);
            return result;
        }

        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for perspective view with field of view.
        /// </summary>
        /// <param name="fieldOfView">Field of view in the y direction in radians.</param>
        /// <param name="aspectRatio">Width divided by height of the viewing volume.</param>
        /// <param name="nearPlaneDistance">Distance of the near plane.</param>
        /// <param name="farPlaneDistance">Distance of the far plane.</param>
        /// <param name="result">The new projection <see cref="matrix"/> for perspective view with FOV as an output parameter.</param>
        public static void CreatePerspectiveFieldOfView(double fieldOfView, double aspectRatio, double nearPlaneDistance, double farPlaneDistance, out matrix result)
        {
            if ((fieldOfView <= 0d) || (fieldOfView >= k.Pi_d))
            {
                throw new ArgumentException("fieldOfView <= 0 or >= PI");
            }
            if (nearPlaneDistance <= 0d)
            {
                throw new ArgumentException("nearPlaneDistance <= 0");
            }
            if (farPlaneDistance <= 0d)
            {
                throw new ArgumentException("farPlaneDistance <= 0");
            }
            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
            }
            double num = 1d / (Math.Tan((fieldOfView * 0.5d)));
            double num9 = num / aspectRatio;
            result.M11 = num9;
            result.M12 = result.M13 = result.M14 = 0;
            result.M22 = num;
            result.M21 = result.M23 = result.M24 = 0;
            result.M31 = result.M32 = 0d;
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M34 = -1;
            result.M41 = result.M42 = result.M44 = 0;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
        }

        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for customized perspective view.
        /// </summary>
        /// <param name="left">Lower x-value at the near plane.</param>
        /// <param name="right">Upper x-value at the near plane.</param>
        /// <param name="bottom">Lower y-coordinate at the near plane.</param>
        /// <param name="top">Upper y-value at the near plane.</param>
        /// <param name="nearPlaneDistance">Distance to the near plane.</param>
        /// <param name="farPlaneDistance">Distance to the far plane.</param>
        /// <returns>The new <see cref="matrix"/> for customized perspective view.</returns>
        public static matrix CreatePerspectiveOffCenter(double left, double right, double bottom, double top, double nearPlaneDistance, double farPlaneDistance)
        {
            matrix result;
            CreatePerspectiveOffCenter(left, right, bottom, top, nearPlaneDistance, farPlaneDistance, out result);
            return result;
        }
        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for customized perspective view.
        /// </summary>
        /// <param name="viewingVolume">The viewing volume.</param>
        /// <param name="nearPlaneDistance">Distance to the near plane.</param>
        /// <param name="farPlaneDistance">Distance to the far plane.</param>
        /// <returns>The new <see cref="matrix"/> for customized perspective view.</returns>
        public static matrix CreatePerspectiveOffCenter(rectangle viewingVolume, double nearPlaneDistance, double farPlaneDistance)
        {
            matrix result;
            CreatePerspectiveOffCenter(viewingVolume.Left, viewingVolume.Right, viewingVolume.Bottom, viewingVolume.Top, nearPlaneDistance, farPlaneDistance, out result);
            return result;
        }

        /// <summary>
        /// Creates a new projection <see cref="matrix"/> for customized perspective view.
        /// </summary>
        /// <param name="left">Lower x-value at the near plane.</param>
        /// <param name="right">Upper x-value at the near plane.</param>
        /// <param name="bottom">Lower y-coordinate at the near plane.</param>
        /// <param name="top">Upper y-value at the near plane.</param>
        /// <param name="nearPlaneDistance">Distance to the near plane.</param>
        /// <param name="farPlaneDistance">Distance to the far plane.</param>
        /// <param name="result">The new <see cref="matrix"/> for customized perspective view as an output parameter.</param>
        public static void CreatePerspectiveOffCenter(double left, double right, double bottom, double top, double nearPlaneDistance, double farPlaneDistance, out matrix result)
        {
            if (nearPlaneDistance <= 0d)
            {
                throw new ArgumentException("nearPlaneDistance <= 0");
            }
            if (farPlaneDistance <= 0d)
            {
                throw new ArgumentException("farPlaneDistance <= 0");
            }
            if (nearPlaneDistance >= farPlaneDistance)
            {
                throw new ArgumentException("nearPlaneDistance >= farPlaneDistance");
            }
            result.M11 = (2d * nearPlaneDistance) / (right - left);
            result.M12 = result.M13 = result.M14 = 0;
            result.M22 = (2d * nearPlaneDistance) / (top - bottom);
            result.M21 = result.M23 = result.M24 = 0;
            result.M31 = (left + right) / (right - left);
            result.M32 = (top + bottom) / (top - bottom);
            result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
            result.M34 = -1;
            result.M43 = (nearPlaneDistance * farPlaneDistance) / (nearPlaneDistance - farPlaneDistance);
            result.M41 = result.M42 = result.M44 = 0;
        }

        /// <summary>
        /// Creates a new rotation <see cref="matrix"/> around X axis.
        /// </summary>
        /// <param name="radians">Angle in radians.</param>
        /// <returns>The rotation <see cref="matrix"/> around X axis.</returns>
        public static matrix CreateRotationX(double radians)
        {
            matrix result;
            CreateRotationX(radians, out result);
            return result;
        }

        /// <summary>
        /// Creates a new rotation <see cref="matrix"/> around X axis.
        /// </summary>
        /// <param name="radians">Angle in radians.</param>
        /// <param name="result">The rotation <see cref="matrix"/> around X axis as an output parameter.</param>
        public static void CreateRotationX(double radians, out matrix result)
        {
            result = matrix.Identity;

            double val1 = Math.Cos(radians);
            double val2 = Math.Sin(radians);

            result.M22 = val1;
            result.M23 = val2;
            result.M32 = -val2;
            result.M33 = val1;
        }

        /// <summary>
        /// Creates a new rotation <see cref="matrix"/> around Y axis.
        /// </summary>
        /// <param name="radians">Angle in radians.</param>
        /// <returns>The rotation <see cref="matrix"/> around Y axis.</returns>
        public static matrix CreateRotationY(double radians)
        {
            matrix result;
            CreateRotationY(radians, out result);
            return result;
        }

        /// <summary>
        /// Creates a new rotation <see cref="matrix"/> around Y axis.
        /// </summary>
        /// <param name="radians">Angle in radians.</param>
        /// <param name="result">The rotation <see cref="matrix"/> around Y axis as an output parameter.</param>
        public static void CreateRotationY(double radians, out matrix result)
        {
            result = matrix.Identity;

            double val1 = Math.Cos(radians);
            double val2 = Math.Sin(radians);

            result.M11 = val1;
            result.M13 = -val2;
            result.M31 = val2;
            result.M33 = val1;
        }

        /// <summary>
        /// Creates a new rotation <see cref="matrix"/> around Z axis.
        /// </summary>
        /// <param name="radians">Angle in radians.</param>
        /// <returns>The rotation <see cref="matrix"/> around Z axis.</returns>
        public static matrix CreateRotationZ(double radians)
        {
            matrix result;
            CreateRotationZ(radians, out result);
            return result;
        }

        /// <summary>
        /// Creates a new rotation <see cref="matrix"/> around Z axis.
        /// </summary>
        /// <param name="radians">Angle in radians.</param>
        /// <param name="result">The rotation <see cref="matrix"/> around Z axis as an output parameter.</param>
        public static void CreateRotationZ(double radians, out matrix result)
        {
            result = matrix.Identity;

            double val1 = Math.Cos(radians);
            double val2 = Math.Sin(radians);

            result.M11 = val1;
            result.M12 = val2;
            result.M21 = -val2;
            result.M22 = val1;
        }

        /// <summary>
        /// Creates a new scaling <see cref="matrix"/>.
        /// </summary>
        /// <param name="scale">Scale value for all three axises.</param>
        /// <returns>The scaling <see cref="matrix"/>.</returns>
        public static matrix CreateScale(double scale)
        {
            matrix result;
            CreateScale(scale, scale, scale, out result);
            return result;
        }

        /// <summary>
        /// Creates a new scaling <see cref="matrix"/>.
        /// </summary>
        /// <param name="scale">Scale value for all three axises.</param>
        /// <param name="result">The scaling <see cref="matrix"/> as an output parameter.</param>
        public static void CreateScale(double scale, out matrix result)
        {
            CreateScale(scale, scale, scale, out result);
        }

        /// <summary>
        /// Creates a new scaling <see cref="matrix"/>.
        /// </summary>
        /// <param name="xScale">Scale value for X axis.</param>
        /// <param name="yScale">Scale value for Y axis.</param>
        /// <param name="zScale">Scale value for Z axis.</param>
        /// <returns>The scaling <see cref="matrix"/>.</returns>
        public static matrix CreateScale(double xScale, double yScale, double zScale)
        {
            matrix result;
            CreateScale(xScale, yScale, zScale, out result);
            return result;
        }

        /// <summary>
        /// Creates a new scaling <see cref="matrix"/>.
        /// </summary>
        /// <param name="xScale">Scale value for X axis.</param>
        /// <param name="yScale">Scale value for Y axis.</param>
        /// <param name="zScale">Scale value for Z axis.</param>
        /// <param name="result">The scaling <see cref="matrix"/> as an output parameter.</param>
        public static void CreateScale(double xScale, double yScale, double zScale, out matrix result)
        {
            result.M11 = xScale;
            result.M12 = 0;
            result.M13 = 0;
            result.M14 = 0;
            result.M21 = 0;
            result.M22 = yScale;
            result.M23 = 0;
            result.M24 = 0;
            result.M31 = 0;
            result.M32 = 0;
            result.M33 = zScale;
            result.M34 = 0;
            result.M41 = 0;
            result.M42 = 0;
            result.M43 = 0;
            result.M44 = 1;
        }

        /// <summary>
        /// Creates a new scaling <see cref="matrix"/>.
        /// </summary>
        /// <param name="scales"><see cref="Vector3"/> representing x,y and z scale values.</param>
        /// <returns>The scaling <see cref="matrix"/>.</returns>
        public static matrix CreateScale(vector3 scales)
        {
            matrix result;
            CreateScale(ref scales, out result);
            return result;
        }

        /// <summary>
        /// Creates a new scaling <see cref="matrix"/>.
        /// </summary>
        /// <param name="scales"><see cref="Vector3"/> representing x,y and z scale values.</param>
        /// <param name="result">The scaling <see cref="matrix"/> as an output parameter.</param>
        public static void CreateScale(ref vector3 scales, out matrix result)
        {
            result.M11 = scales.X;
            result.M12 = 0;
            result.M13 = 0;
            result.M14 = 0;
            result.M21 = 0;
            result.M22 = scales.Y;
            result.M23 = 0;
            result.M24 = 0;
            result.M31 = 0;
            result.M32 = 0;
            result.M33 = scales.Z;
            result.M34 = 0;
            result.M41 = 0;
            result.M42 = 0;
            result.M43 = 0;
            result.M44 = 1;
        }


        /// <summary>
        /// Creates a new <see cref="matrix"/> that flattens geometry into a specified <see cref="Plane"/> as if casting a shadow from a specified light source. 
        /// </summary>
        /// <param name="lightDirection">A vector specifying the direction from which the light that will cast the shadow is coming.</param>
        /// <param name="plane">The plane onto which the new matrix should flatten geometry so as to cast a shadow.</param>
        /// <returns>A <see cref="matrix"/> that can be used to flatten geometry onto the specified plane from the specified direction. </returns>
        public static matrix CreateShadow(vector3 lightDirection, plane plane)
        {
            matrix result;
            CreateShadow(ref lightDirection, ref plane, out result);
            return result;
        }


        /// <summary>
        /// Creates a new <see cref="matrix"/> that flattens geometry into a specified <see cref="Plane"/> as if casting a shadow from a specified light source. 
        /// </summary>
        /// <param name="lightDirection">A vector specifying the direction from which the light that will cast the shadow is coming.</param>
        /// <param name="plane">The plane onto which the new matrix should flatten geometry so as to cast a shadow.</param>
        /// <param name="result">A <see cref="matrix"/> that can be used to flatten geometry onto the specified plane from the specified direction as an output parameter.</param>
        public static void CreateShadow(ref vector3 lightDirection, ref plane plane, out matrix result)
        {
            double dot = (plane.Normal.X * lightDirection.X) + (plane.Normal.Y * lightDirection.Y) + (plane.Normal.Z * lightDirection.Z);
            double x = -plane.Normal.X;
            double y = -plane.Normal.Y;
            double z = -plane.Normal.Z;
            double d = -plane.D;

            result.M11 = (x * lightDirection.X) + dot;
            result.M12 = x * lightDirection.Y;
            result.M13 = x * lightDirection.Z;
            result.M14 = 0;
            result.M21 = y * lightDirection.X;
            result.M22 = (y * lightDirection.Y) + dot;
            result.M23 = y * lightDirection.Z;
            result.M24 = 0;
            result.M31 = z * lightDirection.X;
            result.M32 = z * lightDirection.Y;
            result.M33 = (z * lightDirection.Z) + dot;
            result.M34 = 0;
            result.M41 = d * lightDirection.X;
            result.M42 = d * lightDirection.Y;
            result.M43 = d * lightDirection.Z;
            result.M44 = dot;
        }

        /// <summary>
        /// Creates a new translation <see cref="matrix"/>.
        /// </summary>
        /// <param name="xPosition">X coordinate of translation.</param>
        /// <param name="yPosition">Y coordinate of translation.</param>
        /// <param name="zPosition">Z coordinate of translation.</param>
        /// <returns>The translation <see cref="matrix"/>.</returns>
        public static matrix CreateTranslation(double xPosition, double yPosition, double zPosition)
        {
            matrix result;
            CreateTranslation(xPosition, yPosition, zPosition, out result);
            return result;
        }

        /// <summary>
        /// Creates a new translation <see cref="matrix"/>.
        /// </summary>
        /// <param name="position">X,Y and Z coordinates of translation.</param>
        /// <param name="result">The translation <see cref="matrix"/> as an output parameter.</param>
        public static void CreateTranslation(ref vector3 position, out matrix result)
        {
            result.M11 = 1;
            result.M12 = 0;
            result.M13 = 0;
            result.M14 = 0;
            result.M21 = 0;
            result.M22 = 1;
            result.M23 = 0;
            result.M24 = 0;
            result.M31 = 0;
            result.M32 = 0;
            result.M33 = 1;
            result.M34 = 0;
            result.M41 = position.X;
            result.M42 = position.Y;
            result.M43 = position.Z;
            result.M44 = 1;
        }

        /// <summary>
        /// Creates a new translation <see cref="matrix"/>.
        /// </summary>
        /// <param name="position">X,Y and Z coordinates of translation.</param>
        /// <returns>The translation <see cref="matrix"/>.</returns>
        public static matrix CreateTranslation(vector3 position)
        {
            matrix result;
            CreateTranslation(ref position, out result);
            return result;
        }

        /// <summary>
        /// Creates a new translation <see cref="matrix"/>.
        /// </summary>
        /// <param name="xPosition">X coordinate of translation.</param>
        /// <param name="yPosition">Y coordinate of translation.</param>
        /// <param name="zPosition">Z coordinate of translation.</param>
        /// <param name="result">The translation <see cref="matrix"/> as an output parameter.</param>
        public static void CreateTranslation(double xPosition, double yPosition, double zPosition, out matrix result)
        {
            result.M11 = 1;
            result.M12 = 0;
            result.M13 = 0;
            result.M14 = 0;
            result.M21 = 0;
            result.M22 = 1;
            result.M23 = 0;
            result.M24 = 0;
            result.M31 = 0;
            result.M32 = 0;
            result.M33 = 1;
            result.M34 = 0;
            result.M41 = xPosition;
            result.M42 = yPosition;
            result.M43 = zPosition;
            result.M44 = 1;
        }

        /// <summary>
        /// Creates a new reflection <see cref="matrix"/>.
        /// </summary>
        /// <param name="value">The plane that used for reflection calculation.</param>
        /// <returns>The reflection <see cref="matrix"/>.</returns>
        public static matrix CreateReflection(plane value)
        {
            matrix result;
            CreateReflection(ref value, out result);
            return result;
        }

        /// <summary>
        /// Creates a new reflection <see cref="matrix"/>.
        /// </summary>
        /// <param name="value">The plane that used for reflection calculation.</param>
        /// <param name="result">The reflection <see cref="matrix"/> as an output parameter.</param>
        public static void CreateReflection(ref plane value, out matrix result)
        {
            plane plane;
            plane.Normalize(ref value, out plane);
            double x = plane.Normal.X;
            double y = plane.Normal.Y;
            double z = plane.Normal.Z;
            double num3 = -2d * x;
            double num2 = -2d * y;
            double num = -2d * z;
            result.M11 = (num3 * x) + 1d;
            result.M12 = num2 * x;
            result.M13 = num * x;
            result.M14 = 0;
            result.M21 = num3 * y;
            result.M22 = (num2 * y) + 1;
            result.M23 = num * y;
            result.M24 = 0;
            result.M31 = num3 * z;
            result.M32 = num2 * z;
            result.M33 = (num * z) + 1;
            result.M34 = 0;
            result.M41 = num3 * plane.D;
            result.M42 = num2 * plane.D;
            result.M43 = num * plane.D;
            result.M44 = 1;
        }

        /// <summary>
        /// Creates a new world <see cref="matrix"/>.
        /// </summary>
        /// <param name="position">The position vector.</param>
        /// <param name="forward">The forward direction vector.</param>
        /// <param name="up">The upward direction vector. Usually <see cref="Vector3.Up"/>.</param>
        /// <returns>The world <see cref="matrix"/>.</returns>
        public static matrix CreateWorld(vector3 position, vector3 forward, vector3 up)
        {
            matrix ret;
            CreateWorld(ref position, ref forward, ref up, out ret);
            return ret;
        }

        /// <summary>
        /// Creates a new world <see cref="matrix"/>.
        /// </summary>
        /// <param name="position">The position vector.</param>
        /// <param name="forward">The forward direction vector.</param>
        /// <param name="up">The upward direction vector. Usually <see cref="Vector3.Up"/>.</param>
        /// <param name="result">The world <see cref="matrix"/> as an output parameter.</param>
        public static void CreateWorld(ref vector3 position, ref vector3 forward, ref vector3 up, out matrix result)
        {
            vector3 x, y, z;
            vector3.Normalize(ref forward, out z);
            vector3.Cross(ref forward, ref up, out x);
            vector3.Cross(ref x, ref forward, out y);
            x.Normalize();
            y.Normalize();

            result = new matrix();
            result.Right = x;
            result.Up = y;
            result.Forward = z;
            result.Translation = position;
            result.M44 = 1d;
        }

        /// <summary>
        /// Decomposes this matrix to translation, rotation and scale elements. Returns <c>true</c> if matrix can be decomposed; <c>false</c> otherwise.
        /// </summary>
        /// <param name="scale">Scale vector as an output parameter.</param>
        /// <param name="rotation">Rotation quaternion as an output parameter.</param>
        /// <param name="translation">Translation vector as an output parameter.</param>
        /// <returns><c>true</c> if matrix can be decomposed; <c>false</c> otherwise.</returns>
        public bool Decompose(out vector3 scale, out quaternion rotation, out vector3 translation)
        {
            translation.X = this.M41;
            translation.Y = this.M42;
            translation.Z = this.M43;

            double xs = (Math.Sign(M11 * M12 * M13 * M14) < 0) ? -1 : 1;
            double ys = (Math.Sign(M21 * M22 * M23 * M24) < 0) ? -1 : 1;
            double zs = (Math.Sign(M31 * M32 * M33 * M34) < 0) ? -1 : 1;

            scale.X = xs * Math.Sqrt(this.M11 * this.M11 + this.M12 * this.M12 + this.M13 * this.M13);
            scale.Y = ys * Math.Sqrt(this.M21 * this.M21 + this.M22 * this.M22 + this.M23 * this.M23);
            scale.Z = zs * Math.Sqrt(this.M31 * this.M31 + this.M32 * this.M32 + this.M33 * this.M33);

            if (scale.X == 0.0 || scale.Y == 0.0 || scale.Z == 0.0)
            {
                rotation = quaternion.Identity;
                return false;
            }

            matrix m1 = new matrix(this.M11 / scale.X, M12 / scale.X, M13 / scale.X, 0,
                                   this.M21 / scale.Y, M22 / scale.Y, M23 / scale.Y, 0,
                                   this.M31 / scale.Z, M32 / scale.Z, M33 / scale.Z, 0,
                                   0, 0, 0, 1);

            rotation = quaternion.CreateFromRotationMatrix(m1);
            return true;
        }

        /// <summary>
        /// Returns a determinant of this <see cref="matrix"/>.
        /// </summary>
        /// <returns>Determinant of this <see cref="matrix"/></returns>
        /// <remarks>See more about determinant here - http://en.wikipedia.org/wiki/Determinant.
        /// </remarks>
        public double Determinant()
        {
            double num22 = this.M11;
            double num21 = this.M12;
            double num20 = this.M13;
            double num19 = this.M14;
            double num12 = this.M21;
            double num11 = this.M22;
            double num10 = this.M23;
            double num9 = this.M24;
            double num8 = this.M31;
            double num7 = this.M32;
            double num6 = this.M33;
            double num5 = this.M34;
            double num4 = this.M41;
            double num3 = this.M42;
            double num2 = this.M43;
            double num = this.M44;
            double num18 = (num6 * num) - (num5 * num2);
            double num17 = (num7 * num) - (num5 * num3);
            double num16 = (num7 * num2) - (num6 * num3);
            double num15 = (num8 * num) - (num5 * num4);
            double num14 = (num8 * num2) - (num6 * num4);
            double num13 = (num8 * num3) - (num7 * num4);
            return ((((num22 * (((num11 * num18) - (num10 * num17)) + (num9 * num16))) - (num21 * (((num12 * num18) - (num10 * num15)) + (num9 * num14)))) + (num20 * (((num12 * num17) - (num11 * num15)) + (num9 * num13)))) - (num19 * (((num12 * num16) - (num11 * num14)) + (num10 * num13))));
        }

        /// <summary>
        /// Divides the elements of a <see cref="matrix"/> by the elements of another matrix.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/>.</param>
        /// <param name="matrix2">Divisor <see cref="matrix"/>.</param>
        /// <returns>The result of dividing the matrix.</returns>
        public static matrix Divide(matrix matrix1, matrix matrix2)
        {
            matrix1.M11 = matrix1.M11 / matrix2.M11;
            matrix1.M12 = matrix1.M12 / matrix2.M12;
            matrix1.M13 = matrix1.M13 / matrix2.M13;
            matrix1.M14 = matrix1.M14 / matrix2.M14;
            matrix1.M21 = matrix1.M21 / matrix2.M21;
            matrix1.M22 = matrix1.M22 / matrix2.M22;
            matrix1.M23 = matrix1.M23 / matrix2.M23;
            matrix1.M24 = matrix1.M24 / matrix2.M24;
            matrix1.M31 = matrix1.M31 / matrix2.M31;
            matrix1.M32 = matrix1.M32 / matrix2.M32;
            matrix1.M33 = matrix1.M33 / matrix2.M33;
            matrix1.M34 = matrix1.M34 / matrix2.M34;
            matrix1.M41 = matrix1.M41 / matrix2.M41;
            matrix1.M42 = matrix1.M42 / matrix2.M42;
            matrix1.M43 = matrix1.M43 / matrix2.M43;
            matrix1.M44 = matrix1.M44 / matrix2.M44;
            return matrix1;
        }

        /// <summary>
        /// Divides the elements of a <see cref="matrix"/> by the elements of another matrix.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/>.</param>
        /// <param name="matrix2">Divisor <see cref="matrix"/>.</param>
        /// <param name="result">The result of dividing the matrix as an output parameter.</param>
        public static void Divide(ref matrix matrix1, ref matrix matrix2, out matrix result)
        {
            result.M11 = matrix1.M11 / matrix2.M11;
            result.M12 = matrix1.M12 / matrix2.M12;
            result.M13 = matrix1.M13 / matrix2.M13;
            result.M14 = matrix1.M14 / matrix2.M14;
            result.M21 = matrix1.M21 / matrix2.M21;
            result.M22 = matrix1.M22 / matrix2.M22;
            result.M23 = matrix1.M23 / matrix2.M23;
            result.M24 = matrix1.M24 / matrix2.M24;
            result.M31 = matrix1.M31 / matrix2.M31;
            result.M32 = matrix1.M32 / matrix2.M32;
            result.M33 = matrix1.M33 / matrix2.M33;
            result.M34 = matrix1.M34 / matrix2.M34;
            result.M41 = matrix1.M41 / matrix2.M41;
            result.M42 = matrix1.M42 / matrix2.M42;
            result.M43 = matrix1.M43 / matrix2.M43;
            result.M44 = matrix1.M44 / matrix2.M44;
        }

        /// <summary>
        /// Divides the elements of a <see cref="matrix"/> by a scalar.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/>.</param>
        /// <param name="divider">Divisor scalar.</param>
        /// <returns>The result of dividing a matrix by a scalar.</returns>
        public static matrix Divide(matrix matrix1, double divider)
        {
            double num = 1d / divider;
            matrix1.M11 = matrix1.M11 * num;
            matrix1.M12 = matrix1.M12 * num;
            matrix1.M13 = matrix1.M13 * num;
            matrix1.M14 = matrix1.M14 * num;
            matrix1.M21 = matrix1.M21 * num;
            matrix1.M22 = matrix1.M22 * num;
            matrix1.M23 = matrix1.M23 * num;
            matrix1.M24 = matrix1.M24 * num;
            matrix1.M31 = matrix1.M31 * num;
            matrix1.M32 = matrix1.M32 * num;
            matrix1.M33 = matrix1.M33 * num;
            matrix1.M34 = matrix1.M34 * num;
            matrix1.M41 = matrix1.M41 * num;
            matrix1.M42 = matrix1.M42 * num;
            matrix1.M43 = matrix1.M43 * num;
            matrix1.M44 = matrix1.M44 * num;
            return matrix1;
        }

        /// <summary>
        /// Divides the elements of a <see cref="matrix"/> by a scalar.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/>.</param>
        /// <param name="divider">Divisor scalar.</param>
        /// <param name="result">The result of dividing a matrix by a scalar as an output parameter.</param>
        public static void Divide(ref matrix matrix1, double divider, out matrix result)
        {
            double num = 1d / divider;
            result.M11 = matrix1.M11 * num;
            result.M12 = matrix1.M12 * num;
            result.M13 = matrix1.M13 * num;
            result.M14 = matrix1.M14 * num;
            result.M21 = matrix1.M21 * num;
            result.M22 = matrix1.M22 * num;
            result.M23 = matrix1.M23 * num;
            result.M24 = matrix1.M24 * num;
            result.M31 = matrix1.M31 * num;
            result.M32 = matrix1.M32 * num;
            result.M33 = matrix1.M33 * num;
            result.M34 = matrix1.M34 * num;
            result.M41 = matrix1.M41 * num;
            result.M42 = matrix1.M42 * num;
            result.M43 = matrix1.M43 * num;
            result.M44 = matrix1.M44 * num;
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="matrix"/> without any tolerance.
        /// </summary>
        /// <param name="other">The <see cref="matrix"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(matrix other)
        {
            return ((((((this.M11 == other.M11) && (this.M22 == other.M22)) && ((this.M33 == other.M33) && (this.M44 == other.M44))) && (((this.M12 == other.M12) && (this.M13 == other.M13)) && ((this.M14 == other.M14) && (this.M21 == other.M21)))) && ((((this.M23 == other.M23) && (this.M24 == other.M24)) && ((this.M31 == other.M31) && (this.M32 == other.M32))) && (((this.M34 == other.M34) && (this.M41 == other.M41)) && (this.M42 == other.M42)))) && (this.M43 == other.M43));
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Object"/> without any tolerance.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            bool flag = false;
            if (obj is matrix)
            {
                flag = this.Equals((matrix)obj);
            }
            return flag;
        }

        /// <summary>
        /// Gets the hash code of this <see cref="matrix"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="matrix"/>.</returns>
        public override int GetHashCode()
        {
            return (((((((((((((((this.M11.GetHashCode() + this.M12.GetHashCode()) + this.M13.GetHashCode()) + this.M14.GetHashCode()) + this.M21.GetHashCode()) + this.M22.GetHashCode()) + this.M23.GetHashCode()) + this.M24.GetHashCode()) + this.M31.GetHashCode()) + this.M32.GetHashCode()) + this.M33.GetHashCode()) + this.M34.GetHashCode()) + this.M41.GetHashCode()) + this.M42.GetHashCode()) + this.M43.GetHashCode()) + this.M44.GetHashCode());
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> which contains inversion of the specified matrix. 
        /// </summary>
        /// <param name="matrix">Source <see cref="matrix"/>.</param>
        /// <returns>The inverted matrix.</returns>
        public static matrix Invert(matrix matrix)
        {
            matrix result;
            Invert(ref matrix, out result);
            return result;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> which contains inversion of the specified matrix. 
        /// </summary>
        /// <param name="matrix">Source <see cref="matrix"/>.</param>
        /// <param name="result">The inverted matrix as output parameter.</param>
        public static void Invert(ref matrix matrix, out matrix result)
        {
            double num1 = matrix.M11;
            double num2 = matrix.M12;
            double num3 = matrix.M13;
            double num4 = matrix.M14;
            double num5 = matrix.M21;
            double num6 = matrix.M22;
            double num7 = matrix.M23;
            double num8 = matrix.M24;
            double num9 = matrix.M31;
            double num10 = matrix.M32;
            double num11 = matrix.M33;
            double num12 = matrix.M34;
            double num13 = matrix.M41;
            double num14 = matrix.M42;
            double num15 = matrix.M43;
            double num16 = matrix.M44;
            double num17 = (num11 * num16 - num12 * num15);
            double num18 = (num10 * num16 - num12 * num14);
            double num19 = (num10 * num15 - num11 * num14);
            double num20 = (num9 * num16 - num12 * num13);
            double num21 = (num9 * num15 - num11 * num13);
            double num22 = (num9 * num14 - num10 * num13);
            double num23 = (num6 * num17 - num7 * num18 + num8 * num19);
            double num24 = -(num5 * num17 - num7 * num20 + num8 * num21);
            double num25 = (num5 * num18 - num6 * num20 + num8 * num22);
            double num26 = -(num5 * num19 - num6 * num21 + num7 * num22);
            double num27 = (1.0 / (num1 * num23 + num2 * num24 + num3 * num25 + num4 * num26));

            result.M11 = num23 * num27;
            result.M21 = num24 * num27;
            result.M31 = num25 * num27;
            result.M41 = num26 * num27;
            result.M12 = -(num2 * num17 - num3 * num18 + num4 * num19) * num27;
            result.M22 = (num1 * num17 - num3 * num20 + num4 * num21) * num27;
            result.M32 = -(num1 * num18 - num2 * num20 + num4 * num22) * num27;
            result.M42 = (num1 * num19 - num2 * num21 + num3 * num22) * num27;
            double num28 = (num7 * num16 - num8 * num15);
            double num29 = (num6 * num16 - num8 * num14);
            double num30 = (num6 * num15 - num7 * num14);
            double num31 = (num5 * num16 - num8 * num13);
            double num32 = (num5 * num15 - num7 * num13);
            double num33 = (num5 * num14 - num6 * num13);
            result.M13 = (num2 * num28 - num3 * num29 + num4 * num30) * num27;
            result.M23 = -(num1 * num28 - num3 * num31 + num4 * num32) * num27;
            result.M33 = (num1 * num29 - num2 * num31 + num4 * num33) * num27;
            result.M43 = -(num1 * num30 - num2 * num32 + num3 * num33) * num27;
            double num34 = (num7 * num12 - num8 * num11);
            double num35 = (num6 * num12 - num8 * num10);
            double num36 = (num6 * num11 - num7 * num10);
            double num37 = (num5 * num12 - num8 * num9);
            double num38 = (num5 * num11 - num7 * num9);
            double num39 = (num5 * num10 - num6 * num9);
            result.M14 = -(num2 * num34 - num3 * num35 + num4 * num36) * num27;
            result.M24 = (num1 * num34 - num3 * num37 + num4 * num38) * num27;
            result.M34 = -(num1 * num35 - num2 * num37 + num4 * num39) * num27;
            result.M44 = (num1 * num36 - num2 * num38 + num3 * num39) * num27;


            /*


            ///
            // Use Laplace expansion theorem to calculate the inverse of a 4x4 matrix
            // 
            // 1. Calculate the 2x2 determinants needed the 4x4 determinant based on the 2x2 determinants 
            // 3. Create the adjugate matrix, which satisfies: A * adj(A) = det(A) * I
            // 4. Divide adjugate matrix with the determinant to find the inverse

            double det1, det2, det3, det4, det5, det6, det7, det8, det9, det10, det11, det12;
            double detMatrix;
            FindDeterminants(ref matrix, out detMatrix, out det1, out det2, out det3, out det4, out det5, out det6, 
                             out det7, out det8, out det9, out det10, out det11, out det12);

            double invDetMatrix = 1f / detMatrix;

            matrix ret; // Allow for matrix and result to point to the same structure

            ret.M11 = (matrix.M22*det12 - matrix.M23*det11 + matrix.M24*det10) * invDetMatrix;
            ret.M12 = (-matrix.M12*det12 + matrix.M13*det11 - matrix.M14*det10) * invDetMatrix;
            ret.M13 = (matrix.M42*det6 - matrix.M43*det5 + matrix.M44*det4) * invDetMatrix;
            ret.M14 = (-matrix.M32*det6 + matrix.M33*det5 - matrix.M34*det4) * invDetMatrix;
            ret.M21 = (-matrix.M21*det12 + matrix.M23*det9 - matrix.M24*det8) * invDetMatrix;
            ret.M22 = (matrix.M11*det12 - matrix.M13*det9 + matrix.M14*det8) * invDetMatrix;
            ret.M23 = (-matrix.M41*det6 + matrix.M43*det3 - matrix.M44*det2) * invDetMatrix;
            ret.M24 = (matrix.M31*det6 - matrix.M33*det3 + matrix.M34*det2) * invDetMatrix;
            ret.M31 = (matrix.M21*det11 - matrix.M22*det9 + matrix.M24*det7) * invDetMatrix;
            ret.M32 = (-matrix.M11*det11 + matrix.M12*det9 - matrix.M14*det7) * invDetMatrix;
            ret.M33 = (matrix.M41*det5 - matrix.M42*det3 + matrix.M44*det1) * invDetMatrix;
            ret.M34 = (-matrix.M31*det5 + matrix.M32*det3 - matrix.M34*det1) * invDetMatrix;
            ret.M41 = (-matrix.M21*det10 + matrix.M22*det8 - matrix.M23*det7) * invDetMatrix;
            ret.M42 = (matrix.M11*det10 - matrix.M12*det8 + matrix.M13*det7) * invDetMatrix;
            ret.M43 = (-matrix.M41*det4 + matrix.M42*det2 - matrix.M43*det1) * invDetMatrix;
            ret.M44 = (matrix.M31*det4 - matrix.M32*det2 + matrix.M33*det1) * invDetMatrix;

            result = ret;
            */
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> that contains linear interpolation of the values in specified matrixes.
        /// </summary>
        /// <param name="matrix1">The first <see cref="matrix"/>.</param>
        /// <param name="matrix2">The second <see cref="Vector2"/>.</param>
        /// <param name="amount">Weighting value(between 0.0 and 1.0).</param>
        /// <returns>>The result of linear interpolation of the specified matrixes.</returns>
        public static matrix Lerp(matrix matrix1, matrix matrix2, double amount)
        {
            matrix1.M11 = matrix1.M11 + ((matrix2.M11 - matrix1.M11) * amount);
            matrix1.M12 = matrix1.M12 + ((matrix2.M12 - matrix1.M12) * amount);
            matrix1.M13 = matrix1.M13 + ((matrix2.M13 - matrix1.M13) * amount);
            matrix1.M14 = matrix1.M14 + ((matrix2.M14 - matrix1.M14) * amount);
            matrix1.M21 = matrix1.M21 + ((matrix2.M21 - matrix1.M21) * amount);
            matrix1.M22 = matrix1.M22 + ((matrix2.M22 - matrix1.M22) * amount);
            matrix1.M23 = matrix1.M23 + ((matrix2.M23 - matrix1.M23) * amount);
            matrix1.M24 = matrix1.M24 + ((matrix2.M24 - matrix1.M24) * amount);
            matrix1.M31 = matrix1.M31 + ((matrix2.M31 - matrix1.M31) * amount);
            matrix1.M32 = matrix1.M32 + ((matrix2.M32 - matrix1.M32) * amount);
            matrix1.M33 = matrix1.M33 + ((matrix2.M33 - matrix1.M33) * amount);
            matrix1.M34 = matrix1.M34 + ((matrix2.M34 - matrix1.M34) * amount);
            matrix1.M41 = matrix1.M41 + ((matrix2.M41 - matrix1.M41) * amount);
            matrix1.M42 = matrix1.M42 + ((matrix2.M42 - matrix1.M42) * amount);
            matrix1.M43 = matrix1.M43 + ((matrix2.M43 - matrix1.M43) * amount);
            matrix1.M44 = matrix1.M44 + ((matrix2.M44 - matrix1.M44) * amount);
            return matrix1;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> that contains linear interpolation of the values in specified matrixes.
        /// </summary>
        /// <param name="matrix1">The first <see cref="matrix"/>.</param>
        /// <param name="matrix2">The second <see cref="Vector2"/>.</param>
        /// <param name="amount">Weighting value(between 0.0 and 1.0).</param>
        /// <param name="result">The result of linear interpolation of the specified matrixes as an output parameter.</param>
        public static void Lerp(ref matrix matrix1, ref matrix matrix2, double amount, out matrix result)
        {
            result.M11 = matrix1.M11 + ((matrix2.M11 - matrix1.M11) * amount);
            result.M12 = matrix1.M12 + ((matrix2.M12 - matrix1.M12) * amount);
            result.M13 = matrix1.M13 + ((matrix2.M13 - matrix1.M13) * amount);
            result.M14 = matrix1.M14 + ((matrix2.M14 - matrix1.M14) * amount);
            result.M21 = matrix1.M21 + ((matrix2.M21 - matrix1.M21) * amount);
            result.M22 = matrix1.M22 + ((matrix2.M22 - matrix1.M22) * amount);
            result.M23 = matrix1.M23 + ((matrix2.M23 - matrix1.M23) * amount);
            result.M24 = matrix1.M24 + ((matrix2.M24 - matrix1.M24) * amount);
            result.M31 = matrix1.M31 + ((matrix2.M31 - matrix1.M31) * amount);
            result.M32 = matrix1.M32 + ((matrix2.M32 - matrix1.M32) * amount);
            result.M33 = matrix1.M33 + ((matrix2.M33 - matrix1.M33) * amount);
            result.M34 = matrix1.M34 + ((matrix2.M34 - matrix1.M34) * amount);
            result.M41 = matrix1.M41 + ((matrix2.M41 - matrix1.M41) * amount);
            result.M42 = matrix1.M42 + ((matrix2.M42 - matrix1.M42) * amount);
            result.M43 = matrix1.M43 + ((matrix2.M43 - matrix1.M43) * amount);
            result.M44 = matrix1.M44 + ((matrix2.M44 - matrix1.M44) * amount);
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> that contains a multiplication of two matrix.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/>.</param>
        /// <param name="matrix2">Source <see cref="matrix"/>.</param>
        /// <returns>Result of the matrix multiplication.</returns>
        public static matrix Multiply(matrix matrix1, matrix matrix2)
        {
            double m11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            double m12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            double m13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            double m14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            double m21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            double m22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            double m23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            double m24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            double m31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            double m32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            double m33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            double m34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            double m41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            double m42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            double m43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            double m44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            matrix1.M11 = m11;
            matrix1.M12 = m12;
            matrix1.M13 = m13;
            matrix1.M14 = m14;
            matrix1.M21 = m21;
            matrix1.M22 = m22;
            matrix1.M23 = m23;
            matrix1.M24 = m24;
            matrix1.M31 = m31;
            matrix1.M32 = m32;
            matrix1.M33 = m33;
            matrix1.M34 = m34;
            matrix1.M41 = m41;
            matrix1.M42 = m42;
            matrix1.M43 = m43;
            matrix1.M44 = m44;
            return matrix1;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> that contains a multiplication of two matrix.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/>.</param>
        /// <param name="matrix2">Source <see cref="matrix"/>.</param>
        /// <param name="result">Result of the matrix multiplication as an output parameter.</param>
        public static void Multiply(ref matrix matrix1, ref matrix matrix2, out matrix result)
        {
            double m11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            double m12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            double m13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            double m14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            double m21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            double m22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            double m23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            double m24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            double m31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            double m32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            double m33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            double m34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            double m41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            double m42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            double m43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            double m44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            result.M11 = m11;
            result.M12 = m12;
            result.M13 = m13;
            result.M14 = m14;
            result.M21 = m21;
            result.M22 = m22;
            result.M23 = m23;
            result.M24 = m24;
            result.M31 = m31;
            result.M32 = m32;
            result.M33 = m33;
            result.M34 = m34;
            result.M41 = m41;
            result.M42 = m42;
            result.M43 = m43;
            result.M44 = m44;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> that contains a multiplication of <see cref="matrix"/> and a scalar.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/>.</param>
        /// <param name="scaleFactor">Scalar value.</param>
        /// <returns>Result of the matrix multiplication with a scalar.</returns>
        public static matrix Multiply(matrix matrix1, double scaleFactor)
        {
            matrix1.M11 *= scaleFactor;
            matrix1.M12 *= scaleFactor;
            matrix1.M13 *= scaleFactor;
            matrix1.M14 *= scaleFactor;
            matrix1.M21 *= scaleFactor;
            matrix1.M22 *= scaleFactor;
            matrix1.M23 *= scaleFactor;
            matrix1.M24 *= scaleFactor;
            matrix1.M31 *= scaleFactor;
            matrix1.M32 *= scaleFactor;
            matrix1.M33 *= scaleFactor;
            matrix1.M34 *= scaleFactor;
            matrix1.M41 *= scaleFactor;
            matrix1.M42 *= scaleFactor;
            matrix1.M43 *= scaleFactor;
            matrix1.M44 *= scaleFactor;
            return matrix1;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> that contains a multiplication of <see cref="matrix"/> and a scalar.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/>.</param>
        /// <param name="scaleFactor">Scalar value.</param>
        /// <param name="result">Result of the matrix multiplication with a scalar as an output parameter.</param>
        public static void Multiply(ref matrix matrix1, double scaleFactor, out matrix result)
        {
            result.M11 = matrix1.M11 * scaleFactor;
            result.M12 = matrix1.M12 * scaleFactor;
            result.M13 = matrix1.M13 * scaleFactor;
            result.M14 = matrix1.M14 * scaleFactor;
            result.M21 = matrix1.M21 * scaleFactor;
            result.M22 = matrix1.M22 * scaleFactor;
            result.M23 = matrix1.M23 * scaleFactor;
            result.M24 = matrix1.M24 * scaleFactor;
            result.M31 = matrix1.M31 * scaleFactor;
            result.M32 = matrix1.M32 * scaleFactor;
            result.M33 = matrix1.M33 * scaleFactor;
            result.M34 = matrix1.M34 * scaleFactor;
            result.M41 = matrix1.M41 * scaleFactor;
            result.M42 = matrix1.M42 * scaleFactor;
            result.M43 = matrix1.M43 * scaleFactor;
            result.M44 = matrix1.M44 * scaleFactor;
        }

        /// <summary>
        /// Copy the values of specified <see cref="matrix"/> to the double array.
        /// </summary>
        /// <param name="matrix">The source <see cref="matrix"/>.</param>
        /// <returns>The array which matrix values will be stored.</returns>
        /// <remarks>
        /// Required for OpenGL 2.0 projection matrix stuff.
        /// </remarks>
        public static double[] ToFloatArray(matrix matrix)
        {
            double[] matarray = {
                                    matrix.M11, matrix.M12, matrix.M13, matrix.M14,
                                    matrix.M21, matrix.M22, matrix.M23, matrix.M24,
                                    matrix.M31, matrix.M32, matrix.M33, matrix.M34,
                                    matrix.M41, matrix.M42, matrix.M43, matrix.M44
                                };
            return matarray;
        }

        /// <summary>
        /// Returns a matrix with the all values negated.
        /// </summary>
        /// <param name="matrix">Source <see cref="matrix"/>.</param>
        /// <returns>Result of the matrix negation.</returns>
        public static matrix Negate(matrix matrix)
        {
            matrix.M11 = -matrix.M11;
            matrix.M12 = -matrix.M12;
            matrix.M13 = -matrix.M13;
            matrix.M14 = -matrix.M14;
            matrix.M21 = -matrix.M21;
            matrix.M22 = -matrix.M22;
            matrix.M23 = -matrix.M23;
            matrix.M24 = -matrix.M24;
            matrix.M31 = -matrix.M31;
            matrix.M32 = -matrix.M32;
            matrix.M33 = -matrix.M33;
            matrix.M34 = -matrix.M34;
            matrix.M41 = -matrix.M41;
            matrix.M42 = -matrix.M42;
            matrix.M43 = -matrix.M43;
            matrix.M44 = -matrix.M44;
            return matrix;
        }

        /// <summary>
        /// Returns a matrix with the all values negated.
        /// </summary>
        /// <param name="matrix">Source <see cref="matrix"/>.</param>
        /// <param name="result">Result of the matrix negation as an output parameter.</param>
        public static void Negate(ref matrix matrix, out matrix result)
        {
            result.M11 = -matrix.M11;
            result.M12 = -matrix.M12;
            result.M13 = -matrix.M13;
            result.M14 = -matrix.M14;
            result.M21 = -matrix.M21;
            result.M22 = -matrix.M22;
            result.M23 = -matrix.M23;
            result.M24 = -matrix.M24;
            result.M31 = -matrix.M31;
            result.M32 = -matrix.M32;
            result.M33 = -matrix.M33;
            result.M34 = -matrix.M34;
            result.M41 = -matrix.M41;
            result.M42 = -matrix.M42;
            result.M43 = -matrix.M43;
            result.M44 = -matrix.M44;
        }

        /// <summary>
        /// Adds two matrixes.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/> on the left of the add sign.</param>
        /// <param name="matrix2">Source <see cref="matrix"/> on the right of the add sign.</param>
        /// <returns>Sum of the matrixes.</returns>
        public static matrix operator +(matrix matrix1, matrix matrix2)
        {
            matrix1.M11 = matrix1.M11 + matrix2.M11;
            matrix1.M12 = matrix1.M12 + matrix2.M12;
            matrix1.M13 = matrix1.M13 + matrix2.M13;
            matrix1.M14 = matrix1.M14 + matrix2.M14;
            matrix1.M21 = matrix1.M21 + matrix2.M21;
            matrix1.M22 = matrix1.M22 + matrix2.M22;
            matrix1.M23 = matrix1.M23 + matrix2.M23;
            matrix1.M24 = matrix1.M24 + matrix2.M24;
            matrix1.M31 = matrix1.M31 + matrix2.M31;
            matrix1.M32 = matrix1.M32 + matrix2.M32;
            matrix1.M33 = matrix1.M33 + matrix2.M33;
            matrix1.M34 = matrix1.M34 + matrix2.M34;
            matrix1.M41 = matrix1.M41 + matrix2.M41;
            matrix1.M42 = matrix1.M42 + matrix2.M42;
            matrix1.M43 = matrix1.M43 + matrix2.M43;
            matrix1.M44 = matrix1.M44 + matrix2.M44;
            return matrix1;
        }

        /// <summary>
        /// Divides the elements of a <see cref="matrix"/> by the elements of another <see cref="matrix"/>.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/> on the left of the div sign.</param>
        /// <param name="matrix2">Divisor <see cref="matrix"/> on the right of the div sign.</param>
        /// <returns>The result of dividing the matrixes.</returns>
        public static matrix operator /(matrix matrix1, matrix matrix2)
        {
            matrix1.M11 = matrix1.M11 / matrix2.M11;
            matrix1.M12 = matrix1.M12 / matrix2.M12;
            matrix1.M13 = matrix1.M13 / matrix2.M13;
            matrix1.M14 = matrix1.M14 / matrix2.M14;
            matrix1.M21 = matrix1.M21 / matrix2.M21;
            matrix1.M22 = matrix1.M22 / matrix2.M22;
            matrix1.M23 = matrix1.M23 / matrix2.M23;
            matrix1.M24 = matrix1.M24 / matrix2.M24;
            matrix1.M31 = matrix1.M31 / matrix2.M31;
            matrix1.M32 = matrix1.M32 / matrix2.M32;
            matrix1.M33 = matrix1.M33 / matrix2.M33;
            matrix1.M34 = matrix1.M34 / matrix2.M34;
            matrix1.M41 = matrix1.M41 / matrix2.M41;
            matrix1.M42 = matrix1.M42 / matrix2.M42;
            matrix1.M43 = matrix1.M43 / matrix2.M43;
            matrix1.M44 = matrix1.M44 / matrix2.M44;
            return matrix1;
        }

        /// <summary>
        /// Divides the elements of a <see cref="matrix"/> by a scalar.
        /// </summary>
        /// <param name="matrix">Source <see cref="matrix"/> on the left of the div sign.</param>
        /// <param name="divider">Divisor scalar on the right of the div sign.</param>
        /// <returns>The result of dividing a matrix by a scalar.</returns>
        public static matrix operator /(matrix matrix, double divider)
        {
            double num = 1d / divider;
            matrix.M11 = matrix.M11 * num;
            matrix.M12 = matrix.M12 * num;
            matrix.M13 = matrix.M13 * num;
            matrix.M14 = matrix.M14 * num;
            matrix.M21 = matrix.M21 * num;
            matrix.M22 = matrix.M22 * num;
            matrix.M23 = matrix.M23 * num;
            matrix.M24 = matrix.M24 * num;
            matrix.M31 = matrix.M31 * num;
            matrix.M32 = matrix.M32 * num;
            matrix.M33 = matrix.M33 * num;
            matrix.M34 = matrix.M34 * num;
            matrix.M41 = matrix.M41 * num;
            matrix.M42 = matrix.M42 * num;
            matrix.M43 = matrix.M43 * num;
            matrix.M44 = matrix.M44 * num;
            return matrix;
        }

        /// <summary>
        /// Compares whether two <see cref="matrix"/> instances are equal without any tolerance.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/> on the left of the equal sign.</param>
        /// <param name="matrix2">Source <see cref="matrix"/> on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(matrix matrix1, matrix matrix2)
        {
            return (
                matrix1.M11 == matrix2.M11 &&
                matrix1.M12 == matrix2.M12 &&
                matrix1.M13 == matrix2.M13 &&
                matrix1.M14 == matrix2.M14 &&
                matrix1.M21 == matrix2.M21 &&
                matrix1.M22 == matrix2.M22 &&
                matrix1.M23 == matrix2.M23 &&
                matrix1.M24 == matrix2.M24 &&
                matrix1.M31 == matrix2.M31 &&
                matrix1.M32 == matrix2.M32 &&
                matrix1.M33 == matrix2.M33 &&
                matrix1.M34 == matrix2.M34 &&
                matrix1.M41 == matrix2.M41 &&
                matrix1.M42 == matrix2.M42 &&
                matrix1.M43 == matrix2.M43 &&
                matrix1.M44 == matrix2.M44
                );
        }

        /// <summary>
        /// Compares whether two <see cref="matrix"/> instances are not equal without any tolerance.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/> on the left of the not equal sign.</param>
        /// <param name="matrix2">Source <see cref="matrix"/> on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(matrix matrix1, matrix matrix2)
        {
            return (
                matrix1.M11 != matrix2.M11 ||
                matrix1.M12 != matrix2.M12 ||
                matrix1.M13 != matrix2.M13 ||
                matrix1.M14 != matrix2.M14 ||
                matrix1.M21 != matrix2.M21 ||
                matrix1.M22 != matrix2.M22 ||
                matrix1.M23 != matrix2.M23 ||
                matrix1.M24 != matrix2.M24 ||
                matrix1.M31 != matrix2.M31 ||
                matrix1.M32 != matrix2.M32 ||
                matrix1.M33 != matrix2.M33 ||
                matrix1.M34 != matrix2.M34 ||
                matrix1.M41 != matrix2.M41 ||
                matrix1.M42 != matrix2.M42 ||
                matrix1.M43 != matrix2.M43 ||
                matrix1.M44 != matrix2.M44
                );
        }

        /// <summary>
        /// Multiplies two matrixes.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/> on the left of the mul sign.</param>
        /// <param name="matrix2">Source <see cref="matrix"/> on the right of the mul sign.</param>
        /// <returns>Result of the matrix multiplication.</returns>
        /// <remarks>
        /// Using matrix multiplication algorithm - see http://en.wikipedia.org/wiki/Matrix_multiplication.
        /// </remarks>
        public static matrix operator *(matrix matrix1, matrix matrix2)
        {
            double m11 = (((matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21)) + (matrix1.M13 * matrix2.M31)) + (matrix1.M14 * matrix2.M41);
            double m12 = (((matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22)) + (matrix1.M13 * matrix2.M32)) + (matrix1.M14 * matrix2.M42);
            double m13 = (((matrix1.M11 * matrix2.M13) + (matrix1.M12 * matrix2.M23)) + (matrix1.M13 * matrix2.M33)) + (matrix1.M14 * matrix2.M43);
            double m14 = (((matrix1.M11 * matrix2.M14) + (matrix1.M12 * matrix2.M24)) + (matrix1.M13 * matrix2.M34)) + (matrix1.M14 * matrix2.M44);
            double m21 = (((matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21)) + (matrix1.M23 * matrix2.M31)) + (matrix1.M24 * matrix2.M41);
            double m22 = (((matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22)) + (matrix1.M23 * matrix2.M32)) + (matrix1.M24 * matrix2.M42);
            double m23 = (((matrix1.M21 * matrix2.M13) + (matrix1.M22 * matrix2.M23)) + (matrix1.M23 * matrix2.M33)) + (matrix1.M24 * matrix2.M43);
            double m24 = (((matrix1.M21 * matrix2.M14) + (matrix1.M22 * matrix2.M24)) + (matrix1.M23 * matrix2.M34)) + (matrix1.M24 * matrix2.M44);
            double m31 = (((matrix1.M31 * matrix2.M11) + (matrix1.M32 * matrix2.M21)) + (matrix1.M33 * matrix2.M31)) + (matrix1.M34 * matrix2.M41);
            double m32 = (((matrix1.M31 * matrix2.M12) + (matrix1.M32 * matrix2.M22)) + (matrix1.M33 * matrix2.M32)) + (matrix1.M34 * matrix2.M42);
            double m33 = (((matrix1.M31 * matrix2.M13) + (matrix1.M32 * matrix2.M23)) + (matrix1.M33 * matrix2.M33)) + (matrix1.M34 * matrix2.M43);
            double m34 = (((matrix1.M31 * matrix2.M14) + (matrix1.M32 * matrix2.M24)) + (matrix1.M33 * matrix2.M34)) + (matrix1.M34 * matrix2.M44);
            double m41 = (((matrix1.M41 * matrix2.M11) + (matrix1.M42 * matrix2.M21)) + (matrix1.M43 * matrix2.M31)) + (matrix1.M44 * matrix2.M41);
            double m42 = (((matrix1.M41 * matrix2.M12) + (matrix1.M42 * matrix2.M22)) + (matrix1.M43 * matrix2.M32)) + (matrix1.M44 * matrix2.M42);
            double m43 = (((matrix1.M41 * matrix2.M13) + (matrix1.M42 * matrix2.M23)) + (matrix1.M43 * matrix2.M33)) + (matrix1.M44 * matrix2.M43);
            double m44 = (((matrix1.M41 * matrix2.M14) + (matrix1.M42 * matrix2.M24)) + (matrix1.M43 * matrix2.M34)) + (matrix1.M44 * matrix2.M44);
            matrix1.M11 = m11;
            matrix1.M12 = m12;
            matrix1.M13 = m13;
            matrix1.M14 = m14;
            matrix1.M21 = m21;
            matrix1.M22 = m22;
            matrix1.M23 = m23;
            matrix1.M24 = m24;
            matrix1.M31 = m31;
            matrix1.M32 = m32;
            matrix1.M33 = m33;
            matrix1.M34 = m34;
            matrix1.M41 = m41;
            matrix1.M42 = m42;
            matrix1.M43 = m43;
            matrix1.M44 = m44;
            return matrix1;
        }

        /// <summary>
        /// Multiplies the elements of matrix by a scalar.
        /// </summary>
        /// <param name="matrix">Source <see cref="matrix"/> on the left of the mul sign.</param>
        /// <param name="scaleFactor">Scalar value on the right of the mul sign.</param>
        /// <returns>Result of the matrix multiplication with a scalar.</returns>
        public static matrix operator *(matrix matrix, double scaleFactor)
        {
            matrix.M11 = matrix.M11 * scaleFactor;
            matrix.M12 = matrix.M12 * scaleFactor;
            matrix.M13 = matrix.M13 * scaleFactor;
            matrix.M14 = matrix.M14 * scaleFactor;
            matrix.M21 = matrix.M21 * scaleFactor;
            matrix.M22 = matrix.M22 * scaleFactor;
            matrix.M23 = matrix.M23 * scaleFactor;
            matrix.M24 = matrix.M24 * scaleFactor;
            matrix.M31 = matrix.M31 * scaleFactor;
            matrix.M32 = matrix.M32 * scaleFactor;
            matrix.M33 = matrix.M33 * scaleFactor;
            matrix.M34 = matrix.M34 * scaleFactor;
            matrix.M41 = matrix.M41 * scaleFactor;
            matrix.M42 = matrix.M42 * scaleFactor;
            matrix.M43 = matrix.M43 * scaleFactor;
            matrix.M44 = matrix.M44 * scaleFactor;
            return matrix;
        }

        /// <summary>
        /// Subtracts the values of one <see cref="matrix"/> from another <see cref="matrix"/>.
        /// </summary>
        /// <param name="matrix1">Source <see cref="matrix"/> on the left of the sub sign.</param>
        /// <param name="matrix2">Source <see cref="matrix"/> on the right of the sub sign.</param>
        /// <returns>Result of the matrix subtraction.</returns>
        public static matrix operator -(matrix matrix1, matrix matrix2)
        {
            matrix1.M11 = matrix1.M11 - matrix2.M11;
            matrix1.M12 = matrix1.M12 - matrix2.M12;
            matrix1.M13 = matrix1.M13 - matrix2.M13;
            matrix1.M14 = matrix1.M14 - matrix2.M14;
            matrix1.M21 = matrix1.M21 - matrix2.M21;
            matrix1.M22 = matrix1.M22 - matrix2.M22;
            matrix1.M23 = matrix1.M23 - matrix2.M23;
            matrix1.M24 = matrix1.M24 - matrix2.M24;
            matrix1.M31 = matrix1.M31 - matrix2.M31;
            matrix1.M32 = matrix1.M32 - matrix2.M32;
            matrix1.M33 = matrix1.M33 - matrix2.M33;
            matrix1.M34 = matrix1.M34 - matrix2.M34;
            matrix1.M41 = matrix1.M41 - matrix2.M41;
            matrix1.M42 = matrix1.M42 - matrix2.M42;
            matrix1.M43 = matrix1.M43 - matrix2.M43;
            matrix1.M44 = matrix1.M44 - matrix2.M44;
            return matrix1;
        }

        /// <summary>
        /// Inverts values in the specified <see cref="matrix"/>.
        /// </summary>
        /// <param name="matrix">Source <see cref="matrix"/> on the right of the sub sign.</param>
        /// <returns>Result of the inversion.</returns>
        public static matrix operator -(matrix matrix)
        {
            matrix.M11 = -matrix.M11;
            matrix.M12 = -matrix.M12;
            matrix.M13 = -matrix.M13;
            matrix.M14 = -matrix.M14;
            matrix.M21 = -matrix.M21;
            matrix.M22 = -matrix.M22;
            matrix.M23 = -matrix.M23;
            matrix.M24 = -matrix.M24;
            matrix.M31 = -matrix.M31;
            matrix.M32 = -matrix.M32;
            matrix.M33 = -matrix.M33;
            matrix.M34 = -matrix.M34;
            matrix.M41 = -matrix.M41;
            matrix.M42 = -matrix.M42;
            matrix.M43 = -matrix.M43;
            matrix.M44 = -matrix.M44;
            return matrix;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> that contains subtraction of one matrix from another.
        /// </summary>
        /// <param name="matrix1">The first <see cref="matrix"/>.</param>
        /// <param name="matrix2">The second <see cref="matrix"/>.</param>
        /// <returns>The result of the matrix subtraction.</returns>
        public static matrix Subtract(matrix matrix1, matrix matrix2)
        {
            matrix1.M11 = matrix1.M11 - matrix2.M11;
            matrix1.M12 = matrix1.M12 - matrix2.M12;
            matrix1.M13 = matrix1.M13 - matrix2.M13;
            matrix1.M14 = matrix1.M14 - matrix2.M14;
            matrix1.M21 = matrix1.M21 - matrix2.M21;
            matrix1.M22 = matrix1.M22 - matrix2.M22;
            matrix1.M23 = matrix1.M23 - matrix2.M23;
            matrix1.M24 = matrix1.M24 - matrix2.M24;
            matrix1.M31 = matrix1.M31 - matrix2.M31;
            matrix1.M32 = matrix1.M32 - matrix2.M32;
            matrix1.M33 = matrix1.M33 - matrix2.M33;
            matrix1.M34 = matrix1.M34 - matrix2.M34;
            matrix1.M41 = matrix1.M41 - matrix2.M41;
            matrix1.M42 = matrix1.M42 - matrix2.M42;
            matrix1.M43 = matrix1.M43 - matrix2.M43;
            matrix1.M44 = matrix1.M44 - matrix2.M44;
            return matrix1;
        }

        /// <summary>
        /// Creates a new <see cref="matrix"/> that contains subtraction of one matrix from another.
        /// </summary>
        /// <param name="matrix1">The first <see cref="matrix"/>.</param>
        /// <param name="matrix2">The second <see cref="matrix"/>.</param>
        /// <param name="result">The result of the matrix subtraction as an output parameter.</param>
        public static void Subtract(ref matrix matrix1, ref matrix matrix2, out matrix result)
        {
            result.M11 = matrix1.M11 - matrix2.M11;
            result.M12 = matrix1.M12 - matrix2.M12;
            result.M13 = matrix1.M13 - matrix2.M13;
            result.M14 = matrix1.M14 - matrix2.M14;
            result.M21 = matrix1.M21 - matrix2.M21;
            result.M22 = matrix1.M22 - matrix2.M22;
            result.M23 = matrix1.M23 - matrix2.M23;
            result.M24 = matrix1.M24 - matrix2.M24;
            result.M31 = matrix1.M31 - matrix2.M31;
            result.M32 = matrix1.M32 - matrix2.M32;
            result.M33 = matrix1.M33 - matrix2.M33;
            result.M34 = matrix1.M34 - matrix2.M34;
            result.M41 = matrix1.M41 - matrix2.M41;
            result.M42 = matrix1.M42 - matrix2.M42;
            result.M43 = matrix1.M43 - matrix2.M43;
            result.M44 = matrix1.M44 - matrix2.M44;
        }

        internal string DebugDisplayString
        {
            get
            {
                if (this == Identity)
                {
                    return "Identity";
                }

                return string.Concat(
                     "( ", this.M11.ToString(), "  ", this.M12.ToString(), "  ", this.M13.ToString(), "  ", this.M14.ToString(), " )  \r\n",
                     "( ", this.M21.ToString(), "  ", this.M22.ToString(), "  ", this.M23.ToString(), "  ", this.M24.ToString(), " )  \r\n",
                     "( ", this.M31.ToString(), "  ", this.M32.ToString(), "  ", this.M33.ToString(), "  ", this.M34.ToString(), " )  \r\n",
                     "( ", this.M41.ToString(), "  ", this.M42.ToString(), "  ", this.M43.ToString(), "  ", this.M44.ToString(), " )");
            }
        }

        /// <summary>
        /// Returns a <see cref="String"/> representation of this <see cref="matrix"/> in the format:
        /// {M11:[<see cref="M11"/>] M12:[<see cref="M12"/>] M13:[<see cref="M13"/>] M14:[<see cref="M14"/>]}
        /// {M21:[<see cref="M21"/>] M12:[<see cref="M22"/>] M13:[<see cref="M23"/>] M14:[<see cref="M24"/>]}
        /// {M31:[<see cref="M31"/>] M32:[<see cref="M32"/>] M33:[<see cref="M33"/>] M34:[<see cref="M34"/>]}
        /// {M41:[<see cref="M41"/>] M42:[<see cref="M42"/>] M43:[<see cref="M43"/>] M44:[<see cref="M44"/>]}
        /// </summary>
        /// <returns>A <see cref="String"/> representation of this <see cref="matrix"/>.</returns>
        public override string ToString()
        {
            return "{M11:" + M11 + " M12:" + M12 + " M13:" + M13 + " M14:" + M14 + "}"
                + " {M21:" + M21 + " M22:" + M22 + " M23:" + M23 + " M24:" + M24 + "}"
                + " {M31:" + M31 + " M32:" + M32 + " M33:" + M33 + " M34:" + M34 + "}"
                + " {M41:" + M41 + " M42:" + M42 + " M43:" + M43 + " M44:" + M44 + "}";
        }

        /// <summary>
        /// Swap the matrix rows and columns.
        /// </summary>
        /// <param name="matrix">The matrix for transposing operation.</param>
        /// <returns>The new <see cref="matrix"/> which contains the transposing result.</returns>
        public static matrix Transpose(matrix matrix)
        {
            matrix ret;
            Transpose(ref matrix, out ret);
            return ret;
        }

        /// <summary>
        /// Swap the matrix rows and columns.
        /// </summary>
        /// <param name="matrix">The matrix for transposing operation.</param>
        /// <param name="result">The new <see cref="matrix"/> which contains the transposing result as an output parameter.</param>
        public static void Transpose(ref matrix matrix, out matrix result)
        {
            matrix ret;

            ret.M11 = matrix.M11;
            ret.M12 = matrix.M21;
            ret.M13 = matrix.M31;
            ret.M14 = matrix.M41;

            ret.M21 = matrix.M12;
            ret.M22 = matrix.M22;
            ret.M23 = matrix.M32;
            ret.M24 = matrix.M42;

            ret.M31 = matrix.M13;
            ret.M32 = matrix.M23;
            ret.M33 = matrix.M33;
            ret.M34 = matrix.M43;

            ret.M41 = matrix.M14;
            ret.M42 = matrix.M24;
            ret.M43 = matrix.M34;
            ret.M44 = matrix.M44;

            result = ret;
        }
        #endregion

        #region Private Static Methods

        /// <summary>
        /// Helper method for using the Laplace expansion theorem using two rows expansions to calculate major and 
        /// minor determinants of a 4x4 matrix. This method is used for inverting a matrix.
        /// </summary>
        private static void FindDeterminants(ref matrix matrix, out double major,
                                             out double minor1, out double minor2, out double minor3, out double minor4, out double minor5, out double minor6,
                                             out double minor7, out double minor8, out double minor9, out double minor10, out double minor11, out double minor12)
        {
            double det1 = matrix.M11 * matrix.M22 - matrix.M12 * matrix.M21;
            double det2 = matrix.M11 * matrix.M23 - matrix.M13 * matrix.M21;
            double det3 = matrix.M11 * matrix.M24 - matrix.M14 * matrix.M21;
            double det4 = matrix.M12 * matrix.M23 - matrix.M13 * matrix.M22;
            double det5 = matrix.M12 * matrix.M24 - matrix.M14 * matrix.M22;
            double det6 = matrix.M13 * matrix.M24 - matrix.M14 * matrix.M23;
            double det7 = matrix.M31 * matrix.M42 - matrix.M32 * matrix.M41;
            double det8 = matrix.M31 * matrix.M43 - matrix.M33 * matrix.M41;
            double det9 = matrix.M31 * matrix.M44 - matrix.M34 * matrix.M41;
            double det10 = matrix.M32 * matrix.M43 - matrix.M33 * matrix.M42;
            double det11 = matrix.M32 * matrix.M44 - matrix.M34 * matrix.M42;
            double det12 = matrix.M33 * matrix.M44 - matrix.M34 * matrix.M43;

            major = (det1 * det12 - det2 * det11 + det3 * det10 + det4 * det9 - det5 * det8 + det6 * det7);
            minor1 = det1;
            minor2 = det2;
            minor3 = det3;
            minor4 = det4;
            minor5 = det5;
            minor6 = det6;
            minor7 = det7;
            minor8 = det8;
            minor9 = det9;
            minor10 = det10;
            minor11 = det11;
            minor12 = det12;
        }

        #endregion
    }

    /// <summary>
    /// Describes a 2D-point.
    /// </summary>
    public struct point : IEquatable<point>
    {
        #region Private Fields

        private static readonly point zeroPoint = new point();

        #endregion

        #region Public Fields

        /// <summary>
        /// The x coordinate of this <see cref="point"/>.
        /// </summary>
        public int X;

        /// <summary>
        /// The y coordinate of this <see cref="point"/>.
        /// </summary>
        public int Y;

        #endregion

        #region Properties

        /// <summary>
        /// Returns a <see cref="point"/> with coordinates 0, 0.
        /// </summary>
        public static point Zero
        {
            get { return zeroPoint; }
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
        public point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Constructs a point with X and Y set to the same value.
        /// </summary>
        /// <param name="value">The x and y coordinates in 2d-space.</param>
        public point(int value)
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
        public static point operator +(point value1, point value2)
        {
            return new point(value1.X + value2.X, value1.Y + value2.Y);
        }

        /// <summary>
        /// Subtracts a <see cref="Point"/> from a <see cref="Point"/>.
        /// </summary>
        /// <param name="value1">Source <see cref="Point"/> on the left of the sub sign.</param>
        /// <param name="value2">Source <see cref="Point"/> on the right of the sub sign.</param>
        /// <returns>Result of the subtraction.</returns>
        public static point operator -(point value1, point value2)
        {
            return new point(value1.X - value2.X, value1.Y - value2.Y);
        }

        /// <summary>
        /// Multiplies the components of two points by each other.
        /// </summary>
        /// <param name="value1">Source <see cref="Point"/> on the left of the mul sign.</param>
        /// <param name="value2">Source <see cref="Point"/> on the right of the mul sign.</param>
        /// <returns>Result of the multiplication.</returns>
        public static point operator *(point value1, point value2)
        {
            return new point(value1.X * value2.X, value1.Y * value2.Y);
        }

        /// <summary>
        /// Divides the components of a <see cref="Point"/> by the components of another <see cref="Point"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Point"/> on the left of the div sign.</param>
        /// <param name="divisor">Divisor <see cref="Point"/> on the right of the div sign.</param>
        /// <returns>The result of dividing the points.</returns>
        public static point operator /(point source, point divisor)
        {
            return new point(source.X / divisor.X, source.Y / divisor.Y);
        }

        /// <summary>
        /// Compares whether two <see cref="Point"/> instances are equal.
        /// </summary>
        /// <param name="a"><see cref="Point"/> instance on the left of the equal sign.</param>
        /// <param name="b"><see cref="Point"/> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(point a, point b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares whether two <see cref="Point"/> instances are not equal.
        /// </summary>
        /// <param name="a"><see cref="Point"/> instance on the left of the not equal sign.</param>
        /// <param name="b"><see cref="Point"/> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>	
        public static bool operator !=(point a, point b)
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
            return (obj is point) && Equals((point)obj);
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="point"/>.
        /// </summary>
        /// <param name="other">The <see cref="point"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(point other)
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

    public struct dpoint : IEquatable<dpoint>
    {
        #region Private Fields

        private static readonly point zeroPoint = new point();

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
        public dpoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Constructs a point with X and Y set to the same value.
        /// </summary>
        /// <param name="value">The x and y coordinates in 2d-space.</param>
        public dpoint(double value)
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
        public static dpoint operator +(dpoint value1, dpoint value2)
        {
            return new dpoint(value1.X + value2.X, value1.Y + value2.Y);
        }

        /// <summary>
        /// Subtracts a <see cref="Point"/> from a <see cref="Point"/>.
        /// </summary>
        /// <param name="value1">Source <see cref="Point"/> on the left of the sub sign.</param>
        /// <param name="value2">Source <see cref="Point"/> on the right of the sub sign.</param>
        /// <returns>Result of the subtraction.</returns>
        public static dpoint operator -(dpoint value1, dpoint value2)
        {
            return new dpoint(value1.X - value2.X, value1.Y - value2.Y);
        }

        /// <summary>
        /// Multiplies the components of two points by each other.
        /// </summary>
        /// <param name="value1">Source <see cref="Point"/> on the left of the mul sign.</param>
        /// <param name="value2">Source <see cref="Point"/> on the right of the mul sign.</param>
        /// <returns>Result of the multiplication.</returns>
        public static dpoint operator *(dpoint value1, dpoint value2)
        {
            return new dpoint(value1.X * value2.X, value1.Y * value2.Y);
        }

        /// <summary>
        /// Divides the components of a <see cref="Point"/> by the components of another <see cref="Point"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Point"/> on the left of the div sign.</param>
        /// <param name="divisor">Divisor <see cref="Point"/> on the right of the div sign.</param>
        /// <returns>The result of dividing the points.</returns>
        public static dpoint operator /(dpoint source, dpoint divisor)
        {
            return new dpoint(source.X / divisor.X, source.Y / divisor.Y);
        }

        /// <summary>
        /// Compares whether two <see cref="Point"/> instances are equal.
        /// </summary>
        /// <param name="a"><see cref="Point"/> instance on the left of the equal sign.</param>
        /// <param name="b"><see cref="Point"/> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(dpoint a, dpoint b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares whether two <see cref="Point"/> instances are not equal.
        /// </summary>
        /// <param name="a"><see cref="Point"/> instance on the left of the not equal sign.</param>
        /// <param name="b"><see cref="Point"/> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>	
        public static bool operator !=(dpoint a, dpoint b)
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

    internal class PlaneHelper
    {
        /// <summary>
        /// Returns a value indicating what side (positive/negative) of a plane a point is
        /// </summary>
        /// <param name="point">The point to check with</param>
        /// <param name="plane">The plane to check against</param>
        /// <returns>Greater than zero if on the positive side, less than zero if on the negative size, 0 otherwise</returns>
        public static double ClassifyPoint(ref vector3 point, ref plane plane)
        {
            return point.X * plane.Normal.X + point.Y * plane.Normal.Y + point.Z * plane.Normal.Z + plane.D;
        }

        /// <summary>
        /// Returns the perpendicular distance from a point to a plane
        /// </summary>
        /// <param name="point">The point to check</param>
        /// <param name="plane">The place to check</param>
        /// <returns>The perpendicular distance from the point to the plane</returns>
        public static double PerpendicularDistance(ref vector3 point, ref plane plane)
        {
            // dist = (ax + by + cz + d) / sqrt(a*a + b*b + c*c)
            return Math.Abs((plane.Normal.X * point.X + plane.Normal.Y * point.Y + plane.Normal.Z * point.Z)
                                    / Math.Sqrt(plane.Normal.X * plane.Normal.X + plane.Normal.Y * plane.Normal.Y + plane.Normal.Z * plane.Normal.Z));
        }
    }
    public struct plane : IEquatable<plane>
    {
        #region Public Fields
        
        public double D;
        
        public vector3 Normal;

        #endregion Public Fields


        #region Constructors

        public plane(vector4 value)
            : this(new vector3(value.X, value.Y, value.Z), value.W)
        {

        }

        public plane(vector3 normal, double d)
        {
            Normal = normal;
            D = d;
        }

        public plane(vector3 a, vector3 b, vector3 c)
        {
            vector3 ab = b - a;
            vector3 ac = c - a;

            vector3 cross = vector3.Cross(ab, ac);
            vector3.Normalize(ref cross, out Normal);
            D = -(vector3.Dot(Normal, a));
        }

        public plane(double a, double b, double c, double d)
            : this(new vector3(a, b, c), d)
        {

        }

        #endregion Constructors


        #region Public Methods

        public double Dot(vector4 value)
        {
            return ((((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + (this.D * value.W));
        }

        public void Dot(ref vector4 value, out double result)
        {
            result = (((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + (this.D * value.W);
        }

        public double DotCoordinate(vector3 value)
        {
            return ((((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + this.D);
        }

        public void DotCoordinate(ref vector3 value, out double result)
        {
            result = (((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z)) + this.D;
        }

        public double DotNormal(vector3 value)
        {
            return (((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z));
        }

        public void DotNormal(ref vector3 value, out double result)
        {
            result = ((this.Normal.X * value.X) + (this.Normal.Y * value.Y)) + (this.Normal.Z * value.Z);
        }

        /// <summary>
        /// Transforms a normalized plane by a matrix.
        /// </summary>
        /// <param name="plane">The normalized plane to transform.</param>
        /// <param name="matrix">The transformation matrix.</param>
        /// <returns>The transformed plane.</returns>
        public static plane Transform(plane plane, matrix matrix)
        {
            plane result;
            Transform(ref plane, ref matrix, out result);
            return result;
        }

        /// <summary>
        /// Transforms a normalized plane by a matrix.
        /// </summary>
        /// <param name="plane">The normalized plane to transform.</param>
        /// <param name="matrix">The transformation matrix.</param>
        /// <param name="result">The transformed plane.</param>
        public static void Transform(ref plane plane, ref matrix matrix, out plane result)
        {
            // See "Transforming Normals" in http://www.glprogramming.com/red/appendixf.html
            // for an explanation of how this works.

            matrix transformedMatrix;
            matrix.Invert(ref matrix, out transformedMatrix);
            matrix.Transpose(ref transformedMatrix, out transformedMatrix);

            vector4 vector = new vector4(plane.Normal, plane.D);

            vector4 transformedVector;
            vector4.Transform(ref vector, ref transformedMatrix, out transformedVector);

            result = new plane(transformedVector);
        }

        /// <summary>
        /// Transforms a normalized plane by a quaternion rotation.
        /// </summary>
        /// <param name="plane">The normalized plane to transform.</param>
        /// <param name="rotation">The quaternion rotation.</param>
        /// <returns>The transformed plane.</returns>
        public static plane Transform(plane plane, quaternion rotation)
        {
            plane result;
            Transform(ref plane, ref rotation, out result);
            return result;
        }

        /// <summary>
        /// Transforms a normalized plane by a quaternion rotation.
        /// </summary>
        /// <param name="plane">The normalized plane to transform.</param>
        /// <param name="rotation">The quaternion rotation.</param>
        /// <param name="result">The transformed plane.</param>
        public static void Transform(ref plane plane, ref quaternion rotation, out plane result)
        {
            vector3.Transform(ref plane.Normal, ref rotation, out result.Normal);
            result.D = plane.D;
        }

        public void Normalize()
        {
            double length = Normal.Length();
            double factor = 1d / length;
            vector3.Multiply(ref Normal, factor, out Normal);
            D = D * factor;
        }

        public static plane Normalize(plane value)
        {
            plane ret;
            Normalize(ref value, out ret);
            return ret;
        }

        public static void Normalize(ref plane value, out plane result)
        {
            double length = value.Normal.Length();
            double factor = 1d / length;
            vector3.Multiply(ref value.Normal, factor, out result.Normal);
            result.D = value.D * factor;
        }

        public static bool operator !=(plane plane1, plane plane2)
        {
            return !plane1.Equals(plane2);
        }

        public static bool operator ==(plane plane1, plane plane2)
        {
            return plane1.Equals(plane2);
        }

        public override bool Equals(object other)
        {
            return (other is plane) ? this.Equals((plane)other) : false;
        }

        public bool Equals(plane other)
        {
            return ((Normal == other.Normal) && (D == other.D));
        }

        public override int GetHashCode()
        {
            return Normal.GetHashCode() ^ D.GetHashCode();
        }

        public PlaneIntersectionType Intersects(boundingbox box)
        {
            return box.Intersects(this);
        }

        public void Intersects(ref boundingbox box, out PlaneIntersectionType result)
        {
            box.Intersects(ref this, out result);
        }

        public PlaneIntersectionType Intersects(BoundingFrustum frustum)
        {
            return frustum.Intersects(this);
        }

        public PlaneIntersectionType Intersects(boundingsphere sphere)
        {
            return sphere.Intersects(this);
        }

        public void Intersects(ref boundingsphere sphere, out PlaneIntersectionType result)
        {
            sphere.Intersects(ref this, out result);
        }

        internal PlaneIntersectionType Intersects(ref vector3 point)
        {
            double distance;
            DotCoordinate(ref point, out distance);

            if (distance > 0)
                return PlaneIntersectionType.Front;

            if (distance < 0)
                return PlaneIntersectionType.Back;

            return PlaneIntersectionType.Intersecting;
        }

        public override string ToString()
        {
            return "{Normal:" + Normal + " D:" + D + "}";
        }

        #endregion
    }

    /// <summary>
    /// An efficient mathematical representation for three dimensional rotations.
    /// </summary>
    public struct quaternion : IEquatable<quaternion>
    {
        #region Private Fields

        private static readonly quaternion _identity = new quaternion(0, 0, 0, 1);

        #endregion

        #region Public Fields

        /// <summary>
        /// The x coordinate of this <see cref="quaternion"/>.
        /// </summary>
        public double X;

        /// <summary>
        /// The y coordinate of this <see cref="quaternion"/>.
        /// </summary>
        public double Y;

        /// <summary>
        /// The z coordinate of this <see cref="quaternion"/>.
        /// </summary>
        public double Z;

        /// <summary>
        /// The rotation component of this <see cref="quaternion"/>.
        /// </summary>
        public double W;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a quaternion with X, Y, Z and W from four values.
        /// </summary>
        /// <param name="x">The x coordinate in 3d-space.</param>
        /// <param name="y">The y coordinate in 3d-space.</param>
        /// <param name="z">The z coordinate in 3d-space.</param>
        /// <param name="w">The rotation component.</param>
        public quaternion(double x, double y, double z, double w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        /// <summary>
        /// Constructs a quaternion with X, Y, Z from <see cref="vector3"/> and rotation component from a scalar.
        /// </summary>
        /// <param name="value">The x, y, z coordinates in 3d-space.</param>
        /// <param name="w">The rotation component.</param>
        public quaternion(vector3 value, double w)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
            this.W = w;
        }

        /// <summary>
        /// Constructs a quaternion from <see cref="vector4"/>.
        /// </summary>
        /// <param name="value">The x, y, z coordinates in 3d-space and the rotation component.</param>
        public quaternion(vector4 value)
        {
            this.X = value.X;
            this.Y = value.Y;
            this.Z = value.Z;
            this.W = value.W;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns a quaternion representing no rotation.
        /// </summary>
        public static quaternion Identity
        {
            get { return _identity; }
        }

        #endregion

        #region Internal Properties

        internal string DebugDisplayString
        {
            get
            {
                if (this == quaternion._identity)
                {
                    return "Identity";
                }

                return string.Concat(
                    this.X.ToString(), " ",
                    this.Y.ToString(), " ",
                    this.Z.ToString(), " ",
                    this.W.ToString()
                );
            }
        }

        #endregion

        #region Public Methods

        #region Add

        /// <summary>
        /// Creates a new <see cref="Quaternion"/> that contains the sum of two quaternions.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="Quaternion"/>.</param>
        /// <param name="quaternion2">Source <see cref="Quaternion"/>.</param>
        /// <returns>The result of the quaternion addition.</returns>
        public static quaternion Add(quaternion quaternion1, quaternion quaternion2)
        {
            quaternion quaternion;
            quaternion.X = quaternion1.X + quaternion2.X;
            quaternion.Y = quaternion1.Y + quaternion2.Y;
            quaternion.Z = quaternion1.Z + quaternion2.Z;
            quaternion.W = quaternion1.W + quaternion2.W;
            return quaternion;
        }

        /// <summary>
        /// Creates a new <see cref="Quaternion"/> that contains the sum of two quaternions.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="Quaternion"/>.</param>
        /// <param name="quaternion2">Source <see cref="Quaternion"/>.</param>
        /// <param name="result">The result of the quaternion addition as an output parameter.</param>
        public static void Add(ref quaternion quaternion1, ref quaternion quaternion2, out quaternion result)
        {
            result.X = quaternion1.X + quaternion2.X;
            result.Y = quaternion1.Y + quaternion2.Y;
            result.Z = quaternion1.Z + quaternion2.Z;
            result.W = quaternion1.W + quaternion2.W;
        }

        #endregion

        #region Concatenate

        /// <summary>
        /// Creates a new <see cref="Quaternion"/> that contains concatenation between two quaternion.
        /// </summary>
        /// <param name="value1">The first <see cref="Quaternion"/> to concatenate.</param>
        /// <param name="value2">The second <see cref="Quaternion"/> to concatenate.</param>
        /// <returns>The result of rotation of <paramref name="value1"/> followed by <paramref name="value2"/> rotation.</returns>
        public static quaternion Concatenate(quaternion value1, quaternion value2)
        {
            quaternion quaternion;

            double x1 = value1.X;
            double y1 = value1.Y;
            double z1 = value1.Z;
            double w1 = value1.W;

            double x2 = value2.X;
            double y2 = value2.Y;
            double z2 = value2.Z;
            double w2 = value2.W;

            quaternion.X = ((x2 * w1) + (x1 * w2)) + ((y2 * z1) - (z2 * y1));
            quaternion.Y = ((y2 * w1) + (y1 * w2)) + ((z2 * x1) - (x2 * z1));
            quaternion.Z = ((z2 * w1) + (z1 * w2)) + ((x2 * y1) - (y2 * x1));
            quaternion.W = (w2 * w1) - (((x2 * x1) + (y2 * y1)) + (z2 * z1));

            return quaternion;
        }

        /// <summary>
        /// Creates a new <see cref="Quaternion"/> that contains concatenation between two quaternion.
        /// </summary>
        /// <param name="value1">The first <see cref="Quaternion"/> to concatenate.</param>
        /// <param name="value2">The second <see cref="Quaternion"/> to concatenate.</param>
        /// <param name="result">The result of rotation of <paramref name="value1"/> followed by <paramref name="value2"/> rotation as an output parameter.</param>
        public static void Concatenate(ref quaternion value1, ref quaternion value2, out quaternion result)
        {
            double x1 = value1.X;
            double y1 = value1.Y;
            double z1 = value1.Z;
            double w1 = value1.W;

            double x2 = value2.X;
            double y2 = value2.Y;
            double z2 = value2.Z;
            double w2 = value2.W;

            result.X = ((x2 * w1) + (x1 * w2)) + ((y2 * z1) - (z2 * y1));
            result.Y = ((y2 * w1) + (y1 * w2)) + ((z2 * x1) - (x2 * z1));
            result.Z = ((z2 * w1) + (z1 * w2)) + ((x2 * y1) - (y2 * x1));
            result.W = (w2 * w1) - (((x2 * x1) + (y2 * y1)) + (z2 * z1));
        }

        #endregion

        #region Conjugate

        /// <summary>
        /// Transforms this quaternion into its conjugated version.
        /// </summary>
        public void Conjugate()
        {
            X = -X;
            Y = -Y;
            Z = -Z;
        }

        /// <summary>
        /// Creates a new <see cref="quaternion"/> that contains conjugated version of the specified quaternion.
        /// </summary>
        /// <param name="value">The quaternion which values will be used to create the conjugated version.</param>
        /// <returns>The conjugate version of the specified quaternion.</returns>
        public static quaternion Conjugate(quaternion value)
        {
            return new quaternion(-value.X, -value.Y, -value.Z, value.W);
        }

        /// <summary>
        /// Creates a new <see cref="quaternion"/> that contains conjugated version of the specified quaternion.
        /// </summary>
        /// <param name="value">The quaternion which values will be used to create the conjugated version.</param>
        /// <param name="result">The conjugated version of the specified quaternion as an output parameter.</param>
        public static void Conjugate(ref quaternion value, out quaternion result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
            result.Z = -value.Z;
            result.W = value.W;
        }

        #endregion

        #region CreateFromAxisAngle

        /// <summary>
        /// Creates a new <see cref="quaternion"/> from the specified axis and angle.
        /// </summary>
        /// <param name="axis">The axis of rotation.</param>
        /// <param name="angle">The angle in radians.</param>
        /// <returns>The new quaternion builded from axis and angle.</returns>
        public static quaternion CreateFromAxisAngle(vector3 axis, double angle)
        {
            double half = angle * 0.5d;
            double sin = Math.Sin(half);
            double cos = Math.Cos(half);
            return new quaternion(axis.X * sin, axis.Y * sin, axis.Z * sin, cos);
        }

        /// <summary>
        /// Creates a new <see cref="Quaternion"/> from the specified axis and angle.
        /// </summary>
        /// <param name="axis">The axis of rotation.</param>
        /// <param name="angle">The angle in radians.</param>
        /// <param name="result">The new quaternion builded from axis and angle as an output parameter.</param>
        public static void CreateFromAxisAngle(ref vector3 axis, double angle, out quaternion result)
        {
            double half = angle * 0.5;
            double sin = Math.Sin(half);
            double cos = Math.Cos(half);
            result.X = axis.X * sin;
            result.Y = axis.Y * sin;
            result.Z = axis.Z * sin;
            result.W = cos;
        }

        #endregion

        #region CreateFromRotationMatrix

        /// <summary>
        /// Creates a new <see cref="Quaternion"/> from the specified <see cref="Matrix"/>.
        /// </summary>
        /// <param name="matrix">The rotation matrix.</param>
        /// <returns>A quaternion composed from the rotation part of the matrix.</returns>
        public static quaternion CreateFromRotationMatrix(matrix matrix)
        {
            quaternion quaternion;
            double sqrt;
            double half;
            double scale = matrix.M11 + matrix.M22 + matrix.M33;

            if (scale > 0.0)
            {
                sqrt = Math.Sqrt(scale + 1.0);
                quaternion.W = sqrt * 0.5;
                sqrt = 0.5 / sqrt;

                quaternion.X = (matrix.M23 - matrix.M32) * sqrt;
                quaternion.Y = (matrix.M31 - matrix.M13) * sqrt;
                quaternion.Z = (matrix.M12 - matrix.M21) * sqrt;

                return quaternion;
            }
            if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
            {
                sqrt = Math.Sqrt(1.0 + matrix.M11 - matrix.M22 - matrix.M33);
                half = 0.5 / sqrt;

                quaternion.X = 0.5 * sqrt;
                quaternion.Y = (matrix.M12 + matrix.M21) * half;
                quaternion.Z = (matrix.M13 + matrix.M31) * half;
                quaternion.W = (matrix.M23 - matrix.M32) * half;

                return quaternion;
            }
            if (matrix.M22 > matrix.M33)
            {
                sqrt = Math.Sqrt(1.0 + matrix.M22 - matrix.M11 - matrix.M33);
                half = 0.5 / sqrt;

                quaternion.X = (matrix.M21 + matrix.M12) * half;
                quaternion.Y = 0.5 * sqrt;
                quaternion.Z = (matrix.M32 + matrix.M23) * half;
                quaternion.W = (matrix.M31 - matrix.M13) * half;

                return quaternion;
            }
            sqrt = Math.Sqrt(1.0 + matrix.M33 - matrix.M11 - matrix.M22);
            half = 0.5 / sqrt;

            quaternion.X = (matrix.M31 + matrix.M13) * half;
            quaternion.Y = (matrix.M32 + matrix.M23) * half;
            quaternion.Z = 0.5 * sqrt;
            quaternion.W = (matrix.M12 - matrix.M21) * half;

            return quaternion;
        }

        /// <summary>
        /// Creates a new <see cref="Quaternion"/> from the specified <see cref="Matrix"/>.
        /// </summary>
        /// <param name="matrix">The rotation matrix.</param>
        /// <param name="result">A quaternion composed from the rotation part of the matrix as an output parameter.</param>
        public static void CreateFromRotationMatrix(ref matrix matrix, out quaternion result)
        {
            double sqrt;
            double half;
            double scale = matrix.M11 + matrix.M22 + matrix.M33;

            if (scale > 0.0)
            {
                sqrt = Math.Sqrt(scale + 1.0);
                result.W = sqrt * 0.5;
                sqrt = 0.5 / sqrt;

                result.X = (matrix.M23 - matrix.M32) * sqrt;
                result.Y = (matrix.M31 - matrix.M13) * sqrt;
                result.Z = (matrix.M12 - matrix.M21) * sqrt;
            }
            else
            if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
            {
                sqrt = Math.Sqrt(1.0 + matrix.M11 - matrix.M22 - matrix.M33);
                half = 0.5 / sqrt;

                result.X = 0.5 * sqrt;
                result.Y = (matrix.M12 + matrix.M21) * half;
                result.Z = (matrix.M13 + matrix.M31) * half;
                result.W = (matrix.M23 - matrix.M32) * half;
            }
            else if (matrix.M22 > matrix.M33)
            {
                sqrt = Math.Sqrt(1.0 + matrix.M22 - matrix.M11 - matrix.M33);
                half = 0.5 / sqrt;

                result.X = (matrix.M21 + matrix.M12) * half;
                result.Y = 0.5 * sqrt;
                result.Z = (matrix.M32 + matrix.M23) * half;
                result.W = (matrix.M31 - matrix.M13) * half;
            }
            else
            {
                sqrt = Math.Sqrt(1.0 + matrix.M33 - matrix.M11 - matrix.M22);
                half = 0.5 / sqrt;

                result.X = (matrix.M31 + matrix.M13) * half;
                result.Y = (matrix.M32 + matrix.M23) * half;
                result.Z = 0.5 * sqrt;
                result.W = (matrix.M12 - matrix.M21) * half;
            }
        }

        #endregion

        #region CreateFromYawPitchRoll

        /// <summary>
        /// Creates a new <see cref="quaternion"/> from the specified yaw, pitch and roll angles.
        /// </summary>
        /// <param name="yaw">Yaw around the y axis in radians.</param>
        /// <param name="pitch">Pitch around the x axis in radians.</param>
        /// <param name="roll">Roll around the z axis in radians.</param>
        /// <returns>A new quaternion from the concatenated yaw, pitch, and roll angles.</returns>
        public static quaternion CreateFromYawPitchRoll(double yaw, double pitch, double roll)
        {
            double halfRoll = roll * 0.5;
            double halfPitch = pitch * 0.5;
            double halfYaw = yaw * 0.5;
            
            double sinRoll = Math.Sin(halfRoll);
            double cosRoll = Math.Cos(halfRoll);
            double sinPitch = Math.Sin(halfPitch);
            double cosPitch = Math.Cos(halfPitch);
            double sinYaw = Math.Sin(halfYaw);
            double cosYaw = Math.Cos(halfYaw);

            return new quaternion((cosYaw * sinPitch * cosRoll) + (sinYaw * cosPitch * sinRoll),
                                  (sinYaw * cosPitch * cosRoll) - (cosYaw * sinPitch * sinRoll),
                                  (cosYaw * cosPitch * sinRoll) - (sinYaw * sinPitch * cosRoll),
                                  (cosYaw * cosPitch * cosRoll) + (sinYaw * sinPitch * sinRoll));
        }

        /// <summary>
        /// Creates a new <see cref="quaternion"/> from the specified yaw, pitch and roll angles.
        /// </summary>
        /// <param name="yaw">Yaw around the y axis in radians.</param>
        /// <param name="pitch">Pitch around the x axis in radians.</param>
        /// <param name="roll">Roll around the z axis in radians.</param>
        /// <param name="result">A new quaternion from the concatenated yaw, pitch, and roll angles as an output parameter.</param>
 		public static void CreateFromYawPitchRoll(double yaw, double pitch, double roll, out quaternion result)
        {
            double halfRoll = roll * 0.5;
            double halfPitch = pitch * 0.5;
            double halfYaw = yaw * 0.5;
            
            double sinRoll = Math.Sin(halfRoll);
            double cosRoll = Math.Cos(halfRoll);
            double sinPitch = Math.Sin(halfPitch);
            double cosPitch = Math.Cos(halfPitch);
            double sinYaw = Math.Sin(halfYaw);
            double cosYaw = Math.Cos(halfYaw);

            result.X = (cosYaw * sinPitch * cosRoll) + (sinYaw * cosPitch * sinRoll);
            result.Y = (sinYaw * cosPitch * cosRoll) - (cosYaw * sinPitch * sinRoll);
            result.Z = (cosYaw * cosPitch * sinRoll) - (sinYaw * sinPitch * cosRoll);
            result.W = (cosYaw * cosPitch * cosRoll) + (sinYaw * sinPitch * sinRoll);
        }

        #endregion

        #region Divide

        /// <summary>
        /// Divides a <see cref="quaternion"/> by the other <see cref="quaternion"/>.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/>.</param>
        /// <param name="quaternion2">Divisor <see cref="quaternion"/>.</param>
        /// <returns>The result of dividing the quaternions.</returns>
        public static quaternion Divide(quaternion quaternion1, quaternion quaternion2)
        {
            quaternion quaternion;
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num14 = (((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W);
            double num5 = 1f / num14;
            double num4 = -quaternion2.X * num5;
            double num3 = -quaternion2.Y * num5;
            double num2 = -quaternion2.Z * num5;
            double num = quaternion2.W * num5;
            double num13 = (y * num2) - (z * num3);
            double num12 = (z * num4) - (x * num2);
            double num11 = (x * num3) - (y * num4);
            double num10 = ((x * num4) + (y * num3)) + (z * num2);
            quaternion.X = ((x * num) + (num4 * w)) + num13;
            quaternion.Y = ((y * num) + (num3 * w)) + num12;
            quaternion.Z = ((z * num) + (num2 * w)) + num11;
            quaternion.W = (w * num) - num10;
            return quaternion;
        }

        /// <summary>
        /// Divides a <see cref="Quaternion"/> by the other <see cref="Quaternion"/>.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="Quaternion"/>.</param>
        /// <param name="quaternion2">Divisor <see cref="Quaternion"/>.</param>
        /// <param name="result">The result of dividing the quaternions as an output parameter.</param>
        public static void Divide(ref quaternion quaternion1, ref quaternion quaternion2, out quaternion result)
        {
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num14 = (((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W);
            double num5 = 1f / num14;
            double num4 = -quaternion2.X * num5;
            double num3 = -quaternion2.Y * num5;
            double num2 = -quaternion2.Z * num5;
            double num = quaternion2.W * num5;
            double num13 = (y * num2) - (z * num3);
            double num12 = (z * num4) - (x * num2);
            double num11 = (x * num3) - (y * num4);
            double num10 = ((x * num4) + (y * num3)) + (z * num2);
            result.X = ((x * num) + (num4 * w)) + num13;
            result.Y = ((y * num) + (num3 * w)) + num12;
            result.Z = ((z * num) + (num2 * w)) + num11;
            result.W = (w * num) - num10;
        }

        #endregion

        #region Dot

        /// <summary>
        /// Returns a dot product of two quaternions.
        /// </summary>
        /// <param name="quaternion1">The first quaternion.</param>
        /// <param name="quaternion2">The second quaternion.</param>
        /// <returns>The dot product of two quaternions.</returns>
        public static double Dot(quaternion quaternion1, quaternion quaternion2)
        {
            return ((((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W));
        }

        /// <summary>
        /// Returns a dot product of two quaternions.
        /// </summary>
        /// <param name="quaternion1">The first quaternion.</param>
        /// <param name="quaternion2">The second quaternion.</param>
        /// <param name="result">The dot product of two quaternions as an output parameter.</param>
        public static void Dot(ref quaternion quaternion1, ref quaternion quaternion2, out double result)
        {
            result = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
        }

        #endregion

        #region Equals

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is quaternion)
                return Equals((quaternion)obj);
            return false;
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Quaternion"/>.
        /// </summary>
        /// <param name="other">The <see cref="Quaternion"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(quaternion other)
        {
            return X == other.X &&
                   Y == other.Y &&
                   Z == other.Z &&
                   W == other.W;
        }

        #endregion

        /// <summary>
        /// Gets the hash code of this <see cref="Quaternion"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="Quaternion"/>.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + W.GetHashCode();
        }

        #region Inverse

        /// <summary>
        /// Returns the inverse quaternion which represents the opposite rotation.
        /// </summary>
        /// <param name="quaternion">Source <see cref="quaternion"/>.</param>
        /// <returns>The inverse quaternion.</returns>
        public static quaternion Inverse(quaternion quaternion)
        {
            quaternion quaternion2;
            double num2 = (((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W);
            double num = 1d / num2;
            quaternion2.X = -quaternion.X * num;
            quaternion2.Y = -quaternion.Y * num;
            quaternion2.Z = -quaternion.Z * num;
            quaternion2.W = quaternion.W * num;
            return quaternion2;
        }

        /// <summary>
        /// Returns the inverse quaternion which represents the opposite rotation.
        /// </summary>
        /// <param name="quaternion">Source <see cref="quaternion"/>.</param>
        /// <param name="result">The inverse quaternion as an output parameter.</param>
        public static void Inverse(ref quaternion quaternion, out quaternion result)
        {
            double num2 = (((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W);
            double num = 1d / num2;
            result.X = -quaternion.X * num;
            result.Y = -quaternion.Y * num;
            result.Z = -quaternion.Z * num;
            result.W = quaternion.W * num;
        }

        #endregion

        /// <summary>
        /// Returns the magnitude of the quaternion components.
        /// </summary>
        /// <returns>The magnitude of the quaternion components.</returns>
        public double Length()
        {
            return Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));
        }

        /// <summary>
        /// Returns the squared magnitude of the quaternion components.
        /// </summary>
        /// <returns>The squared magnitude of the quaternion components.</returns>
        public double LengthSquared()
        {
            return (X * X) + (Y * Y) + (Z * Z) + (W * W);
        }

        #region Lerp

        /// <summary>
        /// Performs a linear blend between two quaternions.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/>.</param>
        /// <param name="quaternion2">Source <see cref="quaternion"/>.</param>
        /// <param name="amount">The blend amount where 0 returns <paramref name="quaternion1"/> and 1 <paramref name="quaternion2"/>.</param>
        /// <returns>The result of linear blending between two quaternions.</returns>
        public static quaternion Lerp(quaternion quaternion1, quaternion quaternion2, double amount)
        {
            double num = amount;
            double num2 = 1d - num;
            quaternion quaternion = new quaternion();
            double num5 = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            if (num5 >= 0d)
            {
                quaternion.X = (num2 * quaternion1.X) + (num * quaternion2.X);
                quaternion.Y = (num2 * quaternion1.Y) + (num * quaternion2.Y);
                quaternion.Z = (num2 * quaternion1.Z) + (num * quaternion2.Z);
                quaternion.W = (num2 * quaternion1.W) + (num * quaternion2.W);
            }
            else
            {
                quaternion.X = (num2 * quaternion1.X) - (num * quaternion2.X);
                quaternion.Y = (num2 * quaternion1.Y) - (num * quaternion2.Y);
                quaternion.Z = (num2 * quaternion1.Z) - (num * quaternion2.Z);
                quaternion.W = (num2 * quaternion1.W) - (num * quaternion2.W);
            }
            double num4 = (((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y)) + (quaternion.Z * quaternion.Z)) + (quaternion.W * quaternion.W);
            double num3 = 1d / (Math.Sqrt(num4));
            quaternion.X *= num3;
            quaternion.Y *= num3;
            quaternion.Z *= num3;
            quaternion.W *= num3;
            return quaternion;
        }

        /// <summary>
        /// Performs a linear blend between two quaternions.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/>.</param>
        /// <param name="quaternion2">Source <see cref="quaternion"/>.</param>
        /// <param name="amount">The blend amount where 0 returns <paramref name="quaternion1"/> and 1 <paramref name="quaternion2"/>.</param>
        /// <param name="result">The result of linear blending between two quaternions as an output parameter.</param>
        public static void Lerp(ref quaternion quaternion1, ref quaternion quaternion2, double amount, out quaternion result)
        {
            double num = amount;
            double num2 = 1d - num;
            double num5 = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            if (num5 >= 0d)
            {
                result.X = (num2 * quaternion1.X) + (num * quaternion2.X);
                result.Y = (num2 * quaternion1.Y) + (num * quaternion2.Y);
                result.Z = (num2 * quaternion1.Z) + (num * quaternion2.Z);
                result.W = (num2 * quaternion1.W) + (num * quaternion2.W);
            }
            else
            {
                result.X = (num2 * quaternion1.X) - (num * quaternion2.X);
                result.Y = (num2 * quaternion1.Y) - (num * quaternion2.Y);
                result.Z = (num2 * quaternion1.Z) - (num * quaternion2.Z);
                result.W = (num2 * quaternion1.W) - (num * quaternion2.W);
            }
            double num4 = (((result.X * result.X) + (result.Y * result.Y)) + (result.Z * result.Z)) + (result.W * result.W);
            double num3 = 1d / (Math.Sqrt(num4));
            result.X *= num3;
            result.Y *= num3;
            result.Z *= num3;
            result.W *= num3;

        }

        #endregion

        #region Slerp

        /// <summary>
        /// Performs a spherical linear blend between two quaternions.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="Quaternion"/>.</param>
        /// <param name="quaternion2">Source <see cref="Quaternion"/>.</param>
        /// <param name="amount">The blend amount where 0 returns <paramref name="quaternion1"/> and 1 <paramref name="quaternion2"/>.</param>
        /// <returns>The result of spherical linear blending between two quaternions.</returns>
        public static quaternion Slerp(quaternion quaternion1, quaternion quaternion2, double amount)
        {
            double num2;
            double num3;
            quaternion quaternion;
            double num = amount;
            double num4 = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            bool flag = false;
            if (num4 < 0d)
            {
                flag = true;
                num4 = -num4;
            }
            if (num4 > 0.9999999999999999999999999d)
            {
                num3 = 1d - num;
                num2 = flag ? -num : num;
            }
            else
            {
                double num5 = Math.Acos(num4);
                double num6 = (1.0 / Math.Sin(num5));
                num3 = (Math.Sin(((1d - num) * num5))) * num6;
                num2 = flag ? ((-Math.Sin((num * num5))) * num6) : ((Math.Sin((num * num5))) * num6);
            }
            quaternion.X = (num3 * quaternion1.X) + (num2 * quaternion2.X);
            quaternion.Y = (num3 * quaternion1.Y) + (num2 * quaternion2.Y);
            quaternion.Z = (num3 * quaternion1.Z) + (num2 * quaternion2.Z);
            quaternion.W = (num3 * quaternion1.W) + (num2 * quaternion2.W);
            return quaternion;
        }

        /// <summary>
        /// Performs a spherical linear blend between two quaternions.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/>.</param>
        /// <param name="quaternion2">Source <see cref="quaternion"/>.</param>
        /// <param name="amount">The blend amount where 0 returns <paramref name="quaternion1"/> and 1 <paramref name="quaternion2"/>.</param>
        /// <param name="result">The result of spherical linear blending between two quaternions as an output parameter.</param>
        public static void Slerp(ref quaternion quaternion1, ref quaternion quaternion2, double amount, out quaternion result)
        {
            double num2;
            double num3;
            double num = amount;
            double num4 = (((quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y)) + (quaternion1.Z * quaternion2.Z)) + (quaternion1.W * quaternion2.W);
            bool flag = false;
            if (num4 < 0d)
            {
                flag = true;
                num4 = -num4;
            }
            if (num4 > 0.999999999999999999999999999999d)
            {
                num3 = 1d - num;
                num2 = flag ? -num : num;
            }
            else
            {
                double num5 = Math.Acos(num4);
                double num6 = (1.0 / Math.Sin(num5));
                num3 = (Math.Sin(((1d - num) * num5))) * num6;
                num2 = flag ? ((-Math.Sin((num * num5))) * num6) : ((Math.Sin((num * num5))) * num6);
            }
            result.X = (num3 * quaternion1.X) + (num2 * quaternion2.X);
            result.Y = (num3 * quaternion1.Y) + (num2 * quaternion2.Y);
            result.Z = (num3 * quaternion1.Z) + (num2 * quaternion2.Z);
            result.W = (num3 * quaternion1.W) + (num2 * quaternion2.W);
        }

        #endregion

        #region Subtract

        /// <summary>
        /// Creates a new <see cref="quaternion"/> that contains subtraction of one <see cref="quaternion"/> from another.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/>.</param>
        /// <param name="quaternion2">Source <see cref="quaternion"/>.</param>
        /// <returns>The result of the quaternion subtraction.</returns>
        public static quaternion Subtract(quaternion quaternion1, quaternion quaternion2)
        {
            quaternion quaternion;
            quaternion.X = quaternion1.X - quaternion2.X;
            quaternion.Y = quaternion1.Y - quaternion2.Y;
            quaternion.Z = quaternion1.Z - quaternion2.Z;
            quaternion.W = quaternion1.W - quaternion2.W;
            return quaternion;
        }

        /// <summary>
        /// Creates a new <see cref="quaternion"/> that contains subtraction of one <see cref="quaternion"/> from another.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/>.</param>
        /// <param name="quaternion2">Source <see cref="quaternion"/>.</param>
        /// <param name="result">The result of the quaternion subtraction as an output parameter.</param>
        public static void Subtract(ref quaternion quaternion1, ref quaternion quaternion2, out quaternion result)
        {
            result.X = quaternion1.X - quaternion2.X;
            result.Y = quaternion1.Y - quaternion2.Y;
            result.Z = quaternion1.Z - quaternion2.Z;
            result.W = quaternion1.W - quaternion2.W;
        }

        #endregion

        #region Multiply

        /// <summary>
        /// Creates a new <see cref="quaternion"/> that contains a multiplication of two quaternions.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/>.</param>
        /// <param name="quaternion2">Source <see cref="quaternion"/>.</param>
        /// <returns>The result of the quaternion multiplication.</returns>
        public static quaternion Multiply(quaternion quaternion1, quaternion quaternion2)
        {
            quaternion quaternion;
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num4 = quaternion2.X;
            double num3 = quaternion2.Y;
            double num2 = quaternion2.Z;
            double num = quaternion2.W;
            double num12 = (y * num2) - (z * num3);
            double num11 = (z * num4) - (x * num2);
            double num10 = (x * num3) - (y * num4);
            double num9 = ((x * num4) + (y * num3)) + (z * num2);
            quaternion.X = ((x * num) + (num4 * w)) + num12;
            quaternion.Y = ((y * num) + (num3 * w)) + num11;
            quaternion.Z = ((z * num) + (num2 * w)) + num10;
            quaternion.W = (w * num) - num9;
            return quaternion;
        }

        /// <summary>
        /// Creates a new <see cref="quaternion"/> that contains a multiplication of <see cref="quaternion"/> and a scalar.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/>.</param>
        /// <param name="scaleFactor">Scalar value.</param>
        /// <returns>The result of the quaternion multiplication with a scalar.</returns>
        public static quaternion Multiply(quaternion quaternion1, double scaleFactor)
        {
            quaternion quaternion;
            quaternion.X = quaternion1.X * scaleFactor;
            quaternion.Y = quaternion1.Y * scaleFactor;
            quaternion.Z = quaternion1.Z * scaleFactor;
            quaternion.W = quaternion1.W * scaleFactor;
            return quaternion;
        }

        /// <summary>
        /// Creates a new <see cref="quaternion"/> that contains a multiplication of <see cref="quaternion"/> and a scalar.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/>.</param>
        /// <param name="scaleFactor">Scalar value.</param>
        /// <param name="result">The result of the quaternion multiplication with a scalar as an output parameter.</param>
        public static void Multiply(ref quaternion quaternion1, double scaleFactor, out quaternion result)
        {
            result.X = quaternion1.X * scaleFactor;
            result.Y = quaternion1.Y * scaleFactor;
            result.Z = quaternion1.Z * scaleFactor;
            result.W = quaternion1.W * scaleFactor;
        }

        /// <summary>
        /// Creates a new <see cref="quaternion"/> that contains a multiplication of two quaternions.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/>.</param>
        /// <param name="quaternion2">Source <see cref="quaternion"/>.</param>
        /// <param name="result">The result of the quaternion multiplication as an output parameter.</param>
        public static void Multiply(ref quaternion quaternion1, ref quaternion quaternion2, out quaternion result)
        {
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num4 = quaternion2.X;
            double num3 = quaternion2.Y;
            double num2 = quaternion2.Z;
            double num = quaternion2.W;
            double num12 = (y * num2) - (z * num3);
            double num11 = (z * num4) - (x * num2);
            double num10 = (x * num3) - (y * num4);
            double num9 = ((x * num4) + (y * num3)) + (z * num2);
            result.X = ((x * num) + (num4 * w)) + num12;
            result.Y = ((y * num) + (num3 * w)) + num11;
            result.Z = ((z * num) + (num2 * w)) + num10;
            result.W = (w * num) - num9;
        }

        #endregion

        #region Negate

        /// <summary>
        /// Flips the sign of the all the quaternion components.
        /// </summary>
        /// <param name="quaternion">Source <see cref="quaternion"/>.</param>
        /// <returns>The result of the quaternion negation.</returns>
        public static quaternion Negate(quaternion quaternion)
        {
            return new quaternion(-quaternion.X, -quaternion.Y, -quaternion.Z, -quaternion.W);
        }

        /// <summary>
        /// Flips the sign of the all the quaternion components.
        /// </summary>
        /// <param name="quaternion">Source <see cref="quaternion"/>.</param>
        /// <param name="result">The result of the quaternion negation as an output parameter.</param>
        public static void Negate(ref quaternion quaternion, out quaternion result)
        {
            result.X = -quaternion.X;
            result.Y = -quaternion.Y;
            result.Z = -quaternion.Z;
            result.W = -quaternion.W;
        }

        #endregion

        #region Normalize

        /// <summary>
        /// Scales the quaternion magnitude to unit length.
        /// </summary>
        public void Normalize()
        {
            double num = 1d / (Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W)));
            X *= num;
            Y *= num;
            Z *= num;
            W *= num;
        }

        /// <summary>
        /// Scales the quaternion magnitude to unit length.
        /// </summary>
        /// <param name="quaternion">Source <see cref="quaternion"/>.</param>
        /// <returns>The unit length quaternion.</returns>
        public static quaternion Normalize(quaternion quaternion)
        {
            quaternion result;
            double num = 1d / (Math.Sqrt((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y) + (quaternion.Z * quaternion.Z) + (quaternion.W * quaternion.W)));
            result.X = quaternion.X * num;
            result.Y = quaternion.Y * num;
            result.Z = quaternion.Z * num;
            result.W = quaternion.W * num;
            return result;
        }

        /// <summary>
        /// Scales the quaternion magnitude to unit length.
        /// </summary>
        /// <param name="quaternion">Source <see cref="quaternion"/>.</param>
        /// <param name="result">The unit length quaternion an output parameter.</param>
        public static void Normalize(ref quaternion quaternion, out quaternion result)
        {
            double num = 1d / (Math.Sqrt((quaternion.X * quaternion.X) + (quaternion.Y * quaternion.Y) + (quaternion.Z * quaternion.Z) + (quaternion.W * quaternion.W)));
            result.X = quaternion.X * num;
            result.Y = quaternion.Y * num;
            result.Z = quaternion.Z * num;
            result.W = quaternion.W * num;
        }

        #endregion

        /// <summary>
        /// Returns a <see cref="String"/> representation of this <see cref="quaternion"/> in the format:
        /// {X:[<see cref="X"/>] Y:[<see cref="Y"/>] Z:[<see cref="Z"/>] W:[<see cref="W"/>]}
        /// </summary>
        /// <returns>A <see cref="String"/> representation of this <see cref="quaternion"/>.</returns>
        public override string ToString()
        {
            return "{X:" + X + " Y:" + Y + " Z:" + Z + " W:" + W + "}";
        }

        /// <summary>
        /// Gets a <see cref="vector4"/> representation for this object.
        /// </summary>
        /// <returns>A <see cref="vector4"/> representation for this object.</returns>
        public vector4 ToVector4()
        {
            return new vector4(X, Y, Z, W);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adds two quaternions.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/> on the left of the add sign.</param>
        /// <param name="quaternion2">Source <see cref="quaternion"/> on the right of the add sign.</param>
        /// <returns>Sum of the vectors.</returns>
        public static quaternion operator +(quaternion quaternion1, quaternion quaternion2)
        {
            quaternion quaternion;
            quaternion.X = quaternion1.X + quaternion2.X;
            quaternion.Y = quaternion1.Y + quaternion2.Y;
            quaternion.Z = quaternion1.Z + quaternion2.Z;
            quaternion.W = quaternion1.W + quaternion2.W;
            return quaternion;
        }

        /// <summary>
        /// Divides a <see cref="quaternion"/> by the other <see cref="quaternion"/>.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/> on the left of the div sign.</param>
        /// <param name="quaternion2">Divisor <see cref="quaternion"/> on the right of the div sign.</param>
        /// <returns>The result of dividing the quaternions.</returns>
        public static quaternion operator /(quaternion quaternion1, quaternion quaternion2)
        {
            quaternion quaternion;
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num14 = (((quaternion2.X * quaternion2.X) + (quaternion2.Y * quaternion2.Y)) + (quaternion2.Z * quaternion2.Z)) + (quaternion2.W * quaternion2.W);
            double num5 = 1d / num14;
            double num4 = -quaternion2.X * num5;
            double num3 = -quaternion2.Y * num5;
            double num2 = -quaternion2.Z * num5;
            double num = quaternion2.W * num5;
            double num13 = (y * num2) - (z * num3);
            double num12 = (z * num4) - (x * num2);
            double num11 = (x * num3) - (y * num4);
            double num10 = ((x * num4) + (y * num3)) + (z * num2);
            quaternion.X = ((x * num) + (num4 * w)) + num13;
            quaternion.Y = ((y * num) + (num3 * w)) + num12;
            quaternion.Z = ((z * num) + (num2 * w)) + num11;
            quaternion.W = (w * num) - num10;
            return quaternion;
        }

        /// <summary>
        /// Compares whether two <see cref="quaternion"/> instances are equal.
        /// </summary>
        /// <param name="quaternion1"><see cref="quaternion"/> instance on the left of the equal sign.</param>
        /// <param name="quaternion2"><see cref="quaternion"/> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(quaternion quaternion1, quaternion quaternion2)
        {
            return ((((quaternion1.X == quaternion2.X) && (quaternion1.Y == quaternion2.Y)) && (quaternion1.Z == quaternion2.Z)) && (quaternion1.W == quaternion2.W));
        }

        /// <summary>
        /// Compares whether two <see cref="quaternion"/> instances are not equal.
        /// </summary>
        /// <param name="quaternion1"><see cref="quaternion"/> instance on the left of the not equal sign.</param>
        /// <param name="quaternion2"><see cref="quaternion"/> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>	
        public static bool operator !=(quaternion quaternion1, quaternion quaternion2)
        {
            if (((quaternion1.X == quaternion2.X) && (quaternion1.Y == quaternion2.Y)) && (quaternion1.Z == quaternion2.Z))
            {
                return (quaternion1.W != quaternion2.W);
            }
            return true;
        }

        /// <summary>
        /// Multiplies two quaternions.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="quaternion"/> on the left of the mul sign.</param>
        /// <param name="quaternion2">Source <see cref="quaternion"/> on the right of the mul sign.</param>
        /// <returns>Result of the quaternions multiplication.</returns>
        public static quaternion operator *(quaternion quaternion1, quaternion quaternion2)
        {
            quaternion quaternion;
            double x = quaternion1.X;
            double y = quaternion1.Y;
            double z = quaternion1.Z;
            double w = quaternion1.W;
            double num4 = quaternion2.X;
            double num3 = quaternion2.Y;
            double num2 = quaternion2.Z;
            double num = quaternion2.W;
            double num12 = (y * num2) - (z * num3);
            double num11 = (z * num4) - (x * num2);
            double num10 = (x * num3) - (y * num4);
            double num9 = ((x * num4) + (y * num3)) + (z * num2);
            quaternion.X = ((x * num) + (num4 * w)) + num12;
            quaternion.Y = ((y * num) + (num3 * w)) + num11;
            quaternion.Z = ((z * num) + (num2 * w)) + num10;
            quaternion.W = (w * num) - num9;
            return quaternion;
        }

        /// <summary>
        /// Multiplies the components of quaternion by a scalar.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="vector3"/> on the left of the mul sign.</param>
        /// <param name="scaleFactor">Scalar value on the right of the mul sign.</param>
        /// <returns>Result of the quaternion multiplication with a scalar.</returns>
        public static quaternion operator *(quaternion quaternion1, double scaleFactor)
        {
            quaternion quaternion;
            quaternion.X = quaternion1.X * scaleFactor;
            quaternion.Y = quaternion1.Y * scaleFactor;
            quaternion.Z = quaternion1.Z * scaleFactor;
            quaternion.W = quaternion1.W * scaleFactor;
            return quaternion;
        }

        /// <summary>
        /// Subtracts a <see cref="quaternion"/> from a <see cref="quaternion"/>.
        /// </summary>
        /// <param name="quaternion1">Source <see cref="vector3"/> on the left of the sub sign.</param>
        /// <param name="quaternion2">Source <see cref="vector3"/> on the right of the sub sign.</param>
        /// <returns>Result of the quaternion subtraction.</returns>
        public static quaternion operator -(quaternion quaternion1, quaternion quaternion2)
        {
            quaternion quaternion;
            quaternion.X = quaternion1.X - quaternion2.X;
            quaternion.Y = quaternion1.Y - quaternion2.Y;
            quaternion.Z = quaternion1.Z - quaternion2.Z;
            quaternion.W = quaternion1.W - quaternion2.W;
            return quaternion;

        }

        /// <summary>
        /// Flips the sign of the all the quaternion components.
        /// </summary>
        /// <param name="quaternion">Source <see cref="quaternion"/> on the right of the sub sign.</param>
        /// <returns>The result of the quaternion negation.</returns>
        public static quaternion operator -(quaternion quaternion)
        {
            quaternion quaternion2;
            quaternion2.X = -quaternion.X;
            quaternion2.Y = -quaternion.Y;
            quaternion2.Z = -quaternion.Z;
            quaternion2.W = -quaternion.W;
            return quaternion2;
        }

        #endregion
    }

    public struct ray : IEquatable<ray>
    {
        #region Public Fields
        
        public vector3 Direction;
        
        public vector3 Position;

        #endregion


        #region Public Constructors

        public ray(vector3 position, vector3 direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        #endregion


        #region Public Methods

        public override bool Equals(object obj)
        {
            return (obj is ray) ? this.Equals((ray)obj) : false;
        }


        public bool Equals(ray other)
        {
            return this.Position.Equals(other.Position) && this.Direction.Equals(other.Direction);
        }


        public override int GetHashCode()
        {
            return Position.GetHashCode() ^ Direction.GetHashCode();
        }
        
        public double? Intersects(boundingbox box)
        {
            const double Epsilon = 1e-6d;

            double? tMin = null, tMax = null;

            if (Math.Abs(Direction.X) < Epsilon)
            {
                if (Position.X < box.Min.X || Position.X > box.Max.X)
                    return null;
            }
            else
            {
                tMin = (box.Min.X - Position.X) / Direction.X;
                tMax = (box.Max.X - Position.X) / Direction.X;

                if (tMin > tMax)
                {
                    double? temp = tMin;
                    tMin = tMax;
                    tMax = temp;
                }
            }

            if (Math.Abs(Direction.Y) < Epsilon)
            {
                if (Position.Y < box.Min.Y || Position.Y > box.Max.Y)
                    return null;
            }
            else
            {
                double tMinY = (box.Min.Y - Position.Y) / Direction.Y;
                double tMaxY = (box.Max.Y - Position.Y) / Direction.Y;

                if (tMinY > tMaxY)
                {
                    double temp = tMinY;
                    tMinY = tMaxY;
                    tMaxY = temp;
                }

                if ((tMin.HasValue && tMin > tMaxY) || (tMax.HasValue && tMinY > tMax))
                    return null;

                if (!tMin.HasValue || tMinY > tMin) tMin = tMinY;
                if (!tMax.HasValue || tMaxY < tMax) tMax = tMaxY;
            }

            if (Math.Abs(Direction.Z) < Epsilon)
            {
                if (Position.Z < box.Min.Z || Position.Z > box.Max.Z)
                    return null;
            }
            else
            {
                double tMinZ = (box.Min.Z - Position.Z) / Direction.Z;
                double tMaxZ = (box.Max.Z - Position.Z) / Direction.Z;

                if (tMinZ > tMaxZ)
                {
                    double temp = tMinZ;
                    tMinZ = tMaxZ;
                    tMaxZ = temp;
                }

                if ((tMin.HasValue && tMin > tMaxZ) || (tMax.HasValue && tMinZ > tMax))
                    return null;

                if (!tMin.HasValue || tMinZ > tMin) tMin = tMinZ;
                if (!tMax.HasValue || tMaxZ < tMax) tMax = tMaxZ;
            }

            // having a positive tMin and a negative tMax means the ray is inside the box
            // we expect the intesection distance to be 0 in that case
            if ((tMin.HasValue && tMin < 0) && tMax > 0) return 0;

            // a negative tMin means that the intersection point is behind the ray's origin
            // we discard these as not hitting the AABB
            if (tMin < 0) return null;

            return tMin;
        }


        public void Intersects(ref boundingbox box, out double? result)
        {
            result = Intersects(box);
        }

        /*
        public float? Intersects(BoundingFrustum frustum)
        {
            if (frustum == null)
			{
				throw new ArgumentNullException("frustum");
			}
			
			return frustum.Intersects(this);			
        }
        */

        public double? Intersects(boundingsphere sphere)
        {
            double? result;
            Intersects(ref sphere, out result);
            return result;
        }

        public double? Intersects(plane plane)
        {
            double? result;
            Intersects(ref plane, out result);
            return result;
        }

        public void Intersects(ref plane plane, out double? result)
        {
            double den = vector3.Dot(Direction, plane.Normal);
            if (Math.Abs(den) < 0.00001d)
            {
                result = null;
                return;
            }

            result = (-plane.D - vector3.Dot(plane.Normal, Position)) / den;

            if (result < 0.0d)
            {
                if (result < -0.00001d)
                {
                    result = null;
                    return;
                }

                result = 0.0d;
            }
        }

        public void Intersects(ref boundingsphere sphere, out double? result)
        {
            // Find the vector between where the ray starts the the sphere's centre
            vector3 difference = sphere.Center - this.Position;

            double differenceLengthSquared = difference.LengthSquared();
            double sphereRadiusSquared = sphere.Radius * sphere.Radius;

            double distanceAlongRay;

            // If the distance between the ray start and the sphere's centre is less than
            // the radius of the sphere, it means we've intersected. N.B. checking the LengthSquared is faster.
            if (differenceLengthSquared < sphereRadiusSquared)
            {
                result = 0.0d;
                return;
            }

            vector3.Dot(ref this.Direction, ref difference, out distanceAlongRay);
            // If the ray is pointing away from the sphere then we don't ever intersect
            if (distanceAlongRay < 0)
            {
                result = null;
                return;
            }

            // Next we kinda use Pythagoras to check if we are within the bounds of the sphere
            // if x = radius of sphere
            // if y = distance between ray position and sphere centre
            // if z = the distance we've travelled along the ray
            // if x^2 + z^2 - y^2 < 0, we do not intersect
            double dist = sphereRadiusSquared + distanceAlongRay * distanceAlongRay - differenceLengthSquared;

            result = (dist < 0) ? null : distanceAlongRay - (double?)Math.Sqrt(dist);
        }


        public static bool operator !=(ray a, ray b)
        {
            return !a.Equals(b);
        }


        public static bool operator ==(ray a, ray b)
        {
            return a.Equals(b);
        }

        public override string ToString()
        {
            return "{{Position:" + Position.ToString() + " Direction:" + Direction.ToString() + "}}";
        }

        #endregion
    }

    public struct rectangle : IEquatable<rectangle>
    {
        #region Private Fields

        private static rectangle emptyRectangle = new rectangle();

        #endregion

        #region Public Fields

        /// <summary>
        /// The x coordinate of the top-left corner of this <see cref="rectangle"/>.
        /// </summary>
        public int X;

        /// <summary>
        /// The y coordinate of the top-left corner of this <see cref="rectangle"/>.
        /// </summary>
        public int Y;

        /// <summary>
        /// The width of this <see cref="rectangle"/>.
        /// </summary>
        public int Width;

        /// <summary>
        /// The height of this <see cref="rectangle"/>.
        /// </summary>
        public int Height;

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns a <see cref="rectangle"/> with X=0, Y=0, Width=0, Height=0.
        /// </summary>
        public static rectangle Empty
        {
            get { return emptyRectangle; }
        }

        /// <summary>
        /// Returns the x coordinate of the left edge of this <see cref="rectangle"/>.
        /// </summary>
        public int Left
        {
            get { return this.X; }
        }

        /// <summary>
        /// Returns the x coordinate of the right edge of this <see cref="rectangle"/>.
        /// </summary>
        public int Right
        {
            get { return (this.X + this.Width); }
        }

        /// <summary>
        /// Returns the y coordinate of the top edge of this <see cref="rectangle"/>.
        /// </summary>
        public int Top
        {
            get { return this.Y; }
        }

        /// <summary>
        /// Returns the y coordinate of the bottom edge of this <see cref="rectangle"/>.
        /// </summary>
        public int Bottom
        {
            get { return (this.Y + this.Height); }
        }

        /// <summary>
        /// Whether or not this <see cref="Rectangle"/> has a <see cref="Width"/> and
        /// <see cref="Height"/> of 0, and a <see cref="Location"/> of (0, 0).
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return ((((this.Width == 0) && (this.Height == 0)) && (this.X == 0)) && (this.Y == 0));
            }
        }

        /// <summary>
        /// The top-left coordinates of this <see cref="Rectangle"/>.
        /// </summary>
        public point Location
        {
            get
            {
                return new point(this.X, this.Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// The width-height coordinates of this <see cref="Rectangle"/>.
        /// </summary>
        public point Size
        {
            get
            {
                return new point(this.Width, this.Height);
            }
            set
            {
                Width = value.X;
                Height = value.Y;
            }
        }

        /// <summary>
        /// A <see cref="Point"/> located in the center of this <see cref="Rectangle"/>.
        /// </summary>
        /// <remarks>
        /// If <see cref="Width"/> or <see cref="Height"/> is an odd number,
        /// the center point will be rounded down.
        /// </remarks>
        public point Center
        {
            get
            {
                return new point(this.X + (this.Width / 2), this.Y + (this.Height / 2));
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="Rectangle"/> struct, with the specified
        /// position, width, and height.
        /// </summary>
        /// <param name="x">The x coordinate of the top-left corner of the created <see cref="Rectangle"/>.</param>
        /// <param name="y">The y coordinate of the top-left corner of the created <see cref="Rectangle"/>.</param>
        /// <param name="width">The width of the created <see cref="Rectangle"/>.</param>
        /// <param name="height">The height of the created <see cref="Rectangle"/>.</param>
        public rectangle(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Rectangle"/> struct, with the specified
        /// location and size.
        /// </summary>
        /// <param name="location">The x and y coordinates of the top-left corner of the created <see cref="Rectangle"/>.</param>
        /// <param name="size">The width and height of the created <see cref="Rectangle"/>.</param>
        public rectangle(point location, point size)
        {
            this.X = location.X;
            this.Y = location.Y;
            this.Width = size.X;
            this.Height = size.Y;
        }

        public rectangle(int width, int height)
        {
            this.X = 0;
            this.Y = 0;
            this.Width = width;
            this.Height = height;
        }

        public rectangle(drectangle rect)
        {
            X = (int)rect.X;
            Y = (int)rect.Y;
            Width = (int)rect.Width;
            Height = (int)rect.Height;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Compares whether two <see cref="Rectangle"/> instances are equal.
        /// </summary>
        /// <param name="a"><see cref="Rectangle"/> instance on the left of the equal sign.</param>
        /// <param name="b"><see cref="Rectangle"/> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(rectangle a, rectangle b)
        {
            return ((a.X == b.X) && (a.Y == b.Y) && (a.Width == b.Width) && (a.Height == b.Height));
        }

        /// <summary>
        /// Compares whether two <see cref="Rectangle"/> instances are not equal.
        /// </summary>
        /// <param name="a"><see cref="Rectangle"/> instance on the left of the not equal sign.</param>
        /// <param name="b"><see cref="Rectangle"/> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(rectangle a, rectangle b)
        {
            return !(a == b);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets whether or not the provided coordinates lie within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="x">The x coordinate of the point to check for containment.</param>
        /// <param name="y">The y coordinate of the point to check for containment.</param>
        /// <returns><c>true</c> if the provided coordinates lie inside this <see cref="Rectangle"/>; <c>false</c> otherwise.</returns>
        public bool Contains(int x, int y)
        {
            return ((((this.X <= x) && (x < (this.X + this.Width))) && (this.Y <= y)) && (y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided coordinates lie within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="x">The x coordinate of the point to check for containment.</param>
        /// <param name="y">The y coordinate of the point to check for containment.</param>
        /// <returns><c>true</c> if the provided coordinates lie inside this <see cref="Rectangle"/>; <c>false</c> otherwise.</returns>
        public bool Contains(double x, double y)
        {
            return ((((this.X <= x) && (x < (this.X + this.Width))) && (this.Y <= y)) && (y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Point"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <returns><c>true</c> if the provided <see cref="Point"/> lies inside this <see cref="Rectangle"/>; <c>false</c> otherwise.</returns>
        public bool Contains(point value)
        {
            return ((((this.X <= value.X) && (value.X < (this.X + this.Width))) && (this.Y <= value.Y)) && (value.Y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Point"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <param name="result"><c>true</c> if the provided <see cref="Point"/> lies inside this <see cref="Rectangle"/>; <c>false</c> otherwise. As an output parameter.</param>
        public void Contains(ref point value, out bool result)
        {
            result = ((((this.X <= value.X) && (value.X < (this.X + this.Width))) && (this.Y <= value.Y)) && (value.Y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Vector2"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <returns><c>true</c> if the provided <see cref="Vector2"/> lies inside this <see cref="Rectangle"/>; <c>false</c> otherwise.</returns>
        public bool Contains(vector2 value)
        {
            return ((((this.X <= value.X) && (value.X < (this.X + this.Width))) && (this.Y <= value.Y)) && (value.Y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Vector2"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <param name="result"><c>true</c> if the provided <see cref="Vector2"/> lies inside this <see cref="Rectangle"/>; <c>false</c> otherwise. As an output parameter.</param>
        public void Contains(ref vector2 value, out bool result)
        {
            result = ((((this.X <= value.X) && (value.X < (this.X + this.Width))) && (this.Y <= value.Y)) && (value.Y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Rectangle"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The <see cref="Rectangle"/> to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <returns><c>true</c> if the provided <see cref="Rectangle"/>'s bounds lie entirely inside this <see cref="Rectangle"/>; <c>false</c> otherwise.</returns>
        public bool Contains(rectangle value)
        {
            return ((((this.X <= value.X) && ((value.X + value.Width) <= (this.X + this.Width))) && (this.Y <= value.Y)) && ((value.Y + value.Height) <= (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Rectangle"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The <see cref="Rectangle"/> to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <param name="result"><c>true</c> if the provided <see cref="Rectangle"/>'s bounds lie entirely inside this <see cref="Rectangle"/>; <c>false</c> otherwise. As an output parameter.</param>
        public void Contains(ref rectangle value, out bool result)
        {
            result = ((((this.X <= value.X) && ((value.X + value.Width) <= (this.X + this.Width))) && (this.Y <= value.Y)) && ((value.Y + value.Height) <= (this.Y + this.Height)));
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return (obj is rectangle) && this == ((rectangle)obj);
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="other">The <see cref="Rectangle"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(rectangle other)
        {
            return this == other;
        }

        /// <summary>
        /// Gets the hash code of this <see cref="Rectangle"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="Rectangle"/>.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + Width.GetHashCode();
                hash = hash * 23 + Height.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Adjusts the edges of this <see cref="Rectangle"/> by specified horizontal and vertical amounts. 
        /// </summary>
        /// <param name="horizontalAmount">Value to adjust the left and right edges.</param>
        /// <param name="verticalAmount">Value to adjust the top and bottom edges.</param>
        public void Inflate(int horizontalAmount, int verticalAmount)
        {
            X -= horizontalAmount;
            Y -= verticalAmount;
            Width += horizontalAmount * 2;
            Height += verticalAmount * 2;
        }

        /// <summary>
        /// Adjusts the edges of this <see cref="Rectangle"/> by specified horizontal and vertical amounts. 
        /// </summary>
        /// <param name="horizontalAmount">Value to adjust the left and right edges.</param>
        /// <param name="verticalAmount">Value to adjust the top and bottom edges.</param>
        public void Inflate(double horizontalAmount, double verticalAmount)
        {
            X -= (int)horizontalAmount;
            Y -= (int)verticalAmount;
            Width += (int)horizontalAmount * 2;
            Height += (int)verticalAmount * 2;
        }

        /// <summary>
        /// Gets whether or not the other <see cref="Rectangle"/> intersects with this rectangle.
        /// </summary>
        /// <param name="value">The other rectangle for testing.</param>
        /// <returns><c>true</c> if other <see cref="Rectangle"/> intersects with this rectangle; <c>false</c> otherwise.</returns>
        public bool Intersects(rectangle value)
        {
            return value.Left < Right &&
                   Left < value.Right &&
                   value.Top < Bottom &&
                   Top < value.Bottom;
        }


        /// <summary>
        /// Gets whether or not the other <see cref="Rectangle"/> intersects with this rectangle.
        /// </summary>
        /// <param name="value">The other rectangle for testing.</param>
        /// <param name="result"><c>true</c> if other <see cref="Rectangle"/> intersects with this rectangle; <c>false</c> otherwise. As an output parameter.</param>
        public void Intersects(ref rectangle value, out bool result)
        {
            result = value.Left < Right &&
                     Left < value.Right &&
                     value.Top < Bottom &&
                     Top < value.Bottom;
        }

        /// <summary>
        /// Creates a new <see cref="Rectangle"/> that contains overlapping region of two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="Rectangle"/>.</param>
        /// <param name="value2">The second <see cref="Rectangle"/>.</param>
        /// <returns>Overlapping region of the two rectangles.</returns>
        public static rectangle Intersect(rectangle value1, rectangle value2)
        {
            rectangle rectangle;
            Intersect(ref value1, ref value2, out rectangle);
            return rectangle;
        }

        /// <summary>
        /// Creates a new <see cref="Rectangle"/> that contains overlapping region of two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="Rectangle"/>.</param>
        /// <param name="value2">The second <see cref="Rectangle"/>.</param>
        /// <param name="result">Overlapping region of the two rectangles as an output parameter.</param>
        public static void Intersect(ref rectangle value1, ref rectangle value2, out rectangle result)
        {
            if (value1.Intersects(value2))
            {
                int right_side = Math.Min(value1.X + value1.Width, value2.X + value2.Width);
                int left_side = Math.Max(value1.X, value2.X);
                int top_side = Math.Max(value1.Y, value2.Y);
                int bottom_side = Math.Min(value1.Y + value1.Height, value2.Y + value2.Height);
                result = new rectangle(left_side, top_side, right_side - left_side, bottom_side - top_side);
            }
            else
            {
                result = new rectangle(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Changes the <see cref="Location"/> of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="offsetX">The x coordinate to add to this <see cref="Rectangle"/>.</param>
        /// <param name="offsetY">The y coordinate to add to this <see cref="Rectangle"/>.</param>
        public void Offset(int offsetX, int offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        /// <summary>
        /// Changes the <see cref="Location"/> of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="offsetX">The x coordinate to add to this <see cref="Rectangle"/>.</param>
        /// <param name="offsetY">The y coordinate to add to this <see cref="Rectangle"/>.</param>
        public void Offset(double offsetX, double offsetY)
        {
            X += (int)offsetX;
            Y += (int)offsetY;
        }

        /// <summary>
        /// Changes the <see cref="Location"/> of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="amount">The x and y components to add to this <see cref="Rectangle"/>.</param>
        public void Offset(point amount)
        {
            X += amount.X;
            Y += amount.Y;
        }

        /// <summary>
        /// Changes the <see cref="Location"/> of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="amount">The x and y components to add to this <see cref="Rectangle"/>.</param>
        public void Offset(vector2 amount)
        {
            X += (int)amount.X;
            Y += (int)amount.Y;
        }

        /// <summary>
        /// Returns a <see cref="String"/> representation of this <see cref="Rectangle"/> in the format:
        /// {X:[<see cref="X"/>] Y:[<see cref="Y"/>] Width:[<see cref="Width"/>] Height:[<see cref="Height"/>]}
        /// </summary>
        /// <returns><see cref="String"/> representation of this <see cref="Rectangle"/>.</returns>
        public override string ToString()
        {
            return "{X:" + X + " Y:" + Y + " Width:" + Width + " Height:" + Height + "}";
        }

        /// <summary>
        /// Creates a new <see cref="Rectangle"/> that completely contains two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="Rectangle"/>.</param>
        /// <param name="value2">The second <see cref="Rectangle"/>.</param>
        /// <returns>The union of the two rectangles.</returns>
        public static rectangle Union(rectangle value1, rectangle value2)
        {
            int x = Math.Min(value1.X, value2.X);
            int y = Math.Min(value1.Y, value2.Y);
            return new rectangle(x, y,
                                 Math.Max(value1.Right, value2.Right) - x,
                                     Math.Max(value1.Bottom, value2.Bottom) - y);
        }

        /// <summary>
        /// Creates a new <see cref="Rectangle"/> that completely contains two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="Rectangle"/>.</param>
        /// <param name="value2">The second <see cref="Rectangle"/>.</param>
        /// <param name="result">The union of the two rectangles as an output parameter.</param>
        public static void Union(ref rectangle value1, ref rectangle value2, out rectangle result)
        {
            result.X = Math.Min(value1.X, value2.X);
            result.Y = Math.Min(value1.Y, value2.Y);
            result.Width = Math.Max(value1.Right, value2.Right) - result.X;
            result.Height = Math.Max(value1.Bottom, value2.Bottom) - result.Y;
        }

        #endregion
    }

    public struct drectangle : IEquatable<drectangle>
    {
        #region Private Fields

        private static drectangle emptyRectangle = new drectangle();

        #endregion

        #region Public Fields

        /// <summary>
        /// The coordinates of the top-left corner of this <see cref="rectangle"/>.
        /// </summary>
        public vector2 position;

        /// <summary>
        /// The size of this <see cref="rectangle"/>.
        /// </summary>
        public vector2 size;

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns a <see cref="rectangle"/> with X=0, Y=0, Width=0, Height=0.
        /// </summary>
        public static drectangle Empty
        {
            get { return emptyRectangle; }
        }

        /// <summary>
        /// Returns the x coordinate of the left edge of this <see cref="rectangle"/>.
        /// </summary>
        public double Left
        {
            get { return this.position.X; }
            set
            {
                double addright = position.X - value;
                position.X = value;
                size.X += addright;
            }
        }

        /// <summary>
        /// Returns the x coordinate of the right edge of this <see cref="rectangle"/>.
        /// </summary>
        public double Right
        {
            get { return (this.position.X + this.size.X); }
            set { size.X = value; }
        }

        /// <summary>
        /// Returns the y coordinate of the top edge of this <see cref="rectangle"/>.
        /// </summary>
        public double Top
        {
            get { return this.position.Y; }
            set
            {
                double addright = position.Y - value;
                position.Y = value;
                size.Y += addright;
            }
        }

        /// <summary>
        /// Returns the y coordinate of the bottom edge of this <see cref="rectangle"/>.
        /// </summary>
        public double Bottom
        {
            get { return (this.position.Y + this.size.Y); }
            set
            { size.Y = value; }
        }

        public double Width
        {
            get { return this.size.X; }
            set { size.X = value; }
        }

        public double Height
        {
            get { return this.size.Y; }
            set { size.Y = value; }
        }

        public double X
        {
            get { return this.position.X; }
            set { position.X = value; }
        }

        public double Y
        {
            get { return this.position.Y; }
            set { position.Y = value; }
        }

        /// <summary>
        /// Whether or not this <see cref="Rectangle"/> has a <see cref="Width"/> and
        /// <see cref="Height"/> of 0, and a <see cref="Location"/> of (0, 0).
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return ((((this.Width == 0) && (this.Height == 0)) && (this.X == 0)) && (this.Y == 0));
            }
        }

        /// <summary>
        /// The top-left coordinates of this <see cref="Rectangle"/>.
        /// </summary>
        public vector2 Location
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        /// <summary>
        /// The width-height coordinates of this <see cref="Rectangle"/>.
        /// </summary>
        public vector2 Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        /// <summary>
        /// A <see cref="Point"/> located in the center of this <see cref="Rectangle"/>.
        /// </summary>
        /// <remarks>
        /// If <see cref="Width"/> or <see cref="Height"/> is an odd number,
        /// the center point will be rounded down.
        /// </remarks>
        public vector2 Center
        {
            get
            {
                return new vector2(this.X + (this.Width / 2), this.Y + (this.Height / 2));
            }
            set
            {
                vector2 adj = value-Center;
                position += adj;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="Rectangle"/> struct, with the specified
        /// position, width, and height.
        /// </summary>
        /// <param name="x">The x coordinate of the top-left corner of the created <see cref="Rectangle"/>.</param>
        /// <param name="y">The y coordinate of the top-left corner of the created <see cref="Rectangle"/>.</param>
        /// <param name="width">The width of the created <see cref="Rectangle"/>.</param>
        /// <param name="height">The height of the created <see cref="Rectangle"/>.</param>
        public drectangle(double x, double y, double width, double height)
        {
            position = new vector2(x, y);
            size = new vector2(width, height);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Rectangle"/> struct, with the specified
        /// location and size.
        /// </summary>
        /// <param name="location">The x and y coordinates of the top-left corner of the created <see cref="Rectangle"/>.</param>
        /// <param name="size">The width and height of the created <see cref="Rectangle"/>.</param>
        public drectangle(point location, point wh_size)
        {
            position = new vector2(location.X, location.Y);
            size = new vector2(wh_size.X, wh_size.Y);
        }

        public drectangle(vector2 location, vector2 wh_size)
        {
            position = location;
            size = wh_size;
        }

        public drectangle(double width, double height)
        {
            position = vector2.Zero;
            size = new vector2(width, height);
        }

        public drectangle(rectangle rect)
        {
            position = new vector2(rect.X, rect.Y);
            size = new vector2(rect.Width, rect.Height);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Compares whether two <see cref="Rectangle"/> instances are equal.
        /// </summary>
        /// <param name="a"><see cref="Rectangle"/> instance on the left of the equal sign.</param>
        /// <param name="b"><see cref="Rectangle"/> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(drectangle a, drectangle b)
        {
            return ((a.X == b.X) && (a.Y == b.Y) && (a.Width == b.Width) && (a.Height == b.Height));
        }

        /// <summary>
        /// Compares whether two <see cref="Rectangle"/> instances are not equal.
        /// </summary>
        /// <param name="a"><see cref="Rectangle"/> instance on the left of the not equal sign.</param>
        /// <param name="b"><see cref="Rectangle"/> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(drectangle a, drectangle b)
        {
            return !(a == b);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets whether or not the provided coordinates lie within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="x">The x coordinate of the point to check for containment.</param>
        /// <param name="y">The y coordinate of the point to check for containment.</param>
        /// <returns><c>true</c> if the provided coordinates lie inside this <see cref="Rectangle"/>; <c>false</c> otherwise.</returns>
        public bool Contains(int x, int y)
        {
            return ((((this.X <= x) && (x < (this.X + this.Width))) && (this.Y <= y)) && (y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided coordinates lie within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="x">The x coordinate of the point to check for containment.</param>
        /// <param name="y">The y coordinate of the point to check for containment.</param>
        /// <returns><c>true</c> if the provided coordinates lie inside this <see cref="Rectangle"/>; <c>false</c> otherwise.</returns>
        public bool Contains(double x, double y)
        {
            return ((((this.X <= x) && (x < (this.X + this.Width))) && (this.Y <= y)) && (y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Point"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <returns><c>true</c> if the provided <see cref="Point"/> lies inside this <see cref="Rectangle"/>; <c>false</c> otherwise.</returns>
        public bool Contains(point value)
        {
            return ((((this.X <= value.X) && (value.X < (this.X + this.Width))) && (this.Y <= value.Y)) && (value.Y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Point"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <param name="result"><c>true</c> if the provided <see cref="Point"/> lies inside this <see cref="Rectangle"/>; <c>false</c> otherwise. As an output parameter.</param>
        public void Contains(ref point value, out bool result)
        {
            result = ((((this.X <= value.X) && (value.X < (this.X + this.Width))) && (this.Y <= value.Y)) && (value.Y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Vector2"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <returns><c>true</c> if the provided <see cref="Vector2"/> lies inside this <see cref="Rectangle"/>; <c>false</c> otherwise.</returns>
        public bool Contains(vector2 value)
        {
            return ((((this.X <= value.X) && (value.X < (this.X + this.Width))) && (this.Y <= value.Y)) && (value.Y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Vector2"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <param name="result"><c>true</c> if the provided <see cref="Vector2"/> lies inside this <see cref="Rectangle"/>; <c>false</c> otherwise. As an output parameter.</param>
        public void Contains(ref vector2 value, out bool result)
        {
            result = ((((this.X <= value.X) && (value.X < (this.X + this.Width))) && (this.Y <= value.Y)) && (value.Y < (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Rectangle"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The <see cref="Rectangle"/> to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <returns><c>true</c> if the provided <see cref="Rectangle"/>'s bounds lie entirely inside this <see cref="Rectangle"/>; <c>false</c> otherwise.</returns>
        public bool Contains(rectangle value)
        {
            return ((((this.X <= value.X) && ((value.X + value.Width) <= (this.X + this.Width))) && (this.Y <= value.Y)) && ((value.Y + value.Height) <= (this.Y + this.Height)));
        }

        /// <summary>
        /// Gets whether or not the provided <see cref="Rectangle"/> lies within the bounds of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="value">The <see cref="Rectangle"/> to check for inclusion in this <see cref="Rectangle"/>.</param>
        /// <param name="result"><c>true</c> if the provided <see cref="Rectangle"/>'s bounds lie entirely inside this <see cref="Rectangle"/>; <c>false</c> otherwise. As an output parameter.</param>
        public void Contains(ref rectangle value, out bool result)
        {
            result = ((((this.X <= value.X) && ((value.X + value.Width) <= (this.X + this.Width))) && (this.Y <= value.Y)) && ((value.Y + value.Height) <= (this.Y + this.Height)));
        }

        public bool Contains(drectangle value)
        {
            return ((((this.X <= value.X) && ((value.X + value.Width) <= (this.X + this.Width))) && (this.Y <= value.Y)) && ((value.Y + value.Height) <= (this.Y + this.Height)));
        }
        
        public void Contains(ref drectangle value, out bool result)
        {
            result = ((((this.X <= value.X) && ((value.X + value.Width) <= (this.X + this.Width))) && (this.Y <= value.Y)) && ((value.Y + value.Height) <= (this.Y + this.Height)));
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return (obj is drectangle) && this == ((drectangle)obj);
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="other">The <see cref="Rectangle"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(drectangle other)
        {
            return this == other;
        }

        /// <summary>
        /// Gets the hash code of this <see cref="Rectangle"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="Rectangle"/>.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                hash = hash * 23 + Width.GetHashCode();
                hash = hash * 23 + Height.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Adjusts the edges of this <see cref="Rectangle"/> by specified horizontal and vertical amounts. 
        /// </summary>
        /// <param name="horizontalAmount">Value to adjust the left and right edges.</param>
        /// <param name="verticalAmount">Value to adjust the top and bottom edges.</param>
        public void Inflate(int horizontalAmount, int verticalAmount)
        {
            X -= horizontalAmount;
            Y -= verticalAmount;
            Width += horizontalAmount * 2;
            Height += verticalAmount * 2;
        }

        /// <summary>
        /// Adjusts the edges of this <see cref="Rectangle"/> by specified horizontal and vertical amounts. 
        /// </summary>
        /// <param name="horizontalAmount">Value to adjust the left and right edges.</param>
        /// <param name="verticalAmount">Value to adjust the top and bottom edges.</param>
        public void Inflate(double horizontalAmount, double verticalAmount)
        {
            X -= horizontalAmount;
            Y -= verticalAmount;
            Width += horizontalAmount * 2;
            Height += verticalAmount * 2;
        }

        /// <summary>
        /// Gets whether or not the other <see cref="Rectangle"/> intersects with this rectangle.
        /// </summary>
        /// <param name="value">The other rectangle for testing.</param>
        /// <returns><c>true</c> if other <see cref="Rectangle"/> intersects with this rectangle; <c>false</c> otherwise.</returns>
        public bool Intersects(drectangle value)
        {
            return value.Left < Right &&
                   Left < value.Right &&
                   value.Top < Bottom &&
                   Top < value.Bottom;
        }


        /// <summary>
        /// Gets whether or not the other <see cref="Rectangle"/> intersects with this rectangle.
        /// </summary>
        /// <param name="value">The other rectangle for testing.</param>
        /// <param name="result"><c>true</c> if other <see cref="Rectangle"/> intersects with this rectangle; <c>false</c> otherwise. As an output parameter.</param>
        public void Intersects(ref rectangle value, out bool result)
        {
            result = value.Left < Right &&
                     Left < value.Right &&
                     value.Top < Bottom &&
                     Top < value.Bottom;
        }

        /// <summary>
        /// Creates a new <see cref="Rectangle"/> that contains overlapping region of two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="Rectangle"/>.</param>
        /// <param name="value2">The second <see cref="Rectangle"/>.</param>
        /// <returns>Overlapping region of the two rectangles.</returns>
        public static drectangle Intersect(drectangle value1, drectangle value2)
        {
            drectangle rectangle;
            Intersect(ref value1, ref value2, out rectangle);
            return rectangle;
        }

        /// <summary>
        /// Creates a new <see cref="Rectangle"/> that contains overlapping region of two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="Rectangle"/>.</param>
        /// <param name="value2">The second <see cref="Rectangle"/>.</param>
        /// <param name="result">Overlapping region of the two rectangles as an output parameter.</param>
        public static void Intersect(ref drectangle value1, ref drectangle value2, out drectangle result)
        {
            if (value1.Intersects(value2))
            {
                double right_side = Math.Min(value1.X + value1.Width, value2.X + value2.Width);
                double left_side = Math.Max(value1.X, value2.X);
                double top_side = Math.Max(value1.Y, value2.Y);
                double bottom_side = Math.Min(value1.Y + value1.Height, value2.Y + value2.Height);
                result = new drectangle(left_side, top_side, right_side - left_side, bottom_side - top_side);
            }
            else
            {
                result = new drectangle(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Changes the <see cref="Location"/> of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="offsetX">The x coordinate to add to this <see cref="Rectangle"/>.</param>
        /// <param name="offsetY">The y coordinate to add to this <see cref="Rectangle"/>.</param>
        public void Offset(int offsetX, int offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        /// <summary>
        /// Changes the <see cref="Location"/> of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="offsetX">The x coordinate to add to this <see cref="Rectangle"/>.</param>
        /// <param name="offsetY">The y coordinate to add to this <see cref="Rectangle"/>.</param>
        public void Offset(double offsetX, double offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        /// <summary>
        /// Changes the <see cref="Location"/> of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="amount">The x and y components to add to this <see cref="Rectangle"/>.</param>
        public void Offset(point amount)
        {
            X += amount.X;
            Y += amount.Y;
        }

        /// <summary>
        /// Changes the <see cref="Location"/> of this <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="amount">The x and y components to add to this <see cref="Rectangle"/>.</param>
        public void Offset(vector2 amount)
        {
            X += amount.X;
            Y += amount.Y;
        }

        /// <summary>
        /// Returns a <see cref="String"/> representation of this <see cref="Rectangle"/> in the format:
        /// {X:[<see cref="X"/>] Y:[<see cref="Y"/>] Width:[<see cref="Width"/>] Height:[<see cref="Height"/>]}
        /// </summary>
        /// <returns><see cref="String"/> representation of this <see cref="Rectangle"/>.</returns>
        public override string ToString()
        {
            return "{X:" + X + " Y:" + Y + " Width:" + Width + " Height:" + Height + "}";
        }

        /// <summary>
        /// Creates a new <see cref="Rectangle"/> that completely contains two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="Rectangle"/>.</param>
        /// <param name="value2">The second <see cref="Rectangle"/>.</param>
        /// <returns>The union of the two rectangles.</returns>
        public static drectangle Union(drectangle value1, drectangle value2)
        {
            double x = Math.Min(value1.X, value2.X);
            double y = Math.Min(value1.Y, value2.Y);
            return new drectangle(x, y,
                                 Math.Max(value1.Right, value2.Right) - x,
                                     Math.Max(value1.Bottom, value2.Bottom) - y);
        }

        /// <summary>
        /// Creates a new <see cref="Rectangle"/> that completely contains two other rectangles.
        /// </summary>
        /// <param name="value1">The first <see cref="Rectangle"/>.</param>
        /// <param name="value2">The second <see cref="Rectangle"/>.</param>
        /// <param name="result">The union of the two rectangles as an output parameter.</param>
        public static void Union(ref drectangle value1, ref drectangle value2, out drectangle result)
        {
            result = new drectangle();
            result.X = Math.Min(value1.X, value2.X);
            result.Y = Math.Min(value1.Y, value2.Y);
            result.Width = Math.Max(value1.Right, value2.Right) - result.X;
            result.Height = Math.Max(value1.Bottom, value2.Bottom) - result.Y;
        }

        #endregion
    }

    public struct size : IEquatable<size>
    {
        #region Private Fields

        private static readonly size zeroSize = new size();

        #endregion

        #region Public Fields

        /// <summary>
        /// The x coordinate of this <see cref="point"/>.
        /// </summary>
        public int Width;

        /// <summary>
        /// The y coordinate of this <see cref="point"/>.
        /// </summary>
        public int Height;

        #endregion

        #region Properties

        /// <summary>
        /// Returns a <see cref="point"/> with coordinates 0, 0.
        /// </summary>
        public static size Zero
        {
            get { return zeroSize; }
        }

        #endregion

        #region Internal Properties

        internal string DebugDisplayString
        {
            get
            {
                return string.Concat(
                    this.Width.ToString(), "  ",
                    this.Height.ToString()
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
        public size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Constructs a point with X and Y set to the same value.
        /// </summary>
        /// <param name="value">The x and y coordinates in 2d-space.</param>
        public size(int value)
        {
            this.Width = value;
            this.Height = value;
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adds two points.
        /// </summary>
        /// <param name="value1">Source <see cref="Point"/> on the left of the add sign.</param>
        /// <param name="value2">Source <see cref="Point"/> on the right of the add sign.</param>
        /// <returns>Sum of the points.</returns>
        public static size operator +(size value1, size value2)
        {
            return new size(value1.Width + value2.Width, value1.Height + value2.Height);
        }

        /// <summary>
        /// Subtracts a <see cref="Point"/> from a <see cref="Point"/>.
        /// </summary>
        /// <param name="value1">Source <see cref="Point"/> on the left of the sub sign.</param>
        /// <param name="value2">Source <see cref="Point"/> on the right of the sub sign.</param>
        /// <returns>Result of the subtraction.</returns>
        public static size operator -(size value1, size value2)
        {
            return new size(value1.Width - value2.Width, value1.Height - value2.Height);
        }

        /// <summary>
        /// Multiplies the components of two points by each other.
        /// </summary>
        /// <param name="value1">Source <see cref="Point"/> on the left of the mul sign.</param>
        /// <param name="value2">Source <see cref="Point"/> on the right of the mul sign.</param>
        /// <returns>Result of the multiplication.</returns>
        public static size operator *(size value1, size value2)
        {
            return new size(value1.Width * value2.Width, value1.Height * value2.Height);
        }

        /// <summary>
        /// Divides the components of a <see cref="Point"/> by the components of another <see cref="Point"/>.
        /// </summary>
        /// <param name="source">Source <see cref="Point"/> on the left of the div sign.</param>
        /// <param name="divisor">Divisor <see cref="Point"/> on the right of the div sign.</param>
        /// <returns>The result of dividing the points.</returns>
        public static size operator /(size source, size divisor)
        {
            return new size(source.Width / divisor.Width, source.Height / divisor.Height);
        }

        /// <summary>
        /// Compares whether two <see cref="Point"/> instances are equal.
        /// </summary>
        /// <param name="a"><see cref="Point"/> instance on the left of the equal sign.</param>
        /// <param name="b"><see cref="Point"/> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(size a, size b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares whether two <see cref="Point"/> instances are not equal.
        /// </summary>
        /// <param name="a"><see cref="Point"/> instance on the left of the not equal sign.</param>
        /// <param name="b"><see cref="Point"/> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>	
        public static bool operator !=(size a, size b)
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
            return (obj is size) && Equals((size)obj);
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="point"/>.
        /// </summary>
        /// <param name="other">The <see cref="point"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(size other)
        {
            return ((Width == other.Width) && (Height == other.Height));
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
                hash = hash * 23 + Width.GetHashCode();
                hash = hash * 23 + Height.GetHashCode();
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
            return "{Width:" + Width + " Height:" + Height + "}";
        }

        /// <summary>
        /// Gets a <see cref="Vector2"/> representation for this object.
        /// </summary>
        /// <returns>A <see cref="Vector2"/> representation for this object.</returns>
        public vector2 ToVector2()
        {
            return new vector2(Width, Height);
        }

        #endregion
    }

    public enum PlaneIntersectionType
    {
        Back, Front, Intersecting
    }
    public enum ContainmentType
    {
        Contains, Disjoint, Intersects
    }
    public struct boundingbox : IEquatable<boundingbox>
    {

        #region Public Fields
        
        public vector3 Min;
        
        public vector3 Max;

        public const int CornerCount = 8;

        #endregion Public Fields


        #region Public Constructors

        public boundingbox(vector3 min, vector3 max)
        {
            this.Min = min;
            this.Max = max;
        }

        #endregion Public Constructors


        #region Public Methods

        public ContainmentType Contains(boundingbox box)
        {
            //test if all corner is in the same side of a face by just checking min and max
            if (box.Max.X < Min.X
                || box.Min.X > Max.X
                || box.Max.Y < Min.Y
                || box.Min.Y > Max.Y
                || box.Max.Z < Min.Z
                || box.Min.Z > Max.Z)
                return ContainmentType.Disjoint;


            if (box.Min.X >= Min.X
                && box.Max.X <= Max.X
                && box.Min.Y >= Min.Y
                && box.Max.Y <= Max.Y
                && box.Min.Z >= Min.Z
                && box.Max.Z <= Max.Z)
                return ContainmentType.Contains;

            return ContainmentType.Intersects;
        }

        public void Contains(ref boundingbox box, out ContainmentType result)
        {
            result = Contains(box);
        }

        public ContainmentType Contains(BoundingFrustum frustum)
        {
            //TODO: bad done here need a fix. 
            //Because question is not frustum contain box but reverse and this is not the same
            int i;
            ContainmentType contained;
            vector3[] corners = frustum.GetCorners();

            // First we check if frustum is in box
            for (i = 0; i < corners.Length; i++)
            {
                this.Contains(ref corners[i], out contained);
                if (contained == ContainmentType.Disjoint)
                    break;
            }

            if (i == corners.Length) // This means we checked all the corners and they were all contain or instersect
                return ContainmentType.Contains;

            if (i != 0)             // if i is not equal to zero, we can fastpath and say that this box intersects
                return ContainmentType.Intersects;


            // If we get here, it means the first (and only) point we checked was actually contained in the frustum.
            // So we assume that all other points will also be contained. If one of the points is disjoint, we can
            // exit immediately saying that the result is Intersects
            i++;
            for (; i < corners.Length; i++)
            {
                this.Contains(ref corners[i], out contained);
                if (contained != ContainmentType.Contains)
                    return ContainmentType.Intersects;

            }

            // If we get here, then we know all the points were actually contained, therefore result is Contains
            return ContainmentType.Contains;
        }

        public ContainmentType Contains(boundingsphere sphere)
        {
            if (sphere.Center.X - Min.X >= sphere.Radius
                && sphere.Center.Y - Min.Y >= sphere.Radius
                && sphere.Center.Z - Min.Z >= sphere.Radius
                && Max.X - sphere.Center.X >= sphere.Radius
                && Max.Y - sphere.Center.Y >= sphere.Radius
                && Max.Z - sphere.Center.Z >= sphere.Radius)
                return ContainmentType.Contains;

            double dmin = 0;

            double e = sphere.Center.X - Min.X;
            if (e < 0)
            {
                if (e < -sphere.Radius)
                {
                    return ContainmentType.Disjoint;
                }
                dmin += e * e;
            }
            else
            {
                e = sphere.Center.X - Max.X;
                if (e > 0)
                {
                    if (e > sphere.Radius)
                    {
                        return ContainmentType.Disjoint;
                    }
                    dmin += e * e;
                }
            }

            e = sphere.Center.Y - Min.Y;
            if (e < 0)
            {
                if (e < -sphere.Radius)
                {
                    return ContainmentType.Disjoint;
                }
                dmin += e * e;
            }
            else
            {
                e = sphere.Center.Y - Max.Y;
                if (e > 0)
                {
                    if (e > sphere.Radius)
                    {
                        return ContainmentType.Disjoint;
                    }
                    dmin += e * e;
                }
            }

            e = sphere.Center.Z - Min.Z;
            if (e < 0)
            {
                if (e < -sphere.Radius)
                {
                    return ContainmentType.Disjoint;
                }
                dmin += e * e;
            }
            else
            {
                e = sphere.Center.Z - Max.Z;
                if (e > 0)
                {
                    if (e > sphere.Radius)
                    {
                        return ContainmentType.Disjoint;
                    }
                    dmin += e * e;
                }
            }

            if (dmin <= sphere.Radius * sphere.Radius)
                return ContainmentType.Intersects;

            return ContainmentType.Disjoint;
        }

        public void Contains(ref boundingsphere sphere, out ContainmentType result)
        {
            result = this.Contains(sphere);
        }

        public ContainmentType Contains(vector3 point)
        {
            ContainmentType result;
            this.Contains(ref point, out result);
            return result;
        }

        public void Contains(ref vector3 point, out ContainmentType result)
        {
            //first we get if point is out of box
            if (point.X < this.Min.X
                || point.X > this.Max.X
                || point.Y < this.Min.Y
                || point.Y > this.Max.Y
                || point.Z < this.Min.Z
                || point.Z > this.Max.Z)
            {
                result = ContainmentType.Disjoint;
            }
            else
            {
                result = ContainmentType.Contains;
            }
        }

        private static readonly vector3 MaxVector3 = new vector3(double.MaxValue);
        private static readonly vector3 MinVector3 = new vector3(double.MinValue);

        /// <summary>
        /// Create a bounding box from the given list of points.
        /// </summary>
        /// <param name="points">The list of Vector3 instances defining the point cloud to bound</param>
        /// <returns>A bounding box that encapsulates the given point cloud.</returns>
        /// <exception cref="System.ArgumentException">Thrown if the given list has no points.</exception>
        public static boundingbox CreateFromPoints(IEnumerable<vector3> points)
        {
            if (points == null)
                throw new ArgumentNullException();

            bool empty = true;
            vector3 minVec = MaxVector3;
            vector3 maxVec = MinVector3;
            foreach (vector3 ptVector in points)
            {
                minVec.X = (minVec.X < ptVector.X) ? minVec.X : ptVector.X;
                minVec.Y = (minVec.Y < ptVector.Y) ? minVec.Y : ptVector.Y;
                minVec.Z = (minVec.Z < ptVector.Z) ? minVec.Z : ptVector.Z;

                maxVec.X = (maxVec.X > ptVector.X) ? maxVec.X : ptVector.X;
                maxVec.Y = (maxVec.Y > ptVector.Y) ? maxVec.Y : ptVector.Y;
                maxVec.Z = (maxVec.Z > ptVector.Z) ? maxVec.Z : ptVector.Z;

                empty = false;
            }
            if (empty)
                throw new ArgumentException();

            return new boundingbox(minVec, maxVec);
        }

        public static boundingbox CreateFromSphere(boundingsphere sphere)
        {
            boundingbox result;
            CreateFromSphere(ref sphere, out result);
            return result;
        }

        public static void CreateFromSphere(ref boundingsphere sphere, out boundingbox result)
        {
            vector3 corner = new vector3(sphere.Radius);
            result.Min = sphere.Center - corner;
            result.Max = sphere.Center + corner;
        }

        public static boundingbox CreateMerged(boundingbox original, boundingbox additional)
        {
            boundingbox result;
            CreateMerged(ref original, ref additional, out result);
            return result;
        }

        public static void CreateMerged(ref boundingbox original, ref boundingbox additional, out boundingbox result)
        {
            result.Min.X = Math.Min(original.Min.X, additional.Min.X);
            result.Min.Y = Math.Min(original.Min.Y, additional.Min.Y);
            result.Min.Z = Math.Min(original.Min.Z, additional.Min.Z);
            result.Max.X = Math.Max(original.Max.X, additional.Max.X);
            result.Max.Y = Math.Max(original.Max.Y, additional.Max.Y);
            result.Max.Z = Math.Max(original.Max.Z, additional.Max.Z);
        }

        public bool Equals(boundingbox other)
        {
            return (this.Min == other.Min) && (this.Max == other.Max);
        }

        public override bool Equals(object obj)
        {
            return (obj is boundingbox) ? this.Equals((boundingbox)obj) : false;
        }

        public vector3[] GetCorners()
        {
            return new vector3[] {
                new vector3(this.Min.X, this.Max.Y, this.Max.Z),
                new vector3(this.Max.X, this.Max.Y, this.Max.Z),
                new vector3(this.Max.X, this.Min.Y, this.Max.Z),
                new vector3(this.Min.X, this.Min.Y, this.Max.Z),
                new vector3(this.Min.X, this.Max.Y, this.Min.Z),
                new vector3(this.Max.X, this.Max.Y, this.Min.Z),
                new vector3(this.Max.X, this.Min.Y, this.Min.Z),
                new vector3(this.Min.X, this.Min.Y, this.Min.Z)
            };
        }

        public void GetCorners(vector3[] corners)
        {
            if (corners == null)
            {
                throw new ArgumentNullException("corners");
            }
            if (corners.Length < 8)
            {
                throw new ArgumentOutOfRangeException("corners", "Not Enought Corners");
            }
            corners[0].X = this.Min.X;
            corners[0].Y = this.Max.Y;
            corners[0].Z = this.Max.Z;
            corners[1].X = this.Max.X;
            corners[1].Y = this.Max.Y;
            corners[1].Z = this.Max.Z;
            corners[2].X = this.Max.X;
            corners[2].Y = this.Min.Y;
            corners[2].Z = this.Max.Z;
            corners[3].X = this.Min.X;
            corners[3].Y = this.Min.Y;
            corners[3].Z = this.Max.Z;
            corners[4].X = this.Min.X;
            corners[4].Y = this.Max.Y;
            corners[4].Z = this.Min.Z;
            corners[5].X = this.Max.X;
            corners[5].Y = this.Max.Y;
            corners[5].Z = this.Min.Z;
            corners[6].X = this.Max.X;
            corners[6].Y = this.Min.Y;
            corners[6].Z = this.Min.Z;
            corners[7].X = this.Min.X;
            corners[7].Y = this.Min.Y;
            corners[7].Z = this.Min.Z;
        }

        public override int GetHashCode()
        {
            return this.Min.GetHashCode() + this.Max.GetHashCode();
        }

        public bool Intersects(boundingbox box)
        {
            bool result;
            Intersects(ref box, out result);
            return result;
        }

        public void Intersects(ref boundingbox box, out bool result)
        {
            if ((this.Max.X >= box.Min.X) && (this.Min.X <= box.Max.X))
            {
                if ((this.Max.Y < box.Min.Y) || (this.Min.Y > box.Max.Y))
                {
                    result = false;
                    return;
                }

                result = (this.Max.Z >= box.Min.Z) && (this.Min.Z <= box.Max.Z);
                return;
            }

            result = false;
            return;
        }

        public bool Intersects(BoundingFrustum frustum)
        {
            return frustum.Intersects(this);
        }

        public bool Intersects(boundingsphere sphere)
        {
            if (sphere.Center.X - Min.X > sphere.Radius
                && sphere.Center.Y - Min.Y > sphere.Radius
                && sphere.Center.Z - Min.Z > sphere.Radius
                && Max.X - sphere.Center.X > sphere.Radius
                && Max.Y - sphere.Center.Y > sphere.Radius
                && Max.Z - sphere.Center.Z > sphere.Radius)
                return true;

            double dmin = 0;

            if (sphere.Center.X - Min.X <= sphere.Radius)
                dmin += (sphere.Center.X - Min.X) * (sphere.Center.X - Min.X);
            else if (Max.X - sphere.Center.X <= sphere.Radius)
                dmin += (sphere.Center.X - Max.X) * (sphere.Center.X - Max.X);

            if (sphere.Center.Y - Min.Y <= sphere.Radius)
                dmin += (sphere.Center.Y - Min.Y) * (sphere.Center.Y - Min.Y);
            else if (Max.Y - sphere.Center.Y <= sphere.Radius)
                dmin += (sphere.Center.Y - Max.Y) * (sphere.Center.Y - Max.Y);

            if (sphere.Center.Z - Min.Z <= sphere.Radius)
                dmin += (sphere.Center.Z - Min.Z) * (sphere.Center.Z - Min.Z);
            else if (Max.Z - sphere.Center.Z <= sphere.Radius)
                dmin += (sphere.Center.Z - Max.Z) * (sphere.Center.Z - Max.Z);

            if (dmin <= sphere.Radius * sphere.Radius)
                return true;

            return false;
        }

        public void Intersects(ref boundingsphere sphere, out bool result)
        {
            result = Intersects(sphere);
        }

        public PlaneIntersectionType Intersects(plane plane)
        {
            PlaneIntersectionType result;
            Intersects(ref plane, out result);
            return result;
        }

        public void Intersects(ref plane plane, out PlaneIntersectionType result)
        {
            vector3 positiveVertex;
            vector3 negativeVertex;

            if (plane.Normal.X >= 0)
            {
                positiveVertex.X = Max.X;
                negativeVertex.X = Min.X;
            }
            else
            {
                positiveVertex.X = Min.X;
                negativeVertex.X = Max.X;
            }

            if (plane.Normal.Y >= 0)
            {
                positiveVertex.Y = Max.Y;
                negativeVertex.Y = Min.Y;
            }
            else
            {
                positiveVertex.Y = Min.Y;
                negativeVertex.Y = Max.Y;
            }

            if (plane.Normal.Z >= 0)
            {
                positiveVertex.Z = Max.Z;
                negativeVertex.Z = Min.Z;
            }
            else
            {
                positiveVertex.Z = Min.Z;
                negativeVertex.Z = Max.Z;
            }

            // Inline Vector3.Dot(plane.Normal, negativeVertex) + plane.D;
            double distance = plane.Normal.X * negativeVertex.X + plane.Normal.Y * negativeVertex.Y + plane.Normal.Z * negativeVertex.Z + plane.D;
            if (distance > 0)
            {
                result = PlaneIntersectionType.Front;
                return;
            }

            // Inline Vector3.Dot(plane.Normal, positiveVertex) + plane.D;
            distance = plane.Normal.X * positiveVertex.X + plane.Normal.Y * positiveVertex.Y + plane.Normal.Z * positiveVertex.Z + plane.D;
            if (distance < 0)
            {
                result = PlaneIntersectionType.Back;
                return;
            }

            result = PlaneIntersectionType.Intersecting;
        }

        public Nullable<double> Intersects(ray ray)
        {
            return ray.Intersects(this);
        }

        public void Intersects(ref ray ray, out Nullable<double> result)
        {
            result = Intersects(ray);
        }

        public static bool operator ==(boundingbox a, boundingbox b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(boundingbox a, boundingbox b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return "{{Min:" + this.Min.ToString() + " Max:" + this.Max.ToString() + "}}";
        }

        #endregion Public Methods
    }

    public struct boundingsphere : IEquatable<boundingsphere>
    {
        #region Public Fields

        /// <summary>
        /// The sphere center.
        /// </summary>
        public vector3 Center;

        /// <summary>
        /// The sphere radius.
        /// </summary>
        public double Radius;

        #endregion
        
        #region Constructors

        /// <summary>
        /// Constructs a bounding sphere with the specified center and radius.  
        /// </summary>
        /// <param name="center">The sphere center.</param>
        /// <param name="radius">The sphere radius.</param>
        public boundingsphere(vector3 center, double radius)
        {
            this.Center = center;
            this.Radius = radius;
        }

        #endregion

        #region Public Methods

        #region Contains

        /// <summary>
        /// Test if a bounding box is fully inside, outside, or just intersecting the sphere.
        /// </summary>
        /// <param name="box">The box for testing.</param>
        /// <returns>The containment type.</returns>
        public ContainmentType Contains(boundingbox box)
        {
            //check if all corner is in sphere
            bool inside = true;
            foreach (vector3 corner in box.GetCorners())
            {
                if (this.Contains(corner) == ContainmentType.Disjoint)
                {
                    inside = false;
                    break;
                }
            }

            if (inside)
                return ContainmentType.Contains;

            //check if the distance from sphere center to cube face < radius
            double dmin = 0;

            if (Center.X < box.Min.X)
                dmin += (Center.X - box.Min.X) * (Center.X - box.Min.X);

            else if (Center.X > box.Max.X)
                dmin += (Center.X - box.Max.X) * (Center.X - box.Max.X);

            if (Center.Y < box.Min.Y)
                dmin += (Center.Y - box.Min.Y) * (Center.Y - box.Min.Y);

            else if (Center.Y > box.Max.Y)
                dmin += (Center.Y - box.Max.Y) * (Center.Y - box.Max.Y);

            if (Center.Z < box.Min.Z)
                dmin += (Center.Z - box.Min.Z) * (Center.Z - box.Min.Z);

            else if (Center.Z > box.Max.Z)
                dmin += (Center.Z - box.Max.Z) * (Center.Z - box.Max.Z);

            if (dmin <= Radius * Radius)
                return ContainmentType.Intersects;

            //else disjoint
            return ContainmentType.Disjoint;
        }

        /// <summary>
        /// Test if a bounding box is fully inside, outside, or just intersecting the sphere.
        /// </summary>
        /// <param name="box">The box for testing.</param>
        /// <param name="result">The containment type as an output parameter.</param>
        public void Contains(ref boundingbox box, out ContainmentType result)
        {
            result = this.Contains(box);
        }

        /// <summary>
        /// Test if a frustum is fully inside, outside, or just intersecting the sphere.
        /// </summary>
        /// <param name="frustum">The frustum for testing.</param>
        /// <returns>The containment type.</returns>
        public ContainmentType Contains(BoundingFrustum frustum)
        {
            //check if all corner is in sphere
            bool inside = true;

            vector3[] corners = frustum.GetCorners();
            foreach (vector3 corner in corners)
            {
                if (this.Contains(corner) == ContainmentType.Disjoint)
                {
                    inside = false;
                    break;
                }
            }
            if (inside)
                return ContainmentType.Contains;

            //check if the distance from sphere center to frustrum face < radius
            double dmin = 0;
            //TODO : calcul dmin

            if (dmin <= Radius * Radius)
                return ContainmentType.Intersects;

            //else disjoint
            return ContainmentType.Disjoint;
        }

        /// <summary>
        /// Test if a frustum is fully inside, outside, or just intersecting the sphere.
        /// </summary>
        /// <param name="frustum">The frustum for testing.</param>
        /// <param name="result">The containment type as an output parameter.</param>
        public void Contains(ref BoundingFrustum frustum, out ContainmentType result)
        {
            result = this.Contains(frustum);
        }

        /// <summary>
        /// Test if a sphere is fully inside, outside, or just intersecting the sphere.
        /// </summary>
        /// <param name="sphere">The other sphere for testing.</param>
        /// <returns>The containment type.</returns>
        public ContainmentType Contains(boundingsphere sphere)
        {
            ContainmentType result;
            Contains(ref sphere, out result);
            return result;
        }

        /// <summary>
        /// Test if a sphere is fully inside, outside, or just intersecting the sphere.
        /// </summary>
        /// <param name="sphere">The other sphere for testing.</param>
        /// <param name="result">The containment type as an output parameter.</param>
        public void Contains(ref boundingsphere sphere, out ContainmentType result)
        {
            double sqDistance;
            vector3.DistanceSquared(ref sphere.Center, ref Center, out sqDistance);

            if (sqDistance > (sphere.Radius + Radius) * (sphere.Radius + Radius))
                result = ContainmentType.Disjoint;

            else if (sqDistance <= (Radius - sphere.Radius) * (Radius - sphere.Radius))
                result = ContainmentType.Contains;

            else
                result = ContainmentType.Intersects;
        }

        /// <summary>
        /// Test if a point is fully inside, outside, or just intersecting the sphere.
        /// </summary>
        /// <param name="point">The vector in 3D-space for testing.</param>
        /// <returns>The containment type.</returns>
        public ContainmentType Contains(vector3 point)
        {
            ContainmentType result;
            Contains(ref point, out result);
            return result;
        }

        /// <summary>
        /// Test if a point is fully inside, outside, or just intersecting the sphere.
        /// </summary>
        /// <param name="point">The vector in 3D-space for testing.</param>
        /// <param name="result">The containment type as an output parameter.</param>
        public void Contains(ref vector3 point, out ContainmentType result)
        {
            double sqRadius = Radius * Radius;
            double sqDistance;
            vector3.DistanceSquared(ref point, ref Center, out sqDistance);

            if (sqDistance > sqRadius)
                result = ContainmentType.Disjoint;

            else if (sqDistance < sqRadius)
                result = ContainmentType.Contains;

            else
                result = ContainmentType.Intersects;
        }

        #endregion

        #region CreateFromBoundingBox

        /// <summary>
        /// Creates the smallest <see cref="boundingsphere"/> that can contain a specified <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The box to create the sphere from.</param>
        /// <returns>The new <see cref="boundingsphere"/>.</returns>
        public static boundingsphere CreateFromBoundingBox(boundingbox box)
        {
            boundingsphere result;
            CreateFromBoundingBox(ref box, out result);
            return result;
        }

        /// <summary>
        /// Creates the smallest <see cref="boundingsphere"/> that can contain a specified <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">The box to create the sphere from.</param>
        /// <param name="result">The new <see cref="boundingsphere"/> as an output parameter.</param>
        public static void CreateFromBoundingBox(ref boundingbox box, out boundingsphere result)
        {
            // Find the center of the box.
            vector3 center = new vector3((box.Min.X + box.Max.X) / 2.0,
                                         (box.Min.Y + box.Max.Y) / 2.0,
                                         (box.Min.Z + box.Max.Z) / 2.0);

            // Find the distance between the center and one of the corners of the box.
            double radius = vector3.Distance(center, box.Max);

            result = new boundingsphere(center, radius);
        }

        #endregion

        /// <summary>
        /// Creates the smallest <see cref="boundingsphere"/> that can contain a specified <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="frustum">The frustum to create the sphere from.</param>
        /// <returns>The new <see cref="boundingsphere"/>.</returns>
        public static boundingsphere CreateFromFrustum(BoundingFrustum frustum)
        {
            return CreateFromPoints(frustum.GetCorners());
        }

        /// <summary>
        /// Creates the smallest <see cref="boundingsphere"/> that can contain a specified list of points in 3D-space. 
        /// </summary>
        /// <param name="points">List of point to create the sphere from.</param>
        /// <returns>The new <see cref="boundingsphere"/>.</returns>
        public static boundingsphere CreateFromPoints(IEnumerable<vector3> points)
        {
            if (points == null)
                throw new ArgumentNullException("points");

            // From "Real-Time Collision Detection" (Page 89)

            vector3 minx = new vector3(double.MaxValue, double.MaxValue, double.MaxValue);
            vector3 maxx = -minx;
            vector3 miny = minx;
            vector3 maxy = -minx;
            vector3 minz = minx;
            vector3 maxz = -minx;

            // Find the most extreme points along the principle axis.
            int numPoints = 0;
            foreach (vector3 pt in points)
            {
                ++numPoints;

                if (pt.X < minx.X)
                    minx = pt;
                if (pt.X > maxx.X)
                    maxx = pt;
                if (pt.Y < miny.Y)
                    miny = pt;
                if (pt.Y > maxy.Y)
                    maxy = pt;
                if (pt.Z < minz.Z)
                    minz = pt;
                if (pt.Z > maxz.Z)
                    maxz = pt;
            }

            if (numPoints == 0)
                throw new ArgumentException("You should have at least one point in points.");

            double sqDistX = vector3.DistanceSquared(maxx, minx);
            double sqDistY = vector3.DistanceSquared(maxy, miny);
            double sqDistZ = vector3.DistanceSquared(maxz, minz);

            // Pick the pair of most distant points.
            vector3 min = minx;
            vector3 max = maxx;
            if (sqDistY > sqDistX && sqDistY > sqDistZ)
            {
                max = maxy;
                min = miny;
            }
            if (sqDistZ > sqDistX && sqDistZ > sqDistY)
            {
                max = maxz;
                min = minz;
            }

            vector3 center = (min + max) * 0.5;
            double radius = vector3.Distance(max, center);

            // Test every point and expand the sphere.
            // The current bounding sphere is just a good approximation and may not enclose all points.            
            // From: Mathematics for 3D Game Programming and Computer Graphics, Eric Lengyel, Third Edition.
            // Page 218
            double sqRadius = radius * radius;
            foreach (vector3 pt in points)
            {
                vector3 diff = (pt - center);
                double sqDist = diff.LengthSquared();
                if (sqDist > sqRadius)
                {
                    double distance = Math.Sqrt(sqDist); // equal to diff.Length();
                    vector3 direction = diff / distance;
                    vector3 G = center - radius * direction;
                    center = (G + pt) / 2;
                    radius = vector3.Distance(pt, center);
                    sqRadius = radius * radius;
                }
            }

            return new boundingsphere(center, radius);
        }

        /// <summary>
        /// Creates the smallest <see cref="boundingsphere"/> that can contain two spheres.
        /// </summary>
        /// <param name="original">First sphere.</param>
        /// <param name="additional">Second sphere.</param>
        /// <returns>The new <see cref="boundingsphere"/>.</returns>
        public static boundingsphere CreateMerged(boundingsphere original, boundingsphere additional)
        {
            boundingsphere result;
            CreateMerged(ref original, ref additional, out result);
            return result;
        }

        /// <summary>
        /// Creates the smallest <see cref="boundingsphere"/> that can contain two spheres.
        /// </summary>
        /// <param name="original">First sphere.</param>
        /// <param name="additional">Second sphere.</param>
        /// <param name="result">The new <see cref="boundingsphere"/> as an output parameter.</param>
        public static void CreateMerged(ref boundingsphere original, ref boundingsphere additional, out boundingsphere result)
        {
            vector3 ocenterToaCenter = vector3.Subtract(additional.Center, original.Center);
            double distance = ocenterToaCenter.Length();
            if (distance <= original.Radius + additional.Radius)//intersect
            {
                if (distance <= original.Radius - additional.Radius)//original contain additional
                {
                    result = original;
                    return;
                }
                if (distance <= additional.Radius - original.Radius)//additional contain original
                {
                    result = additional;
                    return;
                }
            }
            //else find center of new sphere and radius
            double leftRadius = Math.Max(original.Radius - distance, additional.Radius);
            double Rightradius = Math.Max(original.Radius + distance, additional.Radius);
            ocenterToaCenter = ocenterToaCenter + (((leftRadius - Rightradius) / (2 * ocenterToaCenter.Length())) * ocenterToaCenter);//oCenterToResultCenter

            result = new boundingsphere();
            result.Center = original.Center + ocenterToaCenter;
            result.Radius = (leftRadius + Rightradius) / 2;
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="boundingsphere"/>.
        /// </summary>
        /// <param name="other">The <see cref="boundingsphere"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(boundingsphere other)
        {
            return this.Center == other.Center && this.Radius == other.Radius;
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is boundingsphere)
                return this.Equals((boundingsphere)obj);

            return false;
        }

        /// <summary>
        /// Gets the hash code of this <see cref="boundingsphere"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="boundingsphere"/>.</returns>
        public override int GetHashCode()
        {
            return this.Center.GetHashCode() + this.Radius.GetHashCode();
        }

        #region Intersects

        /// <summary>
        /// Gets whether or not a specified <see cref="BoundingBox"/> intersects with this sphere.
        /// </summary>
        /// <param name="box">The box for testing.</param>
        /// <returns><c>true</c> if <see cref="BoundingBox"/> intersects with this sphere; <c>false</c> otherwise.</returns>
        public bool Intersects(boundingbox box)
        {
            return box.Intersects(this);
        }

        /// <summary>
        /// Gets whether or not a specified <see cref="BoundingBox"/> intersects with this sphere.
        /// </summary>
        /// <param name="box">The box for testing.</param>
        /// <param name="result"><c>true</c> if <see cref="BoundingBox"/> intersects with this sphere; <c>false</c> otherwise. As an output parameter.</param>
        public void Intersects(ref boundingbox box, out bool result)
        {
            box.Intersects(ref this, out result);
        }

        /*
        TODO : Make the public bool Intersects(BoundingFrustum frustum) overload
        public bool Intersects(BoundingFrustum frustum)
        {
            if (frustum == null)
                throw new NullReferenceException();
            throw new NotImplementedException();
        }
        */

        /// <summary>
        /// Gets whether or not the other <see cref="boundingsphere"/> intersects with this sphere.
        /// </summary>
        /// <param name="sphere">The other sphere for testing.</param>
        /// <returns><c>true</c> if other <see cref="boundingsphere"/> intersects with this sphere; <c>false</c> otherwise.</returns>
        public bool Intersects(boundingsphere sphere)
        {
            bool result;
            Intersects(ref sphere, out result);
            return result;
        }

        /// <summary>
        /// Gets whether or not the other <see cref="boundingsphere"/> intersects with this sphere.
        /// </summary>
        /// <param name="sphere">The other sphere for testing.</param>
        /// <param name="result"><c>true</c> if other <see cref="boundingsphere"/> intersects with this sphere; <c>false</c> otherwise. As an output parameter.</param>
        public void Intersects(ref boundingsphere sphere, out bool result)
        {
            double sqDistance;
            vector3.DistanceSquared(ref sphere.Center, ref Center, out sqDistance);

            if (sqDistance > (sphere.Radius + Radius) * (sphere.Radius + Radius))
                result = false;
            else
                result = true;
        }

        /// <summary>
        /// Gets whether or not a specified <see cref="Plane"/> intersects with this sphere.
        /// </summary>
        /// <param name="plane">The plane for testing.</param>
        /// <returns>Type of intersection.</returns>
        public PlaneIntersectionType Intersects(plane plane)
        {
            PlaneIntersectionType result = default(PlaneIntersectionType);
            // TODO: we might want to inline this for performance reasons
            this.Intersects(ref plane, out result);
            return result;
        }

        /// <summary>
        /// Gets whether or not a specified <see cref="Plane"/> intersects with this sphere.
        /// </summary>
        /// <param name="plane">The plane for testing.</param>
        /// <param name="result">Type of intersection as an output parameter.</param>
        public void Intersects(ref plane plane, out PlaneIntersectionType result)
        {
            double distance = default(double);
            // TODO: we might want to inline this for performance reasons
            vector3.Dot(ref plane.Normal, ref this.Center, out distance);
            distance += plane.D;
            if (distance > this.Radius)
                result = PlaneIntersectionType.Front;
            else if (distance < -this.Radius)
                result = PlaneIntersectionType.Back;
            else
                result = PlaneIntersectionType.Intersecting;
        }

        /// <summary>
        /// Gets whether or not a specified <see cref="Ray"/> intersects with this sphere.
        /// </summary>
        /// <param name="ray">The ray for testing.</param>
        /// <returns>Distance of ray intersection or <c>null</c> if there is no intersection.</returns>
        public double? Intersects(ray ray)
        {
            return ray.Intersects(this);
        }

        /// <summary>
        /// Gets whether or not a specified <see cref="Ray"/> intersects with this sphere.
        /// </summary>
        /// <param name="ray">The ray for testing.</param>
        /// <param name="result">Distance of ray intersection or <c>null</c> if there is no intersection as an output parameter.</param>
        public void Intersects(ref ray ray, out double? result)
        {
            ray.Intersects(ref this, out result);
        }

        #endregion

        /// <summary>
        /// Returns a <see cref="String"/> representation of this <see cref="boundingsphere"/> in the format:
        /// {Center:[<see cref="Center"/>] Radius:[<see cref="Radius"/>]}
        /// </summary>
        /// <returns>A <see cref="String"/> representation of this <see cref="boundingsphere"/>.</returns>
        public override string ToString()
        {
            return "{Center:" + this.Center + " Radius:" + this.Radius + "}";
        }

        #region Transform

        /// <summary>
        /// Creates a new <see cref="boundingsphere"/> that contains a transformation of translation and scale from this sphere by the specified <see cref="Matrix"/>.
        /// </summary>
        /// <param name="matrix">The transformation <see cref="Matrix"/>.</param>
        /// <returns>Transformed <see cref="boundingsphere"/>.</returns>
        public boundingsphere Transform(matrix matrix)
        {
            boundingsphere sphere = new boundingsphere();
            sphere.Center = vector3.Transform(this.Center, matrix);
            sphere.Radius = this.Radius * (Math.Sqrt(Math.Max(((matrix.M11 * matrix.M11) + (matrix.M12 * matrix.M12)) + (matrix.M13 * matrix.M13), Math.Max(((matrix.M21 * matrix.M21) + (matrix.M22 * matrix.M22)) + (matrix.M23 * matrix.M23), ((matrix.M31 * matrix.M31) + (matrix.M32 * matrix.M32)) + (matrix.M33 * matrix.M33)))));
            return sphere;
        }

        /// <summary>
        /// Creates a new <see cref="boundingsphere"/> that contains a transformation of translation and scale from this sphere by the specified <see cref="Matrix"/>.
        /// </summary>
        /// <param name="matrix">The transformation <see cref="Matrix"/>.</param>
        /// <param name="result">Transformed <see cref="boundingsphere"/> as an output parameter.</param>
        public void Transform(ref matrix matrix, out boundingsphere result)
        {
            result.Center = vector3.Transform(this.Center, matrix);
            result.Radius = this.Radius * (Math.Sqrt(Math.Max(((matrix.M11 * matrix.M11) + (matrix.M12 * matrix.M12)) + (matrix.M13 * matrix.M13), Math.Max(((matrix.M21 * matrix.M21) + (matrix.M22 * matrix.M22)) + (matrix.M23 * matrix.M23), ((matrix.M31 * matrix.M31) + (matrix.M32 * matrix.M32)) + (matrix.M33 * matrix.M33)))));
        }

        #endregion

        #endregion

        #region Operators

        /// <summary>
        /// Compares whether two <see cref="boundingsphere"/> instances are equal.
        /// </summary>
        /// <param name="a"><see cref="boundingsphere"/> instance on the left of the equal sign.</param>
        /// <param name="b"><see cref="boundingsphere"/> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(boundingsphere a, boundingsphere b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Compares whether two <see cref="boundingsphere"/> instances are not equal.
        /// </summary>
        /// <param name="a"><see cref="boundingsphere"/> instance on the left of the not equal sign.</param>
        /// <param name="b"><see cref="boundingsphere"/> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(boundingsphere a, boundingsphere b)
        {
            return !a.Equals(b);
        }

        #endregion
    }

    public class BoundingFrustum : IEquatable<BoundingFrustum>
    {
        #region Private Fields

        private matrix _matrix;
        private readonly vector3[] _corners = new vector3[CornerCount];
        private readonly plane[] _planes = new plane[PlaneCount];

        #endregion

        #region Public Fields

        /// <summary>
        /// The number of planes in the frustum.
        /// </summary>
        public const int PlaneCount = 6;

        /// <summary>
        /// The number of corner points in the frustum.
        /// </summary>
        public const int CornerCount = 8;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="Matrix"/> of the frustum.
        /// </summary>
        public matrix Matrix
        {
            get { return this._matrix; }
            set
            {
                this._matrix = value;
                this.CreatePlanes();    // FIXME: The odds are the planes will be used a lot more often than the matrix
                this.CreateCorners();   // is updated, so this should help performance. I hope ;)
            }
        }

        /// <summary>
        /// Gets the near plane of the frustum.
        /// </summary>
        public plane Near
        {
            get { return this._planes[0]; }
        }

        /// <summary>
        /// Gets the far plane of the frustum.
        /// </summary>
        public plane Far
        {
            get { return this._planes[1]; }
        }

        /// <summary>
        /// Gets the left plane of the frustum.
        /// </summary>
        public plane Left
        {
            get { return this._planes[2]; }
        }

        /// <summary>
        /// Gets the right plane of the frustum.
        /// </summary>
        public plane Right
        {
            get { return this._planes[3]; }
        }

        /// <summary>
        /// Gets the top plane of the frustum.
        /// </summary>
        public plane Top
        {
            get { return this._planes[4]; }
        }

        /// <summary>
        /// Gets the bottom plane of the frustum.
        /// </summary>
        public plane Bottom
        {
            get { return this._planes[5]; }
        }

        #endregion
        
        #region Constructors

        /// <summary>
        /// Constructs the frustum by extracting the view planes from a matrix.
        /// </summary>
        /// <param name="value">Combined matrix which usually is (View * Projection).</param>
        public BoundingFrustum(matrix value)
        {
            this._matrix = value;
            this.CreatePlanes();
            this.CreateCorners();
        }

        #endregion

        #region Operators

        /// <summary>
        /// Compares whether two <see cref="BoundingFrustum"/> instances are equal.
        /// </summary>
        /// <param name="a"><see cref="BoundingFrustum"/> instance on the left of the equal sign.</param>
        /// <param name="b"><see cref="BoundingFrustum"/> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(BoundingFrustum a, BoundingFrustum b)
        {
            if (Equals(a, null))
                return (Equals(b, null));

            if (Equals(b, null))
                return (Equals(a, null));

            return a._matrix == (b._matrix);
        }

        /// <summary>
        /// Compares whether two <see cref="BoundingFrustum"/> instances are not equal.
        /// </summary>
        /// <param name="a"><see cref="BoundingFrustum"/> instance on the left of the not equal sign.</param>
        /// <param name="b"><see cref="BoundingFrustum"/> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(BoundingFrustum a, BoundingFrustum b)
        {
            return !(a == b);
        }

        #endregion

        #region Public Methods

        #region Contains

        /// <summary>
        /// Containment test between this <see cref="BoundingFrustum"/> and specified <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">A <see cref="BoundingBox"/> for testing.</param>
        /// <returns>Result of testing for containment between this <see cref="BoundingFrustum"/> and specified <see cref="BoundingBox"/>.</returns>
        public ContainmentType Contains(boundingbox box)
        {
            ContainmentType result = default(ContainmentType);
            this.Contains(ref box, out result);
            return result;
        }

        /// <summary>
        /// Containment test between this <see cref="BoundingFrustum"/> and specified <see cref="BoundingBox"/>.
        /// </summary>
        /// <param name="box">A <see cref="BoundingBox"/> for testing.</param>
        /// <param name="result">Result of testing for containment between this <see cref="BoundingFrustum"/> and specified <see cref="BoundingBox"/> as an output parameter.</param>
        public void Contains(ref boundingbox box, out ContainmentType result)
        {
            bool intersects = false;
            for (int i = 0; i < PlaneCount; ++i)
            {
                PlaneIntersectionType planeIntersectionType = default(PlaneIntersectionType);
                box.Intersects(ref this._planes[i], out planeIntersectionType);
                switch (planeIntersectionType)
                {
                    case PlaneIntersectionType.Front:
                        result = ContainmentType.Disjoint;
                        return;
                    case PlaneIntersectionType.Intersecting:
                        intersects = true;
                        break;
                }
            }
            result = intersects ? ContainmentType.Intersects : ContainmentType.Contains;
        }

        /// <summary>
        /// Containment test between this <see cref="BoundingFrustum"/> and specified <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="frustum">A <see cref="BoundingFrustum"/> for testing.</param>
        /// <returns>Result of testing for containment between this <see cref="BoundingFrustum"/> and specified <see cref="BoundingFrustum"/>.</returns>
        public ContainmentType Contains(BoundingFrustum frustum)
        {
            if (this == frustum)                // We check to see if the two frustums are equal
                return ContainmentType.Contains;// If they are, there's no need to go any further.

            bool intersects = false;
            for (int i = 0; i < PlaneCount; ++i)
            {
                PlaneIntersectionType planeIntersectionType;
                frustum.Intersects(ref _planes[i], out planeIntersectionType);
                switch (planeIntersectionType)
                {
                    case PlaneIntersectionType.Front:
                        return ContainmentType.Disjoint;
                    case PlaneIntersectionType.Intersecting:
                        intersects = true;
                        break;
                }
            }
            return intersects ? ContainmentType.Intersects : ContainmentType.Contains;
        }

        /// <summary>
        /// Containment test between this <see cref="BoundingFrustum"/> and specified <see cref="boundingsphere"/>.
        /// </summary>
        /// <param name="sphere">A <see cref="boundingsphere"/> for testing.</param>
        /// <returns>Result of testing for containment between this <see cref="BoundingFrustum"/> and specified <see cref="boundingsphere"/>.</returns>
        public ContainmentType Contains(boundingsphere sphere)
        {
            ContainmentType result = default(ContainmentType);
            this.Contains(ref sphere, out result);
            return result;
        }

        /// <summary>
        /// Containment test between this <see cref="BoundingFrustum"/> and specified <see cref="boundingsphere"/>.
        /// </summary>
        /// <param name="sphere">A <see cref="boundingsphere"/> for testing.</param>
        /// <param name="result">Result of testing for containment between this <see cref="BoundingFrustum"/> and specified <see cref="boundingsphere"/> as an output parameter.</param>
        public void Contains(ref boundingsphere sphere, out ContainmentType result)
        {
            bool intersects = false;
            for (int i = 0; i < PlaneCount; ++i)
            {
                PlaneIntersectionType planeIntersectionType = default(PlaneIntersectionType);

                // TODO: we might want to inline this for performance reasons
                sphere.Intersects(ref this._planes[i], out planeIntersectionType);
                switch (planeIntersectionType)
                {
                    case PlaneIntersectionType.Front:
                        result = ContainmentType.Disjoint;
                        return;
                    case PlaneIntersectionType.Intersecting:
                        intersects = true;
                        break;
                }
            }
            result = intersects ? ContainmentType.Intersects : ContainmentType.Contains;
        }

        /// <summary>
        /// Containment test between this <see cref="BoundingFrustum"/> and specified <see cref="Vector3"/>.
        /// </summary>
        /// <param name="point">A <see cref="Vector3"/> for testing.</param>
        /// <returns>Result of testing for containment between this <see cref="BoundingFrustum"/> and specified <see cref="Vector3"/>.</returns>
        public ContainmentType Contains(vector3 point)
        {
            ContainmentType result = default(ContainmentType);
            this.Contains(ref point, out result);
            return result;
        }

        /// <summary>
        /// Containment test between this <see cref="BoundingFrustum"/> and specified <see cref="Vector3"/>.
        /// </summary>
        /// <param name="point">A <see cref="Vector3"/> for testing.</param>
        /// <param name="result">Result of testing for containment between this <see cref="BoundingFrustum"/> and specified <see cref="Vector3"/> as an output parameter.</param>
        public void Contains(ref vector3 point, out ContainmentType result)
        {
            for (int i = 0; i < PlaneCount; ++i)
            {
                // TODO: we might want to inline this for performance reasons
                if (PlaneHelper.ClassifyPoint(ref point, ref this._planes[i]) > 0)
                {
                    result = ContainmentType.Disjoint;
                    return;
                }
            }
            result = ContainmentType.Contains;
        }

        #endregion

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="other">The <see cref="BoundingFrustum"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(BoundingFrustum other)
        {
            return (this == other);
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return (obj is BoundingFrustum) && this == ((BoundingFrustum)obj);
        }

        /// <summary>
        /// Returns a copy of internal corners array.
        /// </summary>
        /// <returns>The array of corners.</returns>
        public vector3[] GetCorners()
        {
            return (vector3[])this._corners.Clone();
        }

        /// <summary>
        /// Returns a copy of internal corners array.
        /// </summary>
        /// <param name="corners">The array which values will be replaced to corner values of this instance. It must have size of <see cref="BoundingFrustum.CornerCount"/>.</param>
		public void GetCorners(vector3[] corners)
        {
            if (corners == null) throw new ArgumentNullException("corners");
            if (corners.Length < CornerCount) throw new ArgumentOutOfRangeException("corners");

            this._corners.CopyTo(corners, 0);
        }

        /// <summary>
        /// Gets the hash code of this <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="BoundingFrustum"/>.</returns>
        public override int GetHashCode()
        {
            return this._matrix.GetHashCode();
        }

        /// <summary>
        /// Gets whether or not a specified <see cref="BoundingBox"/> intersects with this <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="box">A <see cref="BoundingBox"/> for intersection test.</param>
        /// <returns><c>true</c> if specified <see cref="BoundingBox"/> intersects with this <see cref="BoundingFrustum"/>; <c>false</c> otherwise.</returns>
        public bool Intersects(boundingbox box)
        {
            bool result = false;
            this.Intersects(ref box, out result);
            return result;
        }

        /// <summary>
        /// Gets whether or not a specified <see cref="BoundingBox"/> intersects with this <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="box">A <see cref="BoundingBox"/> for intersection test.</param>
        /// <param name="result"><c>true</c> if specified <see cref="BoundingBox"/> intersects with this <see cref="BoundingFrustum"/>; <c>false</c> otherwise as an output parameter.</param>
        public void Intersects(ref boundingbox box, out bool result)
        {
            ContainmentType containment = default(ContainmentType);
            this.Contains(ref box, out containment);
            result = containment != ContainmentType.Disjoint;
        }

        /// <summary>
        /// Gets whether or not a specified <see cref="BoundingFrustum"/> intersects with this <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="frustum">An other <see cref="BoundingFrustum"/> for intersection test.</param>
        /// <returns><c>true</c> if other <see cref="BoundingFrustum"/> intersects with this <see cref="BoundingFrustum"/>; <c>false</c> otherwise.</returns>
        public bool Intersects(BoundingFrustum frustum)
        {
            return Contains(frustum) != ContainmentType.Disjoint;
        }

        /// <summary>
        /// Gets whether or not a specified <see cref="boundingsphere"/> intersects with this <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="sphere">A <see cref="boundingsphere"/> for intersection test.</param>
        /// <returns><c>true</c> if specified <see cref="boundingsphere"/> intersects with this <see cref="BoundingFrustum"/>; <c>false</c> otherwise.</returns>
        public bool Intersects(boundingsphere sphere)
        {
            bool result = default(bool);
            this.Intersects(ref sphere, out result);
            return result;
        }

        /// <summary>
        /// Gets whether or not a specified <see cref="boundingsphere"/> intersects with this <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="sphere">A <see cref="boundingsphere"/> for intersection test.</param>
        /// <param name="result"><c>true</c> if specified <see cref="boundingsphere"/> intersects with this <see cref="BoundingFrustum"/>; <c>false</c> otherwise as an output parameter.</param>
        public void Intersects(ref boundingsphere sphere, out bool result)
        {
            ContainmentType containment = default(ContainmentType);
            this.Contains(ref sphere, out containment);
            result = containment != ContainmentType.Disjoint;
        }

        /// <summary>
        /// Gets type of intersection between specified <see cref="Plane"/> and this <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="plane">A <see cref="Plane"/> for intersection test.</param>
        /// <returns>A plane intersection type.</returns>
        public PlaneIntersectionType Intersects(plane plane)
        {
            PlaneIntersectionType result;
            Intersects(ref plane, out result);
            return result;
        }

        /// <summary>
        /// Gets type of intersection between specified <see cref="Plane"/> and this <see cref="BoundingFrustum"/>.
        /// </summary>
        /// <param name="plane">A <see cref="Plane"/> for intersection test.</param>
        /// <param name="result">A plane intersection type as an output parameter.</param>
        public void Intersects(ref plane plane, out PlaneIntersectionType result)
        {
            result = plane.Intersects(ref _corners[0]);
            for (int i = 1; i < _corners.Length; i++)
                if (plane.Intersects(ref _corners[i]) != result)
                    result = PlaneIntersectionType.Intersecting;
        }

        /// <summary>
        /// Gets the distance of intersection of <see cref="Ray"/> and this <see cref="BoundingFrustum"/> or null if no intersection happens.
        /// </summary>
        /// <param name="ray">A <see cref="Ray"/> for intersection test.</param>
        /// <returns>Distance at which ray intersects with this <see cref="BoundingFrustum"/> or null if no intersection happens.</returns>
        public double? Intersects(ray ray)
        {
            double? result;
            Intersects(ref ray, out result);
            return result;
        }

        /// <summary>
        /// Gets the distance of intersection of <see cref="Ray"/> and this <see cref="BoundingFrustum"/> or null if no intersection happens.
        /// </summary>
        /// <param name="ray">A <see cref="Ray"/> for intersection test.</param>
        /// <param name="result">Distance at which ray intersects with this <see cref="BoundingFrustum"/> or null if no intersection happens as an output parameter.</param>
        public void Intersects(ref ray ray, out double? result)
        {
            ContainmentType ctype;
            this.Contains(ref ray.Position, out ctype);

            switch (ctype)
            {
                case ContainmentType.Disjoint:
                    result = null;
                    return;
                case ContainmentType.Contains:
                    result = 0.0;
                    return;
                case ContainmentType.Intersects:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Returns a <see cref="String"/> representation of this <see cref="BoundingFrustum"/> in the format:
        /// {Near:[nearPlane] Far:[farPlane] Left:[leftPlane] Right:[rightPlane] Top:[topPlane] Bottom:[bottomPlane]}
        /// </summary>
        /// <returns><see cref="String"/> representation of this <see cref="BoundingFrustum"/>.</returns>
        public override string ToString()
        {
            return "{Near: " + this._planes[0] +
                   " Far:" + this._planes[1] +
                   " Left:" + this._planes[2] +
                   " Right:" + this._planes[3] +
                   " Top:" + this._planes[4] +
                   " Bottom:" + this._planes[5] +
                   "}";
        }

        #endregion

        #region Private Methods

        private void CreateCorners()
        {
            IntersectionPoint(ref this._planes[0], ref this._planes[2], ref this._planes[4], out this._corners[0]);
            IntersectionPoint(ref this._planes[0], ref this._planes[3], ref this._planes[4], out this._corners[1]);
            IntersectionPoint(ref this._planes[0], ref this._planes[3], ref this._planes[5], out this._corners[2]);
            IntersectionPoint(ref this._planes[0], ref this._planes[2], ref this._planes[5], out this._corners[3]);
            IntersectionPoint(ref this._planes[1], ref this._planes[2], ref this._planes[4], out this._corners[4]);
            IntersectionPoint(ref this._planes[1], ref this._planes[3], ref this._planes[4], out this._corners[5]);
            IntersectionPoint(ref this._planes[1], ref this._planes[3], ref this._planes[5], out this._corners[6]);
            IntersectionPoint(ref this._planes[1], ref this._planes[2], ref this._planes[5], out this._corners[7]);
        }

        private void CreatePlanes()
        {
            this._planes[0] = new plane(-this._matrix.M13, -this._matrix.M23, -this._matrix.M33, -this._matrix.M43);
            this._planes[1] = new plane(this._matrix.M13 - this._matrix.M14, this._matrix.M23 - this._matrix.M24, this._matrix.M33 - this._matrix.M34, this._matrix.M43 - this._matrix.M44);
            this._planes[2] = new plane(-this._matrix.M14 - this._matrix.M11, -this._matrix.M24 - this._matrix.M21, -this._matrix.M34 - this._matrix.M31, -this._matrix.M44 - this._matrix.M41);
            this._planes[3] = new plane(this._matrix.M11 - this._matrix.M14, this._matrix.M21 - this._matrix.M24, this._matrix.M31 - this._matrix.M34, this._matrix.M41 - this._matrix.M44);
            this._planes[4] = new plane(this._matrix.M12 - this._matrix.M14, this._matrix.M22 - this._matrix.M24, this._matrix.M32 - this._matrix.M34, this._matrix.M42 - this._matrix.M44);
            this._planes[5] = new plane(-this._matrix.M14 - this._matrix.M12, -this._matrix.M24 - this._matrix.M22, -this._matrix.M34 - this._matrix.M32, -this._matrix.M44 - this._matrix.M42);

            this.NormalizePlane(ref this._planes[0]);
            this.NormalizePlane(ref this._planes[1]);
            this.NormalizePlane(ref this._planes[2]);
            this.NormalizePlane(ref this._planes[3]);
            this.NormalizePlane(ref this._planes[4]);
            this.NormalizePlane(ref this._planes[5]);
        }

        private static void IntersectionPoint(ref plane a, ref plane b, ref plane c, out vector3 result)
        {
            // Formula used
            //                d1 ( N2 * N3 ) + d2 ( N3 * N1 ) + d3 ( N1 * N2 )
            //P =   -------------------------------------------------------------------------
            //                             N1 . ( N2 * N3 )
            //
            // Note: N refers to the normal, d refers to the displacement. '.' means dot product. '*' means cross product

            vector3 v1, v2, v3;
            vector3 cross;

            vector3.Cross(ref b.Normal, ref c.Normal, out cross);

            double f;
            vector3.Dot(ref a.Normal, ref cross, out f);
            f *= -1.0;

            vector3.Cross(ref b.Normal, ref c.Normal, out cross);
            vector3.Multiply(ref cross, a.D, out v1);
            //v1 = (a.D * (Vector3.Cross(b.Normal, c.Normal)));


            vector3.Cross(ref c.Normal, ref a.Normal, out cross);
            vector3.Multiply(ref cross, b.D, out v2);
            //v2 = (b.D * (Vector3.Cross(c.Normal, a.Normal)));


            vector3.Cross(ref a.Normal, ref b.Normal, out cross);
            vector3.Multiply(ref cross, c.D, out v3);
            //v3 = (c.D * (Vector3.Cross(a.Normal, b.Normal)));

            result.X = (v1.X + v2.X + v3.X) / f;
            result.Y = (v1.Y + v2.Y + v3.Y) / f;
            result.Z = (v1.Z + v2.Z + v3.Z) / f;
        }

        private void NormalizePlane(ref plane p)
        {
            double factor = 1d / p.Normal.Length();
            p.Normal.X *= factor;
            p.Normal.Y *= factor;
            p.Normal.Z *= factor;
            p.D *= factor;
        }

        #endregion
    }
}