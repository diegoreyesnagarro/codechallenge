import React, { Component } from "react";
import axios from "axios";

export default class DealView extends Component {
  constructor(props) {
    super(props);
    this.state = {
      deals: [],
    };
  }
  componentDidMount() {
    axios.get(`https://localhost:44338/api/VehicleDeals`).then((res) => {
      const deals = res.data;
      console.log(res.data);
      this.setState({ deals });
    });
  }
  render() {
    var heading = [
      "VehicleDealId",
      "DealNumber",
      "CustomerName",
      "DealershipName",
      "Vehicle",
      "Price",
      "Date",
    ];

    return (
      <div>
        <h2>Current Deals</h2>

        <table style={{ width: 500 }}>
          <thead>
            <tr>
              {heading.map((head) => (
                <th>{head}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {this.state.deals.map((row) => (
              <TableRow row={row} />
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}
class TableRow extends Component {
  render() {
    var row = this.props.row;
    console.log(row);
    return (
      <tr>
        <td>{row.vehicleDealId}</td>
        <td>{row.dealNumber}</td>
        <td>{row.customerName}</td>
        <td>{row.dealershipName}</td>
        <td>{row.vehicle}</td>
        <td>{row.price}</td>
        <td>{row.date}</td>
      </tr>
    );
  }
}
