import React from "react";
import PropTypes from "prop-types";
import { Pagination } from "antd";

import * as Icon from "react-bootstrap-icons";

const ClientList = ({ clientState, onEdit, onDelete, onPageChange }) => {
  const { results, currentPage, rowCount, pageSize } = clientState;
  const showTotal: PaginationProps["showTotal"] = (total) =>
    `Total ${total} items`;
  return (
    <table className="table">
      <thead>
        <tr>
          <th />
          <th />
          <th>Id#</th>
          <th>Name</th>
          <th>Emergency Contact</th>
          <th>Mobile</th>
          <th>Email</th>
          <th>Address</th>
        </tr>
      </thead>
      <tbody>
        {results.map((client) => {
          return (
            <tr key={client.id}>
              <td width={20}>
                <Icon.PencilSquare
                  size={20}
                  title="Edit"
                  className="text-muted"
                  style={{ cursor: "pointer" }}
                  onClick={() => onEdit(client)}
                />
              </td>
              <td width={20}>
                <Icon.Trash
                  size={20}
                  title="Edit"
                  className="text-muted"
                  style={{ cursor: "pointer" }}
                  onClick={() => onDelete(client)}
                />
              </td>
              <td>{client.id}</td>
              <td>{client.fullName}</td>
              <td>
                {client.emergencyContact && client.emergencyContact.fullName}
              </td>
              <td>{client.mobileNumber}</td>
              <td>{client.emailAddress}</td>
              <td>{client.fullAddress}</td>
            </tr>
          );
        })}
        <tr>
          <td colSpan={8}>
            {results.length > 0 && (
              <Pagination
                showLessItems={true}
                showTotal={showTotal}
                defaultCurrent={currentPage}
                total={rowCount}
                pageSize={pageSize}
                onChange={onPageChange}
                showSizeChanger={true}
                pageSizeOptions={[10, 15, 20, 25, 50]}
              />
            )}
          </td>
        </tr>
      </tbody>
    </table>
  );
};

ClientList.propTypes = {
  clientState: PropTypes.object.isRequired,
  onSelect: PropTypes.func,
  onEdit: PropTypes.func.isRequired,
  onDelete: PropTypes.func.isRequired,
  onPageChange: PropTypes.func.isRequired,
};

export default ClientList;
