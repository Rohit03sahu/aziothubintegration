const GeoPosition = () => {
    const [geoPosition, setGeoPosition] = useState();
    const consumerClient = new EventHubConsumerClient(
      "$Default",
      connectionString,
      clientOptions
    );
  
    const getGeoPosition = async () => {
      consumerClient.subscribe({
        processEvents: async (events, context) => {
          for (const event of events) {
            var temperature = event.body.temperature;
            var humidity = event.body.humidity;
            setTemperature(temperature);
            console.log(temperature);
            console.log(humidity);
          }
        },
        processError: async (err, context) => {
          console.log(`Error : ${err}`);
        },
      });
    };
  
    useEffect(() => {
      getTemperature().catch((error) => {
        console.error("Error running sample:", error);
      });
      return () => {
        // cleanUpFunction if applicable
        // consumerClient.unsubscribe()
      };
    }, []);
  
    return (
      <div className="environment">
        <p>The GeoPosition is {geoPosition}&#176; Celcius.</p>
      </div>
    );
  };