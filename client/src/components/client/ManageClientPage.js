import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import ClientForm from "./ClientForm";
import PropTypes from "prop-types";
import { newClient } from "../../store/dataInitialiser";
import { getClientById, saveClient } from "../../store/actions/clientActions";
import { setCurrentPageTitle } from "../../store/actions/pageAction";
import withRouter from "../../components/common/withRouter";
import Spinner from "../common/Spinner";
import { toast } from "react-toastify";

function ManageClientPage({
  clients,
  getClientById,
  setCurrentPageTitle,
  saveClient,
  navigate,
  ...props
}) {
  const [client, setClient] = useState({ ...props.client });
  const [errors, setErrors] = useState({});
  const [saving, setSaving] = useState(false);

  useEffect(() => {
    const { id } = props.params;

    if (id && parseInt(id) !== props.client.id) {
      getClientById(id).catch((ex) => {
        toast.error("Error loading client. " + ex);
      });
    } else {
      setClient({ ...props.client });
    }

    setCurrentPageTitle("Manage Client");
  }, [props.client]);

  function handleChange(event) {
    const { name, value } = event.target;
    setClient((prevClient) => ({
      ...prevClient,
      [name]: name === "id" ? parseInt(value, 0) : value,
    }));
  }

  function handleSave(event) {
    event.preventDefault();
    setSaving(true);
    saveClient(client)
      .then(() => {
        toast.success("Save client completed.");
        navigate("/clients");
      })
      .catch((ex) => {
        const validationErrors = {
          onSave: ex.message,
          ...ex.error.errors,
          validationErrors: ex.error.validationErrors,
        };
        setSaving(false);
        setErrors(validationErrors);
      });
  }

  function handleCancel() {
    navigate("/clients");
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
              onSave={handleSave}
              onCancel={handleCancel}
              saving={saving}
              errors={errors}
            />
          </div>
        </div>
      )}
    </>
  );
}

ManageClientPage.propTypes = {
  client: PropTypes.object.isRequired,
  clients: PropTypes.array.isRequired,
  getClientById: PropTypes.func.isRequired,
  setCurrentPageTitle: PropTypes.func.isRequired,
  navigate: PropTypes.func.isRequired,
};

function getClient(clients, id) {
  return clients.find((client) => client.id === parseInt(id)) || null;
}

function mapStateToProps(state, ownProps) {
  const { id } = ownProps.params;

  const client =
    id && state.clients.length > 0 ? getClient(state.clients, id) : newClient;

  return {
    client,
    clients: state.clients,
  };
}

const mapDispatchToProps = {
  getClientById,
  setCurrentPageTitle,
  saveClient,
};

export default withRouter(
  connect(mapStateToProps, mapDispatchToProps)(ManageClientPage)
);
