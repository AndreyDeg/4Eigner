﻿using System.Collections.Generic;
using BaseEngine.MyTypes;

namespace BaseEngine
{
	public interface IPhyOrient
	{
		MyVector pos { get; set; }
		MyVector scale { get; set; }
		MyVector angle { get; set; }
	}

	public interface IModel3D: IPhyOrient
	{
		void Paint(MyMatrix position);
		void SetVertices(List<MyVertex> value);
		void SetTexture(ITexture value);
	};

	public interface ILight3D
	{
		void Setup();
	}

	public interface ISky
	{
		IModel3D Model { get; set; }
		void Paint(MyVector cameraPos);
	}

	public interface ICamera : IPhyOrient
	{
		float fovy { get; set; }
		MyColor BackColor { get; set; }
		MyColor LightColor { get; set; }
		IMap Map { get; set; }

		MyMatrix View { get; }
		MyMatrix Proj { get; }
		MyViewport ViewPort { get; set; }

		void Paint();
	}

	public interface IViewRender
	{
		void OnPaint();

		//bool CreateVertex(int l, LPDIRECT3DVERTEXBUFFER9 g_pVB);
		//void DrawVertex(D3DXMATRIX position, int l, LPDIRECT3DVERTEXBUFFER9 g_pVB, LPDIRECT3DTEXTURE9 g_pHDRTexture);
		//void SetLight(int i, D3DLIGHT9 light);

		//bool preloadTexture(string sFileName, D3DXIMAGE_INFO ScrInfo);
		//bool loadTexture(string sFileName, LPDIRECT3DTEXTURE9 g_pHDRTexture);

		ICamera NewCamera();
		IModel3D NewModel3D();
	}
}
