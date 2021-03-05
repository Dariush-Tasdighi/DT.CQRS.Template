namespace LoggingMicroservice.Domain.IQueryRepositories
{
	public interface ILogQueryRepository : Dtx.Domain.IQueryRepository<Models.Log>
	{
		System.Collections.Generic.IList<ViewModels.GetLogsQueryResponseViewModel> Get();
	}
}
