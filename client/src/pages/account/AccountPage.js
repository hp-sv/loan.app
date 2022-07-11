import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";

import Disabled from "../../components/common/Disabled";
import AccountList from "./AccountList";
import SearchForm from "../../components/common/SearchForm";
import { searchAccounts } from "../../store/actions/accountActions";
import { setAccountFilterBy } from "../../store/actions/filterAction";
import { getLookupSetById } from "../../store/actions/lookupSetActions";
import * as constants from "../../constants/Common";
import ClientPage from "../client/ClientPage";
import ManageAccount from "./ManageAccount";
import dataInitialiser from "../../store/dataInitialiser";

function AccountPage({
  accounts,
  searchAccounts,
  setAccountFilterBy,
  accountFilterBy,
  accountStatus,
  repaymentSchedule,
  durationType,
  getLookupSetById,
  loading,
}) {
  const [recordMode, setRecordMode] = useState(constants.RECORD_NONE);
  const [selectedAccount, setSelectedAccount] = useState(
    dataInitialiser.newAccount
  );

  useEffect(() => {
    if (accountStatus.length === 0) getLookupSetById(constants.ACCOUNT_STATUS);

    if (repaymentSchedule.length === 0)
      getLookupSetById(constants.REPAYMENT_SCHEDULE);

    if (durationType.length === 0) getLookupSetById(constants.DURATION_TYPE);
  }, []);

  function handleValueChange(event) {
    const { value } = event.target;
    setAccountFilterBy(value);
  }

  function handleSearch(event) {
    event.preventDefault();
    searchAccounts(accountFilterBy);
  }

  function handleSelectClient(client) {
    setSelectedAccount({ ...selectedAccount, clientId: client.id, client });
  }

  function handleAddAccount() {
    setSelectedAccount(dataInitialiser.newAccount);
    setRecordMode(constants.RECORD_ADD);
  }

  function render() {
    switch (recordMode) {
      case constants.RECORD_ADD:
        if (!selectedAccount.client) {
          return (
            <ClientPage
              mode={constants.PAGE_SELECT}
              onAfterClientSelect={handleSelectClient}
            />
          );
        } else {
          return (
            <ManageAccount
              account={selectedAccount}
              mode={constants.RECORD_ADD}
              accountStatus={accountStatus}
              durationType={durationType}
              repaymentSchedule={repaymentSchedule}
            />
          );
        }
      case constants.RECORD_EDIT:
      case constants.RECORD_DELETE:
        return <ManageAccount account={selectedAccount} mode={recordMode} />;
      default:
        return (
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
                  onClick={handleAddAccount}
                ></button>
              </div>
            </div>
            <AccountList
              accounts={accounts}
              accountStatus={accountStatus}
              repaymentSchedule={repaymentSchedule}
              durationType={durationType}
            />
          </Disabled>
        );
    }
  }

  return render();
}

AccountPage.propTypes = {
  accounts: PropTypes.array.isRequired,
  searchAccounts: PropTypes.func.isRequired,
  setAccountFilterBy: PropTypes.func.isRequired,
  accountFilterBy: PropTypes.string.isRequired,
  accountStatus: PropTypes.array.isRequired,
  repaymentSchedule: PropTypes.array.isRequired,
  durationType: PropTypes.array.isRequired,
  loading: PropTypes.bool.isRequired,
};

function mapStateToProps(state) {
  const { accounts, filters, lookupSets } = state;
  return {
    accounts: accounts.length === 0 ? [] : accounts,
    loading: state.apiCallsInProgress > 0,
    accountFilterBy: filters.accountFilterBy,
    accountStatus: lookupSets.accountStatus.lookups,
    repaymentSchedule: lookupSets.repaymentSchedule.lookups,
    durationType: lookupSets.durationType.lookups,
  };
}

const mapDispatchToProps = {
  searchAccounts,
  setAccountFilterBy,
  getLookupSetById,
};

export default connect(mapStateToProps, mapDispatchToProps)(AccountPage);
