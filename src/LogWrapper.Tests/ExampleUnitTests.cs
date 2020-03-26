using System;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace LogWrapper.Tests
{
    public class ExampleUnitTests
    {
        [Fact]
        public void Application_started_logged()
        {
            var mockLog = new Mock<ILog<SampleApplication>>();

            var application = new SampleApplication(mockLog.Object);
            application.Start();

            mockLog.Verify(x => x.LogInformation("Application started"), Times.Once);
        }

        [Fact]
        public void Ensure_exception_logged_as_error()
        {
            var mockLog = new Mock<ILog<SampleApplication>>();

            var application = new SampleApplication(mockLog.Object);
            application.MethodThatHandlesException();

            mockLog.Verify(x => x.LogError(It.IsAny<Exception>(), "An error occurred"), Times.Once);
        }


        [Fact]
        public void Example_failing_test_showing_inability_to_mock_ILogger_extension_methods()
        {
            var mockLogger = new Mock<ILogger<SampleApplication>>();

            // The following line throws an exception in the XUnit test runner
            // proving that we can't mock ILogger extension methods but we can
            // with the ILog tests above

            mockLogger.Verify(x => x.LogError(It.IsAny<Exception>(), "An error occurred"), Times.Once);
        }
    }
}
