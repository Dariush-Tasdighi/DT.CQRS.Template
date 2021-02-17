using Microsoft.EntityFrameworkCore;

namespace Dtx.Persistence
{
	public abstract class QueryUnitOfWork<T> :
		object, Domain.IQueryUnitOfWork where T : Microsoft.EntityFrameworkCore.DbContext
	{
		public QueryUnitOfWork(Options options) : base()
		{
			Options = options;
		}

		// **********
		protected Options Options { get; set; }
		// **********

		// **********
		// **********
		// **********
		private T _databaseContext;
		// **********

		// **********
		protected T DatabaseContext
		{
			get
			{
				if (_databaseContext == null)
				{
					var optionsBuilder =
						new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<T>();

					switch (Options.Provider)
					{
						case Enums.Provider.SqlServer:
						{
							optionsBuilder.UseSqlServer
								(connectionString: Options.ConnectionString);

							break;
						}

						case Enums.Provider.MySql:
						{
							//optionsBuilder.UseMySql
							//	(connectionString: Options.ConnectionString);

							break;
						}

						case Enums.Provider.Oracle:
						{
							//optionsBuilder.UseOracle
							//	(connectionString: Options.ConnectionString);

							break;
						}

						case Enums.Provider.PostgreSQL:
						{
							//optionsBuilder.UsePostgreSQL
							//	(connectionString: Options.ConnectionString);

							break;
						}

						case Enums.Provider.InMemory:
						{
							optionsBuilder.UseInMemoryDatabase
								(databaseName: Options.InMemoryDatabaseName);

							break;
						}

						default:
						{
							break;
						}
					}

					_databaseContext =
						(T)System.Activator.CreateInstance
						(type: typeof(T), args: optionsBuilder.Options);
				}

				return _databaseContext;
			}
		}
		// **********
		// **********
		// **********

		// **********
		/// <summary>
		/// To detect redundant calls
		/// </summary>
		public bool IsDisposed { get; protected set; }
		// **********

		/// <summary>
		/// Public implementation of Dispose pattern callable by consumers.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);

			System.GC.SuppressFinalize(this);
		}

		/// <summary>
		/// https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (IsDisposed)
			{
				return;
			}

			if (disposing)
			{
				// TODO: dispose managed state (managed objects).

				if (_databaseContext != null)
				{
					_databaseContext.Dispose();
					_databaseContext = null;
				}
			}

			// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
			// TODO: set large fields to null.

			IsDisposed = true;
		}

		~QueryUnitOfWork()
		{
			Dispose(false);
		}
	}
}
