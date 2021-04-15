namespace LoggingMicroservice.Persistence.IQueryRepositories
{
	public interface ILogQueryRepository : Dtx.Persistence.IQueryRepository<Domain.Models.Log>
	{
		System.Threading.Tasks.Task
			<System.Collections.Generic.IList<ViewModels.GetLogsQueryResponseViewModel>>
			GetSomeAsync(int count);
	}
}
