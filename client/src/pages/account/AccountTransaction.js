import React, { useState } from "react";
import PropTypes from "prop-types";
import DateDisplay from "../../components/common/DateDisplay";
import PaginateArray from "../../module/PaginateArray";
import SmallPagination from "../../components/common/SmallPagination";

function AccountTransaction({ account }) {
  const [selectedAccount, setSelectedAccount] = useState({
    ...account,
    pagedTransactions: PaginateArray(account.accountTransactions, 10, 1),
    totalTransactions: account.accountTransactions.length,
    pageSize: 10,
    displayPagination: account.accountTransactions.length > 10,
    displayTransactions: account.accountTransactions.length > 0,
  });

  const handlePageChange = (page) => {
    setSelectedAccount((prevState) => ({
      ...prevState,
      pagedTransactions: PaginateArray(
        prevState.accountTransactions,
        prevState.pageSize,
        page
      ),
    }));
  };

  return (
    <table className="table">
      <thead>
        <tr>
          <td>Date</td>
          <td>Type</td>
          <td>Expected</td>
          <td>Actual</td>
        </tr>
      </thead>
      <tbody>
        {selectedAccount.displayTransactions &&
          selectedAccount.pagedTransactions.map((accountTransaction) => {
            return (
              <tr
                key={`a_${accountTransaction.accountId}_trn_id_${accountTransaction.id}`}
              >
                <td>{DateDisplay(accountTransaction.transactionDate)}</td>
                <td>{accountTransaction.transactionType.name}</td>
                <td>{accountTransaction.expectedAmount}</td>
                <td>{accountTransaction.actualdAmount}</td>
              </tr>
            );
          })}
        {selectedAccount.displayPagination && (
          <tr>
            <td colSpan={4}>
              <SmallPagination
                total={selectedAccount.totalTransactions}
                pageSize={selectedAccount.pageSize}
                onChange={handlePageChange}
              />
            </td>
          </tr>
        )}
      </tbody>
    </table>
  );
}

AccountTransaction.propTypes = {
  account: PropTypes.object.isRequired,
};

export default AccountTransaction;
