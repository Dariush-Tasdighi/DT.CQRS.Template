using FluentValidation;

namespace LoggingMicroservice.Application.LogsFeature.Commands.Validators
{
	public class CreateLogCommandValidator :
		FluentValidation.AbstractValidator<Commands.CreateLogCommand>
	{
		public CreateLogCommandValidator() : base()
		{
			RuleFor(current => current.ApplicationName)
				.NotEmpty()
				.WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)
				;
		}
	}
}
