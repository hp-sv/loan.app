import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import ClientForm from "./ClientForm";
import PropTypes from "prop-types";
import { newClient } from "../../store/dataInitialiser";
import {
  getClientById,
  saveClient,
  deleteClient,
} from "../../store/actions/clientActions";
import withRouter from "../../components/common/withRouter";
import Spinner from "../../components/common/Spinner";
import { toast } from "react-toastify";
import * as constants from "../../constants/Common";

function ManageClient({
  clients,
  getClientById,
  saveClient,
  deleteClient,
  navigate,
  mode,
  afterClientSave,
  handleCancelForm,
  ...props
}) {
  const [client, setClient] = useState({ ...props.client });
  const [errors, setErrors] = useState({});
  const [saving, setSaving] = useState(false);

  useEffect(() => {
    const { id } = props.params;

    if (id && parseInt(id) > 0 && !props.client.id) {
      getClientById(id).catch((ex) => {
        toast.error("Error loading client. " + ex);
      });
    } else {
      setClient({ ...props.client });
    }
  }, [props.client]);

  function handleChange(event) {
    const { name, value } = event.target;
    setClient((prevClient) => ({
      ...prevClient,
      [name]: name === "id" ? parseInt(value, 0) : value,
    }));
  }

  function handleSumbit(event) {
    event.preventDefault();
    setSaving(true);
    if (mode === constants.RECORD_DELETE) {
      deleteClient(client)
        .then(() => {
          afterClientSave();
        })
        .catch((ex) => {
          catchError(ex);
        });
    } else {
      //RECORD_ADD, RECORD_EDIT
      saveClient(client)
        .then(() => {
          afterClientSave();
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
    <>
      {client === null ? (
        <Spinner />
      ) : (
        <div className="row">
          <div className="col-md-6">
            <ClientForm
              client={client}
              onChange={handleChange}
              onSubmitForm={handleSumbit}
              onCancelForm={handleCancelForm}
              mode={mode}
              submitting={saving}
              errors={errors}
            />
          </div>
        </div>
      )}
    </>
  );
}

ManageClient.propTypes = {
  client: PropTypes.object.isRequired,
  clients: PropTypes.array.isRequired,
  getClientById: PropTypes.func.isRequired,
  saveClient: PropTypes.func.isRequired,
  deleteClient: PropTypes.func.isRequired,
  navigate: PropTypes.func.isRequired,
  mode: PropTypes.number.isRequired,
  afterClientSave: PropTypes.func.isRequired,
  handleCancelForm: PropTypes.func.isRequired,
};

function getClient(clients, id) {
  return clients.find((client) => client.id === parseInt(id)) || null;
}

function mapStateToProps(state, ownProps) {
  const { id } = ownProps;

  const client =
    id && state.clients.length > 0 ? getClient(state.clients, id) : newClient;

  return {
    client,
    clients: state.clients,
  };
}

const mapDispatchToProps = {
  getClientById,
  saveClient,
  deleteClient,
};

export default withRouter(
  connect(mapStateToProps, mapDispatchToProps)(ManageClient)
);
