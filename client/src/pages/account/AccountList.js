import React from "react";
import PropTypes from "prop-types";
import * as Icon from "react-bootstrap-icons";
import { Pagination } from "antd";
import * as constants from "../../constants/Common";
import formatMoney from "../../module/formatMoney";

function AccountList({
  accountState,
  accountStatus,
  repaymentSchedule,
  durationType,
  onEdit,
  onDelete,
  onReview,
  onPageChange,
}) {
  const { results, currentPage, rowCount, pageSize } = accountState;
  const showTotal: PaginationProps["showTotal"] = (total) =>
    `Total ${total} items`;

  function getLookupName(lookups, id) {
    const lookup = lookups.find((lookup) => lookup.id === id);
    return lookup ? lookup.name : null;
  }

  function showDelete(account) {
    return (
      account.statusId === constants.ACCOUNT_STATUS_CANCEL ||
      account.statusId === constants.ACCOUNT_STATUS_PENDING ||
      account.statusId === constants.ACCOUNT_STATUS_DECLINE
    );
  }

  function showReview(account) {
    return (
      account.statusId === constants.ACCOUNT_STATUS_CANCEL ||
      account.statusId === constants.ACCOUNT_STATUS_PENDING ||
      account.statusId === constants.ACCOUNT_STATUS_DECLINE
    );
  }

  return (
    <table className="table">
      <thead>
        <tr>
          <th />
          <th align="middle">Account#</th>
          <th align="middle">Name</th>
          <th align="middle">Status</th>
          <th align="middle">Duration</th>
          <th align="middle">Repayment Type</th>
          <th align="middle">Principal</th>
          <th align="middle">Rate</th>
          <th align="middle">Interest</th>
          <th align="middle">Expected</th>
          <th align="middle">Actual</th>
          <th align="middle">Balance</th>
        </tr>
      </thead>
      <tbody>
        {results.map((account) => {
          return (
            <tr key={account.id}>
              <td>
                <div className="input-group sm">
                  <Icon.PencilSquare
                    size={20}
                    title="Edit"
                    className="text-muted m-1"
                    style={{ cursor: "pointer" }}
                    onClick={() => onEdit(account)}
                  />
                  {showDelete(account) && (
                    <Icon.Trash
                      size={20}
                      title="Edit"
                      className="text-muted m-1"
                      style={{ cursor: "pointer" }}
                      onClick={() => onDelete(account)}
                    />
                  )}
                  {showReview(account) && (
                    <Icon.CheckSquare
                      size={20}
                      title="Review account"
                      className="text-muted m-1"
                      style={{ cursor: "pointer" }}
                      onClick={() => onReview(account)}
                    />
                  )}
                </div>
              </td>
              <td align="middle">{account.id}</td>
              <td align="left">{account.client.fullName}</td>
              <td align="middle">
                {getLookupName(accountStatus, account.statusId)}
              </td>
              <td align="middle">
                {getLookupName(durationType, account.durationTypeId)}
              </td>
              <td align="middle">
                {getLookupName(repaymentSchedule, account.repaymentTypeId)}
              </td>
              <td align="middle">
                {account.principal.toLocaleString(undefined, {
                  maximumFractionDigits: 2,
                })}
              </td>
              <td align="middle">{`${account.rate}%`}</td>
              <td align="middle">{formatMoney(account.interest)}</td>
              <td align="middle">{formatMoney(account.expectedRepayments)}</td>
              <td align="middle">{formatMoney(account.actualRepayments)}</td>
              <td align="middle">{formatMoney(account.balance)}</td>
            </tr>
          );
        })}
        <tr>
          <td colSpan={12}>
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
}

AccountList.propTypes = {
  accountState: PropTypes.object.isRequired,
  accountStatus: PropTypes.array.isRequired,
  repaymentSchedule: PropTypes.array.isRequired,
  durationType: PropTypes.array.isRequired,
  onEdit: PropTypes.func.isRequired,
  onDelete: PropTypes.func.isRequired,
  onReview: PropTypes.func.isRequired,
  onPageChange: PropTypes.func.isRequired,
};

export default AccountList;
