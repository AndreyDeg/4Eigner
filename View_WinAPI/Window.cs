using BaseEngine;
using System;
using System.Collections.Generic;
using View_WinAPI.WinAPI;

namespace View_WinAPI
{
	public class Window : IViewWindow
	{
		public IntPtr hWnd { get; private set; }
		public IntPtr hInstance;

		public string lpClassName;
		public string lpWindowName;

		public int iLeft { get; private set; }
		public int iTop { get; private set; }
		public int iWidth { get; private set; }
		public int iHeight { get; private set; }

		public Action<uint, uint, long> OnMouseMove { get; set; }
		public Action<uint> OnKeyDown { get; set; }
		public Action<uint> OnKeyUp { get; set; }

		readonly WndProcDelegate WndProc;

		private IntPtr WndProcFunc(IntPtr hWnd, WM message, IntPtr wParam, IntPtr lParam)
		{
			switch (message)
			{
				case WM.DESTROY:
				{
					Win32.PostQuitMessage(0);

					return IntPtr.Zero;
				}

				case WM.TIMER:
				{
					Timers[(uint)wParam]?.Invoke();
					return IntPtr.Zero;
				}

				case WM.MOUSEMOVE:
				{
					uint x = (uint)lParam.ToInt32() & 0xffff;
					uint y = ((uint)lParam.ToInt32() >> 16) & 0xffff;
					long keys = wParam.ToInt64();

					if (OnMouseMove != null)
						OnMouseMove(x, y, keys);

					return IntPtr.Zero;
				}

				case WM.KEYDOWN:
				{
					uint keyId = (uint) wParam.ToInt32();

					if (OnKeyDown != null)
						OnKeyDown(keyId);

					return IntPtr.Zero;
				}

				case WM.KEYUP:
				{
					uint keyId = (uint) wParam.ToInt32();

					if (OnKeyUp != null)
						OnKeyUp(keyId);

					return IntPtr.Zero;
				}
			}

			return Win32.DefWindowProc(hWnd, message, wParam, lParam);
		}

		public Window(string ClassName, string WindowName)
		{
			hWnd = IntPtr.Zero;
			hInstance = IntPtr.Zero;
			lpClassName = ClassName;
			lpWindowName = WindowName;

			iLeft = 0;
			iTop = 0;
			iWidth = Win32.GetSystemMetrics(SM.CXSCREEN);
			iHeight = Win32.GetSystemMetrics(SM.CYSCREEN);

			// Register the window class
			var wndclass = new WNDCLASS
			{
				style = CS.VREDRAW | CS.HREDRAW,
				lpfnWndProc = WndProc = WndProcFunc,
				cbClsExtra = 0,
				cbWndExtra = 0,
				hInstance = hInstance,
				hIcon = IntPtr.Zero,
				hCursor = Win32.LoadCursor(hInstance, IDC.ARROW),
				hbrBackground = IntPtr.Zero,
				lpszMenuName = null,
				lpszClassName = lpClassName
			};

			var regResult = Win32.RegisterClass(ref wndclass);
			if (regResult == 0)
				throw new Exception("Window.Window: regResult == 0");

			hWnd = Win32.CreateWindowEx(0,
				new IntPtr(regResult),
				lpWindowName,
				WS.POPUP | WS.SYSMENU,
				iLeft, iTop, iWidth, iHeight,
				IntPtr.Zero,
				IntPtr.Zero,
				hInstance,
				IntPtr.Zero 
			);

			if (hWnd == IntPtr.Zero)
				throw new Exception("Window.Window: hWnd is null");
		}

		//Таймеры <nIDEvent, uElapse>
		Dictionary<uint, Action> Timers = new Dictionary<uint, Action>();
		uint TimerMaxId;

		public void CreateTimer(uint uElapse, Action<uint> func)
		{
			uint nIDEvent = TimerMaxId++;
			Win32.SetTimer(hWnd, nIDEvent, uElapse, null);
			Timers[nIDEvent] = () => func(uElapse);
		}

		public void Run()
		{
			Win32.ShowWindow(hWnd, SW.MAXIMIZE);
			Win32.UpdateWindow(hWnd);

			while (Win32.GetMessage(out MSG msg, IntPtr.Zero, 0, 0) != 0)
			{
				Win32.TranslateMessage(ref msg);
				Win32.DispatchMessage(ref msg);
			}

			foreach (var timer in Timers)
				Win32.KillTimer(hWnd, timer.Key);
		}

		public void Close()
		{
			Win32.DestroyWindow(hWnd);
		}

		~Window()
		{
			Win32.UnregisterClass(lpClassName, hInstance);
		}
	}
}
