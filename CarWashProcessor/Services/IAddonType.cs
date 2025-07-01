using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public interface IAddonType
{
    EServiceAddon AddonType { get; }
}