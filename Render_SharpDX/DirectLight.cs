using BaseEngine;
using BaseEngine.MyTypes;
using SharpDX.Direct3D9;

namespace Render_SharpDX
{
	public class DirectLight : ILight3D
	{
        public MyColor Diffuse;
        public MyColor Specular;
        public MyColor Ambient;
        public MyVector Position;
        public MyVector Direction;
        public float Range;
        public float Falloff;
        public float Attenuation0;
        public float Attenuation1;
        public float Attenuation2;
        public float Theta;
        public float Phi;

        public DirectX render { get; set; }

		public DirectLight()
		{

		}

		public void Setup()
		{
            var data = new Light
            {
                Type = LightType.Directional,
                Diffuse = Diffuse.ToRawColor4(),
                Specular = Specular.ToRawColor4(),
                Ambient = Ambient.ToRawColor4(),
                Position = Position.ToVector3(),
                Direction = Direction.ToVector3(),
                Range = Range,
                Falloff = Falloff,
                Attenuation0 = Attenuation0,
                Attenuation1 = Attenuation1,
                Attenuation2 = Attenuation2,
                Theta = Theta,
                Phi = Phi,
            };

            render.SetLight(data);
		}
	}
}
