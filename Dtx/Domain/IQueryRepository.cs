namespace Dtx.Domain
{
	public interface IQueryRepository<T> where T : IEntity
	{
		System.Threading.Tasks.Task<T> GetByIdAsync(System.Guid id);

		System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync();
	}
}
