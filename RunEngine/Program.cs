using System;
using System.Collections.Generic;
using Action_NLua;
using BaseEngine;
using BaseEngine.ModelWorld;
using BaseEngine.MyTypes;
using Logic_PhyX.Net;
using Render_SharpDX;
using View_WinAPI;

namespace RunEngine
{
	class Program
	{
		static void Main(string[] args)
		{
			//var content = new Content();
			//var file	= new FileManager();
			var world = new World();

			//var input = new Input();
			var window = new Window("4Eigner", "4Eigner");
			var render = new DirectX();

			var action = new MyLua();
			var logic = new Logic();
			//var network	= new Network();

			Func<object, List<MyVertex>> FuncToListMyVertex = action.ToList<MyVertex>;
			action.Register("ToListMyVertex", FuncToListMyVertex.Target, FuncToListMyVertex.Method);

			Func<float, float, float, float, MyColor> FuncColor = (a, r, g, b) => new MyColor((byte)a, (byte)r, (byte)g, (byte)b);
			action.Register("Color", FuncColor.Target, FuncColor.Method);

			Func<float, float, float, MyColor, float, float, MyVertex> FuncVertex = (x, y, z, color, tu, tv) => new MyVertex(x, y, z, color, tu, tv);
			action.Register("MyVertex", FuncVertex.Target, FuncVertex.Method);

			Func<IModel3D> FuncModel3D = render.NewModel3D;
			action.Register("Model3D", FuncModel3D.Target, FuncModel3D.Method);

			Func<IObject3D> FuncObject3D = () => new Object3D();
			action.Register("Object3D", FuncObject3D.Target, FuncObject3D.Method);

			Func<IMap> FuncMap = () => {
				var map = world.CreateMap();
				map.Physic = logic.CreatePhysic();
				return map;
			};
			action.Register("Map", FuncMap.Target, FuncMap.Method);

			Func<ICamera> FuncCamera = render.GetCamera;
			action.Register("Camera3D", FuncCamera.Target, FuncCamera.Method);

			render.Create(window);
			var camera = render.NewCamera();

			camera.ViewPort = new MyViewport
			{
				X = 0,
				Y = 0,
				Width = window.iWidth,
				Height = window.iHeight,
				MinZ = 0,
				MaxZ = 1
			};

			render.ActiveCamera = camera;
			action.DoFile("LuaScripts\\test1\\main.lua");
			camera.Map = world.GetMap(0);
			//Controller::network->Init();

			window.OnKeyDown += delegate(uint keyId)
			{
				if (keyId == 27)
					window.Close();
			};

			window.OnMouseMove += delegate(uint x, uint y, long keys)
			{
				camera.angle = new MyVector
				{
					X = ((float)y / window.iHeight - 0.5f) * (float)Math.PI,
					Y = ((float)-x / window.iWidth - 0.5f) * (float)Math.PI*2
				};
			};

			window.OnTimer += () =>
			{
				world.UpdateMaps();
				action.OnTimer();
				render.OnPaint();
			};

			//Model::content->Run();
			window.Run(12);
		}
	}
}
