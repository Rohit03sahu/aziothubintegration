import React, { Component } from "react";
import '../DeviceIntegratioCss/DeviceCss.css';
import Button from '../Component/Button';
import TextArea from '../Component/TextArea';
import TextBox from '../Component/TextBox';
import GeoPosition from '../Component/GPProcessor';
import { Client } from 'azure-iothub';

function Device() {

    
    const OnConnect = event => {
        const connectionString = 'HostName=iothubdeviceintegration.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=r0uGKCJTJSbCxhug5MIa3piuJD+jOWbtTimS1CbkWHU=';
        const client = Client.fromConnectionString(connectionString);
        client.open(function (err) {
            if (err) {
                console.error('Could not connect: ' + err.message);
            } else {
                console.log('Client connected');
            }
        });
    };
    return (
        <div style={{ width: '100%' }}>

            <div style={{ float: 'left', width: '90%', height: '100vh', textAlign: 'center' }} >

                <tr style={{ float: 'left', fontSize: '18px', textAlign: 'center' }}>Topic : &nbsp;&nbsp;&nbsp;
                    <TextBox />
                    &nbsp;&nbsp;&nbsp;
                </tr>
                <label style={{ float: 'left', fontSize: '18px', textAlign: 'center' }}>QOS : &nbsp;&nbsp;&nbsp;
                    <select style={{ height: '22px', width: '80px' }} id="pub_qos" name="pub_qos">
                        <option value="Pub_QOS_0">QOS 0</option>
                        <option value="Pub_QOS_1">QOS 1</option>
                        <option value="Pub_QOS_2">QOS 2</option>
                    </select>
                </label>
                <label> <button value="Publish"></button> </label>
                <label>
                    <button value="Publish" onClick={OnConnect}>Connect</button>
                </label>
                <br /><br />
                <TextArea />

                <br /><br /><br />

                <label
                    style={{ float: 'left', fontSize: '18px', textAlign: 'center' }}>Topic : &nbsp;&nbsp;&nbsp;
                    <TextBox />
                    &nbsp;&nbsp;&nbsp;
                </label>
                <label style={{ float: 'left', fontSize: '18px', textAlign: 'center' }}>QOS : &nbsp;&nbsp;
                    <select style={{ height: '22px', width: '80px' }} id="sub_qos" name="sub_qos">
                        <option value="Sub_QOS_0">QOS 0</option>
                        <option value="Sub_QOS_1">QOS 1</option>
                        <option value="Sub_QOS_2">QOS 2</option>
                    </select>
                </label>
                <label>
                    <Button value="Subcribe"></Button>
                </label>
                <br /><br />
                <TextArea />
                <br /><br />

            </div>
        </div>
    );
}

export default Device;


