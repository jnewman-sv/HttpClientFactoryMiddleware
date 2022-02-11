namespace HttpClientFactoryMiddleware.Handlers
{
	public class FeatureLogger:DelegatingHandler
	{
		private readonly IMessageRetriever<MessageContent, Guid> _messageRetriever;
		private readonly IWriter<string, string> _writer;

		public FeatureLogger(IMessageRetriever<MessageContent, Guid> messageRetriever,IWriter<string,string> writer)
		{
			_messageRetriever = messageRetriever;
			_writer = writer;
		}
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			HttpResponseMessage? response = await base.SendAsync(request, cancellationToken);
			MessageContent message = await _messageRetriever.GetMessage(request, response);
			Guid logId = await _messageRetriever.GetLogId(request);

			await _writer.WriteMessageAsync(message.combinedMessage, logId.ToString(), cancellationToken);

			return response;
		}
	}
}