namespace HttpClientFactoryMiddleware
{
	public interface IMessageContent
	{
		public string requestMessage { set; }
		public string responseMessage { set; }
		public string combinedMessage { get;}
	}

	public class MessageContent:IMessageContent
	{
		public MessageContent(string requestMessage, string responseMessage)
		{
			this.requestMessage = requestMessage;
			this.responseMessage = responseMessage;
		}

		public string requestMessage { private get; set; }
		public string responseMessage { private get; set; }
		public string combinedMessage => $"Request:\n{requestMessage} \n\n Response:\n{responseMessage}";
	}
}