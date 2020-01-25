using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using BaseEngine;
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

			CreateGroundPlane();
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
			Vector3[] vertices = 
			{
				new Vector3( -100, 0, -100 ),
				new Vector3( -100, 0, 100 ),
				new Vector3( 100, 0, -100 ),
				new Vector3( 100, 0, 100 ),
			};

			int[] indices =
			{
				0, 1, 2,
				1, 3, 2
			};

			var triangleMeshDesc = new TriangleMeshDesc()
			{
				Flags = (MeshFlag)0,
				Triangles = indices,
				Points = vertices
			};

			TriangleMesh triangleMesh;
			using (MemoryStream stream = new MemoryStream())
			{
				var cooking = Physics.CreateCooking();
				var cookResult = cooking.CookTriangleMesh(triangleMeshDesc, stream);

				stream.Position = 0;
				triangleMesh = Physics.CreateTriangleMesh(stream);
			}

			var triangleMeshGeom = new TriangleMeshGeometry(triangleMesh)
			{
				Scale = new MeshScale(new Vector3(0.3f, 0.3f, 0.3f), Quaternion.Identity)
			};

			var rigidActor = Physics.CreateRigidStatic();

			var material = Physics.CreateMaterial(0.7f, 0.7f, 0.1f);
			RigidActorExt.CreateExclusiveShape(rigidActor, triangleMeshGeom, material);

			rigidActor.GlobalPose =
				Matrix4x4.CreateRotationX(-(float)System.Math.PI / 2) *
				Matrix4x4.CreateTranslation(0, 0, 0);

			Scene.AddActor(rigidActor);

			return new Actor3D(rigidActor);
		}

		public IActor3D CreateBox(float fX, float fY, float fZ, float fSize)
		{
			var actor = Physics.CreateRigidDynamic();

			var boxGeom = new BoxGeometry(fSize, fSize, fSize);
			var material = Physics.CreateMaterial(0.7f, 0.7f, 0.1f);
			RigidActorExt.CreateExclusiveShape(actor, boxGeom, material);

			actor.Name = "Box";
			actor.GlobalPose = Matrix4x4.CreateTranslation(fX, fY, fZ);
			actor.SetMassAndUpdateInertia(10);

			Scene.AddActor(actor);

			return new Actor3D(actor);
		}

		public IActor3D CreateSphere(float fX, float fY, float fZ, float fR, float fMass)
		{
			throw new NotImplementedException();
		}

		public IActor3D CreateConcaveMesh(List<BaseEngine.MyTypes.MyVector> points, float fX, float fY, float fZ, float fMass)
		{
			throw new NotImplementedException();
		}

		public IActor3D CreateCloth(float iX, float iY, float iZ, float iW, float iH)
		{
			throw new NotImplementedException();
		}

		public IJoint CreateWheelJoint(IActor3D a0, IActor3D a1, BaseEngine.MyTypes.MyVector globalAnchor, BaseEngine.MyTypes.MyVector globalAxis)
		{
			throw new NotImplementedException();
		}

		public void SetMotor(IJoint joint, float maxForce, float velTarget)
		{
			throw new NotImplementedException();
		}
	}
}
