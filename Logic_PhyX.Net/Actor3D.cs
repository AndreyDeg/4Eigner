using BaseEngine;
using BaseEngine.MyTypes;
using PhysX;
using System;
using System.Numerics;

namespace Logic_PhyX.Net
{
	public class Actor3D : IActor3D
	{
		public RigidActor actor;
		//private Cloth cloth;

		public Actor3D(RigidActor m_actor)
		{
			actor = m_actor;
		}

		public MyVector pos
		{
			get
			{
				return actor.GlobalPosePosition.ToMyVector();
			}
		}

		public MyMatrix GetPosition()
		{
			//if(cloth)
			//{
			//	NxVec3 v3 = cloth->getPosition(100);
			//	D3DXMatrixTranslation(&matWorld, v3.x, v3.y, v3.z);
			//}

			if (actor != null)
				return actor.GlobalPose.ToMyMatrix();

			return new MyMatrix { M11 = 1, M22 = 1, M33 = 1, M44 = 1 };
		}

		public void Update(IModel3D model)
		{
			var pos = GetPosition();

			//if (cloth)
			//{
			//	UpdateCloth(model);
			//	D3DXMatrixIdentity(&pos);
			//}

			model.Paint(pos);
		}

		public void Rotate(MyVector value)
		{
			if (actor != null)
			{
				var pos = actor.GlobalPosePosition;
				var nxm = actor.GlobalPose;
				nxm *= Matrix4x4.CreateRotationX(value.X, pos);
				nxm *= Matrix4x4.CreateRotationY(value.Y, pos);
				nxm *= Matrix4x4.CreateRotationZ(value.Z, pos);
				actor.GlobalPose = nxm;
			}
		}

		public IJoint WheelJoint(IActor3D a1, MyVector globalAnchor, MyVector globalAxis)
		{
			throw new NotImplementedException();
		}
	}
}
