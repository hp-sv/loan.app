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
  setAccountFilter,
} from "../../store/actions/accountActions";
import { getLookupSetById } from "../../store/actions/lookupSetActions";
import * as constants from "../../constants/Common";
import { newAccount } from "../../store/dataInitialiser";
import { Drawer } from "antd";

function AccountPage({
  accountState,  
  searchAccounts,
  saveAccount,
  deleteAccount,
  setAccountFilter,  
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
    setAccountFilter(value);    
  }

  function handleSearch(event) {
    event.preventDefault();
    searchAccounts(accountState.filterBy, 1, accountState.pageSize);
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

  function handlePageChange(page, pageSize) {
    searchAccounts(
      accountState.filterBy,
      page > 0 ? page : accountState.currentPage,
      accountState.pageSize !== pageSize ? pageSize : accountState.pageSize
    );
  }

  function render() {
    return (
      <>
        {drawerState.visible && (
          <Drawer
            title={drawerState.title}
            placement={"right"}
            closable={true}
            maskClosable={false}
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
              value={accountState.filterBy}
            />
            <button
              className="btn btn-outline-secondary bi-journal-plus btn-sm"
              onClick={handleAddAccount}
            ></button>
          </div>
        </div>
        <AccountList
          accountState={accountState}          
          accountStatus={accountStatus}
          repaymentSchedule={repaymentSchedule}
          durationType={durationType}
          onEdit={handleEditAccount}
          onDelete={handleDeleteAccount}
          onPageChange={handlePageChange}
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
  accountState: PropTypes.object.isRequired,  
  searchAccounts: PropTypes.func.isRequired,
  saveAccount: PropTypes.func.isRequired,
  deleteAccount: PropTypes.func.isRequired,
  setAccountFilter: PropTypes.func.isRequired,  
  accountStatus: PropTypes.array.isRequired,
  repaymentSchedule: PropTypes.array.isRequired,
  durationType: PropTypes.array.isRequired,
  loading: PropTypes.bool.isRequired,
};

function mapStateToProps(state) {
  const { accountState, lookupSets } = state;
  return {
    accountState,    
    loading: state.apiCallsInProgress > 0,    
    accountStatus: lookupSets.accountStatus.lookups,
    repaymentSchedule: lookupSets.repaymentSchedule.lookups,
    durationType: lookupSets.durationType.lookups,
  };
}

const mapDispatchToProps = {
  searchAccounts,
  saveAccount,
  deleteAccount,
  setAccountFilter,  
  getLookupSetById,  
};

export default connect(mapStateToProps, mapDispatchToProps)(AccountPage);
