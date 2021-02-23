namespace Dtx.Logging
{
	public class Log4NetAdapter<T> : Logger<T> where T : class
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
