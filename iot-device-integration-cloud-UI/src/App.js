import logo from './logo.svg';
import './App.css';
import React, { Component, useState } from "react";
import Device from './DeviceIntegrationJS/Device';
import Button from '../src/Component/Button';
import DeviceMap from './DeviceIntegrationJS/DeviceMap';
import * as serviceWorker from './serviceworker';
function App() {

  const [lat, setlat] = useState('26.912434');
  const [lng, setlng] = useState('75.787270');
  const [isSubmit, setisSubmit] = useState('');

  const setlathandleChange = event => {
    setlat(event.target.value);
    console.log('lat value is:', event.target.value);
  };

  const setlnghandleChange = event => {
    setlng(event.target.value);
    console.log('lng value is:', event.target.value);
  };

  const onSubmit = event => {
    setisSubmit(!isSubmit);
  };

  return (
    <div className="App">
      {/* <header className="App-header">        
        { isMapDisplay ? <div style={{height:"450px", width:"50px"}}><DeviceMap /> </div> : <DeviceMap /> }        
      </header>  */}
      {/* <Button value='Device Position' onClick={ () => setMapDisplay}> </Button> */}
      <body>

        <br /><br /><br />
        <label>Latitude : </label>
        <input type="text" name="Lat" onChange={setlathandleChange} value={lat} />
        <label>Longitude : </label>
        <input type="text" name="Long" onChange={setlnghandleChange} value={lng} />
        <button type="button" onClick={onSubmit} className="btn">Show Device </button>
        <br /><br />
        {isSubmit ? <DeviceMap lat={lat} lng={lng} /> : null}
      </body>
    </div>
  );
}
serviceWorker.register();
export default App;
