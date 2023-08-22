using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using SharpCompress.Common;
using System.Linq;
using iotintegrationapi.Model;
using Microsoft.EntityFrameworkCore;

public class DBLayer : IDBLayer
{
    private readonly AppSettings _appSettings;
    private readonly MongoClient _mongoClient;
    private readonly MongoServer _mongoServer;
    private readonly MongoDatabase _mongoDatabase;


    public DBLayer(AppSettings appSettings, ILogger<DBLayer> logger)
    {
        _appSettings = appSettings;
        var MongoConnectionString = _appSettings.MongoConnectionString;
        _mongoClient = new MongoClient(MongoConnectionString);
        _mongoServer = _mongoClient.GetServer();
        _mongoDatabase = _mongoServer.GetDatabase("GPS");

    }

    public List<Location> GetLocation(string DeviceId, int RecordCount)
    {
        MongoCollection Location = _mongoDatabase.GetCollection<Location>("Location");
        var loc = Location.AsQueryable<Location>().AsQueryable().Where(x => x.DeviceId == DeviceId).OrderByDescending(c => c.CreatedDateTime).Take(RecordCount).ToList();
        return loc;
    }

    public bool SaveLocation(Location location)
    {
        MongoCollection Location = _mongoDatabase.GetCollection<Location>("Location"); ;
        Location.Save(location);
        return true;
    }
}


