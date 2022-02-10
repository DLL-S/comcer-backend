using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DLLS.Comcer.API
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.ConfigureKestrel(x =>
					{
						x.ListenAnyIP(5000);
						x.ListenAnyIP(5001);
					}
					).UseStartup<Startup>();
				});
	}
}
