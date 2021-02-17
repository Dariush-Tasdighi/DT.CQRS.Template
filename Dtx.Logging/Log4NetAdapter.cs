namespace Dtx.Logging
{
	public class Log4NetAdapter<T> : Logger<T>
	{
		public Log4NetAdapter
			(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
		{
		}

		protected override void LogByFavoriteLibrary(Log log, System.Exception exception)
		{
			throw new System.NotImplementedException();
		}
	}
}
