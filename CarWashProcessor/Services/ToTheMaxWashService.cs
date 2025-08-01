﻿using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public class ToTheMaxWashService : IWashService, IWashType
{
	private readonly ILogger<ToTheMaxWashService> _logger;

	public EServiceWash WashType => EServiceWash.ToTheMax;

	public ToTheMaxWashService(ILogger<ToTheMaxWashService> logger)
	{
		// Set services
		_logger = logger;
	}

	public async Task DoServiceAsync(CarJob carJob)
	{
		// Wait a second
		await Task.Delay(TimeSpan.FromSeconds(1));
		// Log information
		_logger.LogInformation("--> To The Max wash performed for customer {}!", carJob.CustomerId);
	}
}
