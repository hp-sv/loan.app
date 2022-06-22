import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import ClientForm from "./ClientForm";
import PropTypes from "prop-types";
import { newClient } from "../../store/dataInitialiser";
import { loadClients, saveClient } from "../../store/actions/clientActions";
import { setCurrentPageTitle } from "../../store/actions/pageAction";
import withRouter from "../../components/common/withRouter";

function ManageClientPage({
  clients,
  loadClients,
  setCurrentPageTitle,
  saveClient,
  navigate,
  ...props
}) {
  const [client, setClient] = useState({ ...props.client });
  const [errors, setErrors] = useState({});

  useEffect(() => {
    if (clients.length === 0) {
      loadClients().catch((error) => {
        alert("Loading clients failed" + error);
      });
    } else {
      setClient({ ...props.client });
    }

    setCurrentPageTitle("Manage Client");
  }, [props.client]);

  function handleChange(event) {
    const { name, value } = event.target;    
    setClient((prevClient) => 
      ({
        ...prevClient,
        [name]: (name === "id" ? parseInt(value, 0) : value),
      })  
    );
  }

  function handleSave(event) {
    event.preventDefault();    
    saveClient(client).then(() => {
      navigate("/clients");
    });
  }

  return (
    <div className="row">
      <div className="col-md-6">
        <ClientForm
          client={client}
          onChange={handleChange}
          onSave={handleSave}
        />
      </div>
    </div>
  );
}

ManageClientPage.propTypes = {
  client: PropTypes.object.isRequired,
  clients: PropTypes.array.isRequired,
  loadClients: PropTypes.func.isRequired,
  setCurrentPageTitle: PropTypes.func.isRequired,
  navigate: PropTypes.object.isRequired,
};

function getClientById(clients, id) {
  return clients.find((client) => client.id === parseInt(id, 0)) || null;
}

function mapStateToProps(state, ownProps) {
  const { id } = ownProps.params;
  const client =
    id && state.clients.length > 0
      ? getClientById(state.clients, id)
      : newClient;

  return {
    client,
    clients: state.clients,
  };
}

const mapDispatchToProps = {
  loadClients,
  setCurrentPageTitle,
  saveClient,
};

export default withRouter(
  connect(mapStateToProps, mapDispatchToProps)(ManageClientPage)
);
