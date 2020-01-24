using System;
using System.Runtime.InteropServices;

namespace View_WinAPI.WinAPI
{
	public delegate IntPtr WndProcDelegate(IntPtr hWnd, WM msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential)]
	public struct WNDCLASS
	{
		public CS style;
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public WndProcDelegate lpfnWndProc;
		public int cbClsExtra;
		public int cbWndExtra;
		public IntPtr hInstance;
		public IntPtr hIcon;
		public IntPtr hCursor;
		public IntPtr hbrBackground;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszMenuName;
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszClassName;
	}
}
