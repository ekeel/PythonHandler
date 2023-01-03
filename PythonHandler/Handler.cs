using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace PythonHandler
{
	/// <summary>
	/// Class <c>Handler</c> handles execution of Python scripts using IronPython.
	/// </summary>
	public class Handler
	{
		/// <summary>
		/// Instance variable <c>_scriptEngine</c> is the IronPython <c>ScriptEngine</c> used for hosting IronPython.
		/// </summary>
		private ScriptEngine _scriptEngine;

		/// <summary>
		/// This constructor initializes a new <c>Handler</c>.
		/// </summary>
		public Handler() {
			_scriptEngine = IronPython.Hosting.Python.CreateEngine();
		}

		/// <summary>
		/// This constructor initializes a new <c>Handler</c> with additional module search paths.
		/// </summary>
		/// <param name="additionalSearchPaths"><c>additionalSearchPaths</c> is a collection of addtional module search paths to add to the IronPython scope.</param>
		public Handler(ICollection<string> additionalSearchPaths)
		{
			_scriptEngine = IronPython.Hosting.Python.CreateEngine();
			
			var searchPaths = _scriptEngine.GetSearchPaths();
			foreach(var searchPath in additionalSearchPaths)
				searchPaths.Add(searchPath);

			_scriptEngine.SetSearchPaths(searchPaths);
		}

		/// <summary>
		/// This method appends a search path to the engine.
		/// </summary>
		/// <param name="searchPath"><c>searchPath</c> is the new search path to append to the engine.</param>
		public void AppendSearchPath(string searchPath) {
			var searchPaths = _scriptEngine.GetSearchPaths();
			searchPaths.Add(searchPath);

			_scriptEngine.SetSearchPaths(searchPaths);
		}

		/// <summary>
		/// This method runs a string of Python code.
		/// </summary>
		/// <param name="code"><c>code</c> is the Python string to execute.</param>
		public void RunFromString(string code)
		{
			ScriptSource source = _scriptEngine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
			CompiledCode compiledCode = source.Compile();

			ScriptScope scope = _scriptEngine.CreateScope();

			compiledCode.Execute(scope);
		}

		/// <summary>
		/// This method runs a string of Python code.
		/// </summary>
		/// <typeparam name="TResult">The type of data to return.</typeparam>
		/// <param name="code"><c>code</c> is the Python string to execute.</param>
		/// <param name="returnVariable"><c>returnVariable</c> is the variable to read from the scope.</param>
		/// <returns>The value of the <c>returnVariable</c> from the scope.</returns>
		/// <exception cref="KeyNotFoundException">The <c>returnVariable</c> was not found.</exception>
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

		/// <summary>
		/// This method runs a string of Python code.
		/// </summary>
		/// <param name="code"><c>code</c> is the Python string to execute.</param>
		/// <param name="variables"><c>variables</c> is an <c>Dictionary</c> containing the key/values of variables to set. </param>
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

		/// <summary>
		/// This method runs a string of Python code.
		/// </summary>
		/// <typeparam name="TResult">The type of data to return.</typeparam>
		/// <param name="code"><c>code</c> is the Python string to execute.</param>
		/// <param name="returnVariable"><c>returnVariable</c> is the variable to read from the scope.</param>
		/// <param name="variables"><c>variables</c> is an <c>Dictionary</c> containing the key/values of variables to set. </param>
		/// <returns>The value of the <c>returnVariable</c> from the scope.</returns>
		/// <exception cref="KeyNotFoundException">The <c>returnVariable</c> was not found.</exception>
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

		/// <summary>
		/// This method runs a Python script.
		/// </summary>
		/// <typeparam name="TResult">The type of data to return.</typeparam>
		/// <param name="scriptFile"><c>scriptFile</c> is the path to the Python script to execute.</param>
		/// <param name="returnVariable"><c>returnVariable</c> is the variable to read from the scope.</param>
		/// <returns>The value of the <c>returnVariable</c> from the scope.</returns>
		/// <exception cref="KeyNotFoundException">The <c>returnVariable</c> was not found.</exception>
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

		/// <summary>
		/// This method runs a Python script.
		/// </summary>
		/// <param name="scriptFile"><c>scriptFile</c> is the path to the Python script to execute.</param>
		public void RunFromFile(string scriptFile)
		{
			ScriptSource source = _scriptEngine.CreateScriptSourceFromFile(scriptFile, System.Text.Encoding.UTF8, Microsoft.Scripting.SourceCodeKind.File);
			CompiledCode compiledCode = source.Compile();

			ScriptScope scope = _scriptEngine.CreateScope();

			compiledCode.Execute(scope);
		}

		/// <summary>
		/// This method runs a Python script.
		/// </summary>
		/// <param name="scriptFile"><c>scriptFile</c> is the path to the Python script to execute.</param>
		/// <param name="variables"><c>variables</c> is an <c>Dictionary</c> containing the key/values of variables to set. </param>
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

		/// <summary>
		/// This method runs a Python script.
		/// </summary>
		/// <typeparam name="TResult">The type of data to return.</typeparam>
		/// <param name="scriptFile"><c>scriptFile</c> is the path to the Python script to execute.</param>
		/// <param name="returnVariable"><c>returnVariable</c> is the variable to read from the scope.</param>
		/// <param name="variables"><c>variables</c> is an <c>Dictionary</c> containing the key/values of variables to set. </param>
		/// <returns>The value of the <c>returnVariable</c> from the scope.</returns>
		/// <exception cref="KeyNotFoundException">The <c>returnVariable</c> was not found.</exception>
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