using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using SharpCompress.Common;
using iotintegrationconsumers.Model;
using System.Linq;

public class DBLayer:IDBLayer
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

    public Location GetLocation(){
        MongoCollection Location  = _mongoDatabase.GetCollection<Location>("Location");
        var loc = Location.AsQueryable<Location>().AsQueryable().OrderByDescending(c => c.CreatedDateTime).FirstOrDefault(); 
        return loc;
    }

     public bool SaveLocation(Location location)
    {
        MongoCollection Location = _mongoDatabase.GetCollection<Location>("Location"); ;
        Location.Save(location);
        return true;
     }
}


