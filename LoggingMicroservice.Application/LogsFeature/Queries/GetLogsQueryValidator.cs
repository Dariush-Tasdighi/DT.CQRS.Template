using FluentValidation;

namespace LoggingMicroservice.Application.LogsFeature.Queries
{
	public class GetLogsQueryValidator :
		FluentValidation.AbstractValidator<GetLogsQuery>
	{
		public GetLogsQueryValidator() : base()
		{
			RuleFor(current => current.Count)
				.NotEmpty()
				.WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)

				.GreaterThan(valueToCompare: 0)
				.WithMessage(errorMessage: Resources.Messages.ErrorGreaterThanFluent)

				.LessThan(valueToCompare: 101)
				.WithMessage(errorMessage: Resources.Messages.ErrorLessThanFluent)
				;
		}
	}
}
