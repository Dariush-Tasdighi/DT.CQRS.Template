namespace LoggingMicroservice.Persistence.QueryRepositories
{
	public class LogQueryRepository : Dtx.Persistence.QueryRepository<Domain.Models.Log>
	{
		public LogQueryRepository(QueryDatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}
