namespace LoggingMicroservice.Persistence
{
	public class QueryDatabaseContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public QueryDatabaseContext
			(Microsoft.EntityFrameworkCore.DbContextOptions<QueryDatabaseContext> options) : base(options: options)
		{
			// TODO
			Database.EnsureCreated();
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
