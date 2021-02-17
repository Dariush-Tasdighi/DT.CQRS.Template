namespace LoggingMicroservice.Persistence
{
	public class UnitOfWork : Dtx.Persistence.UnitOfWork<DatabaseContext>, IUnitOfWork
	{
		public UnitOfWork
			(Dtx.Persistence.Options options) : base(options: options)
		{
		}

		// **************************************************
		//private IXXXXXRepository _xXXXXRepository;

		//public IXXXXXRepository XXXXXRepository
		//{
		//	get
		//	{
		//		if (_xXXXXRepository == null)
		//		{
		//			_xXXXXRepository =
		//				new XXXXXRepository(DatabaseContext);
		//		}

		//		return _xXXXXRepository;
		//	}
		//}
		// **************************************************

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
