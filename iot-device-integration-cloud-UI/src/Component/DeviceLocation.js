import React, { Component,useState,useEffect  } from "react";
import DeviceMap from "../DeviceIntegrationJS/DeviceMap";
function DeviceLocation() {

    const [lat, setlat] = useState('26.912434');
    const [lng, setlng] = useState('75.787270');
    const [isSubmit, setisSubmit] = useState('');
    const [deviceId, setdeviceId] = useState('iot-device-001')

    const setlathandleChange = event => {
        setlat(event.target.value);
        console.log('lat value is:', event.target.value);
    };

    const setlnghandleChange = event => {
        setlng(event.target.value);
        console.log('lng value is:', event.target.value);
    };

    const setDevicehandleChange = event => {
        setdeviceId(event.target.value);
        console.log('device value is:', event.target.value);
    };

    const onSubmit = event => {
        setisSubmit(!isSubmit);
    };

    useEffect(() => {
        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'application/json');
        headers.append('Access-Control-Allow-Origin', 'http://localhost:3001');
        headers.append('Access-Control-Allow-Credentials', 'true');

        headers.append('GET', 'POST', 'OPTIONS');

        let interval = setInterval(async () => {
            // const resp = await fetch(`http://localhost:5116/api/device-location?DeviceId=`+deviceId
            // , { headers: headers  }

            // );
            fetch('http://localhost:5116/api/device-location?DeviceId=' + deviceId).then((response) => {
                if (response.ok) {
                    var resp = response.json();
                    return resp;
                }
                throw new Error('Something went wrong');
            })
                .then((responseJson) => {
                    setlng(responseJson.long);
                    setlat(responseJson.lat);
                    setisSubmit(true);
                    console.log(responseJson);
                    // Do something with the response
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
        <div style={{ width: "46%", float: "right", margin: "1%" }}>
            <h1>Device Current Location</h1>
            <br /><br /><br />
            <label>Device Name : </label>
            <input type="text" name="Long" onChange={setDevicehandleChange} value={deviceId} />
            <br />
            <br />
            <label>Latitude : </label>
            <input type="text" name="Lat" onChange={setlathandleChange} value={lat} />
            <label>Longitude : </label>
            <input type="text" name="Long" onChange={setlnghandleChange} value={lng} />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <button type="button" onClick={onSubmit} className="btn">Show Device </button>
            <br /><br />
            {isSubmit ? <DeviceMap lat={lat} lng={lng} /> : null}
        </div>

    );
}


export default DeviceLocation;