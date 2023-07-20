using System.Text;
using Azure.Messaging.EventHubs.Consumer;

public interface IIotHubDataConsumer
{
    public Task DefaultEndpointSetup();
    public Task ReceiveMessagesFromDeviceAsync(string partitionId);
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

//         private static Task initializeEventHandler(PartitionInitializingEventArgs arg)
//         {
//             arg.DefaultStartingPosition = EventPosition.Latest;
//             return Task.CompletedTask;
//         }

//         static async Task ProcessEventHandler(ProcessEventArgs eventArgs)
//         {
//             Console.WriteLine("\tReceived event: {0}", Encoding.UTF8.GetString(eventArgs.Data.Body.ToArray()));
//             await eventArgs.UpdateCheckpointAsync(eventArgs.CancellationToken);
//         }

//         static Task ProcessErrorHandler(ProcessErrorEventArgs eventArgs)
//         {
//             Console.WriteLine($"\tPartition '{ eventArgs.PartitionId}': an unhandled exception was encountered.");
//             Console.WriteLine(eventArgs.Exception.Message);
//             return Task.CompletedTask;
//         }

//         static async Task Main()
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