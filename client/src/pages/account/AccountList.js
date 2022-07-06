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
        <th>Account#</th>
        <th>Name</th>
        <th>Status</th>
        <th>Duration</th>
        <th>Repayment Type</th>
        <th>Principal</th>
        <th>Rate</th>
        <th>Expected</th>
        <th>Actual</th>
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
            <td>{account.id}</td>
            <td>{account.client.fullName}</td>
            <td></td>
            <td></td>
            <td></td>
            <td>{account.totalAmount}</td>
            <td>{account.rate}</td>
            <td>{account.actualRepayments}</td>
            <td>{account.expectedRepayments}</td>
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
