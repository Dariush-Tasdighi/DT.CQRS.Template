namespace LoggingMicroservice.Persistence
{
	public class QueryUnitOfWork :
		Dtx.Persistence.QueryUnitOfWork<QueryDatabaseContext>, IQueryUnitOfWork
	{
		public QueryUnitOfWork
			(Dtx.Persistence.Options options) : base(options: options)
		{
		}

		// **************************************************
		private Logs.Repositories.ILogQueryRepository _logs;

		public Logs.Repositories.ILogQueryRepository Logs
		{
			get
			{
				if (_logs == null)
				{
					_logs =
						new Logs.Repositories.LogQueryRepository(databaseContext: DatabaseContext);
				}

				return _logs;
			}
		}
		// **************************************************
	}
}
