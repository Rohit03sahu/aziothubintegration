using iotintegrationconsumers.Model;

public interface IDBLayer{
    public Location GetLocation();
    public bool SaveLocation(Location location);
}