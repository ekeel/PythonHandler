using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using PythonHandler;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace UnitTests
{
	public class Tests
	{
		string testScriptString, testFilePath;
		CHandler cHandler;

        [SetUp]
		public void Setup()
		{
			testScriptString = "import sys; sysversion = sys.version";
			testFilePath = Path.Combine("resources", "test_file.py");

            EnvLoader.LoadEnvFile("../../../../TestShell/bin/Release/net6.0/.env");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                cHandler = new CHandler(Environment.GetEnvironmentVariable("PY_HANDLER_WIN_PYTHON_DLL"), Environment.GetEnvironmentVariable("PY_HANDLER_WIN_PYTHON_HOME"));
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                cHandler = new CHandler(Environment.GetEnvironmentVariable("PY_HANDLER_LIN_PYTHON_DLL"));
        }

		[Test]
		public void IronPythonRunFromStringWithoutReturn()
		{
			Handler pythonHandler = new Handler();
			pythonHandler.RunFromString(testScriptString);

			Assert.Pass();
		}

		[Test]
		public void IronPythonRunFromStringWithReturn()
		{
			Handler pythonHandler = new Handler();
			var result = pythonHandler.RunFromString<string>(testScriptString, "sysversion");

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void IronPythonRunFromStringWithAdditionalVariablesTest()
		{
			var tdict = new Dictionary<string, object>();
			tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");

			Handler pythonHandler = new Handler();
			var result = pythonHandler.RunFromString<string>(testScriptString, "testvar", tdict);

			Assert.IsNotEmpty(result);
			Assert.That(result, Is.EqualTo("1ece43cc-b45a-4f97-ba69-5106f23e3932"));
		}


		[Test]
		public void IronPythonRunFromFileWithoutReturn()
		{
			Handler pythonHandler = new Handler();
			pythonHandler.RunFromFile(testFilePath);

			Assert.Pass();
		}

		[Test]
		public void IronPythonRunFromFileWithReturn()
		{
			Handler pythonHandler = new Handler();
			var result = pythonHandler.RunFromFile<string>(testFilePath, "sysversion");

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void IronPythonRunFromFileWithAdditionalVariablesTest()
		{
			var tdict = new Dictionary<string, object>();
			tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");

			Handler pythonHandler = new Handler();
			var result = pythonHandler.RunFromFile<string>(testFilePath, "testvar", tdict);

			Assert.IsNotEmpty(result);
			Assert.That(result, Is.EqualTo("1ece43cc-b45a-4f97-ba69-5106f23e3932"));
		}




        [Test]
        public void CPythonRunFromStringWithoutReturn()
        {
            cHandler.RunFromString(testScriptString);

            Assert.Pass();
        }

        [Test]
        public void CPythonRunFromStringWithReturn()
        {
            var result = cHandler.RunFromString<string>(testScriptString, "sysversion");

            Assert.IsNotEmpty(result);
        }

        [Test]
        public void CPythonRunFromStringWithAdditionalVariablesTest()
        {
            var tdict = new Dictionary<string, object>();
            tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");

            var result = cHandler.RunFromString<string>(testScriptString, "testvar", tdict);

            Assert.IsNotEmpty(result);
            Assert.That(result, Is.EqualTo("1ece43cc-b45a-4f97-ba69-5106f23e3932"));
        }


        [Test]
        public void CPythonRunFromFileWithoutReturn()
        {
            cHandler.RunFromFile(testFilePath);

            Assert.Pass();
        }

        [Test]
        public void CPythonRunFromFileWithReturn()
        {
            var result = cHandler.RunFromFile<string>(testFilePath, "sysversion");

            Assert.IsNotEmpty(result);
        }

        [Test]
        public void CPythonRunFromFileWithAdditionalVariablesTest()
        {
            var tdict = new Dictionary<string, object>
            {
                { "testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932" }
            };

            var result = cHandler.RunFromFile<string>(testFilePath, "testvar", tdict);

            Assert.IsNotEmpty(result);
            Assert.That(result, Is.EqualTo("1ece43cc-b45a-4f97-ba69-5106f23e3932"));
        }
    }
}