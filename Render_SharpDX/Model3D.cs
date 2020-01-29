using BaseEngine;
using BaseEngine.MyTypes;
using System.Collections.Generic;
using System.Linq;

namespace Render_SharpDX
{
    public class Model3D : IModel3D
    {
        public MyVector pos { get; set; }
        public MyVector scale { get; set; }
        public MyVector angle { get; set; }

        public DirectX render { get; set; }

        public ITexture texture;

        private DirectX.PositionColoredTextured[] verts;

        public bool ClearZBuf;

        public void SetTexture(ITexture value)
        {
            texture = value;
        }

        public void SetVertices(List<MyVertex> value)
        {
            verts = value.Select(x => new DirectX.PositionColoredTextured(x)).ToArray();
        }

        public void Paint(MyMatrix position)
        {
            render.DrawVertex(position, verts, texture);

            if (ClearZBuf)
                render.ClearZBuf();
        }
    }
}
