namespace BaseEngine
{
	public interface IViewInput
	{
		void OnTimer();
		void OnMouseMove(int x, int y, uint keys);
		void OnKeyDown(int key);
		void OnKeyUp(int key);
	}
}
