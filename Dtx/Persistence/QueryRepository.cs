using Microsoft.EntityFrameworkCore;

namespace Dtx.Persistence
{
	public abstract class QueryRepository<TEntity> :
		object, IQueryRepository<TEntity> where TEntity : class, Domain.IEntity
	{
		protected QueryRepository
			(Microsoft.EntityFrameworkCore.DbContext databaseContext) : base()
		{
			DatabaseContext =
				databaseContext ??
				throw new System.ArgumentNullException(paramName: nameof(databaseContext));

			DbSet = DatabaseContext.Set<TEntity>();
		}

		// **********
		protected Microsoft.EntityFrameworkCore.DbSet<TEntity> DbSet { get; }
		// **********

		// **********
		protected Microsoft.EntityFrameworkCore.DbContext DatabaseContext { get; }
		// **********

		public virtual async System.Threading.Tasks.Task<TEntity> GetByIdAsync(System.Guid id)
		{
			return await DbSet.FindAsync(keyValues: id);
		}

		public virtual async System.Threading.Tasks.Task<System.Collections.Generic.IList<TEntity>> GetAllAsync()
		{
			// ToListAsync -> Extension Method -> using Microsoft.EntityFrameworkCore;
			var result =
				await
				DbSet.ToListAsync()
				;

			return result;

		}
	}
}
