namespace BaseEngine
{
	public interface IObject3D
	{
		IActor3D Actor { get; set; }
		IModel3D Model { get; set; }
		void Paint();
	};

	public interface IMap
	{
		IPhysic Physic { get; set; }

		IObject3D GetObject3D(int i);
		void AddObject(IObject3D obj);
		void AddLight(ILight3D obj);

		void Paint(ICamera camera);

		IObject3D AddPicture(string TextureName, float x, float y, float z);
		IObject3D AddSoftPicture(string TextureName, float x, float y, float z);
		void AddSky(string TextureName, int du, int dv);
		void AddGround(string TextureName);
		void AddLight();
	};

	public interface IWorld
	{
		IMap CreateMap();
		IMap GetMap(int iN);
	};
}
