namespace LoggingMicroservice.Application.LogsFeature
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
