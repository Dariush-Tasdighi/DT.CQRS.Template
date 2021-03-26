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
		private Domain.IQueryRepositories.ILogQueryRepository _logs;

		public Domain.IQueryRepositories.ILogQueryRepository Logs
		{
			get
			{
				if (_logs == null)
				{
					_logs =
						new Persistence.QueryRepositories.LogQueryRepository(databaseContext: DatabaseContext);
				}

				return _logs;
			}
		}
		// **************************************************
	}
}
