import React, { Component } from "react";
import '../DeviceIntegratioCss/TextArea.Css';
class TextArea extends Component {
    render() {
        return (
            <textarea style={{
                width: "100%",
                height: "350px"
            }}
                name="body"
                onChange={this.handleChange}
                value={this.props.value} />

        );
    }
}

export default TextArea;