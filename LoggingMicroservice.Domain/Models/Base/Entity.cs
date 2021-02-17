namespace LoggingMicroservice.Domain.Models.Base
{
	public abstract class Entity : Dtx.Domain.IEntity
	{
		protected Entity() : base()
		{
			Id = System.Guid.NewGuid();
		}

		public System.Guid Id { get; set; }
	}
}
