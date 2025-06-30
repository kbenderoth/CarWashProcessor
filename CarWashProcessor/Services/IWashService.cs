using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public interface IWashService
{ 
    Task DoServiceAsync(CarJob carJob);
}