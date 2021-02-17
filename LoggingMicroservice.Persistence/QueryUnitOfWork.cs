namespace LoggingMicroservice.Persistence
{
	public class QueryUnitOfWork : Microsoft.EntityFrameworkCore.DbContext
	{
		public QueryUnitOfWork
			(Microsoft.EntityFrameworkCore.DbContextOptions<QueryDatabaseContext> options) : base(options: options)
		{
		}

		// **********
		public Microsoft.EntityFrameworkCore.DbSet<Domain.Models.Log> Logs { get; set; }
		// **********

		protected override void OnModelCreating
			(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
