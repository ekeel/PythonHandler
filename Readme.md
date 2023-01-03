# PythonHandler

This package is a wrapper around IronPython/CPython allowing for easily running Python scripts.

[![Validate](https://github.com/ekeel/PythonHandler/actions/workflows/test.yml/badge.svg?branch=main)](https://github.com/ekeel/PythonHandler/actions/workflows/test.yml)
[![Release](https://github.com/ekeel/PythonHandler/actions/workflows/release.yml/badge.svg?branch=main)](https://github.com/ekeel/PythonHandler/actions/workflows/release.yml)

## Create a `Handler`  (IronPython)

```csharp
using PythonHandler;

// Create a handler without additional module search paths.
Handler pythonHandler = new Handler();

// Create a handler with additional module search paths.
var searchPaths = new List<string>() {"/custom/python/lib"}
Handler pythonHandler = new Handler(searchPaths);
```

## Run from String (IronPython)

```csharp
using PythonHandler;

Handler pythonHandler = new Handler();

// Run an IronPython script from a string without a return value.
pythonHandler.RunFromString("import sys; sysversion = sys.version");

// Run an IronPython script from a string with a return value.
var result = pythonHandler.RunFromString<string>("import sys; sysversion = sys.version", "sysversion");

// Run an IronPython script from a string with a return value and additional variables.
var tdict = new Dictionary<string, object>();
tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");
var result = pythonHandler.RunFromString<string>("import sys", "testvar", tdict);
```

## Run from File (IronPython)

```csharp
using PythonHandler;

Handler pythonHandler = new Handler();

// Run an IronPython script from a file without a return value.
pythonHandler.RunFromFile("import sys; sysversion = sys.version");

// Run an IronPython script from a file with a return value.
var result = pythonHandler.RunFromFile<string>("import sys; sysversion = sys.version", "sysversion");

// Run an IronPython script from a file with a return value and additional variables.
var tdict = new Dictionary<string, object>();
tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");
var result = pythonHandler.RunFromFile<string>("import sys", "testvar", tdict);
```

## Create a `CHandler`  (CPython)

```csharp
using PythonHandler;

// Create a handler without additional module search paths.
CHandler pythonHandler = new CHandler();

// Create a handler with additional module search paths.
var searchPaths = new List<string>() {"/custom/python/lib"}
CHandler pythonHandler = new CHandler(searchPaths);
```

## Run from String (CPython)

```csharp
using PythonHandler;

CHandler pythonHandler = new CHandler();

// Run a CPython script from a string without a return value.
pythonHandler.RunFromString("import sys; sysversion = sys.version");

// Run a CPython script from a string with a return value.
var result = pythonHandler.RunFromString<string>("import sys; sysversion = sys.version", "sysversion");

// Run a CPython script from a string with a return value and additional variables.
var tdict = new Dictionary<string, object>();
tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");
var result = pythonHandler.RunFromString<string>("import sys", "testvar", tdict);
```

## Run from File (CPython)

```csharp
using PythonHandler;

CHandler pythonHandler = new CHandler();

// Run a CPython script from a file without a return value.
pythonHandler.RunFromFile("import sys; sysversion = sys.version");

// Run a CPython script from a file with a return value.
var result = pythonHandler.RunFromFile<string>("import sys; sysversion = sys.version", "sysversion");

// Run a CPython script from a file with a return value and additional variables.
var tdict = new Dictionary<string, object>();
tdict.Add("testvar", "1ece43cc-b45a-4f97-ba69-5106f23e3932");
var result = pythonHandler.RunFromFile<string>("import sys", "testvar", tdict);
```


## Contents

- [PythonHandler](#pythonhandler)
  - [Create a `Handler`  (IronPython)](#create-a-handler--ironpython)
  - [Run from String (IronPython)](#run-from-string-ironpython)
  - [Run from File (IronPython)](#run-from-file-ironpython)
  - [Create a `CHandler`  (CPython)](#create-a-chandler--cpython)
  - [Run from String (CPython)](#run-from-string-cpython)
  - [Run from File (CPython)](#run-from-file-cpython)
  - [Contents](#contents)
  - [Classes](#classes)
    - [`CHandler`](#chandler)
      - [Constructor \& Destructor Documentation](#constructor--destructor-documentation)
        - [PythonHandler.CHandler.CHandler (string pythonDllPath)](#pythonhandlerchandlerchandler-string-pythondllpath)
        - [PythonHandler.CHandler.CHandler (string pythonDllPath, string pythonHome)](#pythonhandlerchandlerchandler-string-pythondllpath-string-pythonhome)
      - [Member Function Documentation](#member-function-documentation)
        - [void PythonHandler.CHandler.RunFromFile (string scriptFile)](#void-pythonhandlerchandlerrunfromfile-string-scriptfile)
        - [void PythonHandler.CHandler.RunFromFile (string scriptFile, Dictionary\< string, object \> variables)](#void-pythonhandlerchandlerrunfromfile-string-scriptfile-dictionary-string-object--variables)
        - [TResult **PythonHandler.CHandler.RunFromFile**\< TResult \> (string scriptFile, string returnVariable)](#tresult-pythonhandlerchandlerrunfromfile-tresult--string-scriptfile-string-returnvariable)
        - [TResult **PythonHandler.CHandler.RunFromFile**\< TResult \> (string scriptFile, string returnVariable, Dictionary\< string, object \> variables)](#tresult-pythonhandlerchandlerrunfromfile-tresult--string-scriptfile-string-returnvariable-dictionary-string-object--variables)
        - [void PythonHandler.CHandler.RunFromString (string code)](#void-pythonhandlerchandlerrunfromstring-string-code)
        - [void PythonHandler.CHandler.RunFromString (string code, Dictionary\< string, object \> variables)](#void-pythonhandlerchandlerrunfromstring-string-code-dictionary-string-object--variables)
        - [TResult **PythonHandler.CHandler.RunFromString**\< TResult \> (string code, string returnVariable)](#tresult-pythonhandlerchandlerrunfromstring-tresult--string-code-string-returnvariable)
        - [TResult **PythonHandler.CHandler.RunFromString**\< TResult \> (string code, string returnVariable, Dictionary\< string, object \> variables)](#tresult-pythonhandlerchandlerrunfromstring-tresult--string-code-string-returnvariable-dictionary-string-object--variables)
    - [`Handler`](#handler)
      - [Constructor \& Destructor Documentation](#constructor--destructor-documentation-1)
        - [PythonHandler.Handler.Handler (ICollection\< string \> additionalSearchPaths)](#pythonhandlerhandlerhandler-icollection-string--additionalsearchpaths)
      - [Member Function Documentation](#member-function-documentation-1)
        - [void PythonHandler.Handler.AppendSearchPath (string searchPath)](#void-pythonhandlerhandlerappendsearchpath-string-searchpath)
        - [void PythonHandler.Handler.RunFromFile (string scriptFile)](#void-pythonhandlerhandlerrunfromfile-string-scriptfile)
        - [void PythonHandler.Handler.RunFromFile (string scriptFile, Dictionary\< string, object \> variables)](#void-pythonhandlerhandlerrunfromfile-string-scriptfile-dictionary-string-object--variables)
        - [TResult **PythonHandler.Handler.RunFromFile**\< TResult \> (string scriptFile, string returnVariable)](#tresult-pythonhandlerhandlerrunfromfile-tresult--string-scriptfile-string-returnvariable)
        - [TResult **PythonHandler.Handler.RunFromFile**\< TResult \> (string scriptFile, string returnVariable, Dictionary\< string, object \> variables)](#tresult-pythonhandlerhandlerrunfromfile-tresult--string-scriptfile-string-returnvariable-dictionary-string-object--variables)
        - [void PythonHandler.Handler.RunFromString (string code)](#void-pythonhandlerhandlerrunfromstring-string-code)
        - [void PythonHandler.Handler.RunFromString (string code, Dictionary\< string, object \> variables)](#void-pythonhandlerhandlerrunfromstring-string-code-dictionary-string-object--variables)
        - [TResult **PythonHandler.Handler.RunFromString**\< TResult \> (string code, string returnVariable)](#tresult-pythonhandlerhandlerrunfromstring-tresult--string-code-string-returnvariable)
        - [TResult **PythonHandler.Handler.RunFromString**\< TResult \> (string code, string returnVariable, Dictionary\< string, object \> variables)](#tresult-pythonhandlerhandlerrunfromstring-tresult--string-code-string-returnvariable-dictionary-string-object--variables)

## Classes

### `CHandler`

Class `CHandler` handles execution of Python scripts using a local
Python setup.

#### Constructor & Destructor Documentation

##### PythonHandler.CHandler.CHandler (string pythonDllPath)

This constructor initializes a new `CHandler`.

**Parameters**

> *pythonDllPath* The local path of the Python DLL to use for the
> runtime.

##### PythonHandler.CHandler.CHandler (string pythonDllPath, string pythonHome)

This constructor initializes a new `CHandler`.

**Parameters**

> *pythonDllPath* The local path of the Python DLL to use for the
> runtime.\
> *pythonHome* The path to the python home directory.

#### Member Function Documentation

##### void PythonHandler.CHandler.RunFromFile (string scriptFile)

This method runs a Python script.

**Parameters**

> *scriptFile* `scriptFile` is the path to the Python script to execute.

##### void PythonHandler.CHandler.RunFromFile (string scriptFile, Dictionary\< string, object \> variables)

This method runs a Python script.

**Parameters**

> *scriptFile* `scriptFile` is the path to the Python script to
> execute.\
> *variables* `variables` is an `Dictionary` containing the key/values
> of variables to set.

##### TResult **PythonHandler.CHandler.RunFromFile**\< TResult \> (string scriptFile, string returnVariable)

This method runs a Python script.

**Parameters**

> *scriptFile* `scriptFile` is the path to the Python script to
> execute.\
> *returnVariable* `returnVariable` is the variable to read from the
> scope.

**Exceptions**

> *KeyNotFoundException* The `returnVariable` was not found.

**Returns**

> The value of the `returnVariable` from the scope.

##### TResult **PythonHandler.CHandler.RunFromFile**\< TResult \> (string scriptFile, string returnVariable, Dictionary\< string, object \> variables)

This method runs a Python script.

**Parameters**

> *scriptFile* `scriptFile` is the path to the Python script to
> execute.\
> *returnVariable* `returnVariable` is the variable to read from the
> scope.\
> *variables* `variables` is an `Dictionary` containing the key/values
> of variables to set.

**Returns**

> The value of the `returnVariable` from the scope.

**Exceptions**

> *KeyNotFoundException* The `returnVariable` was not found.

##### void PythonHandler.CHandler.RunFromString (string code)

This method runs a string of Python code.

**Parameters**

> *code* `code` is the Python string to execute.

##### void PythonHandler.CHandler.RunFromString (string code, Dictionary\< string, object \> variables)

This method runs a string of Python code.

**Parameters**

> *code* `code` is the Python string to execute.\
> *variables* `variables` is an `Dictionary` containing the key/values
> of variables to set.

##### TResult **PythonHandler.CHandler.RunFromString**\< TResult \> (string code, string returnVariable)

This method runs a string of Python code.

**Parameters**

> *code* `code` is the Python string to execute.\
> *returnVariable* `returnVariable` is the variable to read from the
> scope.

**Returns**

> The value of the `returnVariable` from the scope.

**Exceptions**

> *KeyNotFoundException* The `returnVariable` was not found.

##### TResult **PythonHandler.CHandler.RunFromString**\< TResult \> (string code, string returnVariable, Dictionary\< string, object \> variables)

This method runs a string of Python code.

**Parameters**

> *code* `code` is the Python string to execute.\
> *returnVariable* `returnVariable` is the variable to read from the
> scope.\
> *variables* `variables` is an `Dictionary` containing the key/values
> of variables to set.

**Exceptions**

> *KeyNotFoundException* The `returnVariable` was not found.

**Returns**

> The value of the `returnVariable` from the scope.

### `Handler`

Class `Handler` handles execution of Python scripts using IronPython.

#### Constructor & Destructor Documentation

##### PythonHandler.Handler.Handler (ICollection\< string \> additionalSearchPaths)

This constructor initializes a new `Handler` with additional module
search paths.

**Parameters**

> *additionalSearchPaths* `additionalSearchPaths` is a collection of
> addtional module search paths to add to the IronPython scope.

#### Member Function Documentation

##### void PythonHandler.Handler.AppendSearchPath (string searchPath)

This method appends a search path to the engine.

**Parameters**

> *searchPath* `searchPath` is the new search path to append to the
> engine.

##### void PythonHandler.Handler.RunFromFile (string scriptFile)

This method runs a Python script.

**Parameters**

> *scriptFile* `scriptFile` is the path to the Python script to execute.

##### void PythonHandler.Handler.RunFromFile (string scriptFile, Dictionary\< string, object \> variables)

This method runs a Python script.

**Parameters**

> *scriptFile* `scriptFile` is the path to the Python script to
> execute.\
> *variables* `variables` is an `Dictionary` containing the key/values
> of variables to set.

##### TResult **PythonHandler.Handler.RunFromFile**\< TResult \> (string scriptFile, string returnVariable)

This method runs a Python script.

**Template Parameters**

> *TResult* The type of data to return.

**Parameters**

> *scriptFile* `scriptFile` is the path to the Python script to
> execute.\
> *returnVariable* `returnVariable` is the variable to read from the
> scope.

**Returns**

> The value of the `returnVariable` from the scope.

**Exceptions**

> *KeyNotFoundException* The `returnVariable` was not found.

##### TResult **PythonHandler.Handler.RunFromFile**\< TResult \> (string scriptFile, string returnVariable, Dictionary\< string, object \> variables)

This method runs a Python script.

**Template Parameters**

> *TResult* The type of data to return.

**Parameters**

> *scriptFile* `scriptFile` is the path to the Python script to
> execute.\
> *returnVariable* `returnVariable` is the variable to read from the
> scope.\
> *variables* `variables` is an `Dictionary` containing the key/values
> of variables to set.

**Returns**

> The value of the `returnVariable` from the scope.

**Exceptions**

> *KeyNotFoundException* The `returnVariable` was not found.

##### void PythonHandler.Handler.RunFromString (string code)

This method runs a string of Python code.

**Parameters**

> *code* `code` is the Python string to execute.

##### void PythonHandler.Handler.RunFromString (string code, Dictionary\< string, object \> variables)

This method runs a string of Python code.

**Parameters**

> *code* `code` is the Python string to execute.\
> *variables* `variables` is an `Dictionary` containing the key/values
> of variables to set.

##### TResult **PythonHandler.Handler.RunFromString**\< TResult \> (string code, string returnVariable)

This method runs a string of Python code.

**Template Parameters**

> *TResult* The type of data to return.

**Parameters**

> *code* `code` is the Python string to execute.\
> *returnVariable* `returnVariable` is the variable to read from the
> scope.

**Returns**

> The value of the `returnVariable` from the scope.

**Exceptions**

> *KeyNotFoundException* The `returnVariable` was not found.

##### TResult **PythonHandler.Handler.RunFromString**\< TResult \> (string code, string returnVariable, Dictionary\< string, object \> variables)

This method runs a string of Python code.

**Template Parameters**

> *TResult* The type of data to return.

**Parameters**

> *code* `code` is the Python string to execute.\
> *returnVariable* `returnVariable` is the variable to read from the
> scope.\
> *variables* `variables` is an `Dictionary` containing the key/values
> of variables to set.

**Returns**

> The value of the `returnVariable` from the scope.

**Exceptions**

> *KeyNotFoundException* The `returnVariable` was not found.