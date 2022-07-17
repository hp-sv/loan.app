import React, { useState, View } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import SelectInput from "../../components/common/SelectInput";
import * as constants from "../../constants/Common";
import Disabled from "../../components/common/Disabled";
import AutoCompleteClient from "../../components/common/AutoCompleteClient";
import PercentageInput from "../../components/common/PercentageInput";
import MoneyInput from "../../components/common/MoneyInput";
import NumberInput from "../../components/common/NumberInput";
import TextInput from "../../components/common/TextInput";
import CommentInput from "../../components/common/CommentInput";
import {
  saveAccount,
  deleteAccount,
  approveAccount,
  cancelAccount,
  declineAccount,
} from "../../store/actions/accountActions";

function AccountForm({
  selectedAccount,
  onSubmitSuccess,
  onCancel,
  saveAccount,
  deleteAccount,
  approveAccount,
  cancelAccount,
  declineAccount,
  mode,
  durationType,
  repaymentSchedule,
  accountStatus,
}) {
  const [accountState, setAccountState] = useState({
    account: selectedAccount,
    comment: "",
    submitting: false,
    errors: {},
  });

  const handleCommentChange = (event) => {
    const { value } = event.target;
    setAccountState({ ...accountState, comment: value });
  };

  function handleOnChange(event) {
    const { name, value } = event.target;
    setAccountState((prevState) => ({
      ...prevState,
      account: {
        ...prevState.account,
        [name]: name === "id" ? parseInt(value, 0) : value,
      },
    }));
  }

  function handleClientSelected(client) {
    setAccountState((prevState) => ({
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

  const handleOnSubmitForm = (event) => {
    event.preventDefault();
    event.stopPropagation();

    if (mode === constants.RECORD_DELETE) {
      deleteAccount(accountState.account)
        .then(() => {
          onSubmitSuccess();
        })
        .catch((ex) => {
          catchError(ex);
        });
    } else {
      //RECORD_ADD, RECORD_EDIT
      saveAccount(accountState.account)
        .then(() => {
          onSubmitSuccess();
        })
        .catch((ex) => {
          catchError(ex);
        });
    }
  };

  const handleApprove = () => {
    const accountComment = {
      accountId: accountState.account.id,
      statusId: constants.ACCOUNT_STATUS_APPROVE,
      comment: accountState.comment,
    };

    const account = {
      ...accountState.account,
      accountComments: [accountComment],
    };

    approveAccount(account)
      .then(() => {
        onSubmitSuccess();
      })
      .catch((ex) => {
        catchError(ex);
      });
  };

  function catchError(ex) {
    const validationErrors = {
      onSave: ex.message,
      ...ex.error.errors,
      validationErrors: ex.error.validationErrors,
    };
    setAccountState((prevState) => ({
      ...prevState,
      errors: validationErrors,
    }));
  }

  const handleCancel = () => {
    const accountComment = {
      accountId: accountState.account.id,
      statusId: constants.ACCOUNT_STATUS_CANCEL,
      comment: accountState.comment,
    };

    const account = {
      ...accountState.account,
      accountComments: [accountComment],
    };

    cancelAccount(account)
      .then(() => {
        onSubmitSuccess();
      })
      .catch((ex) => {
        catchError(ex);
      });
  };

  const handleDecline = () => {
    const accountComment = {
      accountId: accountState.account.id,
      statusId: constants.ACCOUNT_STATUS_DECLINE,
      comment: accountState.comment,
    };

    const account = {
      ...accountState.account,
      accountComments: [accountComment],
    };

    declineAccount(account)
      .then(() => {
        onSubmitSuccess();
      })
      .catch((ex) => {
        catchError(ex);
      });
  };

  const showSaveUpdateDelete =
    mode === constants.RECORD_ADD ||
    mode === constants.RECORD_EDIT ||
    mode === constants.RECORD_DELETE;

  const showApproveCancelDeny = mode === constants.RECORD_REVIEW;

  const { account, submitting, errors } = accountState;

  const accountReadOnly =
    account.statusId === constants.ACCOUNT_STATUS_APPROVE ||
    account.statusId === constants.ACCOUNT_STATUS_ACTIVE;

  return (
    <Disabled disabled={submitting}>
      <form onSubmit={handleOnSubmitForm}>
        {errors.onSave && (
          <div className="alert alert-danger" role="alert">
            {errors.onSave}
            <br />
            {errors.validationErrors &&
              errors.validationErrors.map((error) => {
                return (
                  <li
                    key={`__validationError${error.code}`}
                  >{`[Code]: ${error.code}: [Message]: ${error.message}`}</li>
                );
              })}
          </div>
        )}

        <AutoCompleteClient
          name="clientId"
          label="Client"
          selected={
            mode === constants.RECORD_ADD ? "" : account.client.fullName
          }
          onSelect={handleClientSelected}
          error={errors.clientId}
          filterOption={() => true}
          disable={mode === constants.RECORD_EDIT ? true : false}
          showEdit={true}
        />
        <PercentageInput
          name="rate"
          label="Rate"
          value={account.rate}
          onChange={handleOnChange}
          error={errors.rate}
          min={1}
          max={10}
          readOnly={accountReadOnly}
        />
        <MoneyInput
          name="principal"
          label="Principal Amount"
          value={account.principal}
          onChange={handleOnChange}
          error={errors.principal}
          readOnly={accountReadOnly}
        />
        <NumberInput
          name="duration"
          label="Duration"
          value={account.duration}
          onChange={handleOnChange}
          error={errors.duration}
          readOnly={accountReadOnly}
        />
        <SelectInput
          name="durationTypeId"
          label="Duration Type"
          value={account.durationTypeId}
          onChange={handleOnChange}
          options={durationType}
          error={errors.durationTypeId}
          readOnly={accountReadOnly}
        />
        <SelectInput
          name="repaymentTypeId"
          label="Repayment Type"
          value={account.repaymentTypeId}
          onChange={handleOnChange}
          options={repaymentSchedule}
          error={errors.repaymentTypeId}
          readOnly={accountReadOnly}
        />
        <TextInput
          name="StatusId"
          label="Status"
          value={
            accountStatus.find((status) => status.id === account.statusId).name
          }
          onChange={() => {}}
          error=""
          readOnly={true}
        />
        {showApproveCancelDeny && (
          <CommentInput
            name="Comment"
            label="Comment"
            value={accountState.comment}
            onChange={handleCommentChange}
            error={
              errors["accountComments[0].Comment"] &&
              errors["accountComments[0].Comment"].length > 0
                ? errors["accountComments[0].Comment"][0]
                : ""
            }
          />
        )}

        <br />

        {showSaveUpdateDelete && !accountReadOnly && (
          <>
            <button
              type="submit"
              disabled={submitting}
              className="btn btn-outline-secondary bi-save btn-sm m-1"
            >
              {mode === constants.RECORD_ADD &&
                (submitting ? "Saving new..." : "Save")}
              {mode === constants.RECORD_EDIT &&
                (submitting ? "Updating..." : "Update")}
              {mode === constants.RECORD_DELETE &&
                (submitting ? "Deleting..." : "Delete")}
            </button>
          </>
        )}

        {showApproveCancelDeny && (
          <>
            <button
              type="button"
              disabled={submitting}
              className="btn btn-outline-secondary bi-hand-thumbs-up btn-sm m-1"
              onClick={handleApprove}
            >
              Approve
            </button>
            <button
              type="button"
              disabled={submitting}
              className="btn btn-outline-secondary bi-file-excel btn-sm m-1"
              onClick={handleCancel}
            >
              Cancel
            </button>
            <button
              type="button"
              disabled={submitting}
              className="btn btn-outline-secondary bi-hand-thumbs-down btn-sm m-1"
              onClick={handleDecline}
            >
              Decline
            </button>
          </>
        )}
      </form>
    </Disabled>
  );
}

AccountForm.propTypes = {
  selectedAccount: PropTypes.object.isRequired,
  onSubmitSuccess: PropTypes.func.isRequired,
  onCancel: PropTypes.func.isRequired,
  saveAccount: PropTypes.func.isRequired,
  deleteAccount: PropTypes.func.isRequired,
  approveAccount: PropTypes.func.isRequired,
  cancelAccount: PropTypes.func.isRequired,
  declineAccount: PropTypes.func.isRequired,
  mode: PropTypes.number.isRequired,
  durationType: PropTypes.array.isRequired,
  repaymentSchedule: PropTypes.array.isRequired,
  accountStatus: PropTypes.array.isRequired,
};

const mapDispatchToProps = {
  saveAccount,
  deleteAccount,
  approveAccount,
  cancelAccount,
  declineAccount,
};

export default connect(() => {
  return {};
}, mapDispatchToProps)(AccountForm);
