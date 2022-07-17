import React, { useState } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import TextInput from "../../components/common/TextInput";
import AutoCompleteClient from "../../components/common/AutoCompleteClient";
import * as constants from "../../constants/Common";
import Disabled from "../../components/common/Disabled";
import { saveClient, deleteClient } from "../../store/actions/clientActions";

const ClientForm = ({
  selectedClient,
  onCancel,
  saveClient,
  deleteClient,
  onSubmitSuccess,
  mode,
}) => {
  const [clientState, setClientState] = useState({
    client: selectedClient,
    submitting: false,
    errors: {},
  });

  const emergencyContactFilter = (optionClient) => {
    return optionClient.id !== client.id;
  };

  function onSubmitForm(event) {
    event.preventDefault();
    event.stopPropagation();

    if (mode === constants.RECORD_DELETE) {
      deleteClient(clientState.client)
        .then(() => {
          onSubmitSuccess();
        })
        .catch((ex) => {
          catchError(ex);
        });
    } else {
      //RECORD_ADD, RECORD_EDIT
      saveClient(clientState.client)
        .then(() => {
          onSubmitSuccess();
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

    setClientState((prevState) => ({
      ...prevState,
      errors: validationErrors,
    }));
  }

  function handleOnChange(event) {
    const { name, value } = event.target;
    setClientState((prevState) => ({
      ...prevState,
      client: {
        ...prevState.client,
        [name]: name === "id" ? parseInt(value, 0) : value,
      },
    }));
  }

  function handleEmergencyContactSelected(client) {
    setClientState((prevState) => ({
      ...prevState,
      client: {
        ...prevState.client,
        emergencyContact: client,
        emergencyContactId: client.id,
      },
    }));
  }

  const { client, submitting, errors } = clientState;

  return (
    <Disabled disabled={submitting}>
      <form onSubmit={onSubmitForm}>
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
          onChange={handleOnChange}
          error={errors.firstName}
          type="text"
        />
        <TextInput
          name="middleName"
          label="Middle Name"
          value={client.middleName}
          onChange={handleOnChange}
          error={errors.middleName}
          type="text"
        />
        <TextInput
          name="lastName"
          label="Last Name"
          value={client.lastName}
          onChange={handleOnChange}
          error={errors.lastName}
          type="text"
        />
        <TextInput
          name="dob"
          label="Birth date"
          value={client.dob}
          onChange={handleOnChange}
          error={errors.dob}
          type="date"
        />
        <TextInput
          name="mobileNumber"
          label="Mobile Number"
          value={client.mobileNumber}
          onChange={handleOnChange}
          error={errors.mobileNumber}
          type="text"
        />
        <TextInput
          name="emailAddress"
          label="Email"
          value={client.emailAddress}
          onChange={handleOnChange}
          error={errors.emailAddress}
          type="email"
        />
        <AutoCompleteClient
          name="emergencyContactId"
          label="Emergency Contact"
          filterOption={emergencyContactFilter}
          selected={
            !client.emergencyContact ? "" : client.emergencyContact.fullName
          }
          onSelect={handleEmergencyContactSelected}
          error={errors.emergencyContactId}
          disable={false}
          showEdit={false}
        />
        <TextInput
          name="addressLine1"
          label="Address Line 1"
          value={client.addressLine1}
          onChange={handleOnChange}
          error={errors.addressLine1}
          type="text"
        />
        <TextInput
          name="addressLine2"
          label="Address Line 2"
          value={client.addressLine2}
          onChange={handleOnChange}
          error={errors.addressLine2}
          type="text"
        />
        <TextInput
          name="addressLine3"
          label="Address Line 3"
          value={client.addressLine3}
          onChange={handleOnChange}
          error={errors.addressLine3}
          type="text"
        />
        <br />
        <button
          type="submit"
          disabled={submitting}
          className="btn btn-outline-secondary bi-save  btn-sm m-1"
        >
          {mode === constants.RECORD_ADD &&
            (submitting ? "Saving new..." : "Save")}
          {mode === constants.RECORD_EDIT &&
            (submitting ? "Updating..." : "Update")}
          {mode === constants.RECORD_DELETE &&
            (submitting ? "Deleting..." : "Delete")}
        </button>
      </form>
    </Disabled>
  );
};

ClientForm.propTypes = {
  selectedClient: PropTypes.object.isRequired,
  onSubmitSuccess: PropTypes.func.isRequired,
  onCancel: PropTypes.func.isRequired,
  saveClient: PropTypes.func.isRequired,
  deleteClient: PropTypes.func.isRequired,
  mode: PropTypes.number.isRequired,
};

const mapDispatchToProps = {
  saveClient,
  deleteClient,
};

export default connect((state) => {
  return state;
}, mapDispatchToProps)(ClientForm);
