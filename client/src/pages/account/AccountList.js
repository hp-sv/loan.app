import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";
import * as Icon from "react-bootstrap-icons";

const AccountList = ({ accounts }) => (
  <table className="table">
    <thead>
      <tr>
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
      {accounts.map((account) => {
        return (
          <tr key={account.id}>
            <td width={25}>
              <Link to={`/account/${account.id}`}>
                <Icon.PencilSquare
                  size={20}
                  title="Edit"
                  className="text-muted"
                />
              </Link>
            </td>
            <td width={25}>
              <Link to={`/client/d/${account.id}`}>
                <Icon.Trash2 size={20} title="Delete" className="text-muted" />
              </Link>
            </td>
            <td>{account.firstName}</td>
            <td>{account.middleName}</td>
            <td>{account.lastName}</td>
            <td>{account.principal}</td>
            <td>{account.balance}</td>
          </tr>
        );
      })}
    </tbody>
  </table>
);

AccountList.propTypes = {
  accounts: PropTypes.array.isRequired,
};

export default AccountList;
