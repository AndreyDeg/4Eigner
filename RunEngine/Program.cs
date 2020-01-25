using System;
using System.Collections.Generic;
using System.Threading;
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
			//new Thread(() => RunEngine("5Eigner", "LuaScripts\\test2\\main.lua")).Start();

			RunEngine("4Eigner", "LuaScripts\\test1\\main.lua");
			//RunEngine("4Eigner", "LuaScripts\\test1\\mainSecondCamera.lua");
			//RunEngine("5Eigner", "LuaScripts\\test2\\main.lua");
			//RunEngine("4Eigner", "LuaScripts\\main.lua");
		}

		static void RunEngine(string windowName, string actionFile)
		{
			//var content = new Content();
			//var file	= new FileManager();
			var world = new World();

			//var input = new Input();
			var window = new Window(windowName, windowName);
			var render = new DirectX();

			var action = new MyLua();
			var logic = new Logic();
			//var network	= new Network();

			Func<object, List<MyVertex>> FuncToListMyVertex = action.ToList<MyVertex>;
			action.Register("ToListMyVertex", FuncToListMyVertex);

			Func<float, float, float, float, MyColor> FuncColor = (a, r, g, b) => new MyColor((byte)a, (byte)r, (byte)g, (byte)b);
			action.Register("Color", FuncColor);

			Func<float, float, float, MyColor, float, float, MyVertex> FuncVertex = (x, y, z, color, tu, tv) => new MyVertex(x, y, z, color, tu, tv);
			action.Register("Vertex", FuncVertex);

			Func<float, float, float, MyVector> FuncVector = (x, y, z) => new MyVector(x, y, z);
			action.Register("Vector", FuncVector);

			Func<int, int, int, int, float, float, MyViewport> FuncViewport = (x, y, width, height, minZ, maxZ) => new MyViewport(x, y, width, height, minZ, maxZ);
			action.Register("Viewport", FuncViewport);

			action.Register("Object3D", (Func<Object3D>)(() => new Object3D()));

			action.Register("World", world);
			action.Register("Window", window);
			action.Register("Logic", logic);
			action.Register("Render", render);

			render.Create(window);

			action.DoFile(actionFile);
			//Controller::network->Init();

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
