using BaseEngine;
using BaseEngine.MyTypes;
using PhysX;
using System;

namespace Logic_PhyX.Net
{
	public class MyJoint : IJoint
	{
		public RevoluteJoint joint;

		public MyJoint(RevoluteJoint joint)
		{
			this.joint = joint;
		}

		public void SetDrive(float maxForce, float velTarget)
		{
			joint.DriveForceLimit = maxForce;
			joint.DriveVelocity = velTarget;
			joint.Flags = RevoluteJointFlag.DriveFreeSpin | RevoluteJointFlag.DriveEnabled;
		}

		public void SetDriveEnable(bool enable)
		{
			if(enable)
				joint.Flags |= RevoluteJointFlag.DriveEnabled;
			else
				joint.Flags &= ~RevoluteJointFlag.DriveEnabled;
		}
	}
}
