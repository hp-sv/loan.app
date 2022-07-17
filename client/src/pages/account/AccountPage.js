import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import AccountList from "./AccountList";
import AccountForm from "./AccountForm";
import SearchForm from "../../components/common/SearchForm";
import {
  searchAccounts,
  setAccountFilter,
} from "../../store/actions/accountActions";
import { getLookupSetById } from "../../store/actions/lookupSetActions";
import * as constants from "../../constants/Common";
import { newAccount } from "../../store/dataInitialiser";
import { Drawer, Tabs } from "antd";
import AccountComment from "./AccountComment";
import AccountTransaction from "./AccountTransaction";

const { TabPane } = Tabs;

function AccountPage({
  accountState,
  searchAccounts,
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

  function handleDrawerClose() {
    setDrawerState({
      visible: false,
      recordMode: constants.RECORD_NONE,
      selectedAccount: newAccount,
      title: "",
    });
  }

  function handleAddAccount() {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_ADD,
      selectedAccount: newAccount,
      title: "Add new account",
    });
  }

  function handleEditAccount(account) {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_EDIT,
      selectedAccount: account,
      title: "Edit account",
    });
  }

  function handleDeleteAccount(account) {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_DELETE,
      selectedAccount: account,
      title: "Delete account",
    });
  }

  function handleReviewAccount(account) {
    setDrawerState({
      visible: true,
      recordMode: constants.RECORD_REVIEW,
      selectedAccount: account,
      title: "Review account",
    });
  }

  function handlePageChange(page, pageSize) {
    searchAccounts(
      accountState.filterBy,
      page > 0 ? page : accountState.currentPage,
      accountState.pageSize !== pageSize ? pageSize : accountState.pageSize
    );
  }

  const showTransactionsTab = (account) => {
    return (
      account.statusId === constants.ACCOUNT_STATUS_ACTIVE ||
      account.statusId === constants.ACCOUNT_STATUS_APPROVE
    );
  };

  function render() {
    return (
      <>
        {drawerState.visible && (
          <Drawer
            title={drawerState.title}
            placement={"right"}
            closable={true}
            maskClosable={false}
            onClose={handleDrawerClose}
            visible={drawerState.visible}
            key={"createUpdateAccount"}
            size={"small"}
          >
            <Tabs defaultActiveKey="1">
              <TabPane tab="Details" key="1">
                <AccountForm
                  selectedAccount={drawerState.selectedAccount}
                  onSubmitSuccess={handleDrawerClose}
                  onCancel={handleDrawerClose}
                  mode={drawerState.recordMode}
                  durationType={durationType}
                  repaymentSchedule={repaymentSchedule}
                  accountStatus={accountStatus}
                />
              </TabPane>
              <TabPane tab="Comment(s)" key="2">
                <AccountComment account={drawerState.selectedAccount} />
              </TabPane>
              {showTransactionsTab(drawerState.selectedAccount) && (
                <TabPane tab="Transactions" key="3">
                  <AccountTransaction account={drawerState.selectedAccount} />
                </TabPane>
              )}
            </Tabs>
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
          onReview={handleReviewAccount}
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
  setAccountFilter,
  getLookupSetById,
};

export default connect(mapStateToProps, mapDispatchToProps)(AccountPage);
