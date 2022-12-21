using PythonHandler;

namespace UnitTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void BasicTestWithoutReturn()
		{
			Handler pythonHandler = new Handler();
			pythonHandler.RunFromString("import sys; sysversion = sys.version");

			Assert.Pass();
		}

		[Test]
		public void BasicTestWithReturn()
		{
			Handler pythonHandler = new Handler();
			var result = pythonHandler.RunFromString<string>("import sys; sysversion = sys.version", "sysversion");

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void AdditionalVariablesTest()
		{
			var tdict = new Dictionary<string, object>();
			tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");

			Handler pythonHandler = new Handler();
			var result = pythonHandler.RunFromString<string>("import sys", "testvar", tdict);

			Assert.IsNotEmpty(result);
			Assert.That(result, Is.EqualTo("1ece43cc-b45a-4f97-ba69-5106f23e3932"));
		}
	}
}