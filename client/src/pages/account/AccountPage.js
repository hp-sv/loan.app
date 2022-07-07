import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { Navigate } from "react-router-dom";

import Disabled from "../../components/common/Disabled";
import AccountList from "./AccountList";
import SearchForm from "../../components/common/SearchForm";
import { searchAccounts } from "../../store/actions/accountActions";
import { setAccountFilterBy } from "../../store/actions/filterAction";
import { getLookupSetById } from "../../store/actions/lookupSetActions";
import * as constants from "../../constants/Common";


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

  useEffect(()=>{    
    if(accountStatus.length === 0) 
      getLookupSetById(constants.ACCOUNT_STATUS);
    
    if(repaymentSchedule.length === 0)    
      getLookupSetById(constants.REPAYMENT_SCHEDULE);
    

    if(durationType.length === 0)    
      getLookupSetById(constants.DURATION_TYPE);   

  },[]);
  

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
        <AccountList accounts={accounts} accountStatus ={accountStatus} repaymentSchedule ={repaymentSchedule} durationType ={durationType} />
      </Disabled>
    </>
  );
}

AccountPage.propTypes = {
  accounts: PropTypes.array.isRequired,
  searchAccounts: PropTypes.func.isRequired,
  setAccountFilterBy: PropTypes.func.isRequired,
  accountFilterBy: PropTypes.string.isRequired,
  accountStatus: PropTypes.object.isRequired,
  repaymentSchedule: PropTypes.object.isRequired,
  durationType: PropTypes.object.isRequired,
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
    durationType: lookupSets.durationType.lookups
  };
}

const mapDispatchToProps = {
  searchAccounts,
  setAccountFilterBy,
  getLookupSetById,
};

export default connect(mapStateToProps, mapDispatchToProps)(AccountPage);
