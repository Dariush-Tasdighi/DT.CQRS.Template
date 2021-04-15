namespace LoggingMicroservice.Application.Logs
{
	public class MappingProfile : AutoMapper.Profile
	{
		public MappingProfile() : base()
		{
			CreateMap<Commands.CreateLogCommand, Domain.Models.Log>();
			CreateMap<Domain.Models.Log, Commands.CreateLogCommand>();
		}
	}
}
