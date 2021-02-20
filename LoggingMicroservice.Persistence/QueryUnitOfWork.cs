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
		private Domain.IRepositories.ILogRepository _logs;

		public Domain.IRepositories.ILogRepository Logs
		{
			get
			{
				if (_logs == null)
				{
					_logs =
						new Repositories.LogRepository(databaseContext: DatabaseContext);
				}

				return _logs;
			}
		}
		// **************************************************
	}
}
