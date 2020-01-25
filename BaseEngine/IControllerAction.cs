using System;
using System.Collections.Generic;
using System.Reflection;

namespace BaseEngine
{
	public interface IAction
	{
		void OnTimer();

		void DoFile(string sFileName);
		void Register(string sName, object target);
		void Register(string sName, Delegate func);

		List<T> ToList<T>(object obj);
	};
}
