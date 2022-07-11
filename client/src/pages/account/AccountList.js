import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";
import * as Icon from "react-bootstrap-icons";

function AccountList({
  accounts,
  accountStatus,
  repaymentSchedule,
  durationType,
}) {
  function getLookupName(lookups, id) {
    const lookup = lookups.find((lookup) => lookup.id === id);
    return lookup ? lookup.name : null;
  }

  return (
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
                  <Icon.Trash2
                    size={20}
                    title="Delete"
                    className="text-muted"
                  />
                </Link>
              </td>
              <td>{account.id}</td>
              <td>{account.client.fullName}</td>
              <td>{getLookupName(accountStatus, account.statusId)}</td>
              <td>{getLookupName(durationType, account.durationTypeId)}</td>
              <td>
                {getLookupName(repaymentSchedule, account.repaymentTypeId)}
              </td>
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
}

AccountList.propTypes = {
  accounts: PropTypes.array.isRequired,
  accountStatus: PropTypes.array.isRequired,
  repaymentSchedule: PropTypes.array.isRequired,
  durationType: PropTypes.array.isRequired,
};

export default AccountList;
