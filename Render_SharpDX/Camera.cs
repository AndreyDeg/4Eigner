using System;
using BaseEngine;
using BaseEngine.MyTypes;
using SharpDX;

namespace Render_SharpDX
{
	public class Camera : ICamera
	{
		public float fovy { get; set; }
		public MyColor BackColor { get; set; }
		public MyColor LightColor { get; set; }
		public IMap Map { get; set; }

		public MyVector pos { get; set; }
		public MyVector scale { get; set; }
		public MyVector angle { get; set; }

		public MyMatrix Proj
		{
			get
			{
				float aspect = (float)ViewPort.Width / ViewPort.Height;
				return Convert.ToMyMatrix(Matrix.PerspectiveFovLH(fovy, aspect, 0.2f, 1000.0f));
			}
		}

		public MyMatrix View
		{
			get
			{
				var cameraYaw = angle.X;
				var cameraPitch = angle.Y;
				Matrix cameraRotation = Matrix.RotationYawPitchRoll(cameraYaw, cameraPitch, 0);
				Vector3 newForward = Vector3.TransformNormal(Vector3.UnitZ, cameraRotation);

				var vEyePt =  pos.ToVector3();
				var vLookatPt = pos.ToVector3() + newForward;
				var vUpVec = Vector3.UnitY;
				return Convert.ToMyMatrix(Matrix.LookAtLH(vEyePt, vLookatPt, vUpVec));
			}
		}

		public MyViewport ViewPort { get; set; }

		public Camera()
		{
			fovy = (float)Math.PI / 4.0f;
		}

		public void Move(MyVector vector)
		{
			var cameraYaw = angle.X;
			var cameraPitch = angle.Y;
			Matrix cameraRotation = Matrix.RotationYawPitchRoll(cameraYaw, cameraPitch, 0);

			pos = (pos.ToVector3() + Vector3.TransformNormal(vector.ToVector3(), cameraRotation)).ToMyVector();
		}

		public void Paint()
		{
			if (Map != null) Map.Paint(this);
		}
	}
}
