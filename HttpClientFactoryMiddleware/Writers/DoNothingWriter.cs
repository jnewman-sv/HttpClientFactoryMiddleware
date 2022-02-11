namespace HttpClientFactoryMiddleware.Writers
{
	public class DoNothingWriter<T,TZ>:IWriter<T,TZ>
	{
		public async Task WriteMessageAsync(T message, TZ logId, CancellationToken token)
		{
			Console.WriteLine("Doing nothing with the log message");
		}
	}
}