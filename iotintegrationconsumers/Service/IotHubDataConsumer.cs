using System.Text;
using Azure.Messaging.EventHubs.Consumer;

public class IotHubDataConsumer : IIotHubDataConsumer
{

    // private const string EventHubsCompatibleEndpoint = "TODO: az iot hub show --query properties.eventHubEndpoints.events.endpoint --name {hubname}";
    // private const string EventHubsCompatiblePath = "TODO: {hubname}";
    // private const string IotHubSasKey = "TODO: az iot hub policy show --name service --query primaryKey --hub-name {hubname}";


    private readonly AppSettings _appSettings;
    // private const string EventHubsCompatibleEndpoint = _appSettings.DefaultEventHub.EventHubsCompatibleEndpoint;// "Endpoint=sb://iothub-ns-iothubdevi-25136667-c95c8ebe56.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=r0uGKCJTJSbCxhug5MIa3piuJD+jOWbtTimS1CbkWHU=;EntityPath=iothubdeviceintegration";
    // private const string EventHubsCompatiblePath = _appSettings.DefaultEventHub.EventHubsCompatiblePath;// "iothubdeviceintegration";
    // private const string IotHubSasKey = _appSettings.DefaultEventHub.IotHubSasKey; // "c8GEFarOpvWGq3pKjqkf3b/yh32kA2ArIcNoYFki434=";
    // private const string ConsumerGroup = _appSettings.DefaultEventHub.ConsumerGroup; // "$Default";
    private EventHubConsumerClient eventHubConsumerClient = null;
    public IotHubDataConsumer(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }
    public async Task DefaultEndpointSetup()
    {
        string eventHubConnectionString = $"Endpoint=sb://iothub-ns-iothubdevi-25136667-c95c8ebe56.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=r0uGKCJTJSbCxhug5MIa3piuJD+jOWbtTimS1CbkWHU=;EntityPath=iothubdeviceintegration";

        //Console.WriteLine($"_appSettings.DefaultEventHub.ConsumerGroup {_appSettings.DefaultEventHub.ConsumerGroup}");
        eventHubConsumerClient = new EventHubConsumerClient(_appSettings.DefaultEventHub.ConsumerGroup, eventHubConnectionString);

        var tasks = new List<Task>();
        var partitions = await eventHubConsumerClient.GetPartitionIdsAsync();
        //Console.WriteLine($"Partitions count : {partitions.Count}");
        foreach (string partition in partitions)
        {
            Console.WriteLine($"Partition Name : {partition}");
            tasks.Add(ReceiveMessagesFromDeviceAsync(partition));
        }
    }

    public async Task ReceiveMessagesFromDeviceAsync(string partitionId)
    {
        Console.WriteLine($"Starting listener thread for partition: {partitionId}");
        while (true)
        {
            await foreach (PartitionEvent receivedEvent in eventHubConsumerClient.ReadEventsFromPartitionAsync(partitionId, EventPosition.Latest))
            {
                string msgSource;
                string body = Encoding.UTF8.GetString(receivedEvent.Data.Body.ToArray());
                if (receivedEvent.Data.SystemProperties.ContainsKey("iothub-message-source"))
                {
                    msgSource = receivedEvent.Data.SystemProperties["iothub-message-source"].ToString();
                    Console.WriteLine($"IOT HUB Received Message partitionId : {partitionId} | Message Source : {msgSource} | Message : {body}");
                }
            }
        }
    }

}




#region Second Options


// using System;  
// using System.Text;
// using System.Threading.Tasks;
// using Azure.Storage.Blobs;
// using Azure.Messaging.EventHubs;
// using Azure.Messaging.EventHubs.Consumer;
// using Azure.Messaging.EventHubs.Processor;

// namespace DotnetService
// {
//     class Program
//     {
//         private const string ehubNamespaceConnectionString = "Endpoint=sb://...";
//         private const string eventHubName = "{iothubname}";
//         private const string blobStorageConnectionString = "DefaultEndpointsProtocol=...";
//         private const string blobContainerName = "{storagename}";

//         private  Task initializeEventHandler(PartitionInitializingEventArgs arg)
//         {
//             arg.DefaultStartingPosition = EventPosition.Latest;
//             return Task.CompletedTask;
//         }

//          async Task ProcessEventHandler(ProcessEventArgs eventArgs)
//         {
//             Console.WriteLine("\tReceived event: {0}", Encoding.UTF8.GetString(eventArgs.Data.Body.ToArray()));
//             await eventArgs.UpdateCheckpointAsync(eventArgs.CancellationToken);
//         }

//          Task ProcessErrorHandler(ProcessErrorEventArgs eventArgs)
//         {
//             Console.WriteLine($"\tPartition '{ eventArgs.PartitionId}': an unhandled exception was encountered.");
//             Console.WriteLine(eventArgs.Exception.Message);
//             return Task.CompletedTask;
//         }

//          async Task Main()
//         {
//             BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);
//             EventProcessorClient processor = new EventProcessorClient(storageClient, EventHubConsumerClient.DefaultConsumerGroupName, ehubNamespaceConnectionString, eventHubName);

//             processor.PartitionInitializingAsync += initializeEventHandler;
//             processor.ProcessEventAsync += ProcessEventHandler;
//             processor.ProcessErrorAsync += ProcessErrorHandler;

//             await processor.StartProcessingAsync();
//             Console.ReadLine();
//         }
//     }
// }

#endregion