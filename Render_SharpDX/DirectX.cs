using BaseEngine;
using BaseEngine.MyTypes;
using SharpDX;
using SharpDX.Direct3D9;
using SharpDX.Mathematics.Interop;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Render_SharpDX
{
	public class DirectX : IViewRender
	{
		Device device;

		public DirectX(IViewWindow window)
		{
			//var Adapters = Manager.Adapters;
			//for (int i = 0; i < Adapters.Count; i++)
			//{
			//	var info = Adapters[i].Information;
			//	Console.Write("Adapter {0}: \n  Driver: {1}\n  Description: {2}\n  DeviceName: {3}\n", i, info.DriverName, info.Description, info.DeviceName);
			//}

			//var presPars = new PresentParameters
			//{
			//	Windowed = true,
			//	SwapEffect = SwapEffect.Discard,
			//	BackBufferFormat = Format.A8R8G8B8,
			//	EnableAutoDepthStencil = true,
			//	AutoDepthStencilFormat = Format.D16,
			//};

			//device = new Device(new Direct3D(), 0, DeviceType.Hardware, window.hWnd, CreateFlags.SoftwareVertexProcessing, presPars);
			//device.SetRenderState(RenderState.CullMode, Cull.None);
			//device.SetRenderState(RenderState.ZEnable, true);
			//device.SetRenderState(RenderState.NormalizeNormals, true);
			//device.SetRenderState(RenderState.AlphaBlendEnable, true);
			//device.SetRenderState(RenderState.SourceBlend, Blend.SourceAlpha);
			//device.SetRenderState(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
			//device.SetRenderState(RenderState.DiffuseMaterialSource, ColorSource.Color1);
			//device.SetRenderState(RenderState.ColorVertex, true);
			//device.SetRenderState(RenderState.Lighting, false);

			var FullScreen = false;
			var VerticalSync = true;
			var WindowWidth = window.iWidth;
			var WindowHeight = window.iHeight;

			var D3D = new Direct3D();
			//Получаем текущий режим экрана
			DisplayMode mode = D3D.GetAdapterDisplayMode(0);
			//Инициализируем параметры
			var d3dpp = new PresentParameters();
			d3dpp.AutoDepthStencilFormat = Format.D16;
			d3dpp.BackBufferCount = 1;
			d3dpp.BackBufferFormat = mode.Format;
			d3dpp.BackBufferHeight = WindowHeight;
			d3dpp.BackBufferWidth = WindowWidth;
			//Куда рисовать
			d3dpp.DeviceWindowHandle = window.hWnd;
			//Контроль вертикальной развертки
			if (VerticalSync)
				d3dpp.PresentationInterval = PresentInterval.Default;
			else
				d3dpp.PresentationInterval = PresentInterval.Immediate;
			d3dpp.SwapEffect = SwapEffect.Discard;
			d3dpp.Windowed = !FullScreen;
			d3dpp.EnableAutoDepthStencil = true;
			if (!FullScreen && VerticalSync)
				d3dpp.SwapEffect = SwapEffect.Copy;
			//Создаем девайс
			device = new Device(D3D, 0, DeviceType.Hardware, window.hWnd, CreateFlags.SoftwareVertexProcessing, d3dpp);
			if (device == null)
				throw new NullReferenceException("Не удалось инициализировать устройство!");

			device.SetRenderState(RenderState.CullMode, Cull.None);
			device.SetRenderState(RenderState.ZEnable, true);
			device.SetRenderState(RenderState.NormalizeNormals, true);
			device.SetRenderState(RenderState.AlphaBlendEnable, true);
			device.SetRenderState(RenderState.SourceBlend, Blend.SourceAlpha);
			device.SetRenderState(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
			device.SetRenderState(RenderState.DiffuseMaterialSource, ColorSource.Color1);
			device.SetRenderState(RenderState.ColorVertex, true);
			device.SetRenderState(RenderState.Lighting, false);
		}

		// Our custom vertex
		[StructLayout(LayoutKind.Sequential)]
		public struct PositionColoredTextured
		{
			public Vector3 position;
			public RawColorBGRA color;
			public float tu, tv;

			public PositionColoredTextured(MyVertex vertex)
			{
				this.position = vertex.position.ToVector3();
				this.color = vertex.color.ToRawColorBGRA();
				tu = vertex.tu;
				tv = vertex.tv;
			}

			public static int SizeBytes
			{
				get { return Marshal.SizeOf(typeof(PositionColoredTextured)); }
			}

			public static VertexFormat Format
			{
				get { return VertexFormat.Position | VertexFormat.Diffuse | VertexFormat.Texture1; }
			}
		}

		public VertexBuffer CreateVertex(int l)
		{
			return new VertexBuffer(device, l * PositionColoredTextured.SizeBytes, Usage.None, PositionColoredTextured.Format, Pool.Default);
		}

		public void DrawVertex(MyMatrix position, int l, VertexBuffer streamData, ITexture texture)
		{
			device.SetTransform(TransformState.World, position.ToRawMatrix());
			device.SetTexture(0, texture != null ? (Texture)texture.data : null);
			device.VertexFormat = PositionColoredTextured.Format;

			device.SetStreamSource(0, streamData, 0, PositionColoredTextured.SizeBytes);
			device.DrawPrimitives(PrimitiveType.TriangleList, 0, l / 3);
		}

		public void DrawVertex(MyMatrix position, PositionColoredTextured[] verts, ITexture texture)
		{
			device.SetTransform(TransformState.World, position.ToRawMatrix());
			device.SetTexture(0, texture != null ? (Texture)texture.data : null);
			device.VertexFormat = PositionColoredTextured.Format;

			device.DrawUserPrimitives(PrimitiveType.TriangleList, verts.Length / 3, verts);
		}

		//void DirectX::SetLight(int i, D3DLIGHT9 light)
		//{
		//	g_pd3dDevice->SetLight( i, &light );
		//	g_pd3dDevice->LightEnable( i, TRUE );
		//	g_pd3dDevice->SetRenderState( D3DRS_LIGHTING, TRUE );
		//	g_pd3dDevice->SetRenderState( D3DRS_AMBIENT, 0 );
		//}

		public void OnPaint()
		{
			if (device == null) return;

			foreach (var camera in Cameras)
			{
				device.SetTransform(TransformState.View, camera.View.ToRawMatrix());
				device.SetTransform(TransformState.Projection, camera.Proj.ToRawMatrix());
				device.Viewport = camera.ViewPort.ToRawViewport();

				device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, camera.BackColor.ToRawColorBGRA(), 1.0f, 0);

				//начинаем сцену
				device.BeginScene();

				//Отрисовываем сожержимое камеры
				camera.Paint();

				//заканчиваем сцену
				device.EndScene();
			}

			device.Present();
		}

		//Загрузка информации о текстуре
		//public bool preloadTexture(string sFileName, D3DXIMAGE_INFO &ScrInfo )
		//{
		//	return D3DXGetImageInfoFromFile(sFileName, &ScrInfo );
		//}

		//Загрузка текстуы
		//public bool loadTexture(string sFileName, LPDIRECT3DTEXTURE9 &g_pHDRTexture)
		//{
		//	return D3DXCreateTextureFromFile( g_pd3dDevice, sFileName, &g_pHDRTexture );
		//}

		List<ICamera> Cameras = new List<ICamera>();

		public ICamera NewCamera()
		{
			var camera = new Camera();
			Cameras.Add(camera);
			return camera;
		}

		public IModel3D NewModel3D()
		{
			return new Model3DBuffered { render = this };
			//return new Model3D { render = this };
		}
	}
}
