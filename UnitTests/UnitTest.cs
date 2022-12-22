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
		public void RunFromStringWithoutReturn()
		{
			Handler pythonHandler = new Handler();
			pythonHandler.RunFromString(testScriptString);

			Assert.Pass();
		}

		[Test]
		public void RunFromStringWithReturn()
		{
			Handler pythonHandler = new Handler();
			var result = pythonHandler.RunFromString<string>(testScriptString, "sysversion");

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void RunFromStringWithAdditionalVariablesTest()
		{
			var tdict = new Dictionary<string, object>();
			tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");

			Handler pythonHandler = new Handler();
			var result = pythonHandler.RunFromString<string>(testScriptString, "testvar", tdict);

			Assert.IsNotEmpty(result);
			Assert.That(result, Is.EqualTo("1ece43cc-b45a-4f97-ba69-5106f23e3932"));
		}


		[Test]
		public void RunFromFileWithoutReturn()
		{
			Handler pythonHandler = new Handler();
			pythonHandler.RunFromFile(testFilePath);

			Assert.Pass();
		}

		[Test]
		public void RunFromFileWithReturn()
		{
			Handler pythonHandler = new Handler();
			var result = pythonHandler.RunFromFile<string>(testFilePath, "sysversion");

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void RunFromFileWithAdditionalVariablesTest()
		{
			var tdict = new Dictionary<string, object>();
			tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");

			Handler pythonHandler = new Handler();
			var result = pythonHandler.RunFromFile<string>(testFilePath, "testvar", tdict);

			Assert.IsNotEmpty(result);
			Assert.That(result, Is.EqualTo("1ece43cc-b45a-4f97-ba69-5106f23e3932"));
		}
	}
}