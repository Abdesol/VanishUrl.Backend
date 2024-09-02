namespace VanishUrl.Api.Services.Interfaces;

/// <summary>
/// Interface for the data service.
/// </summary>
public interface IDataService
{
    /// <summary>
    /// Gets the data for the given id from the data store.
    /// </summary>
    /// <param name="id">The id to get the data for.</param>
    /// <returns>The data for the given id or null if it doesn't exist</returns>
    public Task<string?> GetData(string id);
    
    /// <summary>
    /// Sets the given data in the data store and returns the id for the data.
    /// </summary>
    /// <param name="data">The data to set.</param>
    /// <returns>The id for the data.</returns>
    public Task<string> SetData(string data);

    /// <summary>
    /// Removes the data for the given id from the database
    /// </summary>
    /// <param name="id">The id to remove the data for</param>
    public Task RemoveData(string id);
}