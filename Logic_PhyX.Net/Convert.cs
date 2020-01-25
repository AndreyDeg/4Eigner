using BaseEngine.MyTypes;
using System.Numerics;

namespace Logic_PhyX.Net
{
    public static class Convert
    {
        public static Matrix4x4 ToMatrix4x4(this MyMatrix m)
        {
            return new Matrix4x4
            {
                M11 = m.M11,
                M12 = m.M12,
                M13 = m.M13,
                M14 = m.M14,
                M21 = m.M21,
                M22 = m.M22,
                M23 = m.M23,
                M24 = m.M24,
                M31 = m.M31,
                M32 = m.M32,
                M33 = m.M33,
                M34 = m.M34,
                M41 = m.M41,
                M42 = m.M42,
                M43 = m.M43,
                M44 = m.M44
            };
        }

        public static MyMatrix ToMyMatrix(this Matrix4x4 m)
        {
            return new MyMatrix
            {
                M11 = m.M11,
                M12 = m.M12,
                M13 = m.M13,
                M14 = m.M14,
                M21 = m.M21,
                M22 = m.M22,
                M23 = m.M23,
                M24 = m.M24,
                M31 = m.M31,
                M32 = m.M32,
                M33 = m.M33,
                M34 = m.M34,
                M41 = m.M41,
                M42 = m.M42,
                M43 = m.M43,
                M44 = m.M44
            };
        }

        public static Vector3 ToVector3(this MyVector v)
        {
            return new Vector3 { X = v.X, Y = v.Y, Z = v.Z };
        }

        public static MyVector ToMyVector(this Vector3 v)
        {
            return new MyVector { X = v.X, Y = v.Y, Z = v.Z };
        }
    }
}
