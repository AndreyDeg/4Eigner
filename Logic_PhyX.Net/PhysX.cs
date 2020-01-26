using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using BaseEngine;
using BaseEngine.MyTypes;
using PhysX;

namespace Logic_PhyX.Net
{
	public class MyPhysX : IPhysic
	{
		public Scene Scene { get; private set; }

		static Physics Physics;
		static Foundation foundation;

		static readonly object locker = new object();

		public MyPhysX()
		{
			lock(locker)
				if (foundation == null)
				{
					ErrorOutput errorOutput = new ErrorOutput();
					foundation = new Foundation(errorOutput);
					var pvd = new PhysX.VisualDebugger.Pvd(foundation);
					Physics = new Physics(foundation, true, pvd);
				}

			Scene = Physics.CreateScene(CreateSceneDesc(foundation));

			Scene.SetVisualizationParameter(VisualizationParameter.Scale, 2.0f);
			Scene.SetVisualizationParameter(VisualizationParameter.CollisionShapes, true);
			Scene.SetVisualizationParameter(VisualizationParameter.JointLocalFrames, true);
			Scene.SetVisualizationParameter(VisualizationParameter.JointLimits, true);
			Scene.SetVisualizationParameter(VisualizationParameter.ActorAxes, true);

			//Scene.SetVisualizationParameter(VisualizationParameter.ClothMesh, true);
			//Scene.SetVisualizationParameter(VisualizationParameter.FluidPosition, true);
			//Scene.SetVisualizationParameter(VisualizationParameter.FluidEmitters, false); // Slows down rendering a bit too much
			//Scene.SetVisualizationParameter(VisualizationParameter.ForceFields, true);
			//Scene.SetVisualizationParameter(VisualizationParameter.SoftBodyMesh, true);

			// Connect to the PhysX Visual Debugger (if the PVD application is running)
			Physics.Pvd.Connect("localhost");
		}

		protected virtual SceneDesc CreateSceneDesc(Foundation foundation)
		{
#if GPU
			var cudaContext = new CudaContextManager(foundation);
#endif

			var sceneDesc = new SceneDesc
			{
				Gravity = new Vector3(0, -9.81f, 0),
#if GPU
				GpuDispatcher = cudaContext.GpuDispatcher,
#endif
				FilterShader = new SampleFilterShader(),
			};

#if GPU
			sceneDesc.Flags |= SceneFlag.EnableGpuDynamics;
			sceneDesc.BroadPhaseType |= BroadPhaseType.Gpu;
#endif

			//_sceneDescCallback?.Invoke(sceneDesc);

			return sceneDesc;
		}

		public class SampleFilterShader : SimulationFilterShader
		{
			public override FilterResult Filter(int attributes0, FilterData filterData0, int attributes1, FilterData filterData1)
			{
				return new FilterResult
				{
					FilterFlag = FilterFlag.Default,
					// Cause PhysX to report any contact of two shapes as a touch and call SimulationEventCallback.OnContact
					PairFlags = PairFlag.ContactDefault | PairFlag.NotifyTouchFound | PairFlag.NotifyTouchLost
				};
			}
		}

		public void Update(float elapsedTime)
		{
			// Update Physics
			this.Scene.Simulate(elapsedTime);
			this.Scene.FetchResults(block: true);
		}

		public IActor3D CreateGroundPlane()
		{
			var groundPlaneMaterial = Physics.CreateMaterial(0.1f, 0.1f, 0.1f);

			var groundPlane = Physics.CreateRigidStatic();
			groundPlane.Name = "Ground Plane";
			groundPlane.GlobalPose = Matrix4x4.CreateFromAxisAngle(new Vector3(0, 0, 1), (float)Math.PI / 2);

			var planeGeom = new PlaneGeometry();

			RigidActorExt.CreateExclusiveShape(groundPlane, planeGeom, groundPlaneMaterial, null);

			Scene.AddActor(groundPlane);

			return new Actor3D(groundPlane);
		}

		public IActor3D CreateBox(float fX, float fY, float fZ, float fSize, float fMass = 10)
		{
			var actor = Physics.CreateRigidDynamic();

			var boxGeom = new BoxGeometry(fSize, fSize, fSize);
			var material = Physics.CreateMaterial(0.7f, 0.7f, 0.1f);
			RigidActorExt.CreateExclusiveShape(actor, boxGeom, material);

			actor.Name = "Box";
			actor.GlobalPose = Matrix4x4.CreateTranslation(fX, fY, fZ);
			actor.SetMassAndUpdateInertia(fMass);

			Scene.AddActor(actor);

			return new Actor3D(actor);
		}

		public IActor3D CreateSphere(float fX, float fY, float fZ, float fR, float fMass = 10)
		{
			var actor = Physics.CreateRigidDynamic();

			var boxGeom = new SphereGeometry(fR);
			var material = Physics.CreateMaterial(0.7f, 0.7f, 0.1f);
			RigidActorExt.CreateExclusiveShape(actor, boxGeom, material);

			actor.Name = "Sphere";
			actor.GlobalPose = Matrix4x4.CreateTranslation(fX, fY, fZ);
			actor.SetMassAndUpdateInertia(fMass);

			Scene.AddActor(actor);

			return new Actor3D(actor);
		}

		public IActor3D CreateConvexMesh(List<MyVector> points, List<int> indices, float fX, float fY, float fZ, float fMass)
		{
			var convexMeshDesc = new ConvexMeshDesc
			{
				Flags = ConvexFlag.ComputeConvex
			};
			convexMeshDesc.SetPositions(points.Select(x => x.ToVector3()).ToArray());
			convexMeshDesc.SetTriangles(indices.ToArray());

			var cooking = Physics.CreateCooking();

			var stream = new MemoryStream();
			var cookResult = cooking.CookConvexMesh(convexMeshDesc, stream);

			stream.Position = 0;

			var convexMesh = Physics.CreateConvexMesh(stream);

			var convexMeshGeom = new ConvexMeshGeometry(convexMesh)
			{
				Scale = new MeshScale(new Vector3(1f, 1f, 1f), Quaternion.Identity)
			};

			var actor = Physics.CreateRigidDynamic();

			var material = Physics.CreateMaterial(0.7f, 0.7f, 0.1f);
			RigidActorExt.CreateExclusiveShape(actor, convexMeshGeom, material);

			actor.GlobalPose = Matrix4x4.CreateTranslation(fX, fY, fZ);
			actor.SetMassAndUpdateInertia(fMass);

			Scene.AddActor(actor);

			return new Actor3D(actor);
		}

		public IActor3D CreateCloth(float iX, float iY, float iZ, float iW, float iH)
		{
			throw new NotImplementedException();
		}

		public IJoint CreateJoint(IActor3D a0, IActor3D a1, MyVector globalAnchor, MyVector globalAxis)
		{
			var revoluteABJoint = Scene.CreateJoint<RevoluteJoint>((a0 as Actor3D).actor, Matrix4x4.Identity, (a1 as Actor3D).actor, Matrix4x4.Identity);
			revoluteABJoint.SetGlobalFrame(globalAnchor.ToVector3(), globalAxis.ToVector3());
			return new MyJoint(revoluteABJoint);
		}
	}
}
