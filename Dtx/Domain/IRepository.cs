namespace Dtx.Domain
{
	public interface IRepository<T> : IQueryRepository<T> where T : IEntity
	{
		System.Threading.Tasks.Task InsertAsync(T entity);

		System.Threading.Tasks.Task UpdateAsync(T entity);

		System.Threading.Tasks.Task DeleteAsync(T entity);

		System.Threading.Tasks.Task<bool> DeleteByIdAsync(System.Guid id);
	}
}
