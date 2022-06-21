import React from "react";
import PropTypes from "prop-types";
import TextInput from "../common/TextInput";

const ClientForm = ({
  client,
  onSave,
  onChange,
  saving = false,
  errors = {},
}) => {
  return (
    <form onSubmit={onSave}>
      <h6>{client.id ? "Edit" : "Add"} Client</h6>
      {errors.onSave && (
        <div className="alert alert-dange" role="alert">
          {errors.onSave}
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

      <button type="submit" disabled={saving} className="btn btn-primary">
        {saving ? "Saving..." : "Save"}
      </button>
    </form>
  );
};

ClientForm.propTypes = {
  client: PropTypes.object.isRequired,
  onSave: PropTypes.func.isRequired,
  onChange: PropTypes.func.isRequired,
  errors: PropTypes.object,
  saving: PropTypes.bool,
};

export default ClientForm;
