import React from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import DecimalInput from "../../components/common/DecimalInput";
import SelectInput from "../../components/common/SelectInput";
import * as constants from "../../constants/Common";
import Disabled from "../../components/common/Disabled";

function AccountForm({
  account,
  onSubmitForm,
  onCancelForm,
  onChange,
  mode,
  durationType,
  repaymentSchedule,
  submitting = false,
  errors = {},
}) {
  return (
    <Disabled disabled={submitting}>
      <form onSubmit={onSubmitForm}>
        <h6>{account.id ? "Edit" : "Add"} Account</h6>
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
        <div>Client Name:{account.client.fullName}</div>
        <DecimalInput
          name="rate"
          label="Rate"
          value={account.rate}
          onChange={onChange}
          error={errors.rate}
          min={1}
          step={0.1}
          max={10}
        />
        <DecimalInput
          name="totalAmount"
          label="Total Amount"
          value={account.totalAmount}
          onChange={onChange}
          error={errors.totalAmount}
          min={1000}
          step={1}
          max={1000000}
        />
        <DecimalInput
          name="duration"
          label="Duration"
          value={account.duration}
          onChange={onChange}
          error={errors.duration}
          min={4}
          step={1}
          max={360}
        />
        <SelectInput
          name="durationTypeId"
          label="Duration Type"
          value={account.durationTypeId}
          onChange={onChange}
          options={durationType}
          error={errors.totalAmount}
        />
        <SelectInput
          name="repaymentTypeId"
          label="Repayment Type"
          value={account.repaymentTypeId}
          onChange={onChange}
          options={repaymentSchedule}
          error={errors.totalAmount}
        />
        <br />
        <button
          type="submit"
          disabled={submitting}
          className="btn btn-outline-secondary bi-save  btn-sm"
        >
          {mode === constants.RECORD_ADD &&
            (submitting ? "Saving new..." : "Save")}
          {mode === constants.RECORD_EDIT &&
            (submitting ? "Updating..." : "Update")}
          {mode === constants.RECORD_DELETE &&
            (submitting ? "Deleting..." : "Delete")}
        </button>
        &nbsp;
        <button
          type="button"
          onClick={onCancelForm}
          className="btn btn-outline-secondary bi-back  btn-sm"
        >
          Cancel
        </button>
      </form>
    </Disabled>
  );
}

AccountForm.propTypes = {
  account: PropTypes.object.isRequired,
  onSubmitForm: PropTypes.func.isRequired,
  onCancelForm: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  mode: PropTypes.number.isRequired,
  durationType: PropTypes.array.isRequired,
  repaymentSchedule: PropTypes.array.isRequired,
  accountStatus: PropTypes.array.isRequired,
};

export default AccountForm;
