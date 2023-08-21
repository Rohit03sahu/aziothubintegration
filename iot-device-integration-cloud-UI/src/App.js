import logo from './logo.svg';
import './App.css';
import React, { Component, } from "react";

import Button from '../src/Component/Button';
import DeviceMap from './DeviceIntegrationJS/DeviceMap';
import TestTool from '../src/Component/TestTool';
import DeviceLocation from '../src/Component/DeviceLocation';
import * as serviceWorker from './serviceworker';
function App() {

 

  return (
    <div className="App">
      <body>
        <TestTool></TestTool>
        <DeviceLocation></DeviceLocation>
      </body>
    </div>
  );
}
serviceWorker.register();
export default App;
