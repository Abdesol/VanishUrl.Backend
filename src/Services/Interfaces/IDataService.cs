namespace VanishUrl.Api.Services.Interfaces;

/// <summary>
/// Interface for the data service.
/// </summary>
public interface IDataService
{
    /// <summary>
    /// Checks if the given id exists in the data store.
    /// </summary>
    /// <param name="id">The id to check.</param>
    /// <returns>True if the id exists, false otherwise.</returns>
    public Task<bool> DoesIdExist(string id);
    
    /// <summary>
    /// Gets the data for the given id from the data store.
    /// </summary>
    /// <param name="id">The id to get the data for.</param>
    /// <returns>The data for the given id.</returns>
    public Task<string> GetData(string id);
    
    /// <summary>
    /// Sets the given data in the data store and returns the id for the data.
    /// </summary>
    /// <param name="data">The data to set.</param>
    /// <returns>The id for the data.</returns>
    public Task<string> SetData(string data);
}