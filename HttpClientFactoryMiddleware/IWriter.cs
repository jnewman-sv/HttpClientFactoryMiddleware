namespace HttpClientFactoryMiddleware
{
	public interface IWriter<in T, in TZ>
	{
		Task WriteMessageAsync(T message, TZ logId, CancellationToken token);
	}
}