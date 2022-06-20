import React from "react";
import PropTypes from "prop-types";

const ClientList = ({ clients }) => (
  <table className="table">
    <thead>
      <tr>        
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
