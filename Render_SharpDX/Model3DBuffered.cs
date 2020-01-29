using BaseEngine;
using BaseEngine.MyTypes;
using SharpDX;
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

        public bool NoLighting, ClearZBuf;

        public void SetTexture(ITexture value)
        {
            texture = value;
        }

        public void SetVertices(List<MyVertex> value)
        {
            var res = new List<DirectX.PositionColoredTextured>();
            for (int i = 0; i < value.Count; i += 3)
            {
                var v1 = value[i].position.ToVector3();
                var v2 = value[i + 1].position.ToVector3();
                var v3 = value[i + 2].position.ToVector3();
                var normal = Vector3.Cross((v2 - v1), (v3 - v1));
                normal.Normalize();
                res.Add(new DirectX.PositionColoredTextured(value[i], normal));
                res.Add(new DirectX.PositionColoredTextured(value[i + 1], normal));
                res.Add(new DirectX.PositionColoredTextured(value[i + 2], normal));
            }

            var verts = res.ToArray();

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
            if (NoLighting)
                render.device.SetRenderState(RenderState.Lighting, false);

            render.DrawVertex(position, iLen, streamData, texture);

            if (NoLighting)
                render.device.SetRenderState(RenderState.Lighting, true);

            if (ClearZBuf)
                render.ClearZBuf();
        }
    }
}
