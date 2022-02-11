namespace HttpClientFactoryMiddlewareDemo
{
	using HttpClientFactoryMiddleware.Handlers;
	using HttpClientFactoryMiddleware.MessageRetrievers;
	using HttpClientFactoryMiddleware.Writers;
	using Microsoft.Extensions.Hosting;
	using HttpClientFactoryMiddleware;
	using Microsoft.Extensions.DependencyInjection;
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			IHostBuilder host = Host.CreateDefaultBuilder(args);
			host.ConfigureServices((context, collection) =>
			{
				collection.AddScoped<IWriter<string, string>, DoNothingWriter<string, string>>();
				collection.AddScoped<IMessageRetriever<IMessageContent, Guid>, SimpleHttpMessageRetriever>();
				collection.AddHttpClient("myClient")
					.AddHttpMessageHandler<FeatureLogger>()
					.AddHttpMessageHandler<ErrorLogger>();
			});
		}
	}
}