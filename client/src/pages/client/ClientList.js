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
        <th>Id#</th>
        <th>Name</th>
        <th>Mobile</th>
        <th>Email</th>
        <th>Address</th>
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
            <td>{client.id}</td>
            <td>{client.fullName}</td>
            <td>{client.mobileNumber}</td>
            <td>{client.emailAddress}</td>
            <td>{client.fullAddress}</td>
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
