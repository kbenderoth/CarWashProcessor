using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public class CarJobProcessorService
{
	private readonly Dictionary<EServiceWash, IWashService> _washServices;
	private readonly Dictionary<EServiceAddon, IWashService> _addOnServices;

	public CarJobProcessorService(IEnumerable<IWashService> washServices)
	{
		// Set services
		_washServices = new Dictionary<EServiceWash, IWashService>();
		_addOnServices = new Dictionary<EServiceAddon, IWashService>();

		InitWashServices(washServices);

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

	private void InitWashServices(IEnumerable<IWashService> washServices)
	{
		foreach (var wash in washServices)
		{
			if (wash is IWashType washType)
				_washServices[washType.WashType] = wash;
			else if (wash is IAddonType addonType)
				_addOnServices[addonType.AddonType] = wash;
		}
	}
}
