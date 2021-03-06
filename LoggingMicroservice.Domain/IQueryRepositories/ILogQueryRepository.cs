namespace LoggingMicroservice.Domain.IQueryRepositories
{
	public interface ILogQueryRepository : Dtx.Domain.IQueryRepository<Models.Log>
	{
		System.Threading.Tasks.Task
			<System.Collections.Generic.IList<ViewModels.GetLogsQueryResponseViewModel>>
			GetSomeAsync(int count);
	}
}
