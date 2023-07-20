import React, { Component } from "react";
import '../DeviceIntegratioCss/Button.Css';
class Button extends Component {
    render() {
      return (
        <button style={{
            width:"100px",
            height:"35px"
        }} 
        className="button">
          {this.props.value}
        </button>
      );
    }
  }

  export default Button;