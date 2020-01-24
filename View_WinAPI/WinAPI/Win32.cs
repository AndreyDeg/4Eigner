using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace View_WinAPI.WinAPI
{
    public static class Win32
	{
		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(SM nIndex);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr CreateWindowEx(
		   uint dwExStyle,
		   IntPtr lpClassName,
		   string lpWindowName,
		   WS dwStyle,
		   int x,
		   int y,
		   int nWidth,
		   int nHeight,
		   IntPtr hWndParent,
		   IntPtr hMenu,
		   IntPtr hInstance,
		   IntPtr lpParam);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow(IntPtr hWnd, SW nCmdShow);

		[DllImport("user32.dll")]
		public static extern ushort RegisterClass([In] ref WNDCLASS lpWndClass);

		[DllImport("user32.dll")]
		public static extern ushort UnregisterClass(string lpszClassName, IntPtr hInstance);

		[DllImport("user32.dll")]
		public static extern bool ValidateRect(IntPtr hwnd, ref Rectangle rect);

		[DllImport("user32.dll")]
		public static extern void PostQuitMessage(int nExitCode);

		[DllImport("user32.dll")]
		public static extern IntPtr DefWindowProc(IntPtr hWnd, WM uMsg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr LoadCursor(IntPtr hInstance, IDC lpCursorName);

		[DllImport("user32.dll")]
		public static extern bool UpdateWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern sbyte GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

		[DllImport("user32.dll")]
		public static extern bool TranslateMessage([In] ref MSG lpMsg);

		[DllImport("user32.dll")]
		public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

		public delegate void TimerProc(IntPtr hWnd, uint msg, uint wParam, double lParam);

		[DllImport("user32.dll")]
		public static extern uint SetTimer(IntPtr hWnd, uint nIDEvent, uint uElapse, TimerProc lpTimerFunc);

		[DllImport("user32.dll")]
		public static extern bool KillTimer(IntPtr hWnd, uint nIDEvent);
	}

		//[DllImport("user32.dll")]
		//public static extern IntPtr BeginPaint(IntPtr hwnd, out PAINTSTRUCT lpPaint);

		//[DllImport("user32.dll")]
		//public static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

		//[DllImport("user32.dll")]
		//public static extern bool EndPaint(IntPtr hWnd, [In] ref PAINTSTRUCT lpPaint);

		//[DllImport("user32.dll")]
		//public static extern IntPtr LoadIcon(IntPtr hInst, IntPtr iconName);

		//[DllImport("User32.dll", SetLastError = true)]
		//public static extern int MessageBox(int hWnd, String text, String caption, uint type);

	//	public static class Win32
	//	{
	//		#region DllImport - User32

	//		#region Virtual Keys, Standard Set
	//		/*
	//			 * Virtual Keys, Standard Set
	//			 */
	//		public const int VK_LBUTTON = 0x01;
	//		public const int VK_RBUTTON = 0x02;
	//		public const int VK_CANCEL = 0x03;
	//		public const int VK_MBUTTON = 0x04;    /* NOT 
	//contiguous with L & RBUTTON */

	//		public const int VK_XBUTTON1 = 0x05; /* NOT contiguous 
	//with L & RBUTTON */
	//		public const int VK_XBUTTON2 = 0x06; /* NOT contiguous 
	//with L & RBUTTON */

	//		/*
	//	 * 0x07 : unassigned
	//	 */

	//		public const int VK_BACK = 0x08;
	//		public const int VK_TAB = 0x09;

	//		/*
	//	 * 0x0A - 0x0B : reserved
	//	 */

	//		public const int VK_CLEAR = 0x0C;
	//		public const int VK_RETURN = 0x0D;

	//		public const int VK_SHIFT = 0x10;
	//		public const int VK_CONTROL = 0x11;
	//		public const int VK_MENU = 0x12;
	//		public const int VK_PAUSE = 0x13;
	//		public const int VK_CAPITAL = 0x14;

	//		public const int VK_KANA = 0x15;
	//		public const int VK_HANGEUL = 0x15; /* old name - 
	//should be here for compatibility */
	//		public const int VK_HANGUL = 0x15;
	//		public const int VK_JUNJA = 0x17;
	//		public const int VK_FINAL = 0x18;
	//		public const int VK_HANJA = 0x19;
	//		public const int VK_KANJI = 0x19;

	//		public const int VK_ESCAPE = 0x1B;

	//		public const int VK_CONVERT = 0x1C;
	//		public const int VK_NONCONVERT = 0x1D;
	//		public const int VK_ACCEPT = 0x1E;
	//		public const int VK_MODECHANGE = 0x1F;

	//		public const int VK_SPACE = 0x20;
	//		public const int VK_PRIOR = 0x21;
	//		public const int VK_NEXT = 0x22;
	//		public const int VK_END = 0x23;
	//		public const int VK_HOME = 0x24;
	//		public const int VK_LEFT = 0x25;
	//		public const int VK_UP = 0x26;
	//		public const int VK_RIGHT = 0x27;
	//		public const int VK_DOWN = 0x28;
	//		public const int VK_SELECT = 0x29;
	//		public const int VK_PRINT = 0x2A;
	//		public const int VK_EXECUTE = 0x2B;
	//		public const int VK_SNAPSHOT = 0x2C;
	//		public const int VK_INSERT = 0x2D;
	//		public const int VK_DELETE = 0x2E;
	//		public const int VK_HELP = 0x2F;

	//		/*
	//	 * VK_0 - VK_9 are the same as ASCII '0' - '9' (0x30 - 0x39)
	//	 * 0x40 : unassigned
	//	 * VK_A - VK_Z are the same as ASCII 'A' - 'Z' (0x41 - 0x5A)
	//	 */

	//		public const int VK_LWIN = 0x5B;
	//		public const int VK_RWIN = 0x5C;
	//		public const int VK_APPS = 0x5D;

	//		/*
	//	 * 0x5E : reserved
	//	 */

	//		public const int VK_SLEEP = 0x5F;

	//		public const int VK_NUMPAD0 = 0x60;
	//		public const int VK_NUMPAD1 = 0x61;
	//		public const int VK_NUMPAD2 = 0x62;
	//		public const int VK_NUMPAD3 = 0x63;
	//		public const int VK_NUMPAD4 = 0x64;
	//		public const int VK_NUMPAD5 = 0x65;
	//		public const int VK_NUMPAD6 = 0x66;
	//		public const int VK_NUMPAD7 = 0x67;
	//		public const int VK_NUMPAD8 = 0x68;
	//		public const int VK_NUMPAD9 = 0x69;
	//		public const int VK_MULTIPLY = 0x6A;
	//		public const int VK_ADD = 0x6B;
	//		public const int VK_SEPARATOR = 0x6C;
	//		public const int VK_SUBTRACT = 0x6D;
	//		public const int VK_DECIMAL = 0x6E;
	//		public const int VK_DIVIDE = 0x6F;
	//		public const int VK_F1 = 0x70;
	//		public const int VK_F2 = 0x71;
	//		public const int VK_F3 = 0x72;
	//		public const int VK_F4 = 0x73;
	//		public const int VK_F5 = 0x74;
	//		public const int VK_F6 = 0x75;
	//		public const int VK_F7 = 0x76;
	//		public const int VK_F8 = 0x77;
	//		public const int VK_F9 = 0x78;
	//		public const int VK_F10 = 0x79;
	//		public const int VK_F11 = 0x7A;
	//		public const int VK_F12 = 0x7B;
	//		public const int VK_F13 = 0x7C;
	//		public const int VK_F14 = 0x7D;
	//		public const int VK_F15 = 0x7E;
	//		public const int VK_F16 = 0x7F;
	//		public const int VK_F17 = 0x80;
	//		public const int VK_F18 = 0x81;
	//		public const int VK_F19 = 0x82;
	//		public const int VK_F20 = 0x83;
	//		public const int VK_F21 = 0x84;
	//		public const int VK_F22 = 0x85;
	//		public const int VK_F23 = 0x86;
	//		public const int VK_F24 = 0x87;

	//		/*
	//	 * 0x88 - 0x8F : unassigned
	//	 */

	//		public const int VK_NUMLOCK = 0x90;
	//		public const int VK_SCROLL = 0x91;

	//		/*
	//	 * NEC PC-9800 kbd definitions
	//	 */
	//		public const int VK_OEM_NEC_EQUAL = 0x92; // '=' key on numpad

	//		/*
	//	 * Fujitsu/OASYS kbd definitions
	//	 */
	//		public const int VK_OEM_FJ_JISHO = 0x92; // 'Dictionary' key
	//		public const int VK_OEM_FJ_MASSHOU = 0x93; // 'Unregister word' key
	//		public const int VK_OEM_FJ_TOUROKU = 0x94; // 'Register word' key
	//		public const int VK_OEM_FJ_LOYA = 0x95; // 'Left OYAYUBI' key
	//		public const int VK_OEM_FJ_ROYA = 0x96; // 'Right OYAYUBI' key

	//		/*
	//	 * 0x97 - 0x9F : unassigned
	//	 */

	//		/*
	//	 * VK_L* & VK_R* - left and right Alt, Ctrl and Shift virtual keys.
	//	 * Used only as parameters to GetAsyncKeyState() and GetKeyState().
	//	 * No other API or message will distinguish left 
	//and right keys in this way.
	//	 */
	//		public const int VK_LSHIFT = 0xA0;
	//		public const int VK_RSHIFT = 0xA1;
	//		public const int VK_LCONTROL = 0xA2;
	//		public const int VK_RCONTROL = 0xA3;
	//		public const int VK_LMENU = 0xA4;
	//		public const int VK_RMENU = 0xA5;
	//		#endregion

	//		//public static bool IsRemoteSession()
	//		//{
	//		//	return GetSystemMetrics(SM_REMOTESESSION) != 0;
	//		//}


	//		/*
	//	[DllImport("user32.dll")]
	//	public static extern uint LockWindowUpdate(IntPtr hWnd);

	//	public static uint LockWindowUpdate(Control ctrl)
	//	{
	//		if (ctrl == null)
	//		{
	//			return LockWindowUpdate(IntPtr.Zero);
	//		}
	//		else
	//			return LockWindowUpdate(ctrl.Handle);
	//	}
	//	*/
	//		[DllImport("user32.dll")]
	//		public static extern uint PeekMessage(ref MSG lpMsg,
	//			IntPtr hWnd,
	//			uint wMsgFilterMin,
	//			uint wMsgFilterMax,
	//			uint wRemoveMsg
	//			);

	//		[DllImport("user32.dll")]
	//		public static extern IntPtr DispatchMessage(ref MSG lpmsg);

	//		[DllImport("user32.dll")]
	//		public static extern Int16 GetAsyncKeyState(
	//			int vKey);


	//		[DllImport("user32.dll")]
	//		public static extern int SetScrollPos(
	//			IntPtr hWnd,
	//			int nBar,
	//			int nPos,
	//			int bRedraw);

	//		[DllImport("user32.dll")]
	//		public static extern int GetScrollPos(
	//			IntPtr hWnd,
	//			int nBar);

	//		[DllImport("user32.dll")]
	//		public static extern int SetScrollRange(
	//			IntPtr hWnd,
	//			int nBar,
	//			int nMinPos,
	//			int nMaxPos,
	//			int bRedraw);

	//		[DllImport("user32.dll")]
	//		public static extern int GetScrollRange(
	//			IntPtr hWnd,
	//			int nBar,
	//			ref int lpMinPos,
	//			ref int lpMaxPos);



	//		[DllImport("user32.dll")]
	//		public static extern uint SetWindowLong(
	//			IntPtr hWnd,
	//			int nIndex,
	//			uint dwNewLong
	//			);

	//		[DllImport("user32.dll")]
	//		public static extern IntPtr FindWindow(
	//			string lpClassName,
	//			string lpWindowName
	//			);

	//		[DllImport("user32.dll")]
	//		public static extern IntPtr FindWindowEx(
	//			IntPtr hwndParent,
	//			IntPtr hwndChildAfter,
	//			string lpszClass,
	//			string lpszWindow
	//			);

	//		[DllImport("user32.dll")]
	//		public static extern uint ShowWindow(
	//			IntPtr hWnd,
	//			int nCmdShow
	//			);

	//		[DllImport("user32.dll")]
	//		public static extern int PostMessage(
	//			IntPtr hWnd,
	//			uint Msg,
	//			int wParam,
	//			int lParam
	//			);
	//		[DllImport("user32.dll")]
	//		public static extern int SendMessage(
	//			IntPtr hWnd,
	//			uint Msg,
	//			int wParam,
	//			int lParam
	//			);


	//		[DllImport("user32.dll")]
	//		public static extern uint GetWindowLong(
	//			IntPtr hWnd,
	//			int nIndex);

	//		[DllImport("user32.dll")]
	//		public static extern uint SetForegroundWindow(
	//			IntPtr hWnd);

	//		[DllImport("user32.dll")]
	//		public static extern IntPtr SetActiveWindow(
	//			IntPtr hWnd);

	//		[DllImport("user32.dll")]
	//		public static extern IntPtr GetParent(
	//			IntPtr hWnd);


	//		[DllImport("user32.dll")]
	//		public static extern IntPtr GetActiveWindow();

	//		[DllImport("user32.dll")]
	//		public static extern IntPtr GetForegroundWindow();


	//		[DllImport("user32.dll")]
	//		public static extern int BringWindowToTop(
	//			IntPtr hWnd);

	//		[DllImport("user32.dll")]
	//		public static extern void SwitchToThisWindow(
	//			IntPtr hWnd, int fl);




	//		[DllImport("user32.dll")]
	//		public static extern IntPtr SetFocus(
	//			IntPtr hWnd);

	//		[DllImport("user32.dll")]
	//		public static extern uint SetWindowText(
	//			IntPtr hWnd,
	//			string String);

	//		[DllImport("user32.dll")]
	//		public static extern IntPtr GetDC(IntPtr handle);

	//		[DllImport("user32.dll")]
	//		public static extern IntPtr GetWindowDC(IntPtr handle);

	//		[DllImport("user32.dll")]
	//		public static extern IntPtr ReleaseDC(IntPtr handle, IntPtr hDC);

	//		[DllImport("Gdi32.dll", CharSet = CharSet.Auto)]
	//		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

	//		[DllImport("user32.dll")]
	//		public static extern int GetClassName(IntPtr hwnd,
	//			char[] className, int maxCount);

	//		[DllImport("user32.dll")]
	//		public static extern int GetWindowText(IntPtr hwnd,
	//			char[] windowText, int maxCount);

	//		[DllImport("user32.dll")]
	//		public static extern IntPtr GetWindow(IntPtr hwnd, int uCmd);

	//		[DllImport("user32.dll")]
	//		public static extern bool IsWindow(IntPtr hwnd);

	//		[DllImport("user32.dll")]
	//		public static extern bool IsWindowVisible(IntPtr hwnd);

	//		[DllImport("user32.dll")]
	//		public static extern int GetClientRect(IntPtr hwnd,
	//			ref RECT lpRect);

	//		[DllImport("user32.dll")]
	//		public static extern int GetClientRect(IntPtr hwnd,
	//			[In, Out] ref Rectangle rect);

	//		[DllImport("user32.dll")]
	//		public static extern bool MoveWindow(IntPtr hwnd, int X,
	//			int Y, int nWidth, int nHeight, bool bRepaint);

	//		[DllImport("user32.dll")]
	//		public static extern bool UpdateWindow(IntPtr hwnd);

	//		[DllImport("user32.dll")]
	//		public static extern bool InvalidateRect(IntPtr hwnd,
	//			ref Rectangle rect, bool bErase);

	//		[DllImport("user32.dll")]
	//		internal static extern bool GetWindowRect(IntPtr hWnd,
	//			[In, Out] ref Rectangle rect);


	//		[DllImport("User32.dll")]
	//		public static extern int GetUpdateRect(IntPtr hwnd,
	//			ref RECT rect, bool erase);

	//		[DllImport("User32.dll", SetLastError = true)]
	//		public static extern bool GetWindowRect(IntPtr handle,
	//			ref RECT rect);

	//		[DllImport("User32.dll")]
	//		public static extern IntPtr BeginPaint(IntPtr hWnd,
	//			ref PAINTSTRUCT paintStruct);

	//		[DllImport("User32.dll")]
	//		public static extern bool EndPaint(IntPtr hWnd,
	//			ref PAINTSTRUCT paintStruct);


	//		#endregion

	//		#region DllImport - Kernel32

	//		[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	//		public static extern uint GetCurrentProcessId();

	//		[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	//		public static extern uint GetTickCount();

	//		[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	//		public static extern void ExitProcess(uint uExitCode);

	//		[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	//		public static extern uint IsDebuggerPresent();


	//		[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	//		public static extern void SetLastError(uint value);

	//		[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	//		public static extern uint GetLastError();

	//		[DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
	//		public static extern uint WinExec(string lpCmdLine,
	//			uint uCmdShow);

	//		#endregion

	//		#region DllImport - Gdi32

	//		public const int PFD_DOUBLEBUFFER = 0x00000001;
	//		public const int PFD_STEREO = 0x00000002;
	//		public const int PFD_DRAW_TO_WINDOW = 0x00000004;
	//		public const int PFD_DRAW_TO_BITMAP = 0x00000008;
	//		public const int PFD_SUPPORT_GDI = 0x00000010;
	//		public const int PFD_SUPPORT_OPENGL = 0x00000020;
	//		public const int PFD_GENERIC_FORMAT = 0x00000040;
	//		public const int PFD_NEED_PALETTE = 0x00000080;
	//		public const int PFD_NEED_SYSTEM_PALETTE = 0x00000100;
	//		public const int PFD_SWAP_EXCHANGE = 0x00000200;
	//		public const int PFD_SWAP_COPY = 0x00000400;
	//		public const int PFD_SWAP_LAYER_BUFFERS = 0x00000800;
	//		public const int PFD_GENERIC_ACCELERATED = 0x00001000;
	//		public const int PFD_SUPPORT_DIRECTDRAW = 0x00002000;

	//		public const int PFD_TYPE_RGBA = 0;
	//		public const int PFD_TYPE_COLORINDEX = 1;

	//		public const int PFD_MAIN_PLANE = 0;
	//		public const int PFD_OVERLAY_PLANE = 1;
	//		public const int PFD_UNDERLAY_PLANE = (-1);


	//		/* Pixel format descriptor */
	//		[StructLayout(LayoutKind.Sequential)]
	//		public struct PIXELFORMATDESCRIPTOR
	//		{
	//			public UInt16 nSize;
	//			public UInt16 nVersion;
	//			public UInt32 dwFlags;
	//			public byte iPixelType;
	//			public byte cColorBits;
	//			public byte cRedBits;
	//			public byte cRedShift;
	//			public byte cGreenBits;
	//			public byte cGreenShift;
	//			public byte cBlueBits;
	//			public byte cBlueShift;
	//			public byte cAlphaBits;
	//			public byte cAlphaShift;
	//			public byte cAccumBits;
	//			public byte cAccumRedBits;
	//			public byte cAccumGreenBits;
	//			public byte cAccumBlueBits;
	//			public byte cAccumAlphaBits;
	//			public byte cDepthBits;
	//			public byte cStencilBits;
	//			public byte cAuxBuffers;
	//			public byte iLayerType;
	//			public byte bReserved;
	//			public UInt32 dwLayerMask;
	//			public UInt32 dwVisibleMask;
	//			public UInt32 dwDamageMask;

	//			//
	//			// PIXELFORMATDESCRIPTOR
	//			//
	//			public PIXELFORMATDESCRIPTOR(
	//				//UInt16  nSize,
	//				UInt16 nVersion,
	//				UInt32 dwFlags,
	//				byte iPixelType,
	//				byte cColorBits,
	//				byte cRedBits,
	//				byte cRedShift,
	//				byte cGreenBits,
	//				byte cGreenShift,
	//				byte cBlueBits,
	//				byte cBlueShift,
	//				byte cAlphaBits,
	//				byte cAlphaShift,
	//				byte cAccumBits,
	//				byte cAccumRedBits,
	//				byte cAccumGreenBits,
	//				byte cAccumBlueBits,
	//				byte cAccumAlphaBits,
	//				byte cDepthBits,
	//				byte cStencilBits,
	//				byte cAuxBuffers,
	//				byte iLayerType,
	//				byte bReserved,//26
	//				UInt32 dwLayerMask,
	//				UInt32 dwVisibleMask,
	//				UInt32 dwDamageMask
	//				)
	//			{
	//				nSize = 38;
	//				// sizeof(PIXELFORMATDESCRIPTOR);//nSize;
	//				this.nVersion = nVersion;
	//				this.dwFlags = dwFlags;
	//				this.iPixelType = iPixelType;
	//				this.cColorBits = cColorBits;
	//				this.cRedBits = cRedBits;
	//				this.cRedShift = cRedShift;
	//				this.cGreenBits = cGreenBits;
	//				this.cGreenShift = cGreenShift;
	//				this.cBlueBits = cBlueBits;
	//				this.cBlueShift = cBlueShift;
	//				this.cAlphaBits = cAlphaBits;
	//				this.cAlphaShift = cAlphaShift;
	//				this.cAccumBits = cAccumBits;
	//				this.cAccumRedBits = cAccumRedBits;
	//				this.cAccumGreenBits = cAccumGreenBits;
	//				this.cAccumBlueBits = cAccumBlueBits;
	//				this.cAccumAlphaBits = cAccumAlphaBits;
	//				this.cDepthBits = cDepthBits;
	//				this.cStencilBits = cStencilBits;
	//				this.cAuxBuffers = cAuxBuffers;
	//				this.iLayerType = iLayerType;
	//				this.bReserved = bReserved;
	//				this.dwLayerMask = dwLayerMask;
	//				this.dwVisibleMask = dwVisibleMask;
	//				this.dwDamageMask = dwDamageMask;
	//			}
	//		};



	//		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	//		internal static extern uint SetPixelFormat(
	//			IntPtr hdc,
	//			int iPixelFormat,
	//			ref PIXELFORMATDESCRIPTOR ppfd);

	//		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
	//		internal static extern int ChoosePixelFormat(
	//			IntPtr hdc,
	//			ref PIXELFORMATDESCRIPTOR ppfd);

	//		#endregion

	//		#region Structs
	//		[StructLayout(LayoutKind.Sequential)]
	//		public struct MSG
	//		{     // msg  
	//			public IntPtr hwnd;
	//			public uint message;
	//			public uint wParam;
	//			public uint lParam;
	//			public uint time;
	//			public POINT pt;
	//		}

	//		[StructLayout(LayoutKind.Sequential, Pack = 1)]
	//		public struct POINT
	//		{
	//			public int X;
	//			public int Y;
	//		}

	//		[StructLayout(LayoutKind.Sequential, Pack = 1)]
	//		public struct RECT
	//		{
	//			public int Left;
	//			public int Top;
	//			public int Right;
	//			public int Bottom;
	//		}

	//		[StructLayout(LayoutKind.Sequential)]
	//		public struct WINDOWPOS
	//		{
	//			public IntPtr hwnd;
	//			public IntPtr hwndAfter;
	//			public int x;
	//			public int y;
	//			public int cx;
	//			public int cy;
	//			public uint flags;
	//		}

	//		[StructLayout(LayoutKind.Sequential)]
	//		public struct NCCALCSIZE_PARAMS
	//		{
	//			public RECT rgc;
	//			public WINDOWPOS wndpos;
	//		}

	//		[StructLayout(LayoutKind.Sequential)]
	//		public struct PAINTSTRUCT
	//		{
	//			public IntPtr hdc;
	//			public int fErase;
	//			public RECT rcPaint;
	//			public int fRestore;
	//			public int fIncUpdate;
	//			public int Reserved1;
	//			public int Reserved2;
	//			public int Reserved3;
	//			public int Reserved4;
	//			public int Reserved5;
	//			public int Reserved6;
	//			public int Reserved7;
	//			public int Reserved8;
	//		}
	//		#endregion

	//		#region DllImport - Mpr.dll (Net)

	//		/// <summary>
	//		/// The NETRESOURCE structure contains 
	//		/// information about a network resource
	//		/// </summary>
	//		[StructLayout(LayoutKind.Sequential)]
	//		public struct NETRESOURCE_W
	//		{
	//			public uint dwScope;
	//			public uint dwType;
	//			public uint dwDisplayType;
	//			public uint dwUsage;

	//			[MarshalAs(UnmanagedType.LPWStr)]
	//			public string lpLocalName;

	//			[MarshalAs(UnmanagedType.LPWStr)]
	//			public string lpRemoteName;

	//			[MarshalAs(UnmanagedType.LPWStr)]
	//			public string lpComment;

	//			[MarshalAs(UnmanagedType.LPWStr)]
	//			public string lpProvider;
	//		}

	//		public const uint RESOURCETYPE_ANY = 0x00000000;
	//		public const uint RESOURCETYPE_DISK = 0x00000001;
	//		public const uint RESOURCETYPE_PRINT = 0x00000002;


	//		/// <summary>
	//		/// The WNetAddConnection2 function makes a connection to a 
	//		/// network resource. The function can redirect a 
	//		/// local device to the network resource.
	//		/// </summary>
	//		/// <param name="lpNetResource"></param>
	//		/// <param name="lpPassword"></param>
	//		/// <param name="lpUsername"></param>
	//		/// <param name="dwFlags"></param>
	//		/// <returns></returns>
	//		[DllImport("Mpr.dll", CharSet = CharSet.Unicode)]
	//		internal static extern uint WNetAddConnection2W(
	//			ref NETRESOURCE_W lpNetResource,
	//			string lpPassword,
	//			string lpUsername,
	//			uint dwFlags
	//			);

	//		/// <summary>
	//		/// The WNetCancelConnection2 function 
	//		/// cancels an existing network connection.
	//		///  You can also call the function 
	//		/// to remove remembered network 
	//		/// connections that are not currently connected.
	//		/// </summary>
	//		/// <param name="lpName"></param>
	//		/// <param name="dwFlags"></param>
	//		/// <param name="fForce"></param>
	//		/// <returns></returns>
	//		[DllImport("Mpr.dll", CharSet = CharSet.Unicode)]
	//		internal static extern uint WNetCancelConnection2W(
	//			string lpName,
	//			uint dwFlags,
	//			uint fForce
	//			);

	//		/// <summary>
	//		/// Открыть подключение
	//		/// </summary>
	//		public static bool OpenRemoteShare(string path,
	//			string user_name, string password)
	//		{
	//			if (string.IsNullOrEmpty(path))
	//				return false;

	//			NETRESOURCE_W NetRsrc = new NETRESOURCE_W
	//			{
	//				dwDisplayType = 0,
	//				dwScope = 0,
	//				dwUsage = 0,
	//				lpLocalName = null,
	//				dwType = RESOURCETYPE_DISK,
	//				lpRemoteName = path,
	//				lpProvider = null
	//			};

	//			uint dwNetResult = WNetAddConnection2W(ref NetRsrc,
	//				password, user_name, 0);
	//			if (dwNetResult != 0)
	//			{
	//				throw new Exception(
	//					new Win32Exception((int)dwNetResult).Message);
	//			}
	//			return true;
	//		}

	//		/// <summary>
	//		/// Закрыть подключение
	//		/// </summary>
	//		/// <param name="path"></param>
	//		/// <returns></returns>
	//		public static bool CloseRemoteShare(string path)
	//		{
	//			try
	//			{
	//				if (WNetCancelConnection2W(path, 0, 1) != 0)
	//					return false;

	//				return true;
	//			}
	//			catch
	//			{
	//				return false;
	//			}
	//		}
	//		#endregion


	//	}
}
