namespace Dtx.Logging
{
	public class Log : object, ILog
	{
		public Log() : base()
		{
		}

		public LogLevel Level { get; set; }



		public string Namespace { get; set; }

		public string ClassName { get; set; }

		public string MethodName { get; set; }



		public string RemoteIP { get; set; }

		public string Username { get; set; }

		public string RequestPath { get; set; }

		public string HttpReferrer { get; set; }



		public string Message { get; set; }

		public string Parameters { get; set; }

		public string Exceptions { get; set; }

		public override string ToString()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

			//stringBuilder.Append($"<Level>{ Level }</Level>");

			stringBuilder.Append($"<{ nameof(Level) }>{ Level }</{ nameof(Level) }>");



			if (string.IsNullOrWhiteSpace(Namespace))
			{
				stringBuilder.Append($"<{ nameof(Namespace) }>NULL</{ nameof(Namespace) }>");
			}
			else
			{
				stringBuilder.Append($"<{ nameof(Namespace) }>{ Namespace }</{ nameof(Namespace) }>");
			}

			if (string.IsNullOrWhiteSpace(ClassName))
			{
				stringBuilder.Append($"<{ nameof(ClassName) }>NULL</{ nameof(ClassName) }>");
			}
			else
			{
				stringBuilder.Append($"<{ nameof(ClassName) }>{ ClassName }</{ nameof(ClassName) }>");
			}

			if (string.IsNullOrWhiteSpace(MethodName))
			{
				stringBuilder.Append($"<{ nameof(MethodName) }>NULL</{ nameof(MethodName) }>");
			}
			else
			{
				stringBuilder.Append($"<{ nameof(MethodName) }>{ MethodName }</{ nameof(MethodName) }>");
			}



			if (string.IsNullOrWhiteSpace(RemoteIP))
			{
				stringBuilder.Append($"<{ nameof(RemoteIP) }>NULL</{ nameof(RemoteIP) }>");
			}
			else
			{
				stringBuilder.Append($"<{ nameof(RemoteIP) }>{ RemoteIP }</{ nameof(RemoteIP) }>");
			}

			if (string.IsNullOrWhiteSpace(RequestPath))
			{
				stringBuilder.Append($"<{ nameof(RequestPath) }>NULL</{ nameof(RequestPath) }>");
			}
			else
			{
				stringBuilder.Append($"<{ nameof(RequestPath) }>{ RequestPath }</{ nameof(RequestPath) }>");
			}

			if (string.IsNullOrWhiteSpace(HttpReferrer))
			{
				stringBuilder.Append($"<{ nameof(HttpReferrer) }>NULL</{ nameof(HttpReferrer) }>");
			}
			else
			{
				stringBuilder.Append($"<{ nameof(HttpReferrer) }>{ HttpReferrer }</{ nameof(HttpReferrer) }>");
			}

			if (string.IsNullOrWhiteSpace(Username))
			{
				stringBuilder.Append($"<{ nameof(Username) }>NULL</{ nameof(Username) }>");
			}
			else
			{
				stringBuilder.Append($"<{ nameof(Username) }>{ Username }</{ nameof(Username) }>");
			}



			if (string.IsNullOrWhiteSpace(Message))
			{
				stringBuilder.Append($"<{ nameof(Message) }>NULL</{ nameof(Message) }>");
			}
			else
			{
				stringBuilder.Append($"<{ nameof(Message) }>{ Message }</{ nameof(Message) }>");
			}

			if (string.IsNullOrWhiteSpace(Exceptions))
			{
				stringBuilder.Append($"<{ nameof(Exceptions) }>NULL</{ nameof(Exceptions) }>");
			}
			else
			{
				stringBuilder.Append($"<{ nameof(Exceptions) }>{ Exceptions }</{ nameof(Exceptions) }>");
			}

			if (string.IsNullOrWhiteSpace(Parameters))
			{
				stringBuilder.Append($"<{ nameof(Parameters) }>NULL</{ nameof(Parameters) }>");
			}
			else
			{
				stringBuilder.Append($"<{ nameof(Parameters) }>{ Parameters }</{ nameof(Parameters) }>");
			}

			string result =
				stringBuilder.ToString();

			return result;
		}
	}
}
