using BaseEngine;
using System;
using View_WinAPI.WinAPI;

namespace View_WinAPI
{
	public class Window : IViewWindow
	{
		private static Window singleton;

		public IntPtr hWnd { get; private set; }
		public IntPtr hInstance;

		public string lpClassName;
		public string lpWindowName;

		public int iLeft { get; private set; }
		public int iTop { get; private set; }
		public int iWidth { get; private set; }
		public int iHeight { get; private set; }

		public Action OnTimer { get; set; }
		public Action<uint, uint, long> OnMouseMove { get; set; }
		public Action<uint> OnKeyDown { get; set; }
		public Action<uint> OnKeyUp { get; set; }

		private static readonly WndProcDelegate WndProc = delegate(IntPtr hWnd, WM message, IntPtr wParam, IntPtr lParam)
		{
			switch (message)
			{
				case WM.DESTROY:
				{
					singleton.Close();

					return IntPtr.Zero;
				}

				case WM.TIMER:
				{
					if (singleton.OnTimer != null)
						singleton.OnTimer();

					return IntPtr.Zero;
				}

				case WM.MOUSEMOVE:
				{
					uint x = (uint)lParam.ToInt32() & 0xffff;
					uint y = ((uint)lParam.ToInt32() >> 16) & 0xffff;
					long keys = wParam.ToInt64();

					if (singleton.OnMouseMove != null)
						singleton.OnMouseMove(x, y, keys);

					return IntPtr.Zero;
				}

				case WM.KEYDOWN:
				{
					uint keyId = (uint) wParam.ToInt32();

					if (singleton.OnKeyDown != null)
						singleton.OnKeyDown(keyId);

					return IntPtr.Zero;
				}

				case WM.KEYUP:
				{
					uint keyId = (uint) wParam.ToInt32();

					if (singleton.OnKeyUp != null)
						singleton.OnKeyUp(keyId);

					return IntPtr.Zero;
				}
			}

			return Win32.DefWindowProc(hWnd, message, wParam, lParam);
		};

		public Window(string ClassName, string WindowName)
		{
			if (singleton != null)
				throw new Exception("Window.Window: пока только одно окно");

			singleton = this;

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
				lpfnWndProc = WndProc,
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

		public void Run(uint iTimeUpdate)
		{
			Win32.SetTimer(hWnd, 0, iTimeUpdate, null);
			Win32.ShowWindow(hWnd, SW.MAXIMIZE);
			Win32.UpdateWindow(hWnd);

			MSG msg;
			while (Win32.GetMessage(out msg, IntPtr.Zero, 0, 0) != 0)
			{
				Win32.TranslateMessage(ref msg);
				Win32.DispatchMessage(ref msg);
			}

			Win32.KillTimer(hWnd, 0);
		}

		public void Close()
		{
			Win32.PostQuitMessage(0);
		}

		~Window()
		{
			Win32.UnregisterClass(lpClassName, hInstance);
		}
	}
}
