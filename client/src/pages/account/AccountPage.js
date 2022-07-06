import React, { useState } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { Navigate } from "react-router-dom";

import Disabled from "../../components/common/Disabled";
import AccountList from "./AccountList";
import SearchForm from "../../components/common/SearchForm";
import { searchAccounts } from "../../store/actions/accountActions";
import { setAccountFilterBy } from "../../store/actions/filterAction";

function AccountPage({
  accounts,
  searchAccounts,
  setAccountFilterBy,
  accountFilterBy,
  loading,
}) {
  function handleValueChange(event) {
    const { value } = event.target;
    setAccountFilterBy(value);
  }

  function handleSearch(event) {
    event.preventDefault();
    searchAccounts(accountFilterBy);
  }
  const [redirectToAddAccount, setRedirectToAddAccount] = useState(false);

  return (
    <>
      {redirectToAddAccount && <Navigate to="/account" />}
      <Disabled disabled={loading}>
        <div className="row">
          <div className="input-group">
            <SearchForm
              placeHolder="Search account"
              onChange={handleValueChange}
              onSearch={handleSearch}
              value={accountFilterBy}
            />
            <button
              className="btn btn-outline-secondary bi-journal-plus btn-sm"
              onClick={() => setRedirectToAddAccount(true)}
            ></button>
          </div>
        </div>
        <AccountList accounts={accounts} />
      </Disabled>
    </>
  );
}

AccountPage.propTypes = {
  accounts: PropTypes.array.isRequired,
  searchAccounts: PropTypes.func.isRequired,
  setAccountFilterBy: PropTypes.func.isRequired,
  accountFilterBy: PropTypes.string.isRequired,
  loading: PropTypes.bool.isRequired,
};

function mapStateToProps(state) {
  const { accounts, filters } = state;
  return {
    accounts: accounts.length === 0 ? [] : accounts,
    loading: state.apiCallsInProgress > 0,
    accountFilterBy: filters.accountFilterBy,
  };
}

const mapDispatchToProps = {
  searchAccounts,
  setAccountFilterBy,
};

export default connect(mapStateToProps, mapDispatchToProps)(AccountPage);
