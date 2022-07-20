import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import DateDisplay from "../../components/common/DateDisplay";
import paginateArray from "../../module/paginateArray";
import SmallPagination from "../../components/common/SmallPagination";
import AccountCommentForm from "./AccountCommentForm";

function AccountComment({ account }) {
  const [selectedAccount, setSelectedAccount] = useState({
    account: account,
    paginatedAccountComments: [],
    pageSize: 5,
    totalComments: 0,
    displayComments: false,
    displayPagination: false,
  });

  useEffect(() => {
    setSelectedAccount({
      account: account,
      paginatedAccountComments: paginateArray(account.accountComments, 5, 1),
      pageSize: 5,
      totalComments: account.accountComments.length,
      displayComments:
        account.accountComments && account.accountComments.length > 0,
      displayPagination:
        account.accountComments && account.accountComments.length > 5,
    });
  }, [account]);

  const handlePageChange = (page) => {
    setSelectedAccount((prevState) => ({
      ...prevState,
      paginatedAccountComments: paginateArray(
        prevState.account.accountComments,
        prevState.pageSize,
        page
      ),
    }));
  };

  const handleCommentSaveSuccess = (savedAccount) => {
    setSelectedAccount((prevState) => ({
      ...prevState,
      account: savedAccount,
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
                  <small className="text-muted">
                    <p>
                      {accountComment.comment}
                      <br />
                      Date:<b>{DateDisplay(accountComment.createdAt)} </b>{" "}
                      Status:<b> {accountComment.status.name}</b>
                    </p>
                  </small>
                </td>
              </tr>
            );
          })}
        {selectedAccount.displayPagination && (
          <tr>
            <td>
              <SmallPagination
                total={selectedAccount.totalComments}
                pageSize={selectedAccount.pageSize}
                onChange={handlePageChange}
              />
            </td>
          </tr>
        )}
        <tr>
          <td>
            <AccountCommentForm
              account={selectedAccount.account}
              onSubmitSuccess={handleCommentSaveSuccess}
            />
          </td>
        </tr>
      </tbody>
    </table>
  );
}

AccountComment.propTypes = {
  account: PropTypes.object.isRequired,
};

const mapStateToProps = (state, ownProps) => {
  const { account } = ownProps;
  const { accountState } = state;
  const selectedAccount = accountState.results.find(
    (stateAccount) => stateAccount.id === account.id
  );
  return {
    account: selectedAccount,
  };
};

export default connect(mapStateToProps)(AccountComment);
