<a name='assembly'></a>
# PythonHandler

## Contents

- [Handler](#T-PythonHandler-Handler 'PythonHandler.Handler')
  - [#ctor()](#M-PythonHandler-Handler-#ctor 'PythonHandler.Handler.#ctor')
  - [#ctor(additionalSearchPaths)](#M-PythonHandler-Handler-#ctor-System-Collections-Generic-ICollection{System-String}- 'PythonHandler.Handler.#ctor(System.Collections.Generic.ICollection{System.String})')
  - [_scriptEngine](#F-PythonHandler-Handler-_scriptEngine 'PythonHandler.Handler._scriptEngine')
  - [RunFromFile(scriptFile)](#M-PythonHandler-Handler-RunFromFile-System-String- 'PythonHandler.Handler.RunFromFile(System.String)')
  - [RunFromFile(scriptFile,variables)](#M-PythonHandler-Handler-RunFromFile-System-String,System-Collections-Generic-Dictionary{System-String,System-Object}- 'PythonHandler.Handler.RunFromFile(System.String,System.Collections.Generic.Dictionary{System.String,System.Object})')
  - [RunFromFile\`\`1(scriptFile,returnVariable)](#M-PythonHandler-Handler-RunFromFile``1-System-String,System-String- 'PythonHandler.Handler.RunFromFile``1(System.String,System.String)')
  - [RunFromFile\`\`1(scriptFile,returnVariable,variables)](#M-PythonHandler-Handler-RunFromFile``1-System-String,System-String,System-Collections-Generic-Dictionary{System-String,System-Object}- 'PythonHandler.Handler.RunFromFile``1(System.String,System.String,System.Collections.Generic.Dictionary{System.String,System.Object})')
  - [RunFromString(code)](#M-PythonHandler-Handler-RunFromString-System-String- 'PythonHandler.Handler.RunFromString(System.String)')
  - [RunFromString(code,variables)](#M-PythonHandler-Handler-RunFromString-System-String,System-Collections-Generic-Dictionary{System-String,System-Object}- 'PythonHandler.Handler.RunFromString(System.String,System.Collections.Generic.Dictionary{System.String,System.Object})')
  - [RunFromString\`\`1(code,returnVariable)](#M-PythonHandler-Handler-RunFromString``1-System-String,System-String- 'PythonHandler.Handler.RunFromString``1(System.String,System.String)')
  - [RunFromString\`\`1(code,returnVariable,variables)](#M-PythonHandler-Handler-RunFromString``1-System-String,System-String,System-Collections-Generic-Dictionary{System-String,System-Object}- 'PythonHandler.Handler.RunFromString``1(System.String,System.String,System.Collections.Generic.Dictionary{System.String,System.Object})')

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
