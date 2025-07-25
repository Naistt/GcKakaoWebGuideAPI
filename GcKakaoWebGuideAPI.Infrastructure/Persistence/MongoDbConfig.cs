using GcKakaoWebGuideAPI.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GcKakaoWebGuideAPI.Infrastructure.Persistence;

public class MongoDbConfig
{
    private readonly IMongoDatabase _database;

    public MongoDbConfig(IOptions<MongoSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Usuario> Usuarios => _database.GetCollection<Usuario>("Usuarios");
    public IMongoCollection<Heroi> Herois => _database.GetCollection<Heroi>("Herois");

}

public class MongoSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;

}
