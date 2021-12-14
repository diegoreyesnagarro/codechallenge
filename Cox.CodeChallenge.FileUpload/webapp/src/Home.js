import React, { Component } from "react";
import axios from "axios";

class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {
      selectedFile: "",
      status: "",
      progress: 0,
    };
  }

  selectFileHandler = (event) => {
    let file = event.target.files;

    this.setState({
      selectedFile: file[0],
    });
  };

  uploadHandler = (event) => {
    const formData = new FormData();
    formData.append("file", this.state.selectedFile);

    axios
      .post("https://localhost:44338/api/VehicleDeals", formData, {
        onUploadProgress: (progressEvent) => {
          this.setState({
            progress: (progressEvent.loaded / progressEvent.total) * 100,
          });
        },
      })
      .then((response) => {
        this.setState({ status: `upload success ${response.data}` });
      })
      .catch((error) => {
        this.setState({ status: `upload failed ${error}` });
      });
  };

  handleChange = (event) => {
    this.setState({ name: event.target.value });
  };

  handleSubmit = (event) => {
    event.preventDefault();

    const user = {
      name: this.state.name,
    };

    axios
      .post(`https://localhost:44338/api/VehicleDeals`, { user })
      .then((res) => {});
  };

  render() {
    return (
      <div>
        <div>
          <h2>Vehicle Deals File Upload</h2>
          <div>
            <label>Select File to Upload</label>
            <input type="file" onChange={this.selectFileHandler} />
          </div>
          <hr />
          <div>
            <button type="button" onClick={this.uploadHandler}>
              Upload
            </button>
          </div>
          <hr />
          <div>{this.state.progress}</div>
          <br />
          <div>{this.state.status}</div>
        </div>
      </div>
    );
  }
}

export default Home;
