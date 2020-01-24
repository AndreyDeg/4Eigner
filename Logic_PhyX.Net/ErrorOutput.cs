using System;
using PhysX;

namespace Logic_PhyX.Net
{
    public class ErrorOutput : ErrorCallback
	{
		public override void ReportError(ErrorCode errorCode, string message, string file, int lineNumber)
		{
			Console.WriteLine("PhysX: " + message);
		}
	}
}