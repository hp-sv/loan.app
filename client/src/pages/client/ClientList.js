import React from "react";
import PropTypes from "prop-types";
import * as Icon from "react-bootstrap-icons";

const ClientList = ({ clients, onSelect, onEdit, onDelete }) => (
  <table className="table">
    <thead>
      <tr>
        {onSelect && <th />}
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
            {onSelect && (
              <td width={20}>
                <Icon.Check2Square
                  size={20}
                  title="Select"
                  className="text-muted"
                  style={{ cursor: "hand" }}
                  onClick={() => onSelect(client)}
                />
              </td>
            )}
            <td width={20}>
              <Icon.PencilSquare
                size={20}
                title="Edit"
                className="text-muted"
                style={{ cursor: "hand" }}
                onClick={() => onEdit(client.id)}
              />
            </td>
            <td width={20}>
              <Icon.Trash2
                size={20}
                title="Edit"
                className="text-muted"
                style={{ cursor: "hand" }}
                onClick={() => onDelete(client.id)}
              />
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
  onSelect: PropTypes.func,
  onEdit: PropTypes.func.isRequired,
  onDelete: PropTypes.func.isRequired,
};

export default ClientList;
