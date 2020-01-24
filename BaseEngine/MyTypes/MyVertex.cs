namespace BaseEngine.MyTypes
{
    public struct MyVertex
	{
		public MyVector position;
		public MyColor color;
		public float tu, tv;

		public MyVertex(float x, float y, float z, MyColor color, float tu, float tv)
		{
			position = new MyVector(x, y, z);
			this.color = color;
			this.tu = tu;
			this.tv = tv;
		}
	}
}
