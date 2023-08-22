using iotintegrationapi.Model;

public interface IDBLayer
{
    public List<Location> GetLocation(string DeviceId, int RecordCount);
    public bool SaveLocation(Location location);
}