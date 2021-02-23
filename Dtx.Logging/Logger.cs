namespace Dtx.Logging
{
	public abstract class Logger<T> : object, ILogger<T> where T : class
	{
		protected Logger(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor = null) : base()
		{
			// **************************************************
			HttpContextAccessor = httpContextAccessor;
			// **************************************************

			// **************************************************
			//if (httpContextAccessor == null)
			//{
			//	throw new System.ArgumentNullException(nameof(httpContextAccessor));
			//}
			// **************************************************

			// **************************************************
			//HttpContextAccessor =
			//	httpContextAccessor ?? throw new System.ArgumentNullException(nameof(httpContextAccessor));
			// **************************************************
		}

		protected Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; set; }

		#region GetExceptions(System.Exception exception)
		protected virtual string GetExceptions(System.Exception exception)
		{
			System.Text.StringBuilder result = new System.Text.StringBuilder();

			System.Exception currentException = exception;

			int index = 0;

			while (currentException != null)
			{
				if (index == 0)
				{
					result.Append($"<{ nameof(System.Exception) }>");
				}
				else
				{
					result.Append($"<{ nameof(System.Exception.InnerException) }>");
				}

				result.Append(currentException.Message);

				if (index == 0)
				{
					result.Append($"</{ nameof(System.Exception) }>");
				}
				else
				{
					result.Append($"</{ nameof(System.Exception.InnerException) }>");
				}

				index++;

				currentException =
					currentException.InnerException;
			}

			return result.ToString();
		}
		#endregion /GetExceptions(System.Exception exception)

		#region protected virtual string GetParameters(System.Collections.Hashtable parameters)
		protected virtual string GetParameters(System.Collections.Hashtable parameters)
		{
			if ((parameters == null) || (parameters.Count == 0))
			{
				return null;
			}

			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

			foreach (System.Collections.DictionaryEntry item in parameters)
			{
				if (item.Key != null)
				{
					stringBuilder.Append("<parameter>");

					stringBuilder.Append($"<key>{ item.Key }</key>");

					if (item.Value == null)
					{
						stringBuilder.Append($"<value>NULL</value>");
					}
					else
					{
						stringBuilder.Append($"<value>{ item.Value }</value>");
					}

					stringBuilder.Append("</parameter>");
				}
			}

			string result =
				stringBuilder.ToString();

			return result;
		}
		#endregion /protected virtual string GetParameters(System.Collections.Hashtable parameters)

		protected void Log
			(LogLevel level,
			System.Reflection.MethodBase methodBase,
			string message,
			System.Exception exception = null,
			System.Collections.Hashtable parameters = null)
		{
			if (exception == null && string.IsNullOrWhiteSpace(message))
			{
				return;
			}

			// **************************************************
			string currentCultureName =
				System.Threading.Thread.CurrentThread.CurrentCulture.Name;

			System.Globalization.CultureInfo newCultureInfo =
				new System.Globalization.CultureInfo(name: "en-US");

			System.Globalization.CultureInfo currentCultureInfo =
				new System.Globalization.CultureInfo(currentCultureName);

			System.Threading.Thread.CurrentThread.CurrentCulture = newCultureInfo;
			// **************************************************

			Log log = new Log();

			log.Level = level;

			log.ClassName = typeof(T).Name;
			log.MethodName = methodBase.Name;
			log.Namespace = typeof(T).Namespace;

			if ((HttpContextAccessor != null) &&
				(HttpContextAccessor.HttpContext != null) &&
				(HttpContextAccessor.HttpContext.Connection != null) &&
				(HttpContextAccessor.HttpContext.Connection.RemoteIpAddress != null))
			{
				log.RemoteIP =
					HttpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
			}

			if ((HttpContextAccessor != null) &&
				(HttpContextAccessor.HttpContext != null) &&
				(HttpContextAccessor.HttpContext.User != null) &&
				(HttpContextAccessor.HttpContext.User.Identity != null))
			{
				log.Username =
					HttpContextAccessor.HttpContext.User.Identity.Name;
			}

			if ((HttpContextAccessor != null) &&
				(HttpContextAccessor.HttpContext != null) &&
				(HttpContextAccessor.HttpContext.Request != null))
			{
				log.RequestPath =
					HttpContextAccessor.HttpContext.Request.Path;

				log.HttpReferrer =
					HttpContextAccessor.HttpContext.Request.Headers["Referer"];
			}

			log.Message = message;

			log.Exceptions =
				GetExceptions(exception: exception);

			log.Parameters =
				GetParameters(parameters: parameters);

			LogByFavoriteLibrary(log: log, exception: exception);

			// **************************************************
			System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
			// **************************************************
		}

		protected abstract void LogByFavoriteLibrary(Log log, System.Exception exception);

		public void LogTrace
			(string message, System.Collections.Hashtable parameters = null)
		{
			System.Diagnostics.StackTrace
				stackTrace = new System.Diagnostics.StackTrace();

			System.Reflection.MethodBase
				methodBase = stackTrace.GetFrame(1).GetMethod();

			Log(methodBase: methodBase,
				level: LogLevel.Trace,
				message: message,
				exception: null,
				parameters: parameters);
		}

		public void LogDebug
			(string message, System.Collections.Hashtable parameters = null)
		{
			System.Diagnostics.StackTrace
				stackTrace = new System.Diagnostics.StackTrace();

			System.Reflection.MethodBase
				methodBase = stackTrace.GetFrame(1).GetMethod();

			Log(methodBase: methodBase,
				level: LogLevel.Debug,
				message: message,
				exception: null,
				parameters: parameters);
		}

		public void LogInformation
			(string message, System.Collections.Hashtable parameters = null)
		{
			System.Diagnostics.StackTrace
				stackTrace = new System.Diagnostics.StackTrace();

			System.Reflection.MethodBase
				methodBase = stackTrace.GetFrame(1).GetMethod();

			Log(methodBase: methodBase,
				level: LogLevel.Information,
				message: message,
				exception: null,
				parameters: parameters);
		}

		public void LogWarning
			(string message, System.Collections.Hashtable parameters = null)
		{
			System.Diagnostics.StackTrace
				stackTrace = new System.Diagnostics.StackTrace();

			System.Reflection.MethodBase
				methodBase = stackTrace.GetFrame(1).GetMethod();

			Log(methodBase: methodBase,
				level: LogLevel.Warning,
				message: message,
				exception: null,
				parameters: parameters);
		}

		public void LogError
			(System.Exception exception = null, string message = null, System.Collections.Hashtable parameters = null)
		{
			System.Diagnostics.StackTrace
				stackTrace = new System.Diagnostics.StackTrace();

			System.Reflection.MethodBase
				methodBase = stackTrace.GetFrame(1).GetMethod();

			Log(methodBase: methodBase,
				level: LogLevel.Error,
				message: message,
				exception: exception,
				parameters: parameters);
		}

		public void LogCritical
			(System.Exception exception = null, string message = null, System.Collections.Hashtable parameters = null)
		{
			System.Diagnostics.StackTrace
				stackTrace = new System.Diagnostics.StackTrace();

			System.Reflection.MethodBase
				methodBase = stackTrace.GetFrame(1).GetMethod();

			Log(methodBase: methodBase,
				level: LogLevel.Critical,
				message: message,
				exception: exception,
				parameters: parameters);
		}
	}
}
