# .NET Core Logger Wrapper

It can be tricky with .NET Core to write tests to ensure that your Logger is working correctly because most mocking libraries are unable to override methods on `Logger<T>` such as `LogCritical()` because they are extension methods.

Attempting to override them with XUnit will give you an error similar to the following:

```
System.NotSupportedException: 'Unsupported expression: x => x.LogCritical("", new[] {  })
Extension methods (here: LoggerExtensions.LogCritical) may not be used in setup / verification expressions.'
```

The aim of this project is to create a simple wrapper around the built-in dotnet `Logger<T>` that encapsulates the static extension methods into instance methods, allowing developers to mock, override and verify their usage in testing scenarios.

## Usage

To use this in your project copy `ILog.cs`, `Log.cs` and `ServiceCollectionExtensions.cs` into your project and when registering your dependencies use the `AddLogWrapper()` extension method to register the `ILog` singleton.

Once this is done you can inject `ILog<T>` to any classes that require it and use it exactly as you would with `ILogger<T>`. You can even replace all instances of `ILogger<T>` with it.

This will then give you the ability to write unit tests that mock the `ILog<T>` dependency and enable you to override all the methods with your mocking library of choice.

See the sample project for an example of usage and some unit tests showing how it works.