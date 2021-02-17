namespace Dtx.Persistence
{
	public abstract class UnitOfWork<T> :
		QueryUnitOfWork<T>, Domain.IUnitOfWork where T : Microsoft.EntityFrameworkCore.DbContext
	{
		public UnitOfWork(Options options) : base(options: options)
		{
		}

		public async System.Threading.Tasks.Task SaveAsync()
		{
			await DatabaseContext.SaveChangesAsync();
		}
	}
}
