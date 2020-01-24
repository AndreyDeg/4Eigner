using BaseEngine;
using BaseEngine.MyTypes;
using PhysX;
using System;

namespace Logic_PhyX.Net
{
	public class Actor3D : IActor3D
	{
		private RigidActor actor;
		//private Cloth cloth;

		public Actor3D(RigidActor m_actor)
		{
			actor = m_actor;
		}

		public MyMatrix GetPosition()
		{
			//if(cloth)
			//{
			//	NxVec3 v3 = cloth->getPosition(100);
			//	D3DXMatrixTranslation(&matWorld, v3.x, v3.y, v3.z);
			//}

			if (actor != null)
			{
				var pos = actor.GlobalPose;
				return new MyMatrix { M41 = pos.M41, M42 = pos.M42, M43 = pos.M43, M11 = 1, M22 = 1, M33 = 1, M44 = 1 };
			}

			return new MyMatrix { M11 = 1, M22 = 1, M33 = 1, M44 = 1 };
		}

		public void set_Rotate(MyVector value)
		{
			throw new NotImplementedException();
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

		public IJoint WheelJoint(IActor3D a1, MyVector globalAnchor, MyVector globalAxis)
		{
			throw new NotImplementedException();
		}
	}
}
