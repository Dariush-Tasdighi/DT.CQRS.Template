using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dtx.Persistence
{
	public abstract class Repository<T> :
		object, Domain.IRepository<T> where T : class, Domain.IEntity
	{
		protected internal Repository(Microsoft.EntityFrameworkCore.DbContext databaseContext) : base()
		{
			DatabaseContext =
				databaseContext ??
				throw new System.ArgumentNullException(paramName: nameof(databaseContext));

			DbSet = DatabaseContext.Set<T>();
		}

		// **********
		protected Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }
		// **********

		// **********
		protected Microsoft.EntityFrameworkCore.DbContext DatabaseContext { get; }
		// **********

		public virtual async System.Threading.Tasks.Task InsertAsync(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

			await DbSet.AddAsync(entity);
		}

		protected virtual void Update(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

			DbSet.Update(entity);
		}

		public virtual async System.Threading.Tasks.Task UpdateAsync(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

			await System.Threading.Tasks.Task.Run(() =>
			{
				DbSet.Update(entity);
			});
		}

		public virtual async System.Threading.Tasks.Task DeleteAsync(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

			await System.Threading.Tasks.Task.Run(() =>
			{
				DbSet.Remove(entity);
			});
		}

		public virtual async System.Threading.Tasks.Task<T> GetByIdAsync(System.Guid id)
		{
			return await DbSet.FindAsync(keyValues: id);
		}

		public virtual async System.Threading.Tasks.Task<bool> DeleteByIdAsync(System.Guid id)
		{
			T entity =
				await GetByIdAsync(id);

			if (entity == null)
			{
				return false;
			}

			await DeleteAsync(entity);

			return true;
		}

		public virtual async System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync()
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
