using System;
using System.Collections.Generic;
using System.Reflection;
using BaseEngine;
using NLua;

namespace Action_NLua
{
	public class MyLua : IAction
	{
		private readonly Lua lua = new Lua();

		public List<T> ToList<T>(object obj)
		{
			var result = new List<T>();
			using (var table = obj as LuaTable)
				foreach (KeyValuePair<object, object> t in table)
					result.Add((T)t.Value);

			return result;
		}

		public void DoFile(string sFileName)
		{
			lua.DoFile(sFileName);
		}

		readonly List<LuaFunction> RegFuncs = new List<LuaFunction>();

		public void Register(string sName, object target)
		{
			lua[sName] = target;
		}

		public void Register(string sName, Delegate func)
		{
			RegFuncs.Add(lua.RegisterFunction(sName, func.Target, func.Method));
		}

		public void Register<T>(string sName, Func<object, T> func)
		{
			RegFuncs.Add(lua.RegisterFunction(sName, func.Target, func.Method));
		}
	}
}
