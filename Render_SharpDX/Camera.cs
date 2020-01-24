using System;
using BaseEngine;
using BaseEngine.MyTypes;
using SharpDX;

namespace Render_SharpDX
{
	public class Camera : ICamera
	{
		public float R { get; set; }
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
				//if (pos.Y < 0.2)
				//	pos = new MyVector { X = pos.X, Y = 0.2f, Z = pos.Z };

				var vEyePt = new Vector3((float)(Math.Sin(angle.Y) * Math.Cos(angle.X)), (float)Math.Sin(angle.X), (float)(-Math.Cos(angle.Y) * Math.Cos(angle.X)));
				vEyePt = vEyePt * R + pos.ToVector3();

				var vLookatPt = pos.ToVector3();

				/*if (vEyePt.Y < 0.2)
				{
					vLookatPt.Y -= vEyePt.Y;
					vEyePt.Y = 0.2f;
				}*/

				var vUpVec = new Vector3((float)(-Math.Sin(angle.Y) * Math.Cos(angle.X + Math.PI / 2)), (float)Math.Sin(angle.X + Math.PI / 2), (float)(-Math.Cos(angle.Y) * Math.Cos(angle.X + Math.PI / 2)));

				return Convert.ToMyMatrix(Matrix.LookAtLH(vEyePt, vLookatPt, vUpVec));

				/*Vector3 position = new Vector3(5.0f, 3.0f, -10.0f); 
				Vector3 target = new Vector3(0.0f, 0.0f, 0.0f); 
				Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);

				return Convert.ToMyMatrix(Matrix.LookAtLH(position, target, up));*/
			}
		}

		public MyViewport ViewPort { get; set; }

		public Camera()
		{
			R = 3.4f;
			fovy = (float)Math.PI / 4.0f;
		}

		public void Paint()
		{
			if (Map != null) Map.Paint(this);
		}
	}
}
