using CarWashProcessor.Models;

namespace CarWashProcessor.Services;

public interface IWashType
{
    EServiceWash WashType { get; }
}