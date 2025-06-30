﻿using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public class InteriorCleanService
{
	private readonly ILogger<InteriorCleanService> _logger;

	public InteriorCleanService(ILogger<InteriorCleanService> logger)
	{
		// Set services
		_logger = logger;
	}

	public async Task CleanInteriorAsync(CarJob carJob)
	{
		// Wait a second
		await Task.Delay(TimeSpan.FromSeconds(1));
		// Log information
		_logger.LogInformation("--> Interior has been cleaned for customer {}!", carJob.CustomerId);
	}
}
