using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public class BasicWashService : IWashService, IWashType
{
	private readonly ILogger<BasicWashService> _logger;
	
	public EServiceWash WashType => EServiceWash.Basic;

	public BasicWashService(ILogger<BasicWashService> logger)
	{
		// Set services
		_logger = logger;
	}

	public async Task DoServiceAsync(CarJob carJob)
	{
		// Wait a second
		await Task.Delay(TimeSpan.FromSeconds(1));
		// Log information
		_logger.LogInformation("--> Basic wash performed for customer {}!", carJob.CustomerId);
	}
}
