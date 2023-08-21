using System.Text;
using Azure.Messaging.EventHubs.Consumer;
using iotintegrationconsumers.Model;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

public class IotHubDataConsumer : IIotHubDataConsumer
{

    // private const string EventHubsCompatibleEndpoint = "TODO: az iot hub show --query properties.eventHubEndpoints.events.endpoint --name {hubname}";
    // private const string EventHubsCompatiblePath = "TODO: {hubname}";
    // private const string IotHubSasKey = "TODO: az iot hub policy show --name service --query primaryKey --hub-name {hubname}";


    private readonly AppSettings _appSettings;
    private readonly IDBLayer _dBLayer;
    private EventHubConsumerClient eventHubConsumerClient = null;
    public IotHubDataConsumer(AppSettings appSettings, IDBLayer dBLayer)
    {
        _appSettings = appSettings;
        _dBLayer = dBLayer;
    }
    public async Task DefaultEndpointSetup()
    {
        //Console.WriteLine($"_appSettings.DefaultEventHub.ConsumerGroup {_appSettings.DefaultEventHub.ConsumerGroup}");
        if(_appSettings.IsDefaultEventHubEnable)
            eventHubConsumerClient = new EventHubConsumerClient(_appSettings.DefaultEventHub.ConsumerGroup, _appSettings.DefaultEventHub.EventHubsCompatibleEndpoint);
        else
            eventHubConsumerClient = new EventHubConsumerClient(_appSettings.CustomEventHub.ConsumerGroup, _appSettings.CustomEventHub.EventHubsCompatibleEndpoint);

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
                    var hubData = JsonConvert.DeserializeObject<HubModel>(body);
                    if (hubData != null)
                    {
                        try
                        {
                            var messageData = JsonConvert.DeserializeObject<DeviceLocation>(hubData.Payload);
                            Location location= new Location() 
                            { 
                                CreatedDateTime= messageData.CreatedDateTime,
                                DeviceId= messageData.DeviceId,
                                DeviceName= messageData.DeviceName,
                                Lat=messageData.Lat, 
                                Long=messageData.Long
                            };    
                            _dBLayer.SaveLocation(location);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Exception | StackTrace: {ex.Message} | {ex.StackTrace}");
                        }
                    }
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