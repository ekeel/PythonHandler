using Python.Runtime;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace PythonHandler
{
    /// <summary>
    /// Class <c>CHandler</c> handles execution of Python scripts using a local Python setup.
    /// </summary>
    public class CHandler
    {
        /// <summary>
		/// This constructor initializes a new <c>CHandler</c> using a .env file.
		/// </summary>
        public CHandler()
        {
            EnvLoader.LoadEnvFile(".env");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Runtime.PythonDLL = Environment.GetEnvironmentVariable("PY_HANDLER_WIN_PYTHON_DLL");
                PythonEngine.PythonHome = Environment.GetEnvironmentVariable("PY_HANDLER_WIN_PYTHON_HOME");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                Runtime.PythonDLL = Environment.GetEnvironmentVariable("PY_HANDLER_LIN_PYTHON_DLL");
        }

        /// <summary>
        /// This constructor initializes a new <c>CHandler</c>.
        /// </summary>
        /// <param name="pythonDllPath">The local path of the Python DLL to use for the runtime.</param>
        public CHandler(string pythonDllPath) 
        {
            Runtime.PythonDLL = pythonDllPath;
        }

        /// <summary>
        /// This constructor initializes a new <c>CHandler</c>.
        /// </summary>
        /// <param name="pythonDllPath">The local path of the Python DLL to use for the runtime.</param>
        /// <param name="pythonHome">The path to the python home directory.</param>
        public CHandler(string pythonDllPath, string pythonHome)
        {
            Runtime.PythonDLL = pythonDllPath;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                PythonEngine.PythonHome = pythonHome;
                string pythonPath = $"{pythonHome};";

                string[] pythonSubPaths = { "DLLs", "lib", "lib/site-packages", "lib/site-packages/win32", "lib/site-packages/win32/lib", "lib/site-packages/Pythonwin" };

                foreach (string p in pythonSubPaths)
                {
                    pythonPath += $"{pythonPath}\\{p};";
                }
            }
        }

        /// <summary>
        /// This method runs a string of Python code.
        /// </summary>
        /// <param name="code"><c>code</c> is the Python string to execute.</param>
        public void RunFromString(string code)
        {
            try
            {
                PythonEngine.Initialize();

                using (Py.GIL())
                {
                    var scope = Py.CreateScope();

                    scope.Exec(code);
                }
            }
            catch (Exception e)
            {

            }
            finally { PythonEngine.Shutdown(); }
        }

        /// <summary>
        /// This method runs a string of Python code.
        /// </summary>
        /// <param name="code"><c>code</c> is the Python string to execute.</param>
        /// <param name="variables"><c>variables</c> is an <c>Dictionary</c> containing the key/values of variables to set. </param>
        public void RunFromString(string code, Dictionary<string, object> variables)
        {
            try
            {
                PythonEngine.Initialize();

                using (Py.GIL())
                {
                    var scope = Py.CreateScope();

                    if (variables.Count > 0)
                        foreach (var arg in variables.Keys)
                            scope.Set(arg, variables[arg]);

                    scope.Exec(code);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unable to execute the given code.", e);
            }
            finally { PythonEngine.Shutdown(); }
        }

        /// <summary>
        /// This method runs a string of Python code.
        /// </summary>
        /// <param name="code"><c>code</c> is the Python string to execute.</param>
        /// <param name="returnVariable"><c>returnVariable</c> is the variable to read from the scope.</param>
		/// <returns>The value of the <c>returnVariable</c> from the scope.</returns>
		/// <exception cref="KeyNotFoundException">The <c>returnVariable</c> was not found.</exception>
        public TResult RunFromString<TResult>(string code, string returnVariable)
        {
            try
            {
                PythonEngine.Initialize();

                using (Py.GIL())
                {
                    var scope = Py.CreateScope();

                    scope.Exec(code);

                    if(scope.Contains(returnVariable))
                        return scope.Get<TResult>(returnVariable);
                    else
                        throw new KeyNotFoundException(string.Format("The return variable ({0}) could not be found in the scope.", returnVariable));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unable to execute the given code.", e);
            }
            finally { PythonEngine.Shutdown(); }
        }

        /// <summary>
        /// This method runs a string of Python code.
        /// </summary>
        /// <param name="code"><c>code</c> is the Python string to execute.</param>
        /// <param name="returnVariable"><c>returnVariable</c> is the variable to read from the scope.</param>
        /// <param name="variables"><c>variables</c> is an <c>Dictionary</c> containing the key/values of variables to set. </param>
		/// <exception cref="KeyNotFoundException">The <c>returnVariable</c> was not found.</exception>
		/// <returns>The value of the <c>returnVariable</c> from the scope.</returns>
        public TResult RunFromString<TResult>(string code, string returnVariable, Dictionary<string, object> variables)
        {
            try
            {
                PythonEngine.Initialize();

                using (Py.GIL())
                {
                    var scope = Py.CreateScope();

                    if (variables.Count > 0)
                        foreach (var arg in variables.Keys)
                            scope.Set(arg, variables[arg]);

                    scope.Exec(code);

                    if (scope.Contains(returnVariable))
                        return scope.Get<TResult>(returnVariable);
                    else
                        throw new KeyNotFoundException(string.Format("The return variable ({0}) could not be found in the scope.", returnVariable));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unable to execute the given code.", e);
            }
            finally { PythonEngine.Shutdown(); }
        }

        /// <summary>
        /// This method runs a Python script.
        /// </summary>
        /// <param name="scriptFile"><c>scriptFile</c> is the path to the Python script to execute.</param>
        public void RunFromFile(string scriptFile)
        {
            try
            {
                PythonEngine.Initialize();

                using (Py.GIL())
                {
                    var scope = Py.CreateScope();

                    var code = File.ReadAllText(scriptFile);
                    scope.Exec(code);
                }
            }
            catch (Exception e)
            {

            }
            finally { PythonEngine.Shutdown(); }
        }

        /// <summary>
        /// This method runs a Python script.
        /// </summary>
        /// <param name="scriptFile"><c>scriptFile</c> is the path to the Python script to execute.</param>
        /// <param name="variables"><c>variables</c> is an <c>Dictionary</c> containing the key/values of variables to set. </param>
        public void RunFromFile(string scriptFile, Dictionary<string, object> variables)
        {
            try
            {
                PythonEngine.Initialize();

                using (Py.GIL())
                {
                    var scope = Py.CreateScope();

                    if (variables.Count > 0)
                        foreach (var arg in variables.Keys)
                            scope.Set(arg, variables[arg]);

                    var code = File.ReadAllText(scriptFile);
                    scope.Exec(code);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unable to execute the given code.", e);
            }
            finally { PythonEngine.Shutdown(); }
        }

        /// <summary>
        /// This method runs a Python script.
        /// </summary>
        /// <param name="scriptFile"><c>scriptFile</c> is the path to the Python script to execute.</param>
        /// <param name="returnVariable"><c>returnVariable</c> is the variable to read from the scope.</param>
		/// <exception cref="KeyNotFoundException">The <c>returnVariable</c> was not found.</exception>
		/// <returns>The value of the <c>returnVariable</c> from the scope.</returns>
        public TResult RunFromFile<TResult>(string scriptFile, string returnVariable)
        {
            try
            {
                PythonEngine.Initialize();

                using (Py.GIL())
                {
                    var scope = Py.CreateScope();

                    var code = File.ReadAllText(scriptFile);
                    scope.Exec(code);

                    if (scope.Contains(returnVariable))
                        return scope.Get<TResult>(returnVariable);
                    else
                        throw new KeyNotFoundException(string.Format("The return variable ({0}) could not be found in the scope.", returnVariable));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unable to execute the given code.", e);
            }
            finally { PythonEngine.Shutdown(); }
        }

        /// <summary>
        /// This method runs a Python script.
        /// </summary>
        /// <param name="scriptFile"><c>scriptFile</c> is the path to the Python script to execute.</param>
        /// <param name="returnVariable"><c>returnVariable</c> is the variable to read from the scope.</param>
        /// <param name="variables"><c>variables</c> is an <c>Dictionary</c> containing the key/values of variables to set. </param>
		/// <returns>The value of the <c>returnVariable</c> from the scope.</returns>
		/// <exception cref="KeyNotFoundException">The <c>returnVariable</c> was not found.</exception>
        public TResult RunFromFile<TResult>(string scriptFile, string returnVariable, Dictionary<string, object> variables)
        {
            try
            {
                PythonEngine.Initialize();

                using (Py.GIL())
                {
                    var scope = Py.CreateScope();

                    if (variables.Count > 0)
                        foreach (var arg in variables.Keys)
                            scope.Set(arg, variables[arg]);

                    var code = File.ReadAllText(scriptFile);
                    scope.Exec(code);

                    if (scope.Contains(returnVariable))
                        return scope.Get<TResult>(returnVariable);
                    else
                        throw new KeyNotFoundException(string.Format("The return variable ({0}) could not be found in the scope.", returnVariable));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unable to execute the given code.", e);
            }
            finally { PythonEngine.Shutdown(); }
        }
    }
}
