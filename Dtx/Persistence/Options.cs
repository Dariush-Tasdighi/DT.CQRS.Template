namespace Dtx.Persistence
{
	public class Options : object
	{
		public Options() : base()
		{
		}

		// **********
		public Enums.Provider Provider { get; set; }
		// **********

		// **********
		public string ConnectionString { get; set; }
		// **********

		// **********
		public string InMemoryDatabaseName { get; set; }
		// **********
	}
}
