namespace BaseEngine
{
	public interface ITexture
	{
		string FileName { get; }

		//D3DXIMAGE_INFO &ScrInfo() = 0;
		object data { get; set; }

		float fCoefY();
		float fCoefX();
	};

	public interface IContent
	{
		ITexture LoadTexture(string TextureName);
		void Run();
	};
}
