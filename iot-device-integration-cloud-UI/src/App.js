import './App.css';
import React, { Component,useState } from "react";
import TestTool from '../src/Component/TestTool';
import DeviceLocation from '../src/Component/DeviceLocation';
import * as serviceWorker from './serviceworker';
function App() {
  const [testTool, settestTool] = useState(false);
  const [showMap, setshowMap] = useState(true);
  const onShowMap = event => {
    settestTool(false);
    setshowMap(true);
  };

  const onTestTool = event => {
    setshowMap(false);
    settestTool(true);
  };

  return (
    <div className="App">
      <body>
      <br /><br />
        <button type="button" onClick={onTestTool} key="testtool" className="btn">Show TestTool </button>
        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <button type="button" onClick={onShowMap} key="showmap" className="btn">Show Map </button>
        { 
          testTool ? <TestTool></TestTool>:""
        }
        {
          showMap?<DeviceLocation></DeviceLocation>:""
        }
        <br /><br /><br /><br /><br />
      </body>
    </div>
  );
}
serviceWorker.register();
export default App;
