namespace BaseEngine.MyTypes
{
	public struct MyColor
	{
		public byte A, R, G, B;

		public MyColor(byte r, byte g, byte b)
		{
			A = byte.MaxValue;
			R = r;
			G = g;
			B = b;
		}

		public MyColor(byte a, byte r, byte g, byte b)
		{
			A = a;
			R = r;
			G = g;
			B = b;
		}
	}
}
