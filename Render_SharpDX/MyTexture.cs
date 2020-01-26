using BaseEngine;
using SharpDX.Direct3D9;
using System;

namespace Render_SharpDX
{
	public class MyTexture : ITexture
	{
		public Texture data;

		public MyTexture(Texture texture)
		{
			data = texture;
		}

		public string FileName => throw new NotImplementedException();

		public float fCoefX()
		{
			throw new NotImplementedException();
		}

		public float fCoefY()
		{
			throw new NotImplementedException();
		}
	}
}
