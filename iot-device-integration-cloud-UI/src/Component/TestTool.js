import React, { Component } from "react";
import Device from './../DeviceIntegrationJS/Device';
class TestTool extends Component {
    render() {
        return (
            <div style={{ width: "46%", float: "left", margin: "1%" }}>
                <h1>IOT Hub Integration Test Tool</h1>
                <br /><br /><br />
                <Device></Device>

            </div>

        );
    }
}

export default TestTool;