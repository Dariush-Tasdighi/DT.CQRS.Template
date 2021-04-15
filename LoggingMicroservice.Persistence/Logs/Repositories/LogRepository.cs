namespace LoggingMicroservice.Persistence.Logs.Repositories
{
	public class LogRepository :
		Dtx.Persistence.Repository<Domain.Models.Log>, ILogRepository
	{
		protected internal LogRepository
			(Microsoft.EntityFrameworkCore.DbContext databaseContext) : base(databaseContext: databaseContext)
		{
		}
	}
}
