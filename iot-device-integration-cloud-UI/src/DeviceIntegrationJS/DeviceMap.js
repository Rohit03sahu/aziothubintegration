import React, { useState, Component } from "react";
import '../DeviceIntegratioCss/leaflet.css';
import { MapContainer, Marker, Popup, TileLayer } from 'react-leaflet';

function DeviceMap(props) {
    const lat = 20.593683;
    const lng = 78.962883;
    const zoom = 5;
    console.log(props.locData);
    return (
        <MapContainer center={[lat, lng]} zoom={zoom} style={{ height: '550px' }}>

            <TileLayer
                attribution='&copy <a href="https://osm.org/copyright">OpenStreetMap</a> contributors'
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
            />
        {/* { 
            props.locData != null ?
                props.locData.map((loc) => (
                    return (
                    <Marker position={[loc.lat, loc.lng]} key={"Marker"+loc.id.timestamp} >
                        <Popup>
                            <span>ADDRESS: Test IOT GPS application</span>
                            <br />
                            <span>BATTALION: Test IOT GPS application </span><br />
                        </Popup>
                    </Marker>
                    )
                ))
            : 
                <Marker position={[lat, lng]} key={"Marker"} >
                    <Popup>
                        <span>ADDRESS: Test IOT GPS application</span>
                        <br />
                        <span>BATTALION: Test IOT GPS application </span><br />
                    </Popup>
                </Marker>
        } */}

        {
            props.locData.map(maps => {
                    
                    const id = maps.id;
                    const ensemble = [maps.lat, maps.long];
                    const deviceId = 'Device Id :    ' + maps.deviceId;
                    const timestamp = 'TimeStamp :    ' + maps.createdDateTime;
                    return (
                        <Marker position={ensemble} key={id}>
                            <Popup>
                                <span>{deviceId}</span>
                                <br />
                                <span>{timestamp}</span>
                                <br />
                            </Popup>
                        </Marker>
                    )
                })
                }

        </MapContainer>
    )
}


export default DeviceMap;