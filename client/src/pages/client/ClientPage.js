import React, { useState } from "react";
import { connect } from "react-redux";
import PropTypes from "prop-types";
import { Navigate } from "react-router-dom";

import Disabled from "../../components/common/Disabled";
import ClientList from "./ClientList";
import SearchForm from "../../components/common/SearchForm";
import { searchClients } from "../../store/actions/clientActions";
import { setClientFilterBy } from "../../store/actions/filterAction";

function ClientPage({
  clients,
  searchClients,
  setClientFilterBy,
  clientFilterBy,
  loading,
}) {
  function handleValueChange(event) {
    const { value } = event.target;
    setClientFilterBy(value);
  }

  function handleSearch(event) {
    event.preventDefault();
    searchClients(clientFilterBy);
  }

  const [redirectToAddClient, setRedirectToAddClient] = useState(false);

  return (
    <>
      {redirectToAddClient && <Navigate to="/client" />}
      <Disabled disabled={loading}>
        <div className="row">
          <div className="input-group">
            <SearchForm
              placeHolder="Search client"
              onChange={handleValueChange}
              onSearch={handleSearch}
              value={clientFilterBy}
            />
            <button
              className="btn btn-outline-secondary bi-person-plus btn-sm"
              onClick={() => setRedirectToAddClient(true)}
            ></button>
          </div>
        </div>
        <ClientList clients={clients} />
      </Disabled>
    </>
  );
}

function mapStateToProps(state) {
  const { clients, filters } = state;
  return {
    clients: clients.length === 0 ? [] : clients,
    loading: state.apiCallsInProgress > 0,
    clientFilterBy: filters.clientFilterBy,
  };
}

const mapDispatchToProps = {
  searchClients,
  setClientFilterBy,
};

ClientPage.propTypes = {
  clients: PropTypes.array.isRequired,
  searchClients: PropTypes.func.isRequired,
  setClientFilterBy: PropTypes.func.isRequired,
  loading: PropTypes.bool.isRequired,
  clientFilterBy: PropTypes.string,
};

export default connect(mapStateToProps, mapDispatchToProps)(ClientPage);
