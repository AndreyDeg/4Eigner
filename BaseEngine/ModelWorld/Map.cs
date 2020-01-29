using System;
using System.Collections.Generic;

namespace BaseEngine.ModelWorld
{
	public class Map : IMap
	{
		private ILight3D light;
		private ISky sky;
		readonly List<IObject3D> objects = new List<IObject3D>();
		public IPhysic Physic { get; set; }

		public IObject3D GetObject3D(int i)
		{
			return i >= 0 && i < objects.Count ? objects[i] : null;
		}

		public void AddObject(IObject3D obj)
		{
			objects.Add(obj);
		}

		public void AddLight(ILight3D obj)
		{
			light = obj;
		}

		public void Paint(ICamera camera)
		{
			if (sky != null)
				sky.Paint(camera.pos);

			if (light != null)
				light.Setup();

			foreach (var obj in objects)
				obj.Paint();
		}

		public IObject3D AddPicture(string TextureName, float x, float y, float z)
		{
			/*var g_quadVertices = new List<MyVertex>
			{
				new MyVertex{ X = -1.0f, Y = 1.0f, Z = 0.0f, color =  0xFFFFFFFF, tu = 0.0f,tv = 0.0f},
				new MyVertex{ X =  1.0f, Y = 1.0f, Z = 0.0f, color =  0xFFFFFFFF, tu = 1.0f,tv = 0.0f},
				new MyVertex{ X = -1.0f, Y = -1.0f, Z = 0.0f, color =  0xFFFFFFFF, tu = 0.0f,tv = 1.0f },

				new MyVertex{ X =  1.0f, Y = -1.0f, Z = 0.0f, color =  0xFFFFFFFF, tu = 1.0f,tv = 1.0f },
				new MyVertex{ X = -1.0f, Y = -1.0f, Z = 0.0f, color =  0xFFFFFFFF, tu = 0.0f,tv = 1.0f },
				new MyVertex{ X =  1.0f, Y = 1.0f, Z = 0.0f, color = 0xFFFFFFFF, tu = 1.0f, tv = 0.0f }
			};*/

			//ITexture texture = content.LoadTexture(TextureName);

			//float coef_x = texture.fCoefX();
			//float coef_y = 1;

			//for( int i=0; i<6; i++)
			//{
			//	g_quadVertices[i].position.x *= coef_x;
			//	g_quadVertices[i].position.y *= coef_y;
			//}

			IObject3D result = new Object3D(
			//	physic.CreateBox(x, y, z, 1.0f),
			//	render.NewModel3D(g_quadVertices, 2*3, texture)
			);

			AddObject(result);
			return result;
		}

		public void AddSky(ISky sky)
		{
			this.sky = sky;
		}

		public void AddLight()
		{
			throw new NotImplementedException();
		}
	}
}
