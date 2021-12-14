import React, { Component } from "react";
import { BrowserRouter as Router, Link, Route, Routes } from "react-router-dom";
import DealView from "./DealView";
import dealUpload from "./dealUpload";
import Home from "./Home";

class Main extends Component {
  render() {
    return (
      <Routes>
        <Route exact path="/" element={<Home />} />
        <Route exact path="/dealUpload" element={<dealUpload />} />
        <Route exact path="/dealView" element={<DealView />} />
        <Route path="*" element={<Home />} />
      </Routes>
    );
  }
}

export default Main;
