using FluentValidation;

namespace LoggingMicroservice.Application.LogsFeature.Validations
{
	public class CreateLogCommandValidation :
		FluentValidation.AbstractValidator<Commands.CreateLogCommand>
	{
		public CreateLogCommandValidation() : base()
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
