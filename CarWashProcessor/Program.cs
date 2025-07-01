using System.Reflection;
using System.Runtime.CompilerServices;
using CarWashProcessor.Services;

namespace CarWashProcessor;

public class Program
{
	public static void Main(string[] args)
	{
		// Create builder
		var builder = Host.CreateApplicationBuilder(args);
		// Configure logging
		builder.Logging.AddSystemdConsole();
		// Register services
		builder.Services.AddHostedService<Worker>();
		builder.Services.AddSingleton<CarJobService>();
		_RegisterServices(builder.Services);
		// Build and run host
		var host = builder.Build();
		host.Run();
	}

	private static void _RegisterServices(IServiceCollection services)
	{
		// Register services
		services.AddSingleton<CarJobProcessorService>();
		
		// Search through the assembly for instances of IWashService
		var washServices = Assembly.GetExecutingAssembly()
			.GetTypes()
			.Where(p=>!p.IsAbstract && !p.IsInterface && typeof(IWashService).IsAssignableFrom(p));

		foreach (var washService in washServices)
		{
			services.AddSingleton(typeof(IWashService), washService);
		}
	}
}
