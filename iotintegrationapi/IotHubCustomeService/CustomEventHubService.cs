using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using MongoDB.Driver.Core.Configuration;
using System.Text;

public class CustomEventHubService : ICustomEventHubService
{

    private readonly AppSettings _appSettings;
    public CustomEventHubService(AppSettings appSettings)
    {
        _appSettings = appSettings;
        //registryManager = RegistryManager.CreateFromConnectionString(_appSettings.IotHUbConnectionString);
    }
    public async Task<bool> PublishToCustomEndpoint(string Data)
    {
        // The Event Hubs client types are safe to cache and use as a singleton for the lifetime
        // of the application, which is best practice when events are being published or read regularly.
        // TODO: Replace the <CONNECTION_STRING> and <HUB_NAME> placeholder values
        string connectionSubstring = _appSettings.CustomEventHubConnectionString.Substring(0, _appSettings.CustomEventHubConnectionString.LastIndexOf(';'));
        string eventHubName = _appSettings.CustomEventHubConnectionString.Substring(_appSettings.CustomEventHubConnectionString.LastIndexOf('=') + 1);
        EventHubProducerClient producerClient = new EventHubProducerClient(
            connectionSubstring,
            eventHubName);

        // Create a batch of events 
        using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
        if (!eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"{Data}"))))
        {
            // if it is too large for the batch
            throw new Exception($"Event {Data} is too large for the batch and cannot be sent.");
        }

        try
        {
            // Use the producer client to send the batch of events to the event hub
            await producerClient.SendAsync(eventBatch);
            Console.WriteLine($"{Data} events has been published.");
            return true;
        }
        finally
        {
            await producerClient.DisposeAsync();
        }
        
    }
}