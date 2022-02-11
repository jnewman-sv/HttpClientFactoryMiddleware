namespace HttpClientFactoryMiddleware.Handlers
{
	public class ErrorLogger:DelegatingHandler
	{
		private readonly IMessageRetriever<string, string> _messageRetriever;
		private readonly IWriter<string, string> _writer;

		public ErrorLogger(IMessageRetriever<string, string> messageRetriever,IWriter<string,string> writer)
		{
			_messageRetriever = messageRetriever;
			_writer = writer;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			HttpResponseMessage? response = null;
			try
			{
				response = await base.SendAsync(request, cancellationToken);
			}
			catch (Exception e)
			{
				Task<string> message = _messageRetriever.GetMessage(request, response);
				Task<string> logId = _messageRetriever.GetLogId(request);
				await _writer.WriteMessageAsync($"{e.Message} \n\n {await message}", await logId, cancellationToken);

				throw;
			}

			return response;
		}
	}
}