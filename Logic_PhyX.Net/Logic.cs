using BaseEngine;

namespace Logic_PhyX.Net
{
	public class Logic: ILogic
    {
		public IPhysic CreatePhysic()
		{
			return new MyPhysX();
		}
    }
}
