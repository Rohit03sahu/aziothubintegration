import React, { useState, Component } from "react";
import '../DeviceIntegratioCss/leaflet.css';
import { MapContainer, Marker, Popup, TileLayer } from 'react-leaflet';

function DeviceMap(props) {
    const lat = 20.593683;
    const lng = 78.962883;
    const zoom = 5;

    return (
        <MapContainer center={[lat, lng]} zoom={zoom} style={{ width: '100%', height: '550px' }}>

            <TileLayer
                attribution='&copy <a href="https://osm.org/copyright">OpenStreetMap</a> contributors'
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
            />

            <Marker position={[props.lat, props.lng]} key={"Marker"} >
                <Popup>
                    <span>ADDRESS: Test Address</span>
                    <br />
                    <span>BATTALION: Test BATTALION </span><br />
                </Popup>
            </Marker>

        </MapContainer>
    )
}


export default DeviceMap;