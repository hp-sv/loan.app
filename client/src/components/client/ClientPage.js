import React, { useEffect } from "react";
import { connect } from "react-redux";
import { loadClients } from "../../store/actions/clientActions";
import { setCurrentPageTitle } from "../../store/actions/pageAction";

import PropTypes from "prop-types";
import ClientList from "./ClientList";

function ClientPage({ clients, loadClients, setCurrentPageTitle }) {
  useEffect(() => {
    if (clients.length === 0) {
      loadClients().catch((error) => {
        alert("Loading courses failed" + error);
      });
    }
    setCurrentPageTitle("Client List");
  }, []);

  return <ClientList clients={clients} />;
}

function mapStateToProps(state) {
  const { clients } = state;
  return {
    clients: clients.length === 0 ? [] : clients,
  };
}

const mapDispatchToProps = {
  loadClients,
  setCurrentPageTitle,
};

ClientPage.propTypes = {
  clients: PropTypes.array.isRequired,
  loadClients: PropTypes.func.isRequired,
  setCurrentPageTitle: PropTypes.func.isRequired,
};

export default connect(mapStateToProps, mapDispatchToProps)(ClientPage);
