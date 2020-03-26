using System;

namespace LogWrapper
{
    public class SampleApplication
    {
        private readonly ILog<SampleApplication> _log;

        public SampleApplication(ILog<SampleApplication> log) // Inject an ILog<T> instead of an ILogger<T>
        {
            _log = log;
        }

        public void Start()
        {
            _log.LogInformation("Application started"); // Methods have the same signature as ILogger<T> extensions
        }

        public void MethodThatHandlesException()
        {
            try
            {
                throw new Exception("Something went wrong");
            }
            catch (Exception exception)
            {
                _log.LogError(exception, "An error occurred");
            }
        }
    }
}