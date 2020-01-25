using System.Collections.Generic;
using BaseEngine.MyTypes;

namespace BaseEngine
{
	public interface IJoint
	{
	};

	public interface IActor3D
	{
		MyMatrix GetPosition();
		void Update(IModel3D model);
		IJoint WheelJoint(IActor3D a1, MyVector globalAnchor, MyVector globalAxis);
	};

	public interface IPhysic
	{
		void Update(float elapsedTime);
		IActor3D CreateGroundPlane();
		IActor3D CreateBox(float fX, float fY, float fZ, float fSize, float fMass);
		IActor3D CreateSphere(float fX, float fY, float fZ, float fR, float fMass);
		IActor3D CreateConcaveMesh(List<MyVector> points, float fX, float fY, float fZ, float fMass);
		IActor3D CreateCloth(float iX, float iY, float iZ, float iW, float iH);
		IJoint CreateWheelJoint(IActor3D a0, IActor3D a1, MyVector globalAnchor, MyVector globalAxis);
		void SetMotor(IJoint joint, float maxForce, float velTarget);
	};
}
