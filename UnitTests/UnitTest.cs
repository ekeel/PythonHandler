using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using PythonHandler;

namespace UnitTests
{
	public class Tests
	{
		string testScriptString, testFilePath;

		[SetUp]
		public void Setup()
		{
			testScriptString = "import sys; sysversion = sys.version";
			testFilePath = Path.Combine("resources", "test_file.py");
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
            CHandler pythonHandler = new CHandler(@"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5\python310.dll", @"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5");
            pythonHandler.RunFromString(testScriptString);

            Assert.Pass();
        }

        [Test]
        public void CPythonRunFromStringWithReturn()
        {
            CHandler pythonHandler = new CHandler(@"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5\python310.dll", @"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5");
            var result = pythonHandler.RunFromString<string>(testScriptString, "sysversion");

            Assert.IsNotEmpty(result);
        }

		[Test]
		public void CPythonRunFromStringWithAdditionalVariablesTest()
		{
			var tdict = new Dictionary<string, object>();
			tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");

			CHandler pythonHandler = new CHandler(@"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5\python310.dll", @"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5");
			var result = pythonHandler.RunFromString<string>(testScriptString, "testvar", tdict);

			Assert.IsNotEmpty(result);
			Assert.That(result, Is.EqualTo("1ece43cc-b45a-4f97-ba69-5106f23e3932"));
		}


		[Test]
		public void CPythonRunFromFileWithoutReturn()
		{
			CHandler pythonHandler = new CHandler(@"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5\python310.dll", @"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5");
			pythonHandler.RunFromFile(testFilePath);

			Assert.Pass();
		}

		[Test]
		public void CPythonRunFromFileWithReturn()
		{
			CHandler pythonHandler = new CHandler(@"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5\python310.dll", @"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5");
			var result = pythonHandler.RunFromFile<string>(testFilePath, "sysversion");

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void CPythonRunFromFileWithAdditionalVariablesTest()
		{
			var tdict = new Dictionary<string, object>();
			tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");

			CHandler pythonHandler = new CHandler(@"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5\python310.dll", @"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5");
			var result = pythonHandler.RunFromFile<string>(testFilePath, "testvar", tdict);

			Assert.IsNotEmpty(result);
			Assert.That(result, Is.EqualTo("1ece43cc-b45a-4f97-ba69-5106f23e3932"));
		}
	}
}