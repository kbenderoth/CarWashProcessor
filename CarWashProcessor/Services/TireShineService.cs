using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public class TireShineService : IWashService, IAddonType
{
	private readonly ILogger<TireShineService> _logger;

	public EServiceAddon AddonType => EServiceAddon.TireShine;

	public TireShineService(ILogger<TireShineService> logger)
	{
		// Set services
		_logger = logger;
	}

	public async Task DoServiceAsync(CarJob carJob)
	{
		// Wait a second
		await Task.Delay(TimeSpan.FromSeconds(1));
		// Log information
		_logger.LogInformation("--> Tires have been shined for customer {}!", carJob.CustomerId);
	}
}
