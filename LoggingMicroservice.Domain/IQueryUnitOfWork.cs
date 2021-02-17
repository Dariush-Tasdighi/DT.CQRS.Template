namespace LoggingMicroservice.Domain
{
	public interface IQueryUnitOfWork : Dtx.Domain.IQueryUnitOfWork
	{
		public IQueryRepositories.ILogQueryRepository Logs { get; set; }
	}
}
