import React, { Component } from "react";
import Device from './../DeviceIntegrationJS/Device';
class TestTool extends Component {
    render() {
        return (
            <div style={{ textAlign:"center", width: "96%", margin: "1%", height:"100%" }}>
                <br />
                <h2>IOT Hub Integration Test Tool</h2>
                <br />
                <Device></Device>

            </div>

        );
    }
}

export default TestTool;