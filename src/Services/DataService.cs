using System.Net;
using Microsoft.Azure.Cosmos;
using VanishUrl.Api.Services.Interfaces;

namespace VanishUrl.Api.Services;

public class DataService : IDataService
{
    private readonly Container _container;

    public DataService(IConfiguration configuration, CosmosClient cosmosClient)
    {
        var cosmosDatabaseId = configuration["COSMOS_DB_DATABASE"]!;
        var cosmosContainerId = configuration["COSMOS_DB_CONTAINER"]!;
        
        var database = cosmosClient.GetDatabase(cosmosDatabaseId);
        _container = database.GetContainer(cosmosContainerId);
    }

    /// <inheritdoc />
    public async Task<string?> GetData(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<dynamic>(id, new PartitionKey(id));
            return response.Resource["data"];
        }
        catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    /// <inheritdoc />
    public async Task<string> SetData(string data)
    {
        var id = GenerateId(6);
        var item = new
        {
            id,
            data
        };
        await _container.CreateItemAsync(item, new PartitionKey(id));
        return id;
    }

    /// <inheritdoc />
    public async Task RemoveData(string id)
    {
        await _container.DeleteItemAsync<dynamic>(id, new PartitionKey(id));
    }

    private static string GenerateId(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}