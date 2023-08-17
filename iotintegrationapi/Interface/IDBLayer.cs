using iotintegrationapi.Model;

public interface IDBLayer
{
    public Location GetLocation(string DeviceId);
    public bool SaveLocation(Location location);
}