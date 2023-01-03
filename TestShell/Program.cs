using PythonHandler;
using System.Runtime.InteropServices;

//EnvLoader.LoadEnvFile(".env");

//CHandler handler = null;
//if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
//    handler = new CHandler(Environment.GetEnvironmentVariable("PY_HANDLER_WIN_PYTHON_DLL"), Environment.GetEnvironmentVariable("PY_HANDLER_WIN_PYTHON_HOME"));
//if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
//    handler = new CHandler(Environment.GetEnvironmentVariable("PY_HANDLER_LIN_PYTHON_DLL"));

CHandler handler = new CHandler();

//var handler = new CHandler(@"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5\python310.dll");
handler.RunFromString("print('yeeeaaahhhhh')");
handler.RunFromString("print('yeeeaaahhhhh2')");