using System.Collections.Generic;

namespace BaseEngine.ModelWorld
{
	public class World: IWorld
	{
		readonly List<IMap> maps = new List<IMap>();

		public void UpdateMaps()
		{
			foreach (var map in maps)
				map.Update();
		}

		public IObject3D CreateObject3D()
		{
			return new Object3D();
		}

		public IMap CreateMap()
		{
			var map = new Map();
			maps.Add(map);
			return map;
		}

		public IMap GetMap(int iN)
		{
			return iN >= 0 && iN < maps.Count ? maps[iN] : null;
		}
	}
}
