namespace LoggingMicroservice.Persistence
{
	public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public DatabaseContext
			(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options: options)
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
