using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public class CarJobProcessorService
{
	private readonly Dictionary<EServiceWash, IWashService> _washServices;
	private readonly Dictionary<EServiceAddon, IWashService> _addOnServices;

	public CarJobProcessorService(
		BasicWashService basicWashService,
		AwesomeWashService awesomeWashService,
		ToTheMaxWashService toTheMaxWashService,
		TireShineService tireShineService,
		InteriorCleanService interiorCleanService,
		HandWaxAndShineService handWaxAndShineService
	)
	{
		// Set services
		_washServices = new Dictionary<EServiceWash, IWashService>
		{
			[EServiceWash.Basic] = basicWashService,
			[EServiceWash.Awesome] = awesomeWashService,
			[EServiceWash.ToTheMax] = toTheMaxWashService
		};
		_addOnServices = new Dictionary<EServiceAddon, IWashService>
		{
			[EServiceAddon.TireShine] = tireShineService,
			[EServiceAddon.InteriorClean] = interiorCleanService,
			[EServiceAddon.HandWaxAndShine] = handWaxAndShineService
		};
	}

	public async Task ProcessCarJobAsync(CarJob carJob)
	{
		// Check wash service
		try
		{
			await _washServices[carJob.ServiceWash].DoServiceAsync(carJob);
		}
		catch (KeyNotFoundException)
		{
			throw new KeyNotFoundException($"Wash service ({carJob.ServiceWash}) not recognized.");
		}
		
		// Check for addons
		foreach (var addons in carJob.ServiceAddons)
		{
			try
			{
				await _addOnServices[addons].DoServiceAsync(carJob);
			}
			catch (KeyNotFoundException)
			{
				throw new KeyNotFoundException($"Addon ({addons}) not recognized.");
			}
		}
	}
}
