using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Python.Runtime;

namespace PythonHandler
{
	/// <summary>
	/// Class <c>Handler</c> handles execution of Python scripts using IronPython.
	/// </summary>
	public class CHandler
	{
		public CHandler()
		{
		}

		public void RunFromString(string code)
		{
			using (Py.GIL())
			{
				using (var scope = Py.CreateScope()) {
					scope.Exec(code);
				}
			}
		}
	}
}