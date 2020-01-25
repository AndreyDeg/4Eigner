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
			//RunEngine("4Eigner", "LuaScripts\\test2\\main.lua");
			//RunEngine("4Eigner", "LuaScripts\\main.lua");
		}

		static void RunEngine(string windowName, string actionFile)
		{
			var action = new MyLua();

			action.Register("ToListVertex", action.ToList<MyVertex>);

			Func<byte, byte, byte, byte, MyColor> FuncColor = (a, r, g, b) => new MyColor(a, r, g, b);
			action.Register("Color", FuncColor);

			Func<float, float, float, MyColor, float, float, MyVertex> FuncVertex = (x, y, z, color, tu, tv) => new MyVertex(x, y, z, color, tu, tv);
			action.Register("Vertex", FuncVertex);

			Func<float, float, float, MyVector> FuncVector = (x, y, z) => new MyVector(x, y, z);
			action.Register("Vector", FuncVector);

			Func<int, int, int, int, float, float, MyViewport> FuncViewport = (x, y, width, height, minZ, maxZ) => new MyViewport(x, y, width, height, minZ, maxZ);
			action.Register("Viewport", FuncViewport);

			Func<Object3D> FuncObject3D = () => new Object3D();
			action.Register("Object3D", FuncObject3D);

			action.Register("World", new World());
			action.Register("windowName", windowName);

			Func<string, string, Window> FuncWindowWinAPI = (x, y) => new Window(x, y);
			action.Register("WindowWinAPI", FuncWindowWinAPI);

			Func<MyPhysX> FuncMyPhysX = () => new MyPhysX();
			action.Register("PhysX", FuncMyPhysX);

			Func<IViewWindow, DirectX> FuncDirectX = x => new DirectX(x);
			action.Register("DirectX", FuncDirectX);

			action.DoFile(actionFile);
		}
	}
}
