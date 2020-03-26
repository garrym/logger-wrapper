# logger-wrapper

It can be tricky with .NET Core to write tests to ensure that your Logger is working correctly. This is mostly down to the extension methods used which mocking libraries cannot override.

Attempting to override them with XUnit will give you an error similar to the following:

```
System.NotSupportedException: 'Unsupported expression: x => x.LogCritical("", new[] {  })
Extension methods (here: LoggerExtensions.LogCritical) may not be used in setup / verification expressions.'
```

The aim of this project is to create a simple wrapper around the built-in dotnet `Logger<T>` that encapsulates the static extension methods into instance methods, allowing developers to mock, override and verify their usage in testing scenarios.
