import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import withRouter from "../../components/common/withRouter";
import {
  getAccountById,
  saveAccount,
  deleteAccount,
} from "../../store/actions/accountActions";
import * as constants from "../../constants/Common";

import AccountForm from "./AccountForm";

function ManageAccount({
  accounts,
  getAccountById,
  deleteAccount,
  saveAccount,
  mode,
  durationType,
  repaymentSchedule,
  accountStatus,
  afterAccountSave,
  ...props
}) {
  const [account, setAccount] = useState(props.account);
  const [errors, setErrors] = useState({});
  const [saving, setSaving] = useState(false);

  useEffect(() => {
    if (account.id !== null && accounts.length === 0) {
      getAccountById(account.id);
    } else {
      setAccount(props.account);
    }
  }, [props.account]);

  function handleChange(event) {
    const { name, value } = event.target;
    setAccount((prevAccount) => ({
      ...prevAccount,
      [name]:
        name === "rate" || name === "totalAmount"
          ? parseFloat(value, 0)
          : value,
    }));
  }

  function handleSumbit(event) {
    event.preventDefault();
    setSaving(true);
    if (mode === constants.RECORD_DELETE) {
      deleteAccount(account)
        .then(() => {
          afterAccountSave();
        })
        .catch((ex) => {
          catchError(ex);
        });
    } else {
      //RECORD_ADD, RECORD_EDIT
      saveAccount(account)
        .then(() => {
          afterAccountSave();
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
    setSaving(false);
    setErrors(validationErrors);
  }

  return (
    <div className="row">
      <div className="col-md-6">
        <AccountForm
          account={account}
          onChange={handleChange}
          onSubmitForm={handleSumbit}
          onCancelForm={() => {}}
          mode={mode}
          durationType={durationType}
          repaymentSchedule={repaymentSchedule}
          accountStatus={accountStatus}
          submitting={saving}
          errors={errors}
        />
      </div>
    </div>
  );
}

ManageAccount.propTypes = {
  account: PropTypes.object.isRequired,
  accounts: PropTypes.array.isRequired,
  durationType: PropTypes.array.isRequired,
  repaymentSchedule: PropTypes.array.isRequired,
  accountStatus: PropTypes.array.isRequired,
  getAccountById: PropTypes.func.isRequired,
  saveAccount: PropTypes.func.isRequired,
  deleteAccount: PropTypes.func.isRequired,
  afterAccountSave: PropTypes.func.isRequired,
};

function mapStateToProps(state) {
  return {
    accounts: state.accounts,
  };
}

const mapDispatchToProps = {
  getAccountById,
  saveAccount,
  deleteAccount,
};

export default withRouter(
  connect(mapStateToProps, mapDispatchToProps)(ManageAccount)
);
