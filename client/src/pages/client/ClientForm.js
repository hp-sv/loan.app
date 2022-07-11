import React from "react";
import PropTypes from "prop-types";
import TextInput from "../../components/common/TextInput";
import * as constants from "../../constants/Common";
import Disabled from "../../components/common/Disabled";

const ClientForm = ({
  client,
  onSubmitForm,
  onCancelForm,
  onChange,
  mode,
  submitting = false,
  errors = {},
}) => {
  return (
    <Disabled disabled={submitting}>
      <form onSubmit={onSubmitForm}>
        <h6>{client.id ? "Edit" : "Add"} Client</h6>
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
        <TextInput
          name="firstName"
          label="First Name"
          value={client.firstName}
          onChange={onChange}
          error={errors.firstName}
          type="text"
        />
        <TextInput
          name="middleName"
          label="Middle Name"
          value={client.middleName}
          onChange={onChange}
          error={errors.middleName}
          type="text"
        />
        <TextInput
          name="lastName"
          label="Last Name"
          value={client.lastName}
          onChange={onChange}
          error={errors.lastName}
          type="text"
        />
        <TextInput
          name="dob"
          label="Birth date"
          value={client.dob}
          onChange={onChange}
          error={errors.dob}
          type="date"
        />
        <TextInput
          name="mobileNumber"
          label="Mobile Number"
          value={client.mobileNumber}
          onChange={onChange}
          error={errors.mobileNumber}
          type="text"
        />
        <TextInput
          name="emailAddress"
          label="Email"
          value={client.emailAddress}
          onChange={onChange}
          error={errors.emailAddress}
          type="email"
        />
        <TextInput
          name="addressLine1"
          label="Address Line 1"
          value={client.addressLine1}
          onChange={onChange}
          error={errors.addressLine1}
          type="text"
        />
        <TextInput
          name="addressLine2"
          label="Address Line 2"
          value={client.addressLine2}
          onChange={onChange}
          error={errors.addressLine2}
          type="text"
        />
        <TextInput
          name="addressLine3"
          label="Address Line 3"
          value={client.addressLine3}
          onChange={onChange}
          error={errors.addressLine3}
          type="text"
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
};

ClientForm.propTypes = {
  client: PropTypes.object.isRequired,
  onSubmitForm: PropTypes.func.isRequired,
  onCancelForm: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  mode: PropTypes.number.isRequired,
  errors: PropTypes.object,
  submitting: PropTypes.bool,
};

export default ClientForm;
