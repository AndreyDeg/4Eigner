using System;

namespace BaseEngine
{
	public interface IViewWindow
	{
		IntPtr hWnd { get; }

		int iLeft { get; }
		int iTop { get; }
		int iWidth { get; }
		int iHeight { get; }

		void Run();
		void Close();

		void CreateTimer(uint uElapse, Action<uint> func);
		Action<uint, uint, long> OnMouseMove { get; set; }
		Action<uint> OnKeyDown { get; set; }
		Action<uint> OnKeyUp { get; set; }
	}
}
