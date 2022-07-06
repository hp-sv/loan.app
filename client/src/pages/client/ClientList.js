import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";
import * as Icon from "react-bootstrap-icons";

const ClientList = ({ clients }) => (
  <table className="table">
    <thead>
      <tr>
        <th />
        <th />
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
          <tr key={client.id}>
            <td width={25}>
              <Link to={`/client/${client.id}`}>
                <Icon.PencilSquare
                  size={20}
                  title="Edit"
                  className="text-muted"
                />
              </Link>
            </td>
            <td width={25}>
              <Link to={`/client/${client.id}`}>
                <Icon.Wallet size={20} title="Account" className="text-muted" />
              </Link>
            </td>
            <td width={25}>
              <Link to={`/client/d/${client.id}`}>
                <Icon.Trash2 size={20} title="Delete" className="text-muted" />
              </Link>
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
