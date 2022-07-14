import React from "react";
import PropTypes from "prop-types";
import {
  EditOutlined,
  DeleteOutlined 
} from '@ant-design/icons';

function AccountList({
  accounts,
  accountStatus,
  repaymentSchedule,
  durationType,
  onEdit,
  onDelete,
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
              <td width={20}>
                <EditOutlined                  
                  title="Edit"      
                  className="grid_inline_icon"                              
                  onClick={() => onEdit(account)}
                />
              </td>
              <td width={20}>
                <DeleteOutlined                   
                  title="Delete"                  
                  className="grid_inline_icon"                              
                  onClick={() => onDelete(account)}
                />
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
  onEdit: PropTypes.func.isRequired,
  onDelete: PropTypes.func.isRequired,
};

export default AccountList;
