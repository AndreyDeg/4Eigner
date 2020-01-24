using BaseEngine.MyTypes;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace Render_SharpDX
{
	public static class Convert
	{
		public static RawMatrix ToRawMatrix(this MyMatrix m)
		{
			return new RawMatrix
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

		public static MyMatrix ToMyMatrix(this RawMatrix m)
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

		public static RawViewport ToRawViewport(this MyViewport m)
		{
			return new RawViewport { X = m.X, Y = m.Y, Width = m.Width, Height = m.Height, MinDepth = m.MinZ, MaxDepth = m.MaxZ };
		}

		public static MyViewport ToMyViewport(this RawViewport m)
		{
			return new MyViewport { X = m.X, Y = m.Y, Width = m.Width, Height = m.Height, MinZ = m.MinDepth, MaxZ = m.MaxDepth };
		}

		public static Vector3 ToVector3(this MyVector v)
		{
			return new Vector3 { X = v.X, Y = v.Y, Z = v.Z };
		}

		public static MyVector ToMyVector(this Vector3 v)
		{
			return new MyVector { X = v.X, Y = v.Y, Z = v.Z };
		}

		public static RawColorBGRA ToRawColorBGRA(this MyColor v)
		{
			return new RawColorBGRA(v.R, v.G, v.B, v.A);
		}

		public static MyColor ToMyColor(this RawColorBGRA v)
		{
			return new MyColor(v.A, v.R, v.G, v.B);
		}
	}
}
