import React, { Component,useState,useEffect  } from "react";
import L, { LatLngExpression } from "leaflet";
import DeviceMap from "../DeviceIntegrationJS/DeviceMap";
function DeviceLocation() {

    const [lat, setlat] = useState('26.912434');
    const [lng, setlng] = useState('75.787270');
    const [locationData, setlocationData] = useState([]);
    const [isSubmit, setisSubmit] = useState(true);
    const [deviceId, setdeviceId] = useState('iot-device-001');
    const setlathandleChange = event => {
        setlat(event.target.value);
        console.log('lat value is:', event.target.value);
    };

    const setlnghandleChange = event => {
        setlng(event.target.value);
        console.log('lng value is:', event.target.value);
    };

    const onSubmit = event => {
        //setisSubmit(!isSubmit);
        //setdeviceId(deviceId);
    };

    useEffect(() => {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'application/json');
        headers.append('Access-Control-Allow-Origin', 'http://localhost:3001');
        headers.append('Access-Control-Allow-Credentials', 'true');
        headers.append('GET', 'POST', 'OPTIONS');
        let _deviceName=deviceId;
        let interval = setInterval(async () => {
            fetch('http://gpsapp.centralindia.cloudapp.azure.com:4002/api/device-location?DeviceId=' + _deviceName +'&recordcount=5').then((response) => {
                if (response.ok) {
                    var resp = response.json();
                    return resp;
                }
                throw new Error('Something went wrong');
            })
                .then((responseJson) => {                  
                    setlocationData(responseJson);                   
                    //console.log(responseJson);
                })
                .catch((error) => {
                    console.log(error)
                });
            //console.log(resp)0
        }, 5000);
        return () => {
            clearInterval(interval);
        };
    }, []);


    return (
        <div>
            <div>
            <h2>Device Current Location</h2>
                <br />
                <label>Device Name : </label>
                <input type="text" name="Long" onInput={e => setdeviceId(e.target.value)} value={deviceId} />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <label>Latitude : </label>
                <input type="text" name="Lat" onChange={setlathandleChange} value={lat} />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <label>Longitude : </label>
                <input type="text" name="Long" onChange={setlnghandleChange} value={lng} />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <button type="button" onClick={onSubmit} className="btn">Show Device </button>
                <br /><br />
            </div>
            <div style={{ textAlign:"center", width: "60%", marginLeft: "20%", marginRight: "20%", marginTop: "3%" }}>
               
                {isSubmit ? <DeviceMap locData={locationData} lat={lat} lng={lng} /> : null}
            </div>
        </div>

    );
}


export default DeviceLocation;