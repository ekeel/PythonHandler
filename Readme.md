# PythonHandler

This package is a wrapper around IronPython allowing for easily running Python scripts.

[![Validate](https://github.com/ekeel/PythonHandler/actions/workflows/test.yml/badge.svg?branch=main)](https://github.com/ekeel/PythonHandler/actions/workflows/test.yml)
[![Release](https://github.com/ekeel/PythonHandler/actions/workflows/release.yml/badge.svg?branch=main)](https://github.com/ekeel/PythonHandler/actions/workflows/release.yml)

## Create an IronPython `Handler`

```csharp
using PythonHandler;

// Create a handler without additional module search paths.
Handler pythonHandler = new Handler();

// Create a handler with additional module search paths.
var searchPaths = new List<string>() {"/custom/python/lib"}
Handler pythonHandler = new Handler(searchPaths);
```

## Run from String

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

## Run from File

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

## Contents

- [PythonHandler](#pythonhandler)
  - [Create an IronPython `Handler`](#create-an-ironpython-handler)
  - [Run from String](#run-from-string)
  - [Run from File](#run-from-file)
  - [Contents](#contents)
  - [Handler `type`](#handler-type)
        - [Namespace](#namespace)
        - [Summary](#summary)
    - [#ctor() `constructor`](#ctor-constructor)
        - [Summary](#summary-1)
        - [Parameters](#parameters)
    - [#ctor(additionalSearchPaths) `constructor`](#ctoradditionalsearchpaths-constructor)
        - [Summary](#summary-2)
        - [Parameters](#parameters-1)
    - [\_scriptEngine `constants`](#_scriptengine-constants)
        - [Summary](#summary-3)
    - [RunFromFile(scriptFile) `method`](#runfromfilescriptfile-method)
        - [Summary](#summary-4)
        - [Parameters](#parameters-2)
    - [RunFromFile(scriptFile,variables) `method`](#runfromfilescriptfilevariables-method)
        - [Summary](#summary-5)
        - [Parameters](#parameters-3)
    - [RunFromFile\`\`1(scriptFile,returnVariable) `method`](#runfromfile1scriptfilereturnvariable-method)
        - [Summary](#summary-6)
        - [Returns](#returns)
        - [Parameters](#parameters-4)
        - [Generic Types](#generic-types)
        - [Exceptions](#exceptions)
    - [RunFromFile\`\`1(scriptFile,returnVariable,variables) `method`](#runfromfile1scriptfilereturnvariablevariables-method)
        - [Summary](#summary-7)
        - [Returns](#returns-1)
        - [Parameters](#parameters-5)
        - [Generic Types](#generic-types-1)
        - [Exceptions](#exceptions-1)
    - [RunFromString(code) `method`](#runfromstringcode-method)
        - [Summary](#summary-8)
        - [Parameters](#parameters-6)
    - [RunFromString(code,variables) `method`](#runfromstringcodevariables-method)
        - [Summary](#summary-9)
        - [Parameters](#parameters-7)
    - [RunFromString\`\`1(code,returnVariable) `method`](#runfromstring1codereturnvariable-method)
        - [Summary](#summary-10)
        - [Returns](#returns-2)
        - [Parameters](#parameters-8)
        - [Generic Types](#generic-types-2)
        - [Exceptions](#exceptions-2)
    - [RunFromString\`\`1(code,returnVariable,variables) `method`](#runfromstring1codereturnvariablevariables-method)
        - [Summary](#summary-11)
        - [Returns](#returns-3)
        - [Parameters](#parameters-9)
        - [Generic Types](#generic-types-3)
        - [Exceptions](#exceptions-3)


<a name='T-PythonHandler-Handler'></a>
## Handler `type`

##### Namespace

PythonHandler

##### Summary

Class `Handler` handles execution of Python scripts using IronPython.

<a name='M-PythonHandler-Handler-#ctor'></a>
### #ctor() `constructor`

##### Summary

This constructor initializes a new `Handler`.

##### Parameters

This constructor has no parameters.

<a name='M-PythonHandler-Handler-#ctor-System-Collections-Generic-ICollection{System-String}-'></a>
### #ctor(additionalSearchPaths) `constructor`

##### Summary

This constructor initializes a new `Handler` with additional module search paths.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| additionalSearchPaths | [System.Collections.Generic.ICollection{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.ICollection 'System.Collections.Generic.ICollection{System.String}') | `additionalSearchPaths` is a collection of addtional module search paths to add to the IronPython scope. |

<a name='F-PythonHandler-Handler-_scriptEngine'></a>
### _scriptEngine `constants`

##### Summary

Instance variable `_scriptEngine` is the IronPython `ScriptEngine` used for hosting IronPython.

<a name='M-PythonHandler-Handler-RunFromFile-System-String-'></a>
### RunFromFile(scriptFile) `method`

##### Summary

This method runs a Python script.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| scriptFile | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `scriptFile` is the path to the Python script to execute. |

<a name='M-PythonHandler-Handler-RunFromFile-System-String,System-Collections-Generic-Dictionary{System-String,System-Object}-'></a>
### RunFromFile(scriptFile,variables) `method`

##### Summary

This method runs a Python script.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| scriptFile | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `scriptFile` is the path to the Python script to execute. |
| variables | [System.Collections.Generic.Dictionary{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.Object}') | `variables` is an `Dictionary` containing the key/values of variables to set. |

<a name='M-PythonHandler-Handler-RunFromFile``1-System-String,System-String-'></a>
### RunFromFile\`\`1(scriptFile,returnVariable) `method`

##### Summary

This method runs a Python script.

##### Returns

The value of the `returnVariable` from the scope.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| scriptFile | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `scriptFile` is the path to the Python script to execute. |
| returnVariable | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `returnVariable` is the variable to read from the scope. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult | The type of data to return. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Collections.Generic.KeyNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException') | The `returnVariable` was not found. |

<a name='M-PythonHandler-Handler-RunFromFile``1-System-String,System-String,System-Collections-Generic-Dictionary{System-String,System-Object}-'></a>
### RunFromFile\`\`1(scriptFile,returnVariable,variables) `method`

##### Summary

This method runs a Python script.

##### Returns

The value of the `returnVariable` from the scope.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| scriptFile | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `scriptFile` is the path to the Python script to execute. |
| returnVariable | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `returnVariable` is the variable to read from the scope. |
| variables | [System.Collections.Generic.Dictionary{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.Object}') | `variables` is an `Dictionary` containing the key/values of variables to set. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult | The type of data to return. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Collections.Generic.KeyNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException') | The `returnVariable` was not found. |

<a name='M-PythonHandler-Handler-RunFromString-System-String-'></a>
### RunFromString(code) `method`

##### Summary

This method runs a string of Python code.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `code` is the Python string to execute. |

<a name='M-PythonHandler-Handler-RunFromString-System-String,System-Collections-Generic-Dictionary{System-String,System-Object}-'></a>
### RunFromString(code,variables) `method`

##### Summary

This method runs a string of Python code.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `code` is the Python string to execute. |
| variables | [System.Collections.Generic.Dictionary{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.Object}') | `variables` is an `Dictionary` containing the key/values of variables to set. |

<a name='M-PythonHandler-Handler-RunFromString``1-System-String,System-String-'></a>
### RunFromString\`\`1(code,returnVariable) `method`

##### Summary

This method runs a string of Python code.

##### Returns

The value of the `returnVariable` from the scope.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `code` is the Python string to execute. |
| returnVariable | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `returnVariable` is the variable to read from the scope. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult | The type of data to return. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Collections.Generic.KeyNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException') | The `returnVariable` was not found. |

<a name='M-PythonHandler-Handler-RunFromString``1-System-String,System-String,System-Collections-Generic-Dictionary{System-String,System-Object}-'></a>
### RunFromString\`\`1(code,returnVariable,variables) `method`

##### Summary

This method runs a string of Python code.

##### Returns

The value of the `returnVariable` from the scope.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| code | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `code` is the Python string to execute. |
| returnVariable | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | `returnVariable` is the variable to read from the scope. |
| variables | [System.Collections.Generic.Dictionary{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.Object}') | `variables` is an `Dictionary` containing the key/values of variables to set. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TResult | The type of data to return. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.Collections.Generic.KeyNotFoundException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.KeyNotFoundException 'System.Collections.Generic.KeyNotFoundException') | The `returnVariable` was not found. |
