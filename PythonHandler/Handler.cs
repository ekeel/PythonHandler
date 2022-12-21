using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace PythonHandler
{
	public class Handler
	{
		private ScriptEngine _scriptEngine;
		private ICollection<string> _additionalSearchPaths;

		public Handler() {
			_scriptEngine = Python.CreateEngine();
		}

		public Handler(ICollection<string> additionalSearchPaths)
		{
			_scriptEngine = Python.CreateEngine();
			
			var searchPaths = _scriptEngine.GetSearchPaths();
			foreach(var searchPath in additionalSearchPaths)
				searchPaths.Add(searchPath);

			_scriptEngine.SetSearchPaths(searchPaths);
		}

		public void RunFromString(string code)
		{
			ScriptSource source = _scriptEngine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
			CompiledCode compiledCode = source.Compile();

			ScriptScope scope = _scriptEngine.CreateScope();

			compiledCode.Execute(scope);
		}

		public TResult RunFromString<TResult>(string code, string returnVariable)
		{
			ScriptSource source = _scriptEngine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
			CompiledCode compiledCode = source.Compile();

			ScriptScope scope = _scriptEngine.CreateScope();

			compiledCode.Execute(scope);

			if (scope.ContainsVariable(returnVariable))
			{
				return scope.GetVariable<TResult>(returnVariable);
			}
			else
				throw new KeyNotFoundException(string.Format("The return variable ({0}) could not be found in the scope.", returnVariable));
		}

		public void RunFromString(string code, Dictionary<string, object> variables)
		{
			ScriptSource source = _scriptEngine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
			CompiledCode compiledCode = source.Compile();

			ScriptScope scope = _scriptEngine.CreateScope();

			if(variables.Count > 0)
				foreach(var arg in variables.Keys)
					scope.SetVariable(arg, variables[arg]);

			compiledCode.Execute(scope);
		}

		public TResult RunFromString<TResult>(string code, string returnVariable, Dictionary<string, object> variables)
		{
			ScriptSource source = _scriptEngine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
			CompiledCode compiledCode = source.Compile();

			ScriptScope scope = _scriptEngine.CreateScope();

			if (variables.Count > 0)
				foreach (var arg in variables.Keys)
					scope.SetVariable(arg, variables[arg]);


			compiledCode.Execute(scope);

			if (scope.ContainsVariable(returnVariable))
			{
				return scope.GetVariable<TResult>(returnVariable);
			}
			else
				throw new KeyNotFoundException(string.Format("The return variable ({0}) could not be found in the scope.", returnVariable));
		}

		public TResult RunFromFile<TResult>(string scriptFile, string returnVariable)
		{
			ScriptSource source = _scriptEngine.CreateScriptSourceFromFile(scriptFile, System.Text.Encoding.UTF8, Microsoft.Scripting.SourceCodeKind.File);
			CompiledCode compiledCode = source.Compile();

			ScriptScope scope = _scriptEngine.CreateScope();

			compiledCode.Execute(scope);

			if (scope.ContainsVariable(returnVariable))
				return scope.GetVariable<TResult>(returnVariable);
			else
				throw new KeyNotFoundException(string.Format("The return variable ({0}) could not be found in the scope.", returnVariable));
		}

		public void RunFromFile(string scriptFile)
		{
			ScriptSource source = _scriptEngine.CreateScriptSourceFromFile(scriptFile, System.Text.Encoding.UTF8, Microsoft.Scripting.SourceCodeKind.File);
			CompiledCode compiledCode = source.Compile();

			ScriptScope scope = _scriptEngine.CreateScope();

			compiledCode.Execute(scope);
		}

		public void RunFromFile(string scriptFile, Dictionary<string, object> variables)
		{
			ScriptSource source = _scriptEngine.CreateScriptSourceFromFile(scriptFile, System.Text.Encoding.UTF8, Microsoft.Scripting.SourceCodeKind.File);
			CompiledCode compiledCode = source.Compile();

			ScriptScope scope = _scriptEngine.CreateScope();

			if (variables.Count > 0)
				foreach (var arg in variables.Keys)
					scope.SetVariable(arg, variables[arg]);

			compiledCode.Execute(scope);
		}

		public TResult RunFromFile<TResult>(string scriptFile, string returnVariable, Dictionary<string, object> variables)
		{
			ScriptSource source = _scriptEngine.CreateScriptSourceFromFile(scriptFile, System.Text.Encoding.UTF8, Microsoft.Scripting.SourceCodeKind.File);
			CompiledCode compiledCode = source.Compile();

			ScriptScope scope = _scriptEngine.CreateScope();

			if (variables.Count > 0)
				foreach (var arg in variables.Keys)
					scope.SetVariable(arg, variables[arg]);

			compiledCode.Execute(scope);

			if (scope.ContainsVariable(returnVariable))
				return scope.GetVariable<TResult>(returnVariable);
			else
				throw new KeyNotFoundException(string.Format("The return variable ({0}) could not be found in the scope.", returnVariable));
		}
	}
}