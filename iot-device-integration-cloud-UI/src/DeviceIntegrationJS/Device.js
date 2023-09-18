import React, { Component } from "react";
import '../DeviceIntegratioCss/DeviceCss.css';
import Button from '../Component/Button';
import TextArea from '../Component/TextArea';
import TextBox from '../Component/TextBox';
// import { Client } from 'azure-iothub';

function Device() {    
    return (
        <div style={{ textAlign:"center", width: '100%', height:"auto" }}>

            <div style={{ width: '48%', float:"left", height: '500vh', textAlign: 'center' }} >

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
                <label>
                     <button value="Publish">Publish</button>  &nbsp;&nbsp;&nbsp;
                </label>
                <label>
                    <button value="Connect">Connect</button>
                </label>
                <br /><br />
                <TextArea />
            </div>
            <div style={{ width: '48%', float:"right", height: '500vh', textAlign: 'center' }} >

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
                    <button value="Subscribe">Subscribe</button>
                </label>
                <br /><br />
                <TextArea />
                <br /><br />

            </div>
        </div>
    );
}

export default Device;


