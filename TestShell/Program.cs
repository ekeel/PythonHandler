using PythonHandler;

var handler = new CHandler(@"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5\python310.dll", @"C:\Users\Erick\.pyenv\pyenv-win\versions\3.10.5");
handler.RunFromString("print('yeeeaaahhhhh')");
handler.RunFromString("print('yeeeaaahhhhh2')");