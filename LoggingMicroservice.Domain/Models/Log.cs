namespace LoggingMicroservice.Domain.Models
{
	public class Log : Base.Entity
	{
		public Log() : base()
		{
		}

		// **********
		public Enums.LogLevel Level { get; set; }
		// **********

		// **********
		public System.DateTime TimeStamp { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Required]
		[System.ComponentModel.DataAnnotations.MaxLength(length: 100)]
		public string ApplicationName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Required]
		[System.ComponentModel.DataAnnotations.MaxLength(length: 100)]
		public string Namespace { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Required]
		[System.ComponentModel.DataAnnotations.MaxLength(length: 100)]
		public string ClassName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Required]
		[System.ComponentModel.DataAnnotations.MaxLength(length: 100)]
		public string MethodName { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.MaxLength(length: 15)]
		public string RemoteIP { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.MaxLength(length: 50)]
		public string Username { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.MaxLength(length: 100)]
		public string RequestPath { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.MaxLength(length: 100)]
		public string HttpReferrer { get; set; }
		// **********

		// **********
		public string Message { get; set; }
		// **********

		// **********
		public string Parameters { get; set; }
		// **********

		// **********
		public string Exceptions { get; set; }
		// **********
	}
}
