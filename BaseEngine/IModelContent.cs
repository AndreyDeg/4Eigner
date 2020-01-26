namespace BaseEngine
{
	public interface ITexture
	{
		string FileName { get; }
		float fCoefY();
		float fCoefX();
	};

	public interface IContent
	{
		ITexture LoadTexture(string TextureName);
		void Run();
	};
}
