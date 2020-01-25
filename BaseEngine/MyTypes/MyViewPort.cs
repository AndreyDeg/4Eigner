namespace BaseEngine.MyTypes
{
	public struct MyViewport
	{
		public int X;
		public int Y;
		public int Width;
		public int Height;
		public float MinZ;
		public float MaxZ;

		public MyViewport(int x, int y, int width, int height, float minZ, float maxZ)
		{
			X = x;
			Y = y;
			Width = width;
			Height = height;
			MinZ = minZ;
			MaxZ = maxZ;
		}
	}
}
