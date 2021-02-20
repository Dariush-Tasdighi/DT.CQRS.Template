namespace LoggingMicroservice.Application
{
	internal static class Utility
	{
		static Utility()
		{
		}

		public
			static
			async
			System.Threading.Tasks.Task
			Validate<TCommand>
			(FluentValidation.AbstractValidator<TCommand> validator, TCommand command, FluentResults.Result result)
		{
			FluentValidation.Results.ValidationResult
				validationResult = await validator.ValidateAsync(instance: command);

			if (validationResult.IsValid == false)
			{
				foreach (var error in validationResult.Errors)
				{
					result.WithError(errorMessage: error.ErrorMessage);
				}
			}
		}
	}
}
