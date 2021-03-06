using FluentValidation;

namespace LoggingMicroservice.Application.LogsFeature.Queries.Validators
{
	public class GetLogsQueryValidator :
		FluentValidation.AbstractValidator<GetLogsQuery>
	{
		public GetLogsQueryValidator() : base()
		{
			RuleFor(current => current.Count)
				.NotEmpty()
				.WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)
				;
		}
	}
}
