namespace HttpClientFactoryMiddleware.MessageRetrievers
{
	public class SimpleHttpMessageRetriever:IMessageRetriever<IMessageContent,Guid>
	{
		public async Task<IMessageContent> GetMessage(HttpRequestMessage request, HttpResponseMessage? response)
		{
			string requestMessage = request.Content.ToString();
			string responseMessage = request.Content.ToString();

			var content = new MessageContent(requestMessage, responseMessage);

			return content;
		}

		public async Task<Guid> GetLogId(HttpRequestMessage request)
		{
			return Guid.NewGuid();
		}
	}
}