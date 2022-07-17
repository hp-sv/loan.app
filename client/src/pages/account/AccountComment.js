import React, { useState } from "react";
import PropTypes from "prop-types";
import DateDisplay from "../../components/common/DateDisplay";
import PaginateArray from "../../module/PaginateArray";
import SmallPagination from "../../components/common/SmallPagination";

function AccountComment({ account }) {
  const [selectedAccount, setSelectedAccount] = useState({
    ...account,
    paginatedAccountComments: PaginateArray(account.accountComments, 5, 1),
    pageSize: 5,
    displayComments:
      account.accountComments && account.accountComments.length > 0,
    displayPagination:
      account.accountComments && account.accountComments.length > 5,
  });

  const handlePageChange = (page) => {
    setSelectedAccount((prevState) => ({
      ...prevState,
      paginatedAccountComments: PaginateArray(
        prevState.accountComments,
        prevState.pageSize,
        page
      ),
    }));
  };
  return (
    <table className="table">
      <thead>
        <tr>
          <td>Comment</td>
        </tr>
      </thead>
      <tbody>
        {selectedAccount.displayComments &&
          selectedAccount.paginatedAccountComments.map((accountComment) => {
            return (
              <tr
                key={`a_${accountComment.accountId}_cmnt_id_${accountComment.id}`}
              >
                <td>
                  <p>{accountComment.comment}</p>
                  <p>
                    Date: {DateDisplay(accountComment.createdAt)} Status:{" "}
                    {accountComment.status.name}
                  </p>
                </td>
              </tr>
            );
          })}
        {selectedAccount.displayPagination && (
          <tr>
            <td>
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

AccountComment.propTypes = {
  account: PropTypes.object.isRequired,
};

export default AccountComment;
