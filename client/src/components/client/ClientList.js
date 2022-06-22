import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

const ClientList = ({ clients }) => (
  <table className="table">
    <thead>
      <tr>
        <th />
        <th>First Name</th>
        <th>Middle Name</th>
        <th>Last Name</th>
        <th>Principal</th>
        <th>Balance</th>
      </tr>
    </thead>
    <tbody>
      {clients.map((client) => {
        return (
          <tr key={client.Id}>
            <td>
              <Link to={`/client/${client.id}`}>Detail</Link>
            </td>
            <td>{client.firstName}</td>
            <td>{client.middleName}</td>
            <td>{client.lastName}</td>
            <td>{client.principal}</td>
            <td>{client.balance}</td>
          </tr>
        );
      })}
    </tbody>
  </table>
);

ClientList.propTypes = {
  clients: PropTypes.array.isRequired,
};

export default ClientList;
