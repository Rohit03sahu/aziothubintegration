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
            var geoPosition = event.body.message;
            setgeoPosition(geoPosition);
            console.log(geoPosition);
          }
        },
        processError: async (err, context) => {
          console.log(`Error : ${err}`);
        },
      });
    };
  
    useEffect(() => {
        getGeoPosition().catch((error) => {
        console.error("Error running Azure Iot Hub Processor:", error);
      });
      return () => {
        // cleanUpFunction if applicable
        // consumerClient.unsubscribe()
      };
    }, []);
  
    return (
      <div className="environment">
        <p>The GeoPosition is {geoPosition}.</p>
      </div>
    );
  };