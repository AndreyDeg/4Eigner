using BaseEngine.MyTypes;

namespace BaseEngine.ModelWorld
{
	public class Object3D : IObject3D
	{
		public IActor3D Actor { get; set; }
		public IModel3D Model { get; set; }

		public void Paint()
		{
			if (Actor != null && Model != null)
				Actor.Update(Model);
			else if (Model != null)
				Model.Paint(new MyMatrix {M11 = 1, M22 = 1, M33 = 1, M44 = 1});
		}
	}
}
