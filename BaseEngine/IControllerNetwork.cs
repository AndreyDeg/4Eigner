namespace BaseEngine
{
	public interface IAddr
	{
	};

	public interface IConnect
	{
		bool Equals(IAddr dest);
		void Recv(string buffer, int len);
		void SendPing();
	};	

	public interface INetwork
	{
		void Init();
		void NewConnect(IConnect connect);
		void Send(IAddr addr, string buffer, int len);
	};
}
