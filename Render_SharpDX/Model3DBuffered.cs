using BaseEngine;
using BaseEngine.MyTypes;
using SharpDX.Direct3D9;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Render_SharpDX
{
    public class Model3DBuffered : IModel3D
    {
        public MyVector pos { get; set; }
        public MyVector scale { get; set; }
        public MyVector angle { get; set; }

        public DirectX render { get; set; }

        public int iLen;
        public VertexBuffer streamData;
        public ITexture texture;

        public bool ClearZBuf;

        public void SetTexture(ITexture value)
        {
            texture = value;
        }

        public void SetVertices(List<MyVertex> value)
        {
            var verts = value.Select(x => new DirectX.PositionColoredTextured(x)).ToArray();

            iLen = verts.Length;

            if (streamData == null)
                streamData = render.CreateVertex(iLen);

            if (iLen <= 0)
                return;

            int size = Marshal.SizeOf(typeof(DirectX.PositionColoredTextured)) * iLen;
            var pVertices = streamData.Lock(0, size, 0);
            pVertices.WriteRange(verts);
            streamData.Unlock();
        }

        public void Paint(MyMatrix position)
        {
            render.DrawVertex(position, iLen, streamData, texture);

            if (ClearZBuf)
                render.ClearZBuf();
        }
    }
}
