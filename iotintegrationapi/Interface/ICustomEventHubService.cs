public interface ICustomEventHubService{
    Task<bool> PublishToCustomEndpoint(string Data);
}