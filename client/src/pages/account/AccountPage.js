import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import AccountList from "./AccountList";
import AccountForm from "./AccountForm";
import SearchForm from "../../components/common/SearchForm";
import {
  searchAccounts,
  saveAccount,
  deleteAccount,
} from "../../store/actions/accountActions";
import { setAccountFilterBy } from "../../store/actions/filterAction";
import { getLookupSetById } from "../../store/actions/lookupSetActions";
import * as constants from "../../constants/Common";
import { newAccount } from "../../store/dataInitialiser";
import { Drawer } from "antd";

function AccountPage({
  accounts,
  searchAccounts,
  saveAccount,
  deleteAccount,
  setAccountFilterBy,
  accountFilterBy,
  accountStatus,
  repaymentSchedule,
  durationType,
  getLookupSetById,
}) {
  const [drawerState, setDrawerState] = useState({
    visible: false,
    recordMode: constants.RECORD_NONE,
    selectedAccount: newAccount,
    title: "Create Account",
    submitting: false,
    error: {},
  });

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

  function onDrawerClose() {
    setDrawerState({
      visible: false,
      recordMode: constants.RECORD_NONE,
      selectedAccount: newAccount,
      title: "",
      submitting: false,
      error: {},
    });
  }

  function handleSubmitForm(event) {
    event.preventDefault();

    if (drawerState.recordMode === constants.RECORD_DELETE) {
      deleteAccount(drawerState.selectedAccount)
        .then(() => {
          setDrawerState((state) => ({ ...state, submitting: false }));
          onDrawerClose();
        })
        .catch((ex) => {
          catchError(ex);
        });
    } else {
      //RECORD_ADD, RECORD_EDIT
      saveAccount(drawerState.selectedAccount)
        .then(() => {
          setDrawerState((state) => ({ ...state, submitting: false }));
          onDrawerClose();
        })
        .catch((ex) => {
          catchError(ex);
        });
    }
  }

  function catchError(ex) {
    const validationErrors = {
      onSave: ex.message,
      ...ex.error.errors,
      validationErrors: ex.error.validationErrors,
    };

    setDrawerState((state) => ({
      ...state,
      error: validationErrors,
    }));
  }

  function handleCancelForm() {
    setDrawerState({
      visible: false,
      recordMode: constants.RECORD_NONE,
      selectedAccount: newAccount,
      title: "",
      submitting: false,
      error: {},
    });
  }

  function handleChange(event) {
    const { name, value } = event.target;
    setDrawerState((prevState) => ({
      ...prevState,
      ...{
        selectedAccount: {
          ...prevState.selectedAccount,
          [name]: name === "id" ? parseInt(value, 0) : value,
        },
      },
    }));
  }

  function handleClientSelected(client) {
    setDrawerState((prevState) => ({
      ...prevState,
      ...{
        selectedAccount: {
          ...prevState.selectedAccount,
          clientId: client.id,
          client: client,
        },
      },
    }));
  }

  function handleAddAccount() {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_ADD,
      selectedAccount: newAccount,
      title: "Add new account",
      submitting: false,
      error: {},
    });
  }

  function handleEditAccount(account) {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_EDIT,
      selectedAccount: account,
      title: "Edit account",
      submitting: false,
      error: {},
    });
  }

  function handleDeleteAccount(account) {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_DELETE,
      selectedAccount: account,
      title: "Delete account",
      submitting: false,
      error: {},
    });
  }

  function render() {
    return (
      <>
        {drawerState.visible && (
          <Drawer
            title={drawerState.title}
            placement={"right"}
            closable={false}
            onClose={onDrawerClose}
            visible={drawerState.visible}
            key={"createUpdateAccount"}
            size={"small"}
          >
            <AccountForm
              account={drawerState.selectedAccount}
              onSubmitForm={handleSubmitForm}
              onCancelForm={handleCancelForm}
              onChange={handleChange}
              onClientSelected={handleClientSelected}
              durationType={durationType}
              repaymentSchedule={repaymentSchedule}
              mode={drawerState.recordMode}
              submitting={drawerState.submitting}
              errors={drawerState.error}
            />
          </Drawer>
        )}
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
          onEdit={handleEditAccount}
          onDelete={handleDeleteAccount}
        />
      </>
    );
  }

  return (
    <>
      <h4>Manage Account</h4>
      {render()}
    </>
  );
}

AccountPage.propTypes = {
  accounts: PropTypes.array.isRequired,
  searchAccounts: PropTypes.func.isRequired,
  saveAccount: PropTypes.func.isRequired,
  deleteAccount: PropTypes.func.isRequired,
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
  saveAccount,
  deleteAccount,
  setAccountFilterBy,
  getLookupSetById,
};

export default connect(mapStateToProps, mapDispatchToProps)(AccountPage);
