﻿using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public class AwesomeWashService : IWashService, IWashType
{
	private readonly ILogger<AwesomeWashService> _logger;

	public EServiceWash WashType => EServiceWash.Awesome;

	public AwesomeWashService(ILogger<AwesomeWashService> logger)
	{
		// Set services
		_logger = logger;
	}

	public async Task DoServiceAsync(CarJob carJob)
	{
		// Wait a second
		await Task.Delay(TimeSpan.FromSeconds(1));
		// Log information
		_logger.LogInformation("--> Awesome wash performed for customer {}!", carJob.CustomerId);
	}
}
