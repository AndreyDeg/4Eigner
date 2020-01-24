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

		public void Register(string sName, object target, MethodInfo Method)
		{
			RegFuncs.Add(lua.RegisterFunction(sName, target, Method));
		}

		public void OnTimer()
		{
			lua.DoString("if OnTimer then OnTimer(); end");
		}
	}
}
