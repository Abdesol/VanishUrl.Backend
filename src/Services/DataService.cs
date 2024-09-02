using VanishUrl.Api.Services.Interfaces;

namespace VanishUrl.Api.Services;

public class DataService : IDataService
{
    /// <inheritdoc />
    public async Task<bool> DoesIdExist(string id)
    {
        return false;
    }

    /// <inheritdoc />
    public async Task<string> GetData(string id)
    {
        return "";
    }

    /// <inheritdoc />
    public async Task<string> SetData(string data)
    {
        return "";
    }
}