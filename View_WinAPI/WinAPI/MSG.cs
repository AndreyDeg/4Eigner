using System;
using System.Drawing;

namespace View_WinAPI.WinAPI
{
    /// <summary>
    /// Message structure
    /// </summary>
    public struct MSG
	{
		public IntPtr hwnd;
		public UInt32 message;
		public IntPtr wParam;
		public IntPtr lParam;
		public UInt32 time;
		public Point pt;
	}
}
