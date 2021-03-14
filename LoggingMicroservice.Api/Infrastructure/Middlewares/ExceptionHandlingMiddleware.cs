using Microsoft.AspNetCore.Http;

namespace LoggingMicroservice.Api.Infrastructure.Middlewares
{
	public class ExceptionHandlingMiddleware : object
	{
		public ExceptionHandlingMiddleware
			(Microsoft.AspNetCore.Http.RequestDelegate next) : base()
		{
			Next = next;
		}

		protected Microsoft.AspNetCore.Http.RequestDelegate Next { get; }

		public
			async
			System.Threading.Tasks.Task
			InvokeAsync(Microsoft.AspNetCore.Http.HttpContext context)
		{
			try
			{
				await Next(context);
			}
			catch (System.Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private
			static
			System.Threading.Tasks.Task HandleExceptionAsync
			(Microsoft.AspNetCore.Http.HttpContext context, System.Exception exception)
		{
			FluentResults.Result result = new FluentResults.Result();

			FluentValidation.ValidationException
				validationException = exception as FluentValidation.ValidationException;

			if (validationException != null)
			{
				var code =
					System.Net.HttpStatusCode.BadRequest;

				context.Response.StatusCode = (int)code;
				context.Response.ContentType = "application/json";

				foreach (var error in validationException.Errors)
				{
					result.WithError(error.ErrorMessage);
				}
			}
			else
			{
				// Log Error!

				var code =
					System.Net.HttpStatusCode.InternalServerError;

				context.Response.StatusCode = (int)code;
				context.Response.ContentType = "application/json";

				result.WithError("Internal Server Error!");
			}

			var options = new System.Text.Json.JsonSerializerOptions
			{
				IncludeFields = true,
				PropertyNamingPolicy =
					System.Text.Json.JsonNamingPolicy.CamelCase,
			};

			string resultString =
				System.Text.Json.JsonSerializer.Serialize(value: result, options: options);

			return context.Response.WriteAsync(resultString);
		}
	}
}
