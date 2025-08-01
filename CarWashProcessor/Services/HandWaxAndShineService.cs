﻿using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public class HandWaxAndShineService : IWashService, IAddonType
{
	private readonly ILogger<HandWaxAndShineService> _logger;

	public EServiceAddon AddonType => EServiceAddon.HandWaxAndShine;

	public HandWaxAndShineService(ILogger<HandWaxAndShineService> logger)
	{
		// Set services
		_logger = logger;
	}

	public async Task DoServiceAsync(CarJob carJob)
	{
		// Wait a second
		await Task.Delay(TimeSpan.FromSeconds(1));
		// Log information
		_logger.LogInformation("--> Hand waxed and shined for customer {}!", carJob.CustomerId);
	}
}
