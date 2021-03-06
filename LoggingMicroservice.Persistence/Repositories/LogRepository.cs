namespace LoggingMicroservice.Persistence.Repositories
{
	public class LogRepository :
		Dtx.Persistence.Repository<Domain.Models.Log>,
		Domain.IRepositories.ILogRepository
	{
		protected internal LogRepository
			(Microsoft.EntityFrameworkCore.DbContext databaseContext) : base(databaseContext: databaseContext)
		{
		}
	}
}
