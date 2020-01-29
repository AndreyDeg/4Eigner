using BaseEngine.MyTypes;

namespace BaseEngine.ModelWorld
{
	public class Sky : ISky
	{
		public IModel3D Model { get; set; }

		public void Paint(MyVector cameraPos)
		{
			if (Model != null)
				Model.Paint(new MyMatrix {
					M11 = 1,				M41 = cameraPos.X,
							M22 = 1,		M42 = cameraPos.Y,
									M33 = 1,M43 = cameraPos.Z,
											M44 = 1,
				});
		}
	}
}
