import React, { Component } from "react";
import '../DeviceIntegratioCss/DeviceCss.css';
import Button from '../Component/Button';
import TextArea from '../Component/TextArea';
import TextBox from '../Component/TextBox';

class Device extends Component {

    render() {
        return (
            <div style={{
                width: '100%'
            }}>
                <tr textAlign='center'>
                    <Button value="Connect to Broker"></Button>
                </tr>                    
                <div style={{
                    float: 'left',
                    width: '45%',
                    margin: '2.5%',
                    height: '100vh',
                    textAlign: 'center'
                }} >
                    <h3> Mqtt Publisher</h3>
                    <label
                        style={{
                            float: 'left',
                            fontSize: '18px',
                            textAlign: 'center'
                        }}>Topic : &nbsp;&nbsp;&nbsp;
                        <TextBox />
                        &nbsp;&nbsp;&nbsp;
                    </label>

                    <label
                        style={{
                            float: 'left',
                            fontSize: '18px',
                            textAlign: 'center'
                        }}>QOS : &nbsp;&nbsp;&nbsp;
                        <select style={{ height: '22px', width: '80px' }} id="pub_qos" name="pub_qos">
                            <option value="Pub_QOS_0">QOS 0</option>
                            <option value="Pub_QOS_1">QOS 1</option>
                            <option value="Pub_QOS_2">QOS 2</option>
                        </select>
                    </label>


                    <br /><br />
                    <TextArea />
                    <br /><br />
                    <div style={{ float: 'right' }}>
                        <Button value="Publish"></Button>
                    </div>
                </div>

                <div style={{
                    float: 'right',
                    width: '45%',
                    margin: '2.5%',
                    height: '100vh',
                    textAlign: 'center'
                }} >
                    <h3>Mqtt Subcriber</h3>
                    <label
                        style={{
                            float: 'left',
                            fontSize: '18px',
                            textAlign: 'center'
                        }}>Topic : &nbsp;&nbsp;&nbsp;
                        <TextBox />
                        &nbsp;&nbsp;&nbsp;
                    </label>
                    <label
                        style={{
                            float: 'left',
                            fontSize: '18px',
                            textAlign: 'center'
                        }}>QOS : &nbsp;&nbsp;
                        <select style={{ height: '22px', width: '80px' }} id="sub_qos" name="sub_qos">
                            <option value="Sub_QOS_0">QOS 0</option>
                            <option value="Sub_QOS_1">QOS 1</option>
                            <option value="Sub_QOS_2">QOS 2</option>
                        </select>
                    </label>


                    <br /><br />
                    <TextArea />
                    <br /><br />

                    <div style={{ float: 'right' }}>
                        <Button value="Subcribe"></Button>
                    </div>
                </div>
            </div>
        );
    }
}

export default Device;


