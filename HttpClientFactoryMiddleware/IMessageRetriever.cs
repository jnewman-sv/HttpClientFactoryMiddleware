namespace HttpClientFactoryMiddleware
{
	public interface IMessageRetriever<T,TZ>
	{
		public Task<T> GetMessage(HttpRequestMessage request, HttpResponseMessage? response);
		public Task<TZ> GetLogId(HttpRequestMessage request);
	}
}