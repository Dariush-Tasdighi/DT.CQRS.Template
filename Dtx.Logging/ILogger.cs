namespace Dtx.Logging
{
	public interface ILogger<T> where T : class
	{
		void LogTrace
			(string message, System.Collections.Hashtable parameters = null);

		void LogDebug
			(string message, System.Collections.Hashtable parameters = null);

		void LogInformation
			(string message, System.Collections.Hashtable parameters = null);

		void LogWarning
			(string message, System.Collections.Hashtable parameters = null);

		void LogError
			(System.Exception exception = null, string message = null, System.Collections.Hashtable parameters = null);

		void LogCritical
			(System.Exception exception = null, string message = null, System.Collections.Hashtable parameters = null);
	}
}
