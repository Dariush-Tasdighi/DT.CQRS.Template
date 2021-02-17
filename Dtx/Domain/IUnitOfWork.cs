namespace Dtx.Domain
{
	public interface IUnitOfWork : IQueryUnitOfWork
	{
		System.Threading.Tasks.Task SaveAsync();
	}
}
