using FluentValidation;

namespace LoggingMicroservice.Application.LogsFeature.Validators
{
	public class CreateLogCommandValidator :
		FluentValidation.AbstractValidator<Commands.CreateLogCommand>
	{
		public CreateLogCommandValidator() : base()
		{
			RuleFor(current => current.ApplicationName)
				.NotNull()
				.WithErrorCode(errorCode: "10")
				.WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)

				.NotEmpty()
				.WithErrorCode(errorCode: "11")
				.WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)
				;
		}
	}
}
