namespace Dtx.Logging
{
	public class NLogAdapter<T> : Logger<T> where T : class
	{
		public NLogAdapter
			(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
		{
		}

		protected override void LogByFavoriteLibrary(Log log, System.Exception exception)
		{
			string loggerMessage = log.ToString();

			NLog.Logger logger =
				NLog.LogManager.GetLogger(name: typeof(T).ToString());

			switch (log.Level)
			{
				case LogLevel.Trace:
				{
					logger.Trace
						(exception, message: loggerMessage);

					break;
				}

				case LogLevel.Debug:
				{
					logger.Debug
						(exception, message: loggerMessage);

					break;
				}

				case LogLevel.Information:
				{
					logger.Info
						(exception, message: loggerMessage);

					break;
				}

				case LogLevel.Warning:
				{
					logger.Warn
						(exception, message: loggerMessage);

					break;
				}

				case LogLevel.Error:
				{
					logger.Error
						(exception, message: loggerMessage);

					break;
				}

				case LogLevel.Critical:
				{
					logger.Fatal
						(exception, message: loggerMessage);

					break;
				}
			}
		}
	}
}
