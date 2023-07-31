const { EventHubConsumerClient, earliestEventPosition } = require("@azure/event-hubs");

async function main() {
  const client = new EventHubConsumerClient(
    "my-consumer-group",
    "connectionString",
    "eventHubName"
  );

  // In this sample, we use the position of earliest available event to start from
  // Other common options to configure would be `maxBatchSize` and `maxWaitTimeInSeconds`
  const subscriptionOptions = {
    startPosition: earliestEventPosition
  };

  const subscription = client.subscribe(
    {
      processEvents: async (events, context) => {
        // event processing code goes here
      },
      processError: async (err, context) => {
        // error reporting/handling code here
      }
    },
    subscriptionOptions
  );

  // Wait for a few seconds to receive events before closing
  setTimeout(async () => {
    await subscription.close();
    await client.close();
    console.log(`Exiting sample`);
  }, 3 * 1000);
}

main();