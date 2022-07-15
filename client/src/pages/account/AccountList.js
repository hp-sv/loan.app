import React from "react";
import PropTypes from "prop-types";
import {
  EditOutlined,
  DeleteOutlined 
} from '@ant-design/icons';

import { Pagination } from "antd";

function AccountList({
  accountState,
  accountStatus,
  repaymentSchedule,
  durationType,
  onEdit,
  onDelete, onPageChange
}) {

  const { results, currentPage, rowCount, pageSize } = accountState;
  const showTotal: PaginationProps["showTotal"] = (total) =>
  `Total ${total} items`;

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
        {results.map((account) => {
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
        <tr>          
          <td colSpan={12}>
            {
              results.length > 0 && 
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
            }
            
          </td>
        </tr>
      </tbody>
    </table>
  );
}

AccountList.propTypes = {
  accountState: PropTypes.object.isRequired,
  accountStatus: PropTypes.array.isRequired,
  repaymentSchedule: PropTypes.array.isRequired,
  durationType: PropTypes.array.isRequired,
  onEdit: PropTypes.func.isRequired,
  onDelete: PropTypes.func.isRequired,
  onPageChange: PropTypes.func.isRequired,
};

export default AccountList;
